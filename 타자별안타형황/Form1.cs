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

namespace 타자별안타형황
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
            // 입력된 타자를 얻는다.
            var players = dbMgr.SelectAll<Player>();
            var player = from p in players
                         where p.Name == textBox1.Text
                         select p;

            GetBatterResult(player.First());
        }

        private void GetBatterResult(Player player)
        {
            // 타자에 대한 경기별 기록을 얻어온다.
            var matches = dbMgr.SelectAll<Match>();
            var ths = dbMgr.SelectAll<Th>();
            var bats = dbMgr.SelectAll<Bat>();

            var wMatches = from m in matches
                           join t in ths
                           on m.Id equals t.MatchId
                           join b in bats
                           on t.Id equals b.ThId
                           where b.HitterId == player.PlayerId
                            && m.GameId.StartsWith("2014")
                           group b by new { m.GameId } into g
                           select new
                           {
                               GameId = g.Key.GameId,
                               Total = g.Count(),
                               Hit = g.Count(x => x.PResult == PResultType.Hit),
                           };


      dgMatch.DataSource = wMatches;
        }
    }
}
