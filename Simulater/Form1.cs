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

namespace Simulater
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();

        public Form1()
        {
            InitializeComponent();
            dgSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            textBox1.Text = "74339";
            textBox2.Text = "77637";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var schedules = dbMgr.SelectAll<Schedule>();

            var query = from s in schedules
                        where s.LeagueId == 1 && s.Href != null && s.Year == 2015
                        group s by s.GameId.Substring(0, 8) into g
                        select new
                        {
                            Date = g.Key
                        };
            dgSchedule.DataSource = query;
        }

        private void dgSchedule_SelectionChanged(object sender, EventArgs e)
        {
            String date = dgSchedule.CurrentRow.Cells[0].Value.ToString();

            var matches = dbMgr.SelectAll<Match>();
            var query = from m in matches
                        where m.GameId.Substring(0, 8) == date
                        select new
                        {
                            m.GameId
                        };

            dgMatch.DataSource = query;
        }

        private void dgMatch_SelectionChanged(object sender, EventArgs e)
        {
            // 투수
            String gameId = dgMatch.CurrentRow.Cells[0].Value.ToString();

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
                           where m.GameId == gameId && t.Number == 1
                           select t;

            var queryBat = (from t in queryTh
                            join b in bats
                            on t.Id equals b.ThId
                            join p in players
                            on b.PitcherId equals p.PlayerId
                            where b.DetailResult.StartsWith("1번")
                            select new { Name = p.Name }).ToList();

            
            dgPitcher.DataSource = queryBat;

            // 타자
            var queryThBatter = from m in matchs
                          join s in schedules
                          on m.GameId equals s.GameId
                          join t in ths
                          on m.Id equals t.MatchId
                          where m.GameId == gameId 
                          select t;

            var batBatter = from t in queryThBatter
                            join b in bats
                           on t.Id equals b.ThId
                            join p in players
                            on b.HitterId equals p.PlayerId
                            select new
                            {
                                PlayerId = b.HitterId,
                                Name = p.Name,
                                PResult = b.PResult
                            };

            var query = from b in batBatter
                        group b by b.PlayerId into g
                        select new
                        {
                            Name = g.Max(x => x.Name),
                            Result = g.Sum(x => x.PResult == PResultType.Hit ? 1 : 0)
                        };

            dgBatter.DataSource = query;
        }


        private Double CalcRatio(Int32 batterId, Int32 pitcherId)
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
                              where b.PitcherId == pitcher.PlayerId
                                   && ph.Hand.Substring(2, 2) == batter.Hand.Substring(2, 2) 
                               select b;

            var pitcherBatsG = from p in pitcherBats
                               group p by p.PitcherId into g
                               select new
                               {
                                   HitCount = g.Sum(x => x.PResult == PResultType.Hit ? 1 : 0),
                                   TotalCount = g.Sum(x => 1),
                                   Ratio = Math.Round(g.Sum(x => x.PResult == PResultType.Hit ? 1 : 0) * 1.0m 
                                   / g.Sum(x => 1), 3, MidpointRounding.AwayFromZero)
                               };


            dgBat.DataSource = pitcherBats;

            return 0.0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ratio = CalcRatio(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }
    }
}
