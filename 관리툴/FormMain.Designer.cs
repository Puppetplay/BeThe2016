namespace 관리툴
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_회원등록 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_회원등록
            // 
            this.bt_회원등록.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_회원등록.Location = new System.Drawing.Point(10, 10);
            this.bt_회원등록.Name = "bt_회원등록";
            this.bt_회원등록.Size = new System.Drawing.Size(459, 50);
            this.bt_회원등록.TabIndex = 0;
            this.bt_회원등록.Text = "회원등록";
            this.bt_회원등록.UseVisualStyleBackColor = true;
            this.bt_회원등록.Click += new System.EventHandler(this.bt_회원등록_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 404);
            this.Controls.Add(this.bt_회원등록);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "BeThe 관리툴";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_회원등록;
    }
}

