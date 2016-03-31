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

namespace 타자분석
{
    public partial class Form1 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();

        public Form1()
        {
            InitializeComponent();
        }


        // 타자에 대한 분석을 한다.
        private void DoParceHitter( )
        { 
            var players = dbMgr.SelectAll<Player>();
            var hitter = from h in players
                         where h.Position != "투수"
                         select new { h.PlayerId, h.Name };
            dgHitter.DataSource = hitter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoParceHitter();
        }

        private void dgHitter_SelectionChanged(object sender, EventArgs e)
        {
            // 선택된 타자가 있는지 확인한다.
            Int32 playerId = 0;
            try
            {
                Int32.TryParse(dgHitter.CurrentRow.Cells[0].Value.ToString(), out playerId);
            }
            catch
            {
            }

            if (playerId == 0) { return; }

            // 타자분석
            var bats = dbMgr.SelectAll<Bat>();
            var players = dbMgr.SelectAll<Player>();

            var hBats = from b in bats
                        join p in players
                        on b.PitcherId equals p.PlayerId
                        where b.HitterId == playerId
                        select new
                        {
                            b.PResult,
                            b.PitcherId,
                            p.Name
                        };

            var result = from b in hBats
                         group b by new { b.PitcherId, b.Name } into g
                         select new
                         {
                             g.Key.PitcherId,
                             g.Key.Name,
                             Out = g.Count(x => x.PResult == PResultType.Out),
                             Pass = g.Count(x => x.PResult == PResultType.Pass),
                             Hit = g.Count(x => x.PResult == PResultType.Hit)
                         };

            dgBatts.DataSource = result;
        }
    }
}
