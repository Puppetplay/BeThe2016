﻿namespace 회원등록
{
    partial class Form회원등록
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKaKaoName = new System.Windows.Forms.TextBox();
            this.bt등록 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(120, 27);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(152, 21);
            this.tbName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "이름 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "카카오대화명 :";
            // 
            // tbKaKaoName
            // 
            this.tbKaKaoName.Location = new System.Drawing.Point(120, 54);
            this.tbKaKaoName.Name = "tbKaKaoName";
            this.tbKaKaoName.Size = new System.Drawing.Size(152, 21);
            this.tbKaKaoName.TabIndex = 3;
            // 
            // bt등록
            // 
            this.bt등록.Location = new System.Drawing.Point(278, 27);
            this.bt등록.Name = "bt등록";
            this.bt등록.Size = new System.Drawing.Size(124, 48);
            this.bt등록.TabIndex = 4;
            this.bt등록.Text = "등록";
            this.bt등록.UseVisualStyleBackColor = true;
            this.bt등록.Click += new System.EventHandler(this.bt등록_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 102);
            this.Controls.Add(this.bt등록);
            this.Controls.Add(this.tbKaKaoName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Name = "Form1";
            this.Text = "회원등록";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKaKaoName;
        private System.Windows.Forms.Button bt등록;
    }
}

