namespace 직구구속확인
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
            this.dgAR = new System.Windows.Forms.DataGridView();
            this.dgAL = new System.Windows.Forms.DataGridView();
            this.dgBR = new System.Windows.Forms.DataGridView();
            this.dgBL = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgHitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBL)).BeginInit();
            this.SuspendLayout();
            // 
            // dgHitter
            // 
            this.dgHitter.AllowUserToAddRows = false;
            this.dgHitter.AllowUserToDeleteRows = false;
            this.dgHitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHitter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHitter.Location = new System.Drawing.Point(12, 8);
            this.dgHitter.MultiSelect = false;
            this.dgHitter.Name = "dgHitter";
            this.dgHitter.ReadOnly = true;
            this.dgHitter.RowTemplate.Height = 23;
            this.dgHitter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHitter.Size = new System.Drawing.Size(271, 809);
            this.dgHitter.TabIndex = 3;
            this.dgHitter.SelectionChanged += new System.EventHandler(this.dgHitter_SelectionChanged);
            // 
            // dgAR
            // 
            this.dgAR.AllowUserToAddRows = false;
            this.dgAR.AllowUserToDeleteRows = false;
            this.dgAR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAR.Location = new System.Drawing.Point(289, 8);
            this.dgAR.MultiSelect = false;
            this.dgAR.Name = "dgAR";
            this.dgAR.ReadOnly = true;
            this.dgAR.RowTemplate.Height = 23;
            this.dgAR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAR.Size = new System.Drawing.Size(433, 148);
            this.dgAR.TabIndex = 4;
            // 
            // dgAL
            // 
            this.dgAL.AllowUserToAddRows = false;
            this.dgAL.AllowUserToDeleteRows = false;
            this.dgAL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAL.Location = new System.Drawing.Point(289, 162);
            this.dgAL.MultiSelect = false;
            this.dgAL.Name = "dgAL";
            this.dgAL.ReadOnly = true;
            this.dgAL.RowTemplate.Height = 23;
            this.dgAL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAL.Size = new System.Drawing.Size(433, 148);
            this.dgAL.TabIndex = 5;
            // 
            // dgBR
            // 
            this.dgBR.AllowUserToAddRows = false;
            this.dgBR.AllowUserToDeleteRows = false;
            this.dgBR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBR.Location = new System.Drawing.Point(289, 316);
            this.dgBR.MultiSelect = false;
            this.dgBR.Name = "dgBR";
            this.dgBR.ReadOnly = true;
            this.dgBR.RowTemplate.Height = 23;
            this.dgBR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBR.Size = new System.Drawing.Size(433, 148);
            this.dgBR.TabIndex = 6;
            // 
            // dgBL
            // 
            this.dgBL.AllowUserToAddRows = false;
            this.dgBL.AllowUserToDeleteRows = false;
            this.dgBL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBL.Location = new System.Drawing.Point(289, 470);
            this.dgBL.MultiSelect = false;
            this.dgBL.Name = "dgBL";
            this.dgBL.ReadOnly = true;
            this.dgBL.RowTemplate.Height = 23;
            this.dgBL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBL.Size = new System.Drawing.Size(433, 148);
            this.dgBL.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 829);
            this.Controls.Add(this.dgBL);
            this.Controls.Add(this.dgBR);
            this.Controls.Add(this.dgAL);
            this.Controls.Add(this.dgAR);
            this.Controls.Add(this.dgHitter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHitter;
        private System.Windows.Forms.DataGridView dgAR;
        private System.Windows.Forms.DataGridView dgAL;
        private System.Windows.Forms.DataGridView dgBR;
        private System.Windows.Forms.DataGridView dgBL;
    }
}

