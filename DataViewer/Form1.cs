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

namespace DataViewer
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();
        private Int32 year = 2014;
        private Int32 year2 = 2015;

        public Form1()
        {
            InitializeComponent();
            dgPitcher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbTeam.DataSource = Util.Teams;
            cbTeam.SelectedIndex = 0;
        }

        private void cbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();

            var players = dbMgr.SelectAll<Player>();

            var teamInitial = Util.GetTeamInitialFromName(cbTeam.SelectedItem.ToString());

            var queryBat = from m in matchs
                        join s in schedules
                        on m.GameId equals s.GameId
                        join t in ths
                        on m.Id equals t.MatchId
                        join b in bats
                        on t.Id equals b.ThId
                        where s.Year == year || s.Year == year2
                           select b;

            var queryPlayer = from p in players
                              join b in queryBat
                              on p.PlayerId equals b.PitcherId
                              where p.Team == teamInitial
                              select p;

            var queryGPlayer = from p in queryPlayer
                               group p by p.PlayerId into g
                               select new { PlayerId = g.Key };

            var data = from p in players
                       join gp in queryGPlayer
                       on p.PlayerId equals gp.PlayerId
                       select new { PlayerId = p.PlayerId, Name = p.Name, Type = p.Hand };

            dgPitcher.DataSource = data;
        }

        private void dgPitcher_SelectionChanged(object sender, EventArgs e)
        {
            Int32 pitcherId = Convert.ToInt32(dgPitcher.CurrentRow.Cells[0].Value);

            dgBallType.DataSource = GetBallInfo(pitcherId, year);
            dgBat.DataSource = GetBatInfo(pitcherId, year);

            dgBallType2.DataSource = GetBallInfo(pitcherId, year2);
            dgBat2.DataSource = GetBatInfo(pitcherId, year2);
        }

        private IQueryable GetBallInfo(Int32 pitcherId, Int32 year)
        {
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();
            var balls = dbMgr.SelectAll<Ball>();

            var queryBall = from m in matchs
                            join s in schedules
                            on m.GameId equals s.GameId
                            join t in ths
                            on m.Id equals t.MatchId
                            join b in bats
                            on t.Id equals b.ThId
                            join ba in balls
                            on b.Id equals ba.BatId
                            where s.Year == year && b.PitcherId == pitcherId
                            select ba;

            var queryGBall = from b in queryBall
                             group b by b.BallType into g
                             select new
                             {
                                 BallType = g.Key,
                                 AvgSpeed = g.Average(x => x.Speed),
                                 MaxSpeed = g.Max(x => x.Speed),
                                 MinSpeed = g.Min(x => x.Speed)
                             };

            return queryGBall;
        }

        private IQueryable GetBatInfo(Int32 pitcherId, Int32 year)
        {
            var matchs = dbMgr.SelectAll<Match>();
            var schedules = dbMgr.SelectAll<Schedule>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();
            var balls = dbMgr.SelectAll<Ball>();

            var players = dbMgr.SelectAll<Player>();

            var queryBat = from m in matchs
                            join s in schedules
                            on m.GameId equals s.GameId
                            join t in ths
                            on m.Id equals t.MatchId
                            join b in bats
                            on t.Id equals b.ThId
                            join p in players
                            on b.HitterId equals p.PlayerId
                            where s.Year == year && b.PitcherId == pitcherId
                           select new
                           {
                               Hand = p.Hand.Substring(2, 1),
                               Result = b.PResult,
                           };

            var queryGBat = from p in queryBat
                            group p by p.Hand into g
                            select new
                            {
                                Hand = g.Key,
                                HitCount = g.Count(x => x.Result == PResultType.Hit),
                                TotalCount = g.Count(),
                                HitRatio = g.Count(x => x.Result == PResultType.Hit) * 1.0 / g.Count()
                            };

            queryGBat = from p in queryGBat
                        where p.TotalCount > 50
                            select p;

            return queryGBat;
        }
    }
}
