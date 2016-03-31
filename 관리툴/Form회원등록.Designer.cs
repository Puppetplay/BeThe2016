namespace 관리툴
{
    partial class Form회원등록
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt등록 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbKakaoName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt등록
            // 
            this.bt등록.Location = new System.Drawing.Point(238, 27);
            this.bt등록.Name = "bt등록";
            this.bt등록.Size = new System.Drawing.Size(75, 41);
            this.bt등록.TabIndex = 0;
            this.bt등록.Text = "등록";
            this.bt등록.UseVisualStyleBackColor = true;
            this.bt등록.Click += new System.EventHandler(this.bt등록_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "이름 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "카카오대화명 : ";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(104, 24);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(128, 21);
            this.tbName.TabIndex = 3;
            // 
            // tbKakaoName
            // 
            this.tbKakaoName.Location = new System.Drawing.Point(104, 51);
            this.tbKakaoName.Name = "tbKakaoName";
            this.tbKakaoName.Size = new System.Drawing.Size(128, 21);
            this.tbKakaoName.TabIndex = 4;
            // 
            // Form회원등록
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 92);
            this.Controls.Add(this.tbKakaoName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt등록);
            this.Name = "Form회원등록";
            this.Text = "Form회원등록";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt등록;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbKakaoName;
    }
}