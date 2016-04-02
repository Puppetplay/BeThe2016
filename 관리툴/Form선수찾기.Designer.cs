namespace 관리툴
{
    partial class Form선수찾기
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.bt_검색 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "선수명";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(62, 21);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(119, 21);
            this.tbName.TabIndex = 1;
            // 
            // bt_검색
            // 
            this.bt_검색.Location = new System.Drawing.Point(187, 20);
            this.bt_검색.Name = "bt_검색";
            this.bt_검색.Size = new System.Drawing.Size(75, 23);
            this.bt_검색.TabIndex = 2;
            this.bt_검색.Text = "검색";
            this.bt_검색.UseVisualStyleBackColor = true;
            this.bt_검색.Click += new System.EventHandler(this.bt_검색_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(245, 156);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form선수찾기
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 216);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bt_검색);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "Form선수찾기";
            this.Text = "Form선수찾기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button bt_검색;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}