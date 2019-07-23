namespace EnglishCalssManager.SystemManager.MemberList.EmployeeBook
{
    partial class frmEmployeeMobilePwdRegist
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
            this.lb_phoneNum = new System.Windows.Forms.Label();
            this.lb_TWname = new System.Windows.Forms.Label();
            this.lb_EmpID = new System.Windows.Forms.Label();
            this.txt_NewPwd = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_oldPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_phoneNum
            // 
            this.lb_phoneNum.AutoSize = true;
            this.lb_phoneNum.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_phoneNum.Location = new System.Drawing.Point(39, 104);
            this.lb_phoneNum.Name = "lb_phoneNum";
            this.lb_phoneNum.Size = new System.Drawing.Size(104, 19);
            this.lb_phoneNum.TabIndex = 20;
            this.lb_phoneNum.Text = "員工電話：";
            // 
            // lb_TWname
            // 
            this.lb_TWname.AutoSize = true;
            this.lb_TWname.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_TWname.Location = new System.Drawing.Point(39, 65);
            this.lb_TWname.Name = "lb_TWname";
            this.lb_TWname.Size = new System.Drawing.Size(104, 19);
            this.lb_TWname.TabIndex = 17;
            this.lb_TWname.Text = "員工姓名：";
            // 
            // lb_EmpID
            // 
            this.lb_EmpID.AutoSize = true;
            this.lb_EmpID.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_EmpID.Location = new System.Drawing.Point(39, 22);
            this.lb_EmpID.Name = "lb_EmpID";
            this.lb_EmpID.Size = new System.Drawing.Size(85, 19);
            this.lb_EmpID.TabIndex = 16;
            this.lb_EmpID.Text = "員工號：";
            // 
            // txt_NewPwd
            // 
            this.txt_NewPwd.Location = new System.Drawing.Point(111, 183);
            this.txt_NewPwd.Name = "txt_NewPwd";
            this.txt_NewPwd.Size = new System.Drawing.Size(129, 22);
            this.txt_NewPwd.TabIndex = 15;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(146, 230);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(54, 230);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 19;
            this.btn_OK.Text = "確認";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(39, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "新密碼";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 13;
            // 
            // lb_oldPwd
            // 
            this.lb_oldPwd.AutoSize = true;
            this.lb_oldPwd.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_oldPwd.Location = new System.Drawing.Point(39, 138);
            this.lb_oldPwd.Name = "lb_oldPwd";
            this.lb_oldPwd.Size = new System.Drawing.Size(85, 19);
            this.lb_oldPwd.TabIndex = 12;
            this.lb_oldPwd.Text = "舊密碼：";
            // 
            // frmEmployeeMobilePwdRegist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 448);
            this.Controls.Add(this.lb_phoneNum);
            this.Controls.Add(this.lb_TWname);
            this.Controls.Add(this.lb_EmpID);
            this.Controls.Add(this.txt_NewPwd);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_oldPwd);
            this.Name = "frmEmployeeMobilePwdRegist";
            this.Text = "frmEmployeeMobilePwdRegist";
            this.Load += new System.EventHandler(this.frmEmployeeMobilePwdRegist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_phoneNum;
        private System.Windows.Forms.Label lb_TWname;
        private System.Windows.Forms.Label lb_EmpID;
        private System.Windows.Forms.TextBox txt_NewPwd;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_oldPwd;
    }
}