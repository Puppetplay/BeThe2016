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

namespace 직구구속확인
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();
        private IQueryable<PitcherInfo> pitcherInfos;
        private Int32 currentPlayerId;

        public Form1()
        {
            InitializeComponent();
        }

        // 타자에 대한 분석을 한다.
        private void DoParceHitter()
        {
            var players = dbMgr.SelectAll<Player>();
            var hitter = from h in players
                         where h.Position != "투수"
                         select new { h.PlayerId, h.Name };
            dgHitter.DataSource = hitter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pitcherInfos = GetPitherInfos();
            DoParceHitter();
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

        private void dgHitter_SelectionChanged(object sender, EventArgs e)
        {
            Int32 hitterId;
            try
            {
                hitterId = Convert.ToInt32(dgHitter.CurrentRow.Cells[0].Value);
            }
            catch
            {
                return;
            }

            if(hitterId == currentPlayerId)
            {
                return;
            }
            currentPlayerId = hitterId;

            var matches = dbMgr.SelectAll<Match>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();

            var arBats = from m in matches
                        join t in ths
                        on m.Id equals t.MatchId
                        join b in bats
                        on t.Id equals b.ThId
                        join p in pitcherInfos
                        on b.PitcherId equals p.PlayerId
                        where m.GameId.StartsWith("2015") && b.HitterId == hitterId && p.Average >= 145 && p.Hand.StartsWith("우투")
                        group b by b.HitterId into g
                        select new
                        {
                            Total = g.Count( x => x.HitterId == hitterId),
                            Hit = g.Count(x => x.PResult == PResultType.Hit),
                            Out = g.Count(x => x.PResult == PResultType.Out),
                            Pass = g.Count(x => x.PResult == PResultType.Pass),
                            Avg = g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count(x => x.HitterId == hitterId),
                        };
                
            dgAR.DataSource = arBats;

            var alBats = from m in matches
                        join t in ths
                        on m.Id equals t.MatchId
                        join b in bats
                        on t.Id equals b.ThId
                        join p in pitcherInfos
                        on b.PitcherId equals p.PlayerId
                        where m.GameId.StartsWith("2015") && b.HitterId == hitterId && p.Average >= 145 && p.Hand.StartsWith("좌투")
                        group b by b.HitterId into g
                        select new
                        {
                            Total = g.Count(x => x.HitterId == hitterId),
                            Hit = g.Count(x => x.PResult == PResultType.Hit),
                            Out = g.Count(x => x.PResult == PResultType.Out),
                            Pass = g.Count(x => x.PResult == PResultType.Pass),
                            Avg = g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count(x => x.HitterId == hitterId),
                        };

            dgAL.DataSource = alBats;

            var brBats = from m in matches
                         join t in ths
                         on m.Id equals t.MatchId
                         join b in bats
                         on t.Id equals b.ThId
                         join p in pitcherInfos
                         on b.PitcherId equals p.PlayerId
                         where m.GameId.StartsWith("2015") && b.HitterId == hitterId && p.Average < 145 && p.Hand.StartsWith("우투")
                         group b by b.HitterId into g
                         select new
                         {
                             Total = g.Count(x => x.HitterId == hitterId),
                             Hit = g.Count(x => x.PResult == PResultType.Hit),
                             Out = g.Count(x => x.PResult == PResultType.Out),
                             Pass = g.Count(x => x.PResult == PResultType.Pass),
                             Avg = g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count(x => x.HitterId == hitterId),
                         };

            dgBR.DataSource = brBats;

            var blBats = from m in matches
                         join t in ths
                         on m.Id equals t.MatchId
                         join b in bats
                         on t.Id equals b.ThId
                         join p in pitcherInfos
                         on b.PitcherId equals p.PlayerId
                         where m.GameId.StartsWith("2015") && b.HitterId == hitterId && p.Average < 145 && p.Hand.StartsWith("좌투")
                         group b by b.HitterId into g
                         select new
                         {
                             Total = g.Count(x => x.HitterId == hitterId),
                             Hit = g.Count(x => x.PResult == PResultType.Hit),
                             Out = g.Count(x => x.PResult == PResultType.Out),
                             Pass = g.Count(x => x.PResult == PResultType.Pass),
                             Avg = g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count(x => x.HitterId == hitterId),
                         };

            dgBL.DataSource = blBats;
        }
    }
}
