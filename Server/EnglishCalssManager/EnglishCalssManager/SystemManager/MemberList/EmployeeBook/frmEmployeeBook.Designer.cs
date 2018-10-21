namespace EnglishClassManager.SystemManager.MemberList.EmployeeBook
{
    partial class frmEmployeeBook
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
            this.btn_CourseManager = new System.Windows.Forms.Button();
            this.cbox_Onjob = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_PhoneNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TwName = new System.Windows.Forms.TextBox();
            this.txt_EnName = new System.Windows.Forms.TextBox();
            this.txt_Home = new System.Windows.Forms.TextBox();
            this.txt_CardNumber = new System.Windows.Forms.TextBox();
            this.txt_EmployeeID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_DepPosEdit = new System.Windows.Forms.Button();
            this.cbox_Pos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_Dep = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_pageNum = new System.Windows.Forms.LinkLabel();
            this.btn_clearText = new System.Windows.Forms.Button();
            this.lb_startpage = new System.Windows.Forms.LinkLabel();
            this.lb_endpage = new System.Windows.Forms.LinkLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CourseManager
            // 
            this.btn_CourseManager.Location = new System.Drawing.Point(327, 113);
            this.btn_CourseManager.Name = "btn_CourseManager";
            this.btn_CourseManager.Size = new System.Drawing.Size(75, 23);
            this.btn_CourseManager.TabIndex = 0;
            this.btn_CourseManager.Text = "群組設定";
            this.btn_CourseManager.UseVisualStyleBackColor = true;
            this.btn_CourseManager.Click += new System.EventHandler(this.btn_CourseManager_Click);
            // 
            // cbox_Onjob
            // 
            this.cbox_Onjob.FormattingEnabled = true;
            this.cbox_Onjob.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbox_Onjob.Location = new System.Drawing.Point(1011, 16);
            this.cbox_Onjob.Name = "cbox_Onjob";
            this.cbox_Onjob.Size = new System.Drawing.Size(50, 20);
            this.cbox_Onjob.TabIndex = 52;
            this.cbox_Onjob.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(964, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "在職：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(752, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 45;
            this.label17.Text = "連絡電話：";
            // 
            // txt_PhoneNumber
            // 
            this.txt_PhoneNumber.Location = new System.Drawing.Point(823, 15);
            this.txt_PhoneNumber.Name = "txt_PhoneNumber";
            this.txt_PhoneNumber.Size = new System.Drawing.Size(135, 22);
            this.txt_PhoneNumber.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 33;
            this.label10.Text = "住址：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(572, 21);
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
            this.txt_EnName.Location = new System.Drawing.Point(631, 16);
            this.txt_EnName.Name = "txt_EnName";
            this.txt_EnName.Size = new System.Drawing.Size(112, 22);
            this.txt_EnName.TabIndex = 26;
            // 
            // txt_Home
            // 
            this.txt_Home.Location = new System.Drawing.Point(69, 50);
            this.txt_Home.Name = "txt_Home";
            this.txt_Home.Size = new System.Drawing.Size(937, 22);
            this.txt_Home.TabIndex = 20;
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
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 9);
            this.groupBox2.Controls.Add(this.btn_DepPosEdit);
            this.groupBox2.Controls.Add(this.cbox_Pos);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbox_Dep);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbox_Onjob);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txt_PhoneNumber);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_TwName);
            this.groupBox2.Controls.Add(this.txt_EnName);
            this.groupBox2.Controls.Add(this.txt_Home);
            this.groupBox2.Controls.Add(this.txt_CardNumber);
            this.groupBox2.Controls.Add(this.txt_EmployeeID);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1335, 104);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "員工資料";
            // 
            // btn_DepPosEdit
            // 
            this.btn_DepPosEdit.Location = new System.Drawing.Point(238, 78);
            this.btn_DepPosEdit.Name = "btn_DepPosEdit";
            this.btn_DepPosEdit.Size = new System.Drawing.Size(136, 23);
            this.btn_DepPosEdit.TabIndex = 57;
            this.btn_DepPosEdit.Text = "部門 / 職位編輯";
            this.btn_DepPosEdit.UseVisualStyleBackColor = true;
            this.btn_DepPosEdit.Click += new System.EventHandler(this.btn_DepPosEdit_Click);
            // 
            // cbox_Pos
            // 
            this.cbox_Pos.FormattingEnabled = true;
            this.cbox_Pos.Location = new System.Drawing.Point(182, 81);
            this.cbox_Pos.Name = "cbox_Pos";
            this.cbox_Pos.Size = new System.Drawing.Size(50, 20);
            this.cbox_Pos.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "職位：";
            // 
            // cbox_Dep
            // 
            this.cbox_Dep.FormattingEnabled = true;
            this.cbox_Dep.Location = new System.Drawing.Point(69, 81);
            this.cbox_Dep.Name = "cbox_Dep";
            this.cbox_Dep.Size = new System.Drawing.Size(50, 20);
            this.cbox_Dep.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "部門：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 9);
            this.dataGridView1.Location = new System.Drawing.Point(3, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 4);
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1335, 571);
            this.dataGridView1.TabIndex = 33;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(246, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(3, 113);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 31;
            this.btnSelect.Text = "查詢";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(165, 113);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(84, 113);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnSelect, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_CourseManager, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_pageNum, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_clearText, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_startpage, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_endpage, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1338, 726);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // lb_pageNum
            // 
            this.lb_pageNum.AutoSize = true;
            this.lb_pageNum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_pageNum.Location = new System.Drawing.Point(554, 127);
            this.lb_pageNum.Name = "lb_pageNum";
            this.lb_pageNum.Size = new System.Drawing.Size(32, 12);
            this.lb_pageNum.TabIndex = 37;
            this.lb_pageNum.TabStop = true;
            this.lb_pageNum.Text = "第 頁";
            // 
            // btn_clearText
            // 
            this.btn_clearText.Location = new System.Drawing.Point(408, 113);
            this.btn_clearText.Name = "btn_clearText";
            this.btn_clearText.Size = new System.Drawing.Size(75, 23);
            this.btn_clearText.TabIndex = 38;
            this.btn_clearText.Text = "清空條件";
            this.btn_clearText.UseVisualStyleBackColor = true;
            this.btn_clearText.Click += new System.EventHandler(this.btn_clearText_Click);
            // 
            // lb_startpage
            // 
            this.lb_startpage.AutoSize = true;
            this.lb_startpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_startpage.Location = new System.Drawing.Point(489, 110);
            this.lb_startpage.Name = "lb_startpage";
            this.lb_startpage.Size = new System.Drawing.Size(59, 29);
            this.lb_startpage.TabIndex = 35;
            this.lb_startpage.TabStop = true;
            this.lb_startpage.Text = "<<     20     ";
            this.lb_startpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_startpage_LinkClicked);
            // 
            // lb_endpage
            // 
            this.lb_endpage.AutoSize = true;
            this.lb_endpage.Location = new System.Drawing.Point(592, 110);
            this.lb_endpage.Name = "lb_endpage";
            this.lb_endpage.Size = new System.Drawing.Size(56, 12);
            this.lb_endpage.TabIndex = 36;
            this.lb_endpage.TabStop = true;
            this.lb_endpage.Text = "    20     >>";
            this.lb_endpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_endpage_LinkClicked);
            // 
            // frmEmployeeBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmEmployeeBook";
            this.Text = "--員工通訊錄--";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployeeBook_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CourseManager;
        private System.Windows.Forms.ComboBox cbox_Onjob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_PhoneNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TwName;
        private System.Windows.Forms.TextBox txt_EnName;
        private System.Windows.Forms.TextBox txt_Home;
        private System.Windows.Forms.TextBox txt_CardNumber;
        private System.Windows.Forms.TextBox txt_EmployeeID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbox_Pos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_Dep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel lb_startpage;
        private System.Windows.Forms.LinkLabel lb_endpage;
        private System.Windows.Forms.LinkLabel lb_pageNum;
        private System.Windows.Forms.Button btn_clearText;
        private System.Windows.Forms.Button btn_DepPosEdit;
    }
}