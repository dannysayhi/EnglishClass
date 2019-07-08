namespace AOISystem.Utility.Account
{
    partial class AccountEditorForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpAccountEdit = new System.Windows.Forms.GroupBox();
            this.cboAccountLevel = new System.Windows.Forms.ComboBox();
            this.lblAccountLevel = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lvwAccount = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAccountLevel = new System.Windows.Forms.Button();
            this.cbox_managerName = new System.Windows.Forms.ComboBox();
            this.grpAccountEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(397, 244);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(397, 285);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grpAccountEdit
            // 
            this.grpAccountEdit.Controls.Add(this.cbox_managerName);
            this.grpAccountEdit.Controls.Add(this.cboAccountLevel);
            this.grpAccountEdit.Controls.Add(this.lblAccountLevel);
            this.grpAccountEdit.Controls.Add(this.txtPassword);
            this.grpAccountEdit.Controls.Add(this.lblPassword);
            this.grpAccountEdit.Controls.Add(this.lblAccount);
            this.grpAccountEdit.Location = new System.Drawing.Point(193, 12);
            this.grpAccountEdit.Name = "grpAccountEdit";
            this.grpAccountEdit.Size = new System.Drawing.Size(252, 97);
            this.grpAccountEdit.TabIndex = 9;
            this.grpAccountEdit.TabStop = false;
            this.grpAccountEdit.Text = "使用者";
            // 
            // cboAccountLevel
            // 
            this.cboAccountLevel.FormattingEnabled = true;
            this.cboAccountLevel.Items.AddRange(new object[] {
            "Intern",
            "Operator",
            "Engineer",
            "Manager",
            "Administrator"});
            this.cboAccountLevel.Location = new System.Drawing.Point(75, 70);
            this.cboAccountLevel.Name = "cboAccountLevel";
            this.cboAccountLevel.Size = new System.Drawing.Size(164, 20);
            this.cboAccountLevel.TabIndex = 7;
            this.cboAccountLevel.Text = "Operator";
            // 
            // lblAccountLevel
            // 
            this.lblAccountLevel.AutoSize = true;
            this.lblAccountLevel.Location = new System.Drawing.Point(12, 73);
            this.lblAccountLevel.Name = "lblAccountLevel";
            this.lblAccountLevel.Size = new System.Drawing.Size(31, 12);
            this.lblAccountLevel.TabIndex = 6;
            this.lblAccountLevel.Text = "Level";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(164, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 48);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 12);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(12, 23);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(32, 12);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "Name";
            // 
            // lvwAccount
            // 
            this.lvwAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lvwAccount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvwAccount.FullRowSelect = true;
            this.lvwAccount.GridLines = true;
            this.lvwAccount.Location = new System.Drawing.Point(0, 0);
            this.lvwAccount.Name = "lvwAccount";
            this.lvwAccount.Size = new System.Drawing.Size(187, 317);
            this.lvwAccount.TabIndex = 10;
            this.lvwAccount.UseCompatibleStateImageBehavior = false;
            this.lvwAccount.View = System.Windows.Forms.View.Details;
            this.lvwAccount.SelectedIndexChanged += new System.EventHandler(this.lvwAccount_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Level";
            this.columnHeader3.Width = 97;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(207, 126);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(273, 126);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(64, 23);
            this.btnModify.TabIndex = 12;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(343, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAccountLevel
            // 
            this.btnAccountLevel.Location = new System.Drawing.Point(207, 155);
            this.btnAccountLevel.Name = "btnAccountLevel";
            this.btnAccountLevel.Size = new System.Drawing.Size(196, 23);
            this.btnAccountLevel.TabIndex = 14;
            this.btnAccountLevel.Text = "功能層級分類";
            this.btnAccountLevel.UseVisualStyleBackColor = true;
            this.btnAccountLevel.Click += new System.EventHandler(this.btnAccountLevel_Click);
            // 
            // cbox_managerName
            // 
            this.cbox_managerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_managerName.FormattingEnabled = true;
            this.cbox_managerName.Location = new System.Drawing.Point(75, 19);
            this.cbox_managerName.Name = "cbox_managerName";
            this.cbox_managerName.Size = new System.Drawing.Size(164, 20);
            this.cbox_managerName.TabIndex = 8;
            // 
            // AccountEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 317);
            this.Controls.Add(this.btnAccountLevel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwAccount);
            this.Controls.Add(this.grpAccountEdit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Name = "AccountEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "帳號編輯";
            this.Load += new System.EventHandler(this.AccountEditorForm_Load);
            this.grpAccountEdit.ResumeLayout(false);
            this.grpAccountEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpAccountEdit;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ListView lvwAccount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label lblAccountLevel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cboAccountLevel;
        private System.Windows.Forms.Button btnAccountLevel;
        private System.Windows.Forms.ComboBox cbox_managerName;
    }
}