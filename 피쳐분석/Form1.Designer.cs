namespace 피쳐분석
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
            this.dgMatch = new System.Windows.Forms.DataGridView();
            this.dgHomePitcher = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHomePitcher = new System.Windows.Forms.TextBox();
            this.tbAwayPitcher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgAwayPitcher = new System.Windows.Forms.DataGridView();
            this.dgAwayHitter = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgHomeHitter = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dgHomePitcherInfo = new System.Windows.Forms.DataGridView();
            this.dgAwayPitcherInfo = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgHitterInfo = new System.Windows.Forms.DataGridView();
            this.dgHitterTypeInfo = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dgHitterVSInfo = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbChangeCount = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHomePitcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAwayPitcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAwayHitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHomeHitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHomePitcherInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAwayPitcherInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHitterInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHitterTypeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHitterVSInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMatch
            // 
            this.dgMatch.AllowUserToAddRows = false;
            this.dgMatch.AllowUserToDeleteRows = false;
            this.dgMatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMatch.Location = new System.Drawing.Point(12, 12);
            this.dgMatch.Name = "dgMatch";
            this.dgMatch.ReadOnly = true;
            this.dgMatch.RowTemplate.Height = 23;
            this.dgMatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMatch.Size = new System.Drawing.Size(274, 829);
            this.dgMatch.TabIndex = 0;
            this.dgMatch.SelectionChanged += new System.EventHandler(this.dgMatch_SelectionChanged);
            // 
            // dgHomePitcher
            // 
            this.dgHomePitcher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHomePitcher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHomePitcher.Location = new System.Drawing.Point(292, 53);
            this.dgHomePitcher.Name = "dgHomePitcher";
            this.dgHomePitcher.RowTemplate.Height = 23;
            this.dgHomePitcher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHomePitcher.Size = new System.Drawing.Size(313, 178);
            this.dgHomePitcher.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "홈팀 선발";
            // 
            // tbHomePitcher
            // 
            this.tbHomePitcher.Location = new System.Drawing.Point(380, 28);
            this.tbHomePitcher.Name = "tbHomePitcher";
            this.tbHomePitcher.ReadOnly = true;
            this.tbHomePitcher.Size = new System.Drawing.Size(125, 21);
            this.tbHomePitcher.TabIndex = 3;
            // 
            // tbAwayPitcher
            // 
            this.tbAwayPitcher.Location = new System.Drawing.Point(698, 29);
            this.tbAwayPitcher.Name = "tbAwayPitcher";
            this.tbAwayPitcher.ReadOnly = true;
            this.tbAwayPitcher.Size = new System.Drawing.Size(125, 21);
            this.tbAwayPitcher.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "어웨이 선발";
            // 
            // dgAwayPitcher
            // 
            this.dgAwayPitcher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgAwayPitcher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAwayPitcher.Location = new System.Drawing.Point(611, 53);
            this.dgAwayPitcher.Name = "dgAwayPitcher";
            this.dgAwayPitcher.RowTemplate.Height = 23;
            this.dgAwayPitcher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAwayPitcher.Size = new System.Drawing.Size(313, 178);
            this.dgAwayPitcher.TabIndex = 4;
            // 
            // dgAwayHitter
            // 
            this.dgAwayHitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgAwayHitter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAwayHitter.Location = new System.Drawing.Point(292, 389);
            this.dgAwayHitter.Name = "dgAwayHitter";
            this.dgAwayHitter.RowTemplate.Height = 23;
            this.dgAwayHitter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAwayHitter.Size = new System.Drawing.Size(313, 452);
            this.dgAwayHitter.TabIndex = 7;
            this.dgAwayHitter.SelectionChanged += new System.EventHandler(this.dgHitter_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "어웨이팀 타자";
            // 
            // dgHomeHitter
            // 
            this.dgHomeHitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHomeHitter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHomeHitter.Location = new System.Drawing.Point(611, 389);
            this.dgHomeHitter.Name = "dgHomeHitter";
            this.dgHomeHitter.RowTemplate.Height = 23;
            this.dgHomeHitter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHomeHitter.Size = new System.Drawing.Size(313, 452);
            this.dgHomeHitter.TabIndex = 9;
            this.dgHomeHitter.SelectionChanged += new System.EventHandler(this.dgHitter_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(622, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "홈팀 타자";
            // 
            // dgHomePitcherInfo
            // 
            this.dgHomePitcherInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHomePitcherInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHomePitcherInfo.Location = new System.Drawing.Point(292, 237);
            this.dgHomePitcherInfo.Name = "dgHomePitcherInfo";
            this.dgHomePitcherInfo.RowTemplate.Height = 23;
            this.dgHomePitcherInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHomePitcherInfo.Size = new System.Drawing.Size(313, 111);
            this.dgHomePitcherInfo.TabIndex = 11;
            // 
            // dgAwayPitcherInfo
            // 
            this.dgAwayPitcherInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgAwayPitcherInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAwayPitcherInfo.Location = new System.Drawing.Point(611, 237);
            this.dgAwayPitcherInfo.Name = "dgAwayPitcherInfo";
            this.dgAwayPitcherInfo.RowTemplate.Height = 23;
            this.dgAwayPitcherInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAwayPitcherInfo.Size = new System.Drawing.Size(313, 111);
            this.dgAwayPitcherInfo.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(942, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "성적";
            // 
            // dgHitterInfo
            // 
            this.dgHitterInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHitterInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHitterInfo.Location = new System.Drawing.Point(930, 53);
            this.dgHitterInfo.Name = "dgHitterInfo";
            this.dgHitterInfo.RowTemplate.Height = 23;
            this.dgHitterInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHitterInfo.Size = new System.Drawing.Size(661, 89);
            this.dgHitterInfo.TabIndex = 14;
            // 
            // dgHitterTypeInfo
            // 
            this.dgHitterTypeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHitterTypeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHitterTypeInfo.Location = new System.Drawing.Point(930, 165);
            this.dgHitterTypeInfo.Name = "dgHitterTypeInfo";
            this.dgHitterTypeInfo.RowTemplate.Height = 23;
            this.dgHitterTypeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHitterTypeInfo.Size = new System.Drawing.Size(661, 158);
            this.dgHitterTypeInfo.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(942, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "투수타입별성적";
            // 
            // dgHitterVSInfo
            // 
            this.dgHitterVSInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHitterVSInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHitterVSInfo.Location = new System.Drawing.Point(930, 347);
            this.dgHitterVSInfo.Name = "dgHitterVSInfo";
            this.dgHitterVSInfo.RowTemplate.Height = 23;
            this.dgHitterVSInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHitterVSInfo.Size = new System.Drawing.Size(661, 158);
            this.dgHitterVSInfo.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(942, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "상대전적";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(930, 517);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "교체수";
            // 
            // tbChangeCount
            // 
            this.tbChangeCount.Location = new System.Drawing.Point(977, 512);
            this.tbChangeCount.Name = "tbChangeCount";
            this.tbChangeCount.ReadOnly = true;
            this.tbChangeCount.Size = new System.Drawing.Size(125, 21);
            this.tbChangeCount.TabIndex = 20;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(932, 539);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(661, 158);
            this.dataGridView1.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1603, 853);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbChangeCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgHitterVSInfo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgHitterTypeInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgHitterInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgAwayPitcherInfo);
            this.Controls.Add(this.dgHomePitcherInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgHomeHitter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgAwayHitter);
            this.Controls.Add(this.tbAwayPitcher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgAwayPitcher);
            this.Controls.Add(this.tbHomePitcher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgHomePitcher);
            this.Controls.Add(this.dgMatch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHomePitcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAwayPitcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAwayHitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHomeHitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHomePitcherInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAwayPitcherInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHitterInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHitterTypeInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHitterVSInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMatch;
        private System.Windows.Forms.DataGridView dgHomePitcher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHomePitcher;
        private System.Windows.Forms.TextBox tbAwayPitcher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgAwayPitcher;
        private System.Windows.Forms.DataGridView dgAwayHitter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgHomeHitter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgHomePitcherInfo;
        private System.Windows.Forms.DataGridView dgAwayPitcherInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgHitterInfo;
        private System.Windows.Forms.DataGridView dgHitterTypeInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgHitterVSInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbChangeCount;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

