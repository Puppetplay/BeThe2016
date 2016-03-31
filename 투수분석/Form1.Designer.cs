namespace 투수분석
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgPitcher = new System.Windows.Forms.DataGridView();
            this.dgBall = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgPitcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBall)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "우투",
            "좌투",
            "우언",
            "좌언"});
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(257, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgPitcher
            // 
            this.dgPitcher.AllowUserToAddRows = false;
            this.dgPitcher.AllowUserToDeleteRows = false;
            this.dgPitcher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPitcher.Location = new System.Drawing.Point(12, 38);
            this.dgPitcher.MultiSelect = false;
            this.dgPitcher.Name = "dgPitcher";
            this.dgPitcher.ReadOnly = true;
            this.dgPitcher.RowTemplate.Height = 23;
            this.dgPitcher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPitcher.Size = new System.Drawing.Size(588, 326);
            this.dgPitcher.TabIndex = 1;
            this.dgPitcher.SelectionChanged += new System.EventHandler(this.dgPitcher_SelectionChanged);
            // 
            // dgBall
            // 
            this.dgBall.AllowUserToAddRows = false;
            this.dgBall.AllowUserToDeleteRows = false;
            this.dgBall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBall.Location = new System.Drawing.Point(12, 370);
            this.dgBall.MultiSelect = false;
            this.dgBall.Name = "dgBall";
            this.dgBall.ReadOnly = true;
            this.dgBall.RowTemplate.Height = 23;
            this.dgBall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBall.Size = new System.Drawing.Size(588, 260);
            this.dgBall.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 642);
            this.Controls.Add(this.dgBall);
            this.Controls.Add(this.dgPitcher);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgPitcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgPitcher;
        private System.Windows.Forms.DataGridView dgBall;
    }
}

