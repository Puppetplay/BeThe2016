namespace DataViewer
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
            this.cbTeam = new System.Windows.Forms.ComboBox();
            this.dgPitcher = new System.Windows.Forms.DataGridView();
            this.dgBallType = new System.Windows.Forms.DataGridView();
            this.dgBat = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgBallType2 = new System.Windows.Forms.DataGridView();
            this.dgBat2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgPitcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBallType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBallType2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBat2)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTeam
            // 
            this.cbTeam.FormattingEnabled = true;
            this.cbTeam.Location = new System.Drawing.Point(50, 28);
            this.cbTeam.Name = "cbTeam";
            this.cbTeam.Size = new System.Drawing.Size(81, 20);
            this.cbTeam.TabIndex = 0;
            this.cbTeam.SelectedIndexChanged += new System.EventHandler(this.cbTeam_SelectedIndexChanged);
            // 
            // dgPitcher
            // 
            this.dgPitcher.AllowUserToAddRows = false;
            this.dgPitcher.AllowUserToDeleteRows = false;
            this.dgPitcher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPitcher.Location = new System.Drawing.Point(50, 54);
            this.dgPitcher.Name = "dgPitcher";
            this.dgPitcher.ReadOnly = true;
            this.dgPitcher.RowTemplate.Height = 23;
            this.dgPitcher.Size = new System.Drawing.Size(326, 545);
            this.dgPitcher.TabIndex = 1;
            this.dgPitcher.SelectionChanged += new System.EventHandler(this.dgPitcher_SelectionChanged);
            // 
            // dgBallType
            // 
            this.dgBallType.AllowUserToAddRows = false;
            this.dgBallType.AllowUserToDeleteRows = false;
            this.dgBallType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBallType.Location = new System.Drawing.Point(382, 54);
            this.dgBallType.Name = "dgBallType";
            this.dgBallType.ReadOnly = true;
            this.dgBallType.RowTemplate.Height = 23;
            this.dgBallType.Size = new System.Drawing.Size(465, 199);
            this.dgBallType.TabIndex = 2;
            // 
            // dgBat
            // 
            this.dgBat.AllowUserToAddRows = false;
            this.dgBat.AllowUserToDeleteRows = false;
            this.dgBat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBat.Location = new System.Drawing.Point(382, 259);
            this.dgBat.Name = "dgBat";
            this.dgBat.ReadOnly = true;
            this.dgBat.RowTemplate.Height = 23;
            this.dgBat.Size = new System.Drawing.Size(465, 340);
            this.dgBat.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 4;
            // 
            // dgBallType2
            // 
            this.dgBallType2.AllowUserToAddRows = false;
            this.dgBallType2.AllowUserToDeleteRows = false;
            this.dgBallType2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBallType2.Location = new System.Drawing.Point(853, 54);
            this.dgBallType2.Name = "dgBallType2";
            this.dgBallType2.ReadOnly = true;
            this.dgBallType2.RowTemplate.Height = 23;
            this.dgBallType2.Size = new System.Drawing.Size(467, 199);
            this.dgBallType2.TabIndex = 5;
            // 
            // dgBat2
            // 
            this.dgBat2.AllowUserToAddRows = false;
            this.dgBat2.AllowUserToDeleteRows = false;
            this.dgBat2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBat2.Location = new System.Drawing.Point(853, 259);
            this.dgBat2.Name = "dgBat2";
            this.dgBat2.ReadOnly = true;
            this.dgBat2.RowTemplate.Height = 23;
            this.dgBat2.Size = new System.Drawing.Size(467, 340);
            this.dgBat2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 634);
            this.Controls.Add(this.dgBat2);
            this.Controls.Add(this.dgBallType2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgBat);
            this.Controls.Add(this.dgBallType);
            this.Controls.Add(this.dgPitcher);
            this.Controls.Add(this.cbTeam);
            this.Name = "Form1";
            this.Text = "DataViewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPitcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBallType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBallType2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBat2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTeam;
        private System.Windows.Forms.DataGridView dgPitcher;
        private System.Windows.Forms.DataGridView dgBallType;
        private System.Windows.Forms.DataGridView dgBat;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgBallType2;
        private System.Windows.Forms.DataGridView dgBat2;
    }
}

