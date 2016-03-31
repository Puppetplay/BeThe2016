namespace 타자분석
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
            this.dgHitter = new System.Windows.Forms.DataGridView();
            this.dgBatts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgHitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBatts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgHitter
            // 
            this.dgHitter.AllowUserToAddRows = false;
            this.dgHitter.AllowUserToDeleteRows = false;
            this.dgHitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHitter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHitter.Location = new System.Drawing.Point(12, 12);
            this.dgHitter.MultiSelect = false;
            this.dgHitter.Name = "dgHitter";
            this.dgHitter.ReadOnly = true;
            this.dgHitter.RowTemplate.Height = 23;
            this.dgHitter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHitter.Size = new System.Drawing.Size(271, 711);
            this.dgHitter.TabIndex = 2;
            this.dgHitter.SelectionChanged += new System.EventHandler(this.dgHitter_SelectionChanged);
            // 
            // dgBatts
            // 
            this.dgBatts.AllowUserToAddRows = false;
            this.dgBatts.AllowUserToDeleteRows = false;
            this.dgBatts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgBatts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBatts.Location = new System.Drawing.Point(289, 12);
            this.dgBatts.MultiSelect = false;
            this.dgBatts.Name = "dgBatts";
            this.dgBatts.ReadOnly = true;
            this.dgBatts.RowTemplate.Height = 23;
            this.dgBatts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBatts.Size = new System.Drawing.Size(589, 711);
            this.dgBatts.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 735);
            this.Controls.Add(this.dgBatts);
            this.Controls.Add(this.dgHitter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBatts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHitter;
        private System.Windows.Forms.DataGridView dgBatts;
    }
}

