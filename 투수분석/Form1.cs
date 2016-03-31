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

namespace 투수분석
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();
        private Int32 currentPitcherId;


        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddAverage();
        }

        private void dgPitcher_SelectionChanged(object sender, EventArgs e)
        {
            Int32 pitcherId;
            try
            {
                pitcherId = Convert.ToInt32(dgPitcher.CurrentRow.Cells[0].Value);
            }
            catch
            {
                pitcherId = currentPitcherId;
            }
            if(currentPitcherId == pitcherId)
            {
                return;
            }
            else
            {
                currentPitcherId = pitcherId;
            }

            // 투수에 대한 분석을 한다.
            DoParcePitcher(pitcherId);
        }

        // 투수에 대한 분석을 한다.
        private void DoParcePitcher(Int32 pitcherId)
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
                         where b.PitcherId == pitcherId && ball.BallType != ""
                         group ball by ball.BallType into g
                         select new
                         {
                             g.Key,
                             MaxSpeed = g.Max(x => x.Speed),
                             MinSpeed = g.Min(x => x.Speed),
                             Average = g.Average(x => x.Speed)
                         };
           

        dgBall.DataSource = pBalls;
        }

        // 직구 평균구속을 붙인다.
        private void AddAverage()
        {
            var players = dbMgr.SelectAll<Player>();
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();
            var balls = dbMgr.SelectAll<Ball>();

            var pitchers = from p in players
                           where p.Position == "투수" && p.Hand.Substring(0, 2) == comboBox1.Text
                           select new { p.PlayerId, p.Name };

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
                              ball.Speed
                          };

            var avPitchers = from b in pBalls
                             group b by new { b.PlayerId, b.Name } into g
                             select new
                             {
                                 g.Key.PlayerId,
                                 g.Key.Name,
                                 MaxSpeed = g.Max(x => x.Speed),
                                 MinSpeed = g.Min(x => x.Speed),
                                 Average = g.Average(x => x.Speed)
                             };
            dgPitcher.DataSource = avPitchers;
        }
    }
}
