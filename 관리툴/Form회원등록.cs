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
    public partial class Form회원등록 : Form
    {
        public String MemberName
        {
            get { return tbName.Text.Trim(); }
        }

        public String KaKaoName
        {
            get { return tbKakaoName.Text.Trim(); }
        }

        public Form회원등록()
        {
            InitializeComponent();
        }

        private void bt등록_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
