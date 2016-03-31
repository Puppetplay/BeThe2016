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

namespace Run
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetPick();
        }

        // 픽을 선택한다.
        private void GetPick()
        {
            DateTime date = new DateTime(2015, 3, 28);
            var matches = dbMgr.SelectAll<Match>();

            dbMgr.DataContext.ExecuteCommand("TRUNCATE TABLE PickResult");
            for (Int32 i = 0; i < 70; ++i)
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

                    picks = picks.GetRange(0, Math.Min(picks.Count(), 10));

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

        // 게임당 타자의 픽을 구한다.
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
                var ratio = CalcRatio(match, batter.PlayerId, awayTeamPitcher.PlayerId);
                if (ratio != 0)
                {
                    var pick = new Pick();
                    pick.MatchId = match.Id;
                    pick.PlayerId = batter.PlayerId;
                    pick.Ratio = ratio;
                    picks.Add(pick);
                }
            }

            foreach (var batter in awayTeamLineUps)
            {
                var ratio = CalcRatio(match, batter.PlayerId, homeTeamPitcher.PlayerId);
                if (ratio != 0)
                {
                    var pick = new Pick();
                    pick.MatchId = match.Id;
                    pick.PlayerId = batter.PlayerId;
                    pick.Ratio = ratio;
                    picks.Add(pick);
                }
            }

            return picks;

        }

        private Double CalcRatio(Match match, Int32 batterId, Int32 pitcherId)
        {
            try
            {
                var players = dbMgr.SelectAll<Player>();
                var matches = dbMgr.SelectAll<Match>();
                var ths = dbMgr.SelectAll<Th>();
                var bats = dbMgr.SelectAll<Bat>();
                var lineUps = dbMgr.SelectAll<LineUp>();

                // 투수를가져온다.
                var pitcher = (from p in players
                               where p.PlayerId == pitcherId
                               select p).First();

                // 타자를 가져온다.
                var batter = (from p in players
                              where p.PlayerId == batterId
                              select p).First();
                Int32 startDate = 20140000;
                Int32 endDate = Convert.ToInt32(match.GameId.Substring(0, 8));

                // 제외조건 확인
                // 1. 300타수 이상인 타자인지 확인
                var batCount = (from m in matches
                                join t in ths
                                on m.Id equals t.MatchId
                                join b in bats
                                on t.Id equals b.ThId
                                where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                                b.HitterId == batter.PlayerId
                                group b by b.HitterId into g
                                select g.Count()).First();
                if (batCount < 300) { return 0.0; }


                // 2. 교체수가 50보다 작아야한다. 8프로 미만이어야한다.
                var wLineUps = from l in lineUps
                               where l.PlayerId == batter.PlayerId && l.EntryType == EntryType.Starting
                               select l;

                var wwLineUps = from l in wLineUps
                                join m in matches
                                on l.MatchId equals m.Id
                                join wl in lineUps
                                on new { l.MatchId, l.BatNumber, l.AttackType } equals new { wl.MatchId, wl.BatNumber, wl.AttackType }
                                where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                                   wl.EntryType == EntryType.Change
                                select wl;

                var changeCount = wwLineUps.Count();
                var changeRate = changeCount * 1.0 / batCount;
                //if (changeCount > 20) { return 0.0; }
                if (changeRate >= 0.8) { return 0.0; }

                // 3. 투수, 타자 상대전적이 0.25 이상이어야한다.
                var vsRatio = (from m in matches
                               join t in ths
                               on m.Id equals t.MatchId
                               join b in bats
                               on t.Id equals b.ThId
                               join p in players
                               on b.PitcherId equals p.PlayerId
                               where m.GameId.StartsWith("2014") && b.HitterId == batter.PlayerId
                                && b.PitcherId == pitcher.PlayerId
                               group b by new { b.HitterId } into g
                               select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();
                if (vsRatio < 0.25) { return 0.0; }

                // 4. 투수의 타자타입 안타율이 0.21보다 높아야한다.
                var tmpPitRatio = (from m in matches
                                join t in ths
                                on m.Id equals t.MatchId
                                join b in bats
                                on t.Id equals b.ThId
                                join p in players
                                on b.HitterId equals p.PlayerId
                                where (m.GameId.StartsWith("2014")) && b.PitcherId == pitcher.PlayerId
                                 && p.Hand.Substring(2, 2) == batter.Hand.Substring(2, 2)
                                select new
                                {
                                    H = p.Hand.Substring(2, 2),
                                    b.PResult
                                });

                var pitRatio = (from r in tmpPitRatio
                                group r by new { r.H } into g
                                select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();
                if (pitRatio < 0.21) { return 0.0; }

                // 5. 타자의 투수타입 안타율이 0.25보다 높아야한다.
                var hitRatio = (from m in matches
                                join t in ths
                                on m.Id equals t.MatchId
                                join b in bats
                                on t.Id equals b.ThId
                                join p in players
                                on b.PitcherId equals p.PlayerId
                                where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                                   b.HitterId == batter.PlayerId
                                    && p.Hand.Substring(0, 2) == pitcher.Hand.Substring(0, 2)
                                group b by new { b.HitterId, Hand = p.Hand.Substring(0, 2) } into g
                                select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();
                if (hitRatio < 0.25) { return 0; }

                // 5. 타자의 우투타입 안타율이 0.20보다 높아야한다.
                var hitRatioR = (from m in matches
                                 join t in ths
                                 on m.Id equals t.MatchId
                                 join b in bats
                                 on t.Id equals b.ThId
                                 join p in players
                                 on b.PitcherId equals p.PlayerId
                                 where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                                   b.HitterId == batter.PlayerId
                                     && p.Hand.Substring(0, 2) == "우투"
                                 group b by new { b.HitterId, Hand = p.Hand.Substring(0, 2) } into g
                                 select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();
                if (hitRatioR < 0.20) { return 0; }

                // 6. 타자의 좌투타입 안타율이 0.20보다 높아야한다.
                var hitRatioL = (from m in matches
                                 join t in ths
                                 on m.Id equals t.MatchId
                                 join b in bats
                                 on t.Id equals b.ThId
                                 join p in players
                                 on b.PitcherId equals p.PlayerId
                                 where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                                   b.HitterId == batter.PlayerId
                                     && p.Hand.Substring(0, 2) == "좌투"
                                 group b by new { b.HitterId, Hand = p.Hand.Substring(0, 2) } into g
                                 select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();
                if (hitRatioL < 0.20) { return 0; }


                var ratio = (vsRatio + hitRatio + pitRatio) / 3;
                return ratio;
            }
            catch (Exception e)
            {
            }
            return 0;
        }

        #region View Result

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

            Int32 tCount = 0;
            Int32 hCount = 0;
            foreach (var result in results)
            {
                if(result.Pick0 != "")
                {
                    tCount++;
                    if(result.Successe0 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick1 != "")
                {
                    tCount++;
                    if (result.Successe1 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick2 != "")
                {
                    tCount++;
                    if (result.Successe2 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick3 != "")
                {
                    tCount++;
                    if (result.Successe3 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick4 != "")
                {
                    tCount++;
                    if (result.Successe4 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick5 != "")
                {
                    tCount++;
                    if (result.Successe5 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick6 != "")
                {
                    tCount++;
                    if (result.Successe6 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick7 != "")
                {
                    tCount++;
                    if (result.Successe7 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick8 != "")
                {
                    tCount++;
                    if (result.Successe8 != "0")
                    {
                        hCount++;
                    }
                }

                if (result.Pick9 != "")
                {
                    tCount++;
                    if (result.Successe9 != "0")
                    {
                        hCount++;
                    }
                }


            }
            MessageBox.Show((hCount * 1.0 / tCount).ToString());

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

        #endregion
    }
}
