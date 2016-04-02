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
    public partial class Form엔트리등록 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();

        public Form엔트리등록()
        {
            InitializeComponent();
        }

        private void bt등록_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry();
            entry.Year = Convert.ToInt32(tb경기날짜.Text.Substring(0, 4));
            entry.Month = Convert.ToInt32(tb경기날짜.Text.Substring(4, 2));
            entry.Day = Convert.ToInt32(tb경기날짜.Text.Substring(6, 2));
            entry.HomeTeam = tb홈팀.Text;
            entry.AwayTeam = tb어웨이팀.Text;
            entry.PlayerId = Convert.ToInt32(tb선수ID.Text);
            entry.PlayerName = tb선수이름.Text;
            entry.PitcherId = Convert.ToInt32(tb선발ID.Text);
            entry.PitcherName = tb선발이름.Text;
            entry.BatNumber = Convert.ToInt32(tb타순.Text);
            Regist(entry);
        }

        private void Regist(Entry entry)
        {
            List<Entry> entries = new List<Entry>();
            entries.Add(entry);
            dbMgr.Save<Entry>(entries);
        }
    }
}
