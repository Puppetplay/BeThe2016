namespace Simulater
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
            this.dgSchedule = new System.Windows.Forms.DataGridView();
            this.dgMatch = new System.Windows.Forms.DataGridView();
            this.dgPitcher = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPitcher)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSchedule
            // 
            this.dgSchedule.AllowUserToAddRows = false;
            this.dgSchedule.AllowUserToDeleteRows = false;
            this.dgSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSchedule.Location = new System.Drawing.Point(12, 12);
            this.dgSchedule.Name = "dgSchedule";
            this.dgSchedule.ReadOnly = true;
            this.dgSchedule.RowTemplate.Height = 23;
            this.dgSchedule.Size = new System.Drawing.Size(164, 491);
            this.dgSchedule.TabIndex = 2;
            this.dgSchedule.SelectionChanged += new System.EventHandler(this.dgSchedule_SelectionChanged);
            // 
            // dgMatch
            // 
            this.dgMatch.AllowUserToAddRows = false;
            this.dgMatch.AllowUserToDeleteRows = false;
            this.dgMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMatch.Location = new System.Drawing.Point(182, 12);
            this.dgMatch.Name = "dgMatch";
            this.dgMatch.ReadOnly = true;
            this.dgMatch.RowTemplate.Height = 23;
            this.dgMatch.Size = new System.Drawing.Size(164, 152);
            this.dgMatch.TabIndex = 3;
            this.dgMatch.SelectionChanged += new System.EventHandler(this.dgMatch_SelectionChanged);
            // 
            // dgPitcher
            // 
            this.dgPitcher.AllowUserToAddRows = false;
            this.dgPitcher.AllowUserToDeleteRows = false;
            this.dgPitcher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPitcher.Location = new System.Drawing.Point(182, 170);
            this.dgPitcher.Name = "dgPitcher";
            this.dgPitcher.ReadOnly = true;
            this.dgPitcher.RowTemplate.Height = 23;
            this.dgPitcher.Size = new System.Drawing.Size(164, 82);
            this.dgPitcher.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 515);
            this.Controls.Add(this.dgPitcher);
            this.Controls.Add(this.dgMatch);
            this.Controls.Add(this.dgSchedule);
            this.Name = "Form1";
            this.Text = "시뮬레이터";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPitcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSchedule;
        private System.Windows.Forms.DataGridView dgMatch;
        private System.Windows.Forms.DataGridView dgPitcher;
    }
}

