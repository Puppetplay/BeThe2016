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

namespace Simulater2
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();

        public Form1()
        {
            InitializeComponent();
        }

        private Double CalcRatio(String gameId, Int32 batterId, Int32 pitcherId)
        {
            String mon = gameId.Substring(4, 2);
            
            try
            {
                dbMgr = new DataBaseManager();
                // 1 투수를가져온다.
                var players = dbMgr.SelectAll<Player>();
                var pitcher = (from p in players
                               where p.PlayerId == pitcherId
                               select p).First();

                // 타자를 가져온다.
                var batter = (from p in players
                              where p.PlayerId == batterId
                              select p).First();

                var matchs = dbMgr.SelectAll<Match>();
                var schedules = dbMgr.SelectAll<Schedule>();
                var ths = dbMgr.SelectAll<Th>();
                var bats = dbMgr.SelectAll<Bat>();

                var pitcherBats = from m in matchs
                                  join s in schedules
                                  on m.GameId equals s.GameId
                                  join t in ths
                                  on m.Id equals t.MatchId
                                  join b in bats
                                  on t.Id equals b.ThId
                                  join ph in players
                                  on b.HitterId equals ph.PlayerId
                                  where b.PitcherId == pitcher.PlayerId && m.GameId.Substring(4, 2) == mon
                                       && ph.Hand.Substring(2, 2) == batter.Hand.Substring(2, 2)
                                  select b;

                // 투수 확률
                var resultPitcher = from p in pitcherBats
                                    group p by p.PitcherId into g
                                    select new
                                    {
                                        HitCount = g.Sum(x => x.PResult == PResultType.Hit ? 1 : 0),
                                        TotalCount = g.Sum(x => 1),
                                        Ratio = Math.Round(g.Sum(x => x.PResult == PResultType.Hit ? 1 : 0) * 1.0
                                        / g.Sum(x => 1), 3, MidpointRounding.AwayFromZero)
                                    };

                var batterBats = from m in matchs
                                 join s in schedules
                                 on m.GameId equals s.GameId
                                 join t in ths
                                 on m.Id equals t.MatchId
                                 join b in bats
                                 on t.Id equals b.ThId
                                 join pp in players
                                 on b.PitcherId equals pp.PlayerId
                                 where b.HitterId == batter.PlayerId
                                      && pp.Hand.Substring(0, 2) == pitcher.Hand.Substring(0, 2)
                                      && m.GameId.Substring(4, 2) == mon
                                 select b;

                // 타자 확률
                var resultBatter = from p in batterBats
                                   group p by p.HitterId into g
                                   select new
                                   {
                                       HitCount = g.Sum(x => x.PResult == PResultType.Hit ? 1 : 0),
                                       TotalCount = g.Sum(x => 1),
                                       Ratio = Math.Round(g.Sum(x => x.PResult == PResultType.Hit ? 1 : 0) * 1.0
                                       / g.Sum(x => 1), 3, MidpointRounding.AwayFromZero)
                                   };

                Int32 분모 = 0;
                double 분자 = 0;
                if (resultPitcher.Count() > 0)
                {
                    if (resultPitcher.First().TotalCount > 10)
                    {
                        분모++;
                        분자 += resultPitcher.First().Ratio;
                    }
                }

                if (resultBatter.Count() > 0)
                {
                    if (resultBatter.First().TotalCount > 10)
                    {
                        분모++;
                        분자 += resultBatter.First().Ratio;
                    }
                }

                if (분모 == 1)
                {
                    return (분자 / 분모) * 0.7;
                }
                else if (분모 == 2)
                {
                    return (분자 / 분모);
                }
            }
            catch
            {

            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetPick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbMgr = new DataBaseManager();

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
            foreach(var date in dates)
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

        private void GetPick()
        {
            DateTime date = new DateTime(2015, 3, 20);
            var matches = dbMgr.SelectAll<Match>();

            dbMgr.DataContext.ExecuteCommand("TRUNCATE TABLE PickResult");
            for (Int32 i = 0; i < 20; ++i)
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

                    picks = picks.GetRange(0, 10);

                    List<PickResult> pickResults = new List<PickResult>();
                    foreach(var pick in picks)
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
            var homeTeamLineUps = from l in lineUps
                                  where l.MatchId == match.Id && l.AttackType == AttackType.Home
                                  && l.EntryType == EntryType.Starting
                                  select l;

            // 어웨이팀 타자 가지고 오기
            var awayTeamLineUps = from l in lineUps
                                  where l.MatchId == match.Id && l.AttackType == AttackType.Away
                                    && l.EntryType == EntryType.Starting
                                  select l;

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

            foreach (var batter in homeTeamLineUps)
            {
                var ratio = CalcRatio(match.GameId, batter.PlayerId, awayTeamPitcher.PlayerId);
                Double addRatio = ((10 - batter.BatNumber) * 0.02);
                ratio = ratio + addRatio;
                var pick = new Pick();
                pick.MatchId = match.Id;
                pick.PlayerId = batter.PlayerId;
                pick.Ratio = ratio;
                picks.Add(pick);
            }

            foreach (var batter in awayTeamLineUps)
            {
                var ratio = CalcRatio(match.GameId, batter.PlayerId, homeTeamPitcher.PlayerId);
                Double addRatio = ((10 - batter.BatNumber) * 0.05);
                ratio = ratio + addRatio;
                var pick = new Pick();
                pick.MatchId = match.Id;
                pick.PlayerId = batter.PlayerId;
                pick.Ratio = ratio;
                picks.Add(pick);
            }
            return picks;

        }

        private void dgTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
