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
        }


    }
}
