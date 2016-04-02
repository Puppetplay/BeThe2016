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

namespace 관리툴
{
    public partial class Form선수찾기 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();

        public Form선수찾기()
        {
            InitializeComponent();
        }

        private void bt_검색_Click(object sender, EventArgs e)
        {
            var players = dbMgr.SelectAll<Player>();
            players = from p in players
                      where p.Name == tbName.Text
                      select p;

            String result = String.Empty;
            foreach(Player p in players)
            {
                result += p.PlayerId + ",";
                result += p.Name + ",";
                result += Environment.NewLine;
            }

            richTextBox1.Text = result;

        }
    }
}
