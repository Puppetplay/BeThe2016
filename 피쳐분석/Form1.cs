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

namespace 피쳐분석
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();
        private List<Player> pitchers;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var players = dbMgr.SelectAll<Player>();
            var matchs = dbMgr.SelectAll<Match>();

            var wMatchs = from m in matchs
                          where m.GameId.StartsWith("2015")
                          select m;

            dgMatch.DataSource = wMatchs;
        }


        private void dgMatch_SelectionChanged(object sender, EventArgs e)
        {
            Int64 matchId;
            try
            {
                matchId = Convert.ToInt64(dgMatch.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                return;
            }

            var matchs = dbMgr.SelectAll<Match>();
            var sMatch = (from m in matchs
                          where m.Id == matchId
                          select m).First();

            pitchers = GetPitchers(sMatch);

            // 투수정보를 가지고온다.
            GetPitcherInfo(pitchers[0], dgHomePitcher, tbHomePitcher, dgHomePitcherInfo);
            GetPitcherInfo(pitchers[1], dgAwayPitcher, tbAwayPitcher, dgAwayPitcherInfo);

            // 게임에 참가한 정보를 가지고 온다.
            GetBatterInfo(sMatch, AttackType.Away);
            GetBatterInfo(sMatch, AttackType.Home);

        }

        // 게임에 참가한 정보를 가지고 온다.
        private void GetBatterInfo(Match match, AttackType attackType)
        {
            var lineUps = dbMgr.SelectAll<LineUp>();
            var players = dbMgr.SelectAll<Player>();

            var wLineUps = from l in lineUps
                           join p in players
                           on l.PlayerId equals p.PlayerId
                           where l.MatchId == match.Id && l.AttackType == attackType
                            && l.EntryType == EntryType.Starting
                           orderby l.BatNumber
                           select new { Id = p.PlayerId, Name = p.Name, Hand = p.Hand };


            if(attackType == AttackType.Home)
            {
                dgHomeHitter.DataSource = wLineUps;
            }
            else
            {
                dgAwayHitter.DataSource = wLineUps;
            }
        }


        // 투수정보를 가지고온다.
        private void GetPitcherInfo(Player player, DataGridView dg, TextBox tb, DataGridView dgRatio)
        {
            var players = dbMgr.SelectAll<Player>();
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();
            var balls = dbMgr.SelectAll<Ball>();

            var pBalls = from m in matchs
                         join s in schedules
                         on m.GameId equals s.GameId
                         join t in ths
                         on m.Id equals t.MatchId
                         join b in bats
                         on t.Id equals b.ThId
                         join ball in balls
                         on b.Id equals ball.BatId
                         where b.PitcherId == player.PlayerId && ball.BallType != ""
                         && (m.GameId.StartsWith("2014") || m.GameId.StartsWith("2013"))
                         group ball by ball.BallType into g
                         select new
                         {
                             g.Key,
                             //MaxSpeed = g.Max(x => x.Speed),
                             //MinSpeed = g.Min(x => x.Speed),
                             Average = g.Average(x => x.Speed)
                         };
            dg.DataSource = pBalls;
            tb.Text = player.Name + " " + player.Hand;

            // 방어율 가져오기
            try
            {
                var ratios1 = (from m in matchs
                               join t in ths
                               on m.Id equals t.MatchId
                               join b in bats
                               on t.Id equals b.ThId
                               join p in players
                               on b.HitterId equals p.PlayerId
                               where (m.GameId.StartsWith("2014") || m.GameId.StartsWith("2013")) && b.PitcherId == player.PlayerId
                               select new
                               {
                                   H = p.Hand.Substring(2, 2),
                                   b.PResult
                               });

                var ratios2 = (from r in ratios1
                              group r by new { r.H } into g
                              select new
                              {
                                  Hand = g.Key.H,
                                  ratio = g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()
                              });

                dgRatio.DataSource = ratios2;
            }
            catch
            {

            }
        }

        // Match에서 투수를 가지고 온다.
        private List<Player> GetPitchers(Match match)
        {
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

            var queryPitcher = from t in queryTh
                               join b in bats
                               on t.Id equals b.ThId
                               join p in players
                               on b.PitcherId equals p.PlayerId
                               where b.DetailResult.StartsWith("1번")
                               select p;

            List<Player> pitchers = new List<Player>();
            pitchers.Add(queryPitcher.ToList()[0]);
            pitchers.Add(queryPitcher.ToList()[1]);
            return pitchers;

        }

        private void dgHitter_SelectionChanged(object sender, EventArgs e)
        {
            // 선택된 타자의 정보를 얻어온다.
            DataGridView dg = sender as DataGridView;
            Int64 hitterId;
            try
            {
                hitterId = Convert.ToInt64(dg.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                return;
            }

            var players = dbMgr.SelectAll<Player>();
            var player = (from p in players
                          where p.PlayerId == hitterId
                          select p).First();

            GetHitterBaseInfo(player);
            GetHitterTypeInfo(player);

            GetHitterVSInfo(player, dg);

            // 교체수 구하기
            tbChangeCount.Text = GetChangeCount(player).ToString();
        }

        // 선택한 타자의 기본 타격정보를 얻어온다.
        private void GetHitterBaseInfo(Player hitter)
        {
            var matches = dbMgr.SelectAll<Match>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();

            // 평균치 데이터
            var allResult = (from m in matches
                          join t in ths
                          on m.Id equals t.MatchId
                          join b in bats
                          on t.Id equals b.ThId
                          where (Convert.ToInt32(m.GameId.Substring(0, 8)) > 20140700 && Convert.ToInt32(m.GameId.Substring(0, 8)) < 20150000) &&
                          b.HitterId == hitter.PlayerId
                          group b by b.HitterId into g
                          select new
                          {
                              Total = g.Count(),
                              Hit = g.Count(x => x.PResult == PResultType.Hit),
                              Pass = g.Count(x => x.PResult == PResultType.Pass),
                              Out = g.Count(x => x.PResult == PResultType.Out),
                              Avg = g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()
                          });

            dgHitterInfo.DataSource = allResult;
        }

        // 선택한 타자의 투수타입 타격정보를 얻어온다.
        private void GetHitterTypeInfo(Player hitter)
        {
            var matches = dbMgr.SelectAll<Match>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();
            var players = dbMgr.SelectAll<Player>();

            // 평균치 데이터
            var allResult = (from m in matches
                             join t in ths
                             on m.Id equals t.MatchId
                             join b in bats
                             on t.Id equals b.ThId
                             join p in players
                             on b.PitcherId equals p.PlayerId
                             where (Convert.ToInt32(m.GameId.Substring(0, 8)) > 20140700 && Convert.ToInt32(m.GameId.Substring(0, 8)) < 20150000) &&
                                b.HitterId == hitter.PlayerId
                             group b by new { b.HitterId, Hand = p.Hand.Substring(0, 2) } into g
                             select new
                             {
                                 Hand = g.Key.Hand,
                                 Total = g.Count(),
                                 Hit = g.Count(x => x.PResult == PResultType.Hit),
                                 Pass = g.Count(x => x.PResult == PResultType.Pass),
                                 Out = g.Count(x => x.PResult == PResultType.Out),
                                 Avg = g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()
                             });

            dgHitterTypeInfo.DataSource = allResult;
        }

        // 선택한 타자와 선발투수의 상대정보를 얻어온다.
        private void GetHitterVSInfo(Player hitter, DataGridView sender)
        {
            // 투수를 가지고 온다.
            Player pitcher;
            if (sender == dgAwayHitter)
            {
                pitcher = pitchers[0];
            }
            else
            {
                pitcher = pitchers[1];
            }

            var matches = dbMgr.SelectAll<Match>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();
            var players = dbMgr.SelectAll<Player>();

            // 평균치 데이터
            var allResult = (from m in matches
                             join t in ths
                             on m.Id equals t.MatchId
                             join b in bats
                             on t.Id equals b.ThId
                             join p in players
                             on b.PitcherId equals p.PlayerId
                             where m.GameId.StartsWith("2014") && b.HitterId == hitter.PlayerId
                              && b.PitcherId == pitcher.PlayerId
                             group b by new { b.HitterId } into g
                             select new
                             {
                                 Total = g.Count(),
                                 Hit = g.Count(x => x.PResult == PResultType.Hit),
                                 Pass = g.Count(x => x.PResult == PResultType.Pass),
                                 Out = g.Count(x => x.PResult == PResultType.Out),
                                 Avg = g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()
                             });

            dgHitterVSInfo.DataSource = allResult;
        }

        // 선택한 타자의 교체된 숫자를 구해온다.
        private Int32 GetChangeCount(Player hitter)
        {
            var matches = dbMgr.SelectAll<Match>();
            var lineUps = dbMgr.SelectAll<LineUp>();

            var wLineUps = from l in lineUps
                           where l.PlayerId == hitter.PlayerId && l.EntryType == EntryType.Starting
                           select l;

            var wwLineUps = from l in wLineUps
                            join m in matches
                            on l.MatchId equals m.Id
                            join wl in lineUps
                            on new { l.MatchId, l.BatNumber, l.AttackType } equals new { wl.MatchId, wl.BatNumber, wl.AttackType }
                            where (Convert.ToInt32(m.GameId.Substring(0, 8)) > 20140700 && Convert.ToInt32(m.GameId.Substring(0, 8)) < 20150000) &&
                            wl.EntryType == EntryType.Change
                            select wl;

            return wwLineUps.Count();
        }
    }
}
