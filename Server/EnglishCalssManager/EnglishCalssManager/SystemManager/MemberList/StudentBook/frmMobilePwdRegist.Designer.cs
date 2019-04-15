namespace EnglishCalssManager.SystemManager.MemberList.StudentBook
{
    partial class frmMobilePwdRegist
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
            this.lb_oldPwd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_NewPwd = new System.Windows.Forms.TextBox();
            this.lb_StdID = new System.Windows.Forms.Label();
            this.lb_TWname = new System.Windows.Forms.Label();
            this.lb_phoneNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_oldPwd
            // 
            this.lb_oldPwd.AutoSize = true;
            this.lb_oldPwd.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_oldPwd.Location = new System.Drawing.Point(18, 139);
            this.lb_oldPwd.Name = "lb_oldPwd";
            this.lb_oldPwd.Size = new System.Drawing.Size(85, 19);
            this.lb_oldPwd.TabIndex = 0;
            this.lb_oldPwd.Text = "舊密碼：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(18, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "新密碼";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(33, 231);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "確認";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(125, 231);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_NewPwd
            // 
            this.txt_NewPwd.Location = new System.Drawing.Point(90, 184);
            this.txt_NewPwd.Name = "txt_NewPwd";
            this.txt_NewPwd.Size = new System.Drawing.Size(129, 22);
            this.txt_NewPwd.TabIndex = 6;
            // 
            // lb_StdID
            // 
            this.lb_StdID.AutoSize = true;
            this.lb_StdID.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_StdID.Location = new System.Drawing.Point(18, 23);
            this.lb_StdID.Name = "lb_StdID";
            this.lb_StdID.Size = new System.Drawing.Size(66, 19);
            this.lb_StdID.TabIndex = 7;
            this.lb_StdID.Text = "學號：";
            // 
            // lb_TWname
            // 
            this.lb_TWname.AutoSize = true;
            this.lb_TWname.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_TWname.Location = new System.Drawing.Point(18, 66);
            this.lb_TWname.Name = "lb_TWname";
            this.lb_TWname.Size = new System.Drawing.Size(104, 19);
            this.lb_TWname.TabIndex = 8;
            this.lb_TWname.Text = "學生姓名：";
            // 
            // lb_phoneNum
            // 
            this.lb_phoneNum.AutoSize = true;
            this.lb_phoneNum.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_phoneNum.Location = new System.Drawing.Point(18, 105);
            this.lb_phoneNum.Name = "lb_phoneNum";
            this.lb_phoneNum.Size = new System.Drawing.Size(104, 19);
            this.lb_phoneNum.TabIndex = 11;
            this.lb_phoneNum.Text = "家長電話：";
            // 
            // frmMobilePwdRegist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 292);
            this.Controls.Add(this.lb_phoneNum);
            this.Controls.Add(this.lb_TWname);
            this.Controls.Add(this.lb_StdID);
            this.Controls.Add(this.txt_NewPwd);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_oldPwd);
            this.Name = "frmMobilePwdRegist";
            this.Text = "密碼註冊";
            this.Load += new System.EventHandler(this.frmMobilePwdRegist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_oldPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_NewPwd;
        private System.Windows.Forms.Label lb_StdID;
        private System.Windows.Forms.Label lb_TWname;
        private System.Windows.Forms.Label lb_phoneNum;
    }
}