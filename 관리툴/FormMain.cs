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
    public partial class FormMain : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();

        public FormMain()
        {
            InitializeComponent();
        }

        #region 회원등록

        private void bt_회원등록_Click(object sender, EventArgs e)
        {
            // 회원등록 창 뛰우기
            var form = new Form회원등록();
            if(form.ShowDialog() == DialogResult.OK)
            {
                // 회원을 등록한다.
                var member = new Member
                {
                    Name = form.MemberName,
                    KakaoName = form.KaKaoName,
                    Enable = Enable.Enable,
                };
                RegistMember(member);
            }
            
        }

        private void RegistMember(Member member)
        {
            List<Member> members = new List<Member>();
            members.Add(member);
            dbMgr.Save<Member>(members);
        }

        #endregion
    }
}
