namespace EnglishCalssManager.EmployeeAttence.ClassEmployeeManager
{
    partial class frmClassEmployeeManager
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
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.cbox_ClassID = new System.Windows.Forms.ComboBox();
            this.dataGridViewSource = new System.Windows.Forms.DataGridView();
            this.lb_endpage = new System.Windows.Forms.LinkLabel();
            this.lb_pageNum = new System.Windows.Forms.LinkLabel();
            this.lb_startpage = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbox_Pos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_Dep = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_Onjob = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_PhoneNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TwName = new System.Windows.Forms.TextBox();
            this.txt_EnName = new System.Windows.Forms.TextBox();
            this.txt_CardNumber = new System.Windows.Forms.TextBox();
            this.txt_EmployeeID = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btn_clearText = new System.Windows.Forms.Button();
            this.btn_insertToClass = new System.Windows.Forms.Button();
            this.btn_DelFromClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(25, 179);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.RowTemplate.Height = 24;
            this.dataGridViewResult.Size = new System.Drawing.Size(458, 479);
            this.dataGridViewResult.TabIndex = 0;
            // 
            // cbox_ClassID
            // 
            this.cbox_ClassID.FormattingEnabled = true;
            this.cbox_ClassID.Location = new System.Drawing.Point(25, 22);
            this.cbox_ClassID.Name = "cbox_ClassID";
            this.cbox_ClassID.Size = new System.Drawing.Size(189, 20);
            this.cbox_ClassID.TabIndex = 1;
            this.cbox_ClassID.SelectedIndexChanged += new System.EventHandler(this.cbox_ClassID_SelectedIndexChanged);
            // 
            // dataGridViewSource
            // 
            this.dataGridViewSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSource.Location = new System.Drawing.Point(501, 179);
            this.dataGridViewSource.Name = "dataGridViewSource";
            this.dataGridViewSource.RowTemplate.Height = 24;
            this.dataGridViewSource.Size = new System.Drawing.Size(574, 479);
            this.dataGridViewSource.TabIndex = 2;
            // 
            // lb_endpage
            // 
            this.lb_endpage.AutoSize = true;
            this.lb_endpage.Location = new System.Drawing.Point(903, 141);
            this.lb_endpage.Name = "lb_endpage";
            this.lb_endpage.Size = new System.Drawing.Size(56, 12);
            this.lb_endpage.TabIndex = 39;
            this.lb_endpage.TabStop = true;
            this.lb_endpage.Text = "    20     >>";
            this.lb_endpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_endpage_LinkClicked);
            // 
            // lb_pageNum
            // 
            this.lb_pageNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_pageNum.AutoSize = true;
            this.lb_pageNum.Location = new System.Drawing.Point(856, 141);
            this.lb_pageNum.Name = "lb_pageNum";
            this.lb_pageNum.Size = new System.Drawing.Size(32, 12);
            this.lb_pageNum.TabIndex = 40;
            this.lb_pageNum.TabStop = true;
            this.lb_pageNum.Text = "第 頁";
            this.lb_pageNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_startpage
            // 
            this.lb_startpage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_startpage.AutoSize = true;
            this.lb_startpage.Location = new System.Drawing.Point(787, 141);
            this.lb_startpage.Name = "lb_startpage";
            this.lb_startpage.Size = new System.Drawing.Size(59, 12);
            this.lb_startpage.TabIndex = 41;
            this.lb_startpage.TabStop = true;
            this.lb_startpage.Text = "<<     20     ";
            this.lb_startpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_startpage_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbox_Pos);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbox_Dep);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbox_Onjob);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txt_PhoneNumber);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_TwName);
            this.groupBox2.Controls.Add(this.txt_EnName);
            this.groupBox2.Controls.Add(this.txt_CardNumber);
            this.groupBox2.Controls.Add(this.txt_EmployeeID);
            this.groupBox2.Location = new System.Drawing.Point(501, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 118);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "員工資料";
            // 
            // cbox_Pos
            // 
            this.cbox_Pos.FormattingEnabled = true;
            this.cbox_Pos.Location = new System.Drawing.Point(182, 86);
            this.cbox_Pos.Name = "cbox_Pos";
            this.cbox_Pos.Size = new System.Drawing.Size(50, 20);
            this.cbox_Pos.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "職位：";
            // 
            // cbox_Dep
            // 
            this.cbox_Dep.FormattingEnabled = true;
            this.cbox_Dep.Location = new System.Drawing.Point(69, 86);
            this.cbox_Dep.Name = "cbox_Dep";
            this.cbox_Dep.Size = new System.Drawing.Size(50, 20);
            this.cbox_Dep.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "部門：";
            // 
            // cbox_Onjob
            // 
            this.cbox_Onjob.FormattingEnabled = true;
            this.cbox_Onjob.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbox_Onjob.Location = new System.Drawing.Point(469, 53);
            this.cbox_Onjob.Name = "cbox_Onjob";
            this.cbox_Onjob.Size = new System.Drawing.Size(50, 20);
            this.cbox_Onjob.TabIndex = 52;
            this.cbox_Onjob.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "在職：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(210, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 45;
            this.label17.Text = "連絡電話：";
            // 
            // txt_PhoneNumber
            // 
            this.txt_PhoneNumber.Location = new System.Drawing.Point(281, 52);
            this.txt_PhoneNumber.Name = "txt_PhoneNumber";
            this.txt_PhoneNumber.Size = new System.Drawing.Size(135, 22);
            this.txt_PhoneNumber.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "英文名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(381, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "員工號：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "卡號：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "員工姓名：";
            // 
            // txt_TwName
            // 
            this.txt_TwName.Location = new System.Drawing.Point(70, 16);
            this.txt_TwName.Name = "txt_TwName";
            this.txt_TwName.Size = new System.Drawing.Size(112, 22);
            this.txt_TwName.TabIndex = 15;
            // 
            // txt_EnName
            // 
            this.txt_EnName.Location = new System.Drawing.Point(70, 53);
            this.txt_EnName.Name = "txt_EnName";
            this.txt_EnName.Size = new System.Drawing.Size(112, 22);
            this.txt_EnName.TabIndex = 26;
            // 
            // txt_CardNumber
            // 
            this.txt_CardNumber.Location = new System.Drawing.Point(252, 15);
            this.txt_CardNumber.Name = "txt_CardNumber";
            this.txt_CardNumber.Size = new System.Drawing.Size(112, 22);
            this.txt_CardNumber.TabIndex = 16;
            // 
            // txt_EmployeeID
            // 
            this.txt_EmployeeID.Location = new System.Drawing.Point(436, 17);
            this.txt_EmployeeID.Name = "txt_EmployeeID";
            this.txt_EmployeeID.Size = new System.Drawing.Size(112, 22);
            this.txt_EmployeeID.TabIndex = 17;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelect.Location = new System.Drawing.Point(595, 141);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 43;
            this.btnSelect.Text = "查詢";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btn_clearText
            // 
            this.btn_clearText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_clearText.Location = new System.Drawing.Point(693, 141);
            this.btn_clearText.Name = "btn_clearText";
            this.btn_clearText.Size = new System.Drawing.Size(75, 23);
            this.btn_clearText.TabIndex = 44;
            this.btn_clearText.Text = "清空條件";
            this.btn_clearText.UseVisualStyleBackColor = true;
            this.btn_clearText.Click += new System.EventHandler(this.btn_clearText_Click);
            // 
            // btn_insertToClass
            // 
            this.btn_insertToClass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_insertToClass.Location = new System.Drawing.Point(292, 150);
            this.btn_insertToClass.Name = "btn_insertToClass";
            this.btn_insertToClass.Size = new System.Drawing.Size(75, 23);
            this.btn_insertToClass.TabIndex = 45;
            this.btn_insertToClass.Text = "新增員工";
            this.btn_insertToClass.UseVisualStyleBackColor = true;
            this.btn_insertToClass.Click += new System.EventHandler(this.btn_insertToClass_Click);
            // 
            // btn_DelFromClass
            // 
            this.btn_DelFromClass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_DelFromClass.Location = new System.Drawing.Point(408, 150);
            this.btn_DelFromClass.Name = "btn_DelFromClass";
            this.btn_DelFromClass.Size = new System.Drawing.Size(75, 23);
            this.btn_DelFromClass.TabIndex = 46;
            this.btn_DelFromClass.Text = "刪除員工";
            this.btn_DelFromClass.UseVisualStyleBackColor = true;
            this.btn_DelFromClass.Click += new System.EventHandler(this.btn_DelFromClass_Click);
            // 
            // frmClassEmployeeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 741);
            this.Controls.Add(this.btn_DelFromClass);
            this.Controls.Add(this.btn_insertToClass);
            this.Controls.Add(this.btn_clearText);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lb_startpage);
            this.Controls.Add(this.lb_pageNum);
            this.Controls.Add(this.lb_endpage);
            this.Controls.Add(this.dataGridViewSource);
            this.Controls.Add(this.cbox_ClassID);
            this.Controls.Add(this.dataGridViewResult);
            this.Name = "frmClassEmployeeManager";
            this.Text = "frmClassEmployeeManager";
            this.Load += new System.EventHandler(this.frmClassEmployeeManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.ComboBox cbox_ClassID;
        private System.Windows.Forms.DataGridView dataGridViewSource;
        private System.Windows.Forms.LinkLabel lb_endpage;
        private System.Windows.Forms.LinkLabel lb_pageNum;
        private System.Windows.Forms.LinkLabel lb_startpage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbox_Pos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_Dep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_Onjob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_PhoneNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TwName;
        private System.Windows.Forms.TextBox txt_EnName;
        private System.Windows.Forms.TextBox txt_CardNumber;
        private System.Windows.Forms.TextBox txt_EmployeeID;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btn_clearText;
        private System.Windows.Forms.Button btn_insertToClass;
        private System.Windows.Forms.Button btn_DelFromClass;
    }
}