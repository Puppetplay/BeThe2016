using BeThe2016.Items;
using BeThe2016.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulater3
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();
        private IQueryable<PitcherInfo> pitcherInfos;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pitcherInfos = GetPitherInfos();
            GetPick();
        }

        private void GetPick()
        {
            DateTime date = new DateTime(2015, 3, 28);
            var matches = dbMgr.SelectAll<Match>();

            dbMgr.DataContext.ExecuteCommand("TRUNCATE TABLE PickResult");
            for (Int32 i = 0; i < 50; ++i)
            {
                DateTime gameDate = date.AddDays(i);
                var ms = (from m in matches
                          where m.GameId.Substring(0, 8) == gameDate.ToString("yyyyMMdd")
                          select m);

                if (ms.Count() > 0)
                {
                    var picks = new List<Pick>();
                    // 매경기당 계산로직
                    foreach (var match in ms)
                    {
                        var ps = GetBestBatters(match);
                        picks = picks.Concat(ps).ToList();
                    }

                    picks.Sort((Pick x, Pick y) => x.Ratio.CompareTo(y.Ratio));
                    picks.Reverse();

                    picks = picks.GetRange(0, 6);

                    List<PickResult> pickResults = new List<PickResult>();
                    foreach (var pick in picks)
                    {
                        var pickResult = new PickResult();
                        pickResult.GameDate = gameDate.ToString("yyyyMMdd");
                        pickResult.MatchId = pick.MatchId;
                        pickResult.PlayerId = pick.PlayerId;
                        pickResults.Add(pickResult);
                    }

                    dbMgr.Save<PickResult>(pickResults);
                }
            }
        }

        private List<Pick> GetBestBatters(Match match)
        {
            List<Pick> picks = new List<Pick>();

            var lineUps = dbMgr.SelectAll<LineUp>();

            // 홈팀 타자 가지고오기
            var homeTeamLineUps =   from l in lineUps
                                   where l.MatchId == match.Id && l.AttackType == AttackType.Home
                                   && l.EntryType == EntryType.Starting
                                   select l;

            if(homeTeamLineUps.Count() >= 3)
            {
                homeTeamLineUps = homeTeamLineUps.Take(3);
            }


            // 어웨이팀 타자 가지고 오기
            var awayTeamLineUps = from l in lineUps
                                  where l.MatchId == match.Id && l.AttackType == AttackType.Away
                                    && l.EntryType == EntryType.Starting
                                  select l;

            if (awayTeamLineUps.Count() >= 4)
            {
                awayTeamLineUps = awayTeamLineUps.Take(4);
            }


            // 투수 가지고 오기
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();

            var players = dbMgr.SelectAll<Player>();

            var queryTh = from m in matchs
                          join s in schedules
                          on m.GameId equals s.GameId
                          join t in ths
                          on m.Id equals t.MatchId
                          where m.GameId == match.GameId && t.Number == 1
                          select t;

            var queryPitcher = (from t in queryTh
                                join b in bats
                                on t.Id equals b.ThId
                                join p in players
                                on b.PitcherId equals p.PlayerId
                                where b.DetailResult.StartsWith("1번")
                                select new { PlayerId = p.PlayerId, Name = p.Name }).ToList();

            var homeTeamPitcher = queryPitcher.ToList()[0];
            var awayTeamPitcher = queryPitcher.ToList()[1];

            // 투수별 레벨구하기
            String hPitcherLevel = GetLevel(homeTeamPitcher.PlayerId);
            String aPitcherLevel = GetLevel(awayTeamPitcher.PlayerId);

            foreach (var batter in homeTeamLineUps)
            {
                var ratio = CalcRatio(match.GameId, batter.PlayerId, awayTeamPitcher.PlayerId, aPitcherLevel);
                var pick = new Pick();
                pick.MatchId = match.Id;
                pick.PlayerId = batter.PlayerId;
                pick.Ratio = ratio;
                picks.Add(pick);
            }

            foreach (var batter in awayTeamLineUps)
            {
                var ratio = CalcRatio(match.GameId, batter.PlayerId, homeTeamPitcher.PlayerId, hPitcherLevel);
                var pick = new Pick();
                pick.MatchId = match.Id;
                pick.PlayerId = batter.PlayerId;
                pick.Ratio = ratio;
                picks.Add(pick);
            }
            return picks;

        }

        private String GetLevel(Int32 pitcherId)
        {
            var players = dbMgr.SelectAll<Player>();
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();
            var balls = dbMgr.SelectAll<Ball>();

            var pitcher = (from p in players
                           where p.PlayerId == pitcherId
                           select p).First();

            var pBalls = from b in bats
                         join ball in balls
                         on b.Id equals ball.BatId
                         where ball.BallType == "직구" && b.PitcherId == pitcher.PlayerId
                         select ball.Speed;

            var avgSpeed = (from b in pBalls
                            group b by 1 into g
                            select new
                            {
                                Average = g.Average(x => x.Value)
                            }).First();

            if(avgSpeed.Average >= 145)
            {
                return "A";
            }
            else
            {
                return "B";
            }

                           
            
        }

        // 투수정보를 가져온다.
        private IQueryable<PitcherInfo> GetPitherInfos()
        {
            var players = dbMgr.SelectAll<Player>();
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();
            var balls = dbMgr.SelectAll<Ball>();

            var pitchers = from p in players
                           where p.Position == "투수"
                           select new { p.PlayerId, p.Name, p.Hand };

            var pBalls = from p in pitchers
                         join b in bats
                         on p.PlayerId equals b.PitcherId
                         join t in ths
                         on b.ThId equals t.Id
                         join ball in balls
                         on b.Id equals ball.BatId
                         where ball.BallType == "직구"
                         select
                         new
                         {
                             p.PlayerId,
                             p.Name,
                             p.Hand,
                             ball.Speed
                         };

            var avPitchers = from b in pBalls
                             group b by new { b.PlayerId, b.Name, b.Hand } into g
                             select new PitcherInfo
                             {
                                 PlayerId = g.Key.PlayerId,
                                 Name = g.Key.Name,
                                 Hand = g.Key.Hand,
                                 MaxSpeed = g.Max(x => x.Speed),
                                 MinSpeed = g.Min(x => x.Speed),
                                 Average = g.Average(x => x.Speed)
                             };
            return avPitchers;

        }

        private Double CalcRatio(String gameId, Int32 batterId, Int32 pitcherId, String pitcherLevel)
        {
            try
            {
                // 1 투수를가져온다.
                var players = dbMgr.SelectAll<Player>();
                var pitcher = (from p in players
                               where p.PlayerId == pitcherId
                               select p).First();

                // 타자를 가져온다.
                var batter = (from p in players
                              where p.PlayerId == batterId
                              select p).First();


                var matches = dbMgr.SelectAll<Match>();
                var ths = dbMgr.SelectAll<Th>();
                var bats = dbMgr.SelectAll<Bat>();

                double ratio = 0;

                if (pitcherLevel == "A")
                {
                    ratio = (from m in matches
                             join t in ths
                             on m.Id equals t.MatchId
                             join b in bats
                             on t.Id equals b.ThId
                             join p in pitcherInfos
                             on b.PitcherId equals p.PlayerId
                             where m.GameId.StartsWith("2014") && b.HitterId == batterId && p.Average >= 145 && p.Hand.Substring(0, 2) == pitcher.Hand.Substring(0, 2)
                             group b by b.HitterId into g
                             select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count(x => x.HitterId == batterId)).First();
                }
                else
                {
                    ratio = (from m in matches
                             join t in ths
                             on m.Id equals t.MatchId
                             join b in bats
                             on t.Id equals b.ThId
                             join p in pitcherInfos
                             on b.PitcherId equals p.PlayerId
                             where m.GameId.StartsWith("2014") && b.HitterId == batterId && p.Average < 145 && p.Hand == pitcher.Hand
                             group b by b.HitterId into g
                             select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count(x => x.HitterId == batterId)).First();
                }

                return ratio;
            }
            catch(Exception e)
            {
            }
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var players = dbMgr.SelectAll<Player>();

            // 1. 날짜를 읽어온다.
            var pickResults = dbMgr.SelectAll<PickResult>();
            var dates = from result in pickResults
                        group result by result.GameDate into g
                        select new
                        {
                            g.Key
                        };

            List<Result> results = new List<Result>();
            foreach (var date in dates)
            {
                Result result = new Result();
                result.Picks = new List<string>();
                result.Successes = new List<string>();
                result.Date = date.Key;

                var picks = from r in pickResults
                            join p in players
                            on r.PlayerId equals p.PlayerId
                            where r.GameDate == result.Date
                            select p;

                foreach (var pick in picks)
                {
                    result.Picks.Add(pick.Name);

                    // 결과 얻어오기
                    Int32 hitCount = GetHitCount(result.Date, pick);
                    result.Successes.Add(hitCount.ToString());
                }

                results.Add(result);
            }
            dgTest.DataSource = results;
        }

        private Int32 GetHitCount(String date, Player p)
        {
            var players = dbMgr.SelectAll<Player>();
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();

            var hitcount = (from m in matchs
                            join s in schedules
                            on m.GameId equals s.GameId
                            join t in ths
                            on m.Id equals t.MatchId
                            join b in bats
                            on t.Id equals b.ThId
                            where m.GameId.Substring(0, 8) == date && b.HitterId == p.PlayerId
                              && b.PResult == PResultType.Hit
                            select b).Count();

            return hitcount;
        }
    }
}
