namespace EnglishClassManager.SystemManager.MemberList.StudentBook
{
    partial class frmStudentBook
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_CHECKIDENT = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbox_Onschool = new System.Windows.Forms.ComboBox();
            this.cbox_Senior = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_School = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_PhoneNumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_Parents3PhoneNumber = new System.Windows.Forms.TextBox();
            this.txt_Parents3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_Parents2PhoneNumber = new System.Windows.Forms.TextBox();
            this.txt_Parents2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TwName = new System.Windows.Forms.TextBox();
            this.txt_EnName = new System.Windows.Forms.TextBox();
            this.txt_Home = new System.Windows.Forms.TextBox();
            this.txt_Parents1PhoneNumber = new System.Windows.Forms.TextBox();
            this.txt_CardNumber = new System.Windows.Forms.TextBox();
            this.txt_Parents1 = new System.Windows.Forms.TextBox();
            this.txt_StudentID = new System.Windows.Forms.TextBox();
            this.btn_ReadCard = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_clearText = new System.Windows.Forms.Button();
            this.lb_endpage = new System.Windows.Forms.LinkLabel();
            this.lb_pageNum = new System.Windows.Forms.LinkLabel();
            this.lb_startpage = new System.Windows.Forms.LinkLabel();
            this.btn_PwdRegist = new System.Windows.Forms.Button();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Home = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.School = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Senior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnSchool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parents1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parents1PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parents2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parents2PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parents3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parents3PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(84, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(165, 116);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(246, 116);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(3, 116);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "查詢";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.CardNumber,
            this.TwName,
            this.EnName,
            this.Home,
            this.PhoneNumber,
            this.School,
            this.Senior,
            this.OnSchool,
            this.Parents1,
            this.Parents1PhoneNumber,
            this.Parents2,
            this.Parents2PhoneNumber,
            this.Parents3,
            this.Parents3PhoneNumber});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 11);
            this.dataGridView1.Location = new System.Drawing.Point(3, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 5);
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1345, 540);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 11);
            this.groupBox2.Controls.Add(this.txt_CHECKIDENT);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cbox_Onschool);
            this.groupBox2.Controls.Add(this.cbox_Senior);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_School);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txt_PhoneNumber);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txt_Parents3PhoneNumber);
            this.groupBox2.Controls.Add(this.txt_Parents3);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txt_Parents2PhoneNumber);
            this.groupBox2.Controls.Add(this.txt_Parents2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_TwName);
            this.groupBox2.Controls.Add(this.txt_EnName);
            this.groupBox2.Controls.Add(this.txt_Home);
            this.groupBox2.Controls.Add(this.txt_Parents1PhoneNumber);
            this.groupBox2.Controls.Add(this.txt_CardNumber);
            this.groupBox2.Controls.Add(this.txt_Parents1);
            this.groupBox2.Controls.Add(this.txt_StudentID);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1330, 107);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "學生資料";
            // 
            // txt_CHECKIDENT
            // 
            this.txt_CHECKIDENT.Location = new System.Drawing.Point(1152, 79);
            this.txt_CHECKIDENT.Name = "txt_CHECKIDENT";
            this.txt_CHECKIDENT.Size = new System.Drawing.Size(55, 22);
            this.txt_CHECKIDENT.TabIndex = 54;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1213, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 53;
            this.button1.Text = "btn_CHECKIDENT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbox_Onschool
            // 
            this.cbox_Onschool.FormattingEnabled = true;
            this.cbox_Onschool.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbox_Onschool.Location = new System.Drawing.Point(1188, 42);
            this.cbox_Onschool.Name = "cbox_Onschool";
            this.cbox_Onschool.Size = new System.Drawing.Size(61, 20);
            this.cbox_Onschool.TabIndex = 52;
            // 
            // cbox_Senior
            // 
            this.cbox_Senior.FormattingEnabled = true;
            this.cbox_Senior.Items.AddRange(new object[] {
            "一",
            "二",
            "三",
            "四",
            "五",
            "六",
            "國一",
            "國二",
            "國三",
            "高一",
            "高二",
            "高三"});
            this.cbox_Senior.Location = new System.Drawing.Point(1188, 15);
            this.cbox_Senior.Name = "cbox_Senior";
            this.cbox_Senior.Size = new System.Drawing.Size(61, 20);
            this.cbox_Senior.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1150, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "在學：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1150, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 49;
            this.label2.Text = "年級：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(964, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "學校：";
            // 
            // txt_School
            // 
            this.txt_School.Location = new System.Drawing.Point(1009, 15);
            this.txt_School.Name = "txt_School";
            this.txt_School.Size = new System.Drawing.Size(135, 22);
            this.txt_School.TabIndex = 46;
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(924, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 12);
            this.label15.TabIndex = 43;
            this.label15.Text = "家長電話(3)：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(747, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 12);
            this.label16.TabIndex = 42;
            this.label16.Text = "家長(3)：";
            // 
            // txt_Parents3PhoneNumber
            // 
            this.txt_Parents3PhoneNumber.Location = new System.Drawing.Point(1007, 47);
            this.txt_Parents3PhoneNumber.Name = "txt_Parents3PhoneNumber";
            this.txt_Parents3PhoneNumber.Size = new System.Drawing.Size(112, 22);
            this.txt_Parents3PhoneNumber.TabIndex = 41;
            // 
            // txt_Parents3
            // 
            this.txt_Parents3.Location = new System.Drawing.Point(803, 47);
            this.txt_Parents3.Name = "txt_Parents3";
            this.txt_Parents3.Size = new System.Drawing.Size(112, 22);
            this.txt_Parents3.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(553, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 12);
            this.label13.TabIndex = 39;
            this.label13.Text = "家長電話(2)：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(380, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 12);
            this.label14.TabIndex = 38;
            this.label14.Text = "家長(2)：";
            // 
            // txt_Parents2PhoneNumber
            // 
            this.txt_Parents2PhoneNumber.Location = new System.Drawing.Point(632, 49);
            this.txt_Parents2PhoneNumber.Name = "txt_Parents2PhoneNumber";
            this.txt_Parents2PhoneNumber.Size = new System.Drawing.Size(112, 22);
            this.txt_Parents2PhoneNumber.TabIndex = 37;
            // 
            // txt_Parents2
            // 
            this.txt_Parents2.Location = new System.Drawing.Point(437, 49);
            this.txt_Parents2.Name = "txt_Parents2";
            this.txt_Parents2.Size = new System.Drawing.Size(112, 22);
            this.txt_Parents2.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 12);
            this.label12.TabIndex = 35;
            this.label12.Text = "家長電話(1)：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 12);
            this.label11.TabIndex = 34;
            this.label11.Text = "家長(1)：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 83);
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
            this.label7.Location = new System.Drawing.Point(394, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "學號：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 21);
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
            this.label5.Text = "學生姓名：";
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
            this.txt_Home.Location = new System.Drawing.Point(69, 80);
            this.txt_Home.Name = "txt_Home";
            this.txt_Home.Size = new System.Drawing.Size(937, 22);
            this.txt_Home.TabIndex = 20;
            // 
            // txt_Parents1PhoneNumber
            // 
            this.txt_Parents1PhoneNumber.Location = new System.Drawing.Point(265, 49);
            this.txt_Parents1PhoneNumber.Name = "txt_Parents1PhoneNumber";
            this.txt_Parents1PhoneNumber.Size = new System.Drawing.Size(112, 22);
            this.txt_Parents1PhoneNumber.TabIndex = 25;
            // 
            // txt_CardNumber
            // 
            this.txt_CardNumber.Location = new System.Drawing.Point(266, 15);
            this.txt_CardNumber.Name = "txt_CardNumber";
            this.txt_CardNumber.Size = new System.Drawing.Size(112, 22);
            this.txt_CardNumber.TabIndex = 16;
            // 
            // txt_Parents1
            // 
            this.txt_Parents1.Location = new System.Drawing.Point(70, 49);
            this.txt_Parents1.Name = "txt_Parents1";
            this.txt_Parents1.Size = new System.Drawing.Size(112, 22);
            this.txt_Parents1.TabIndex = 24;
            // 
            // txt_StudentID
            // 
            this.txt_StudentID.Location = new System.Drawing.Point(436, 17);
            this.txt_StudentID.Name = "txt_StudentID";
            this.txt_StudentID.Size = new System.Drawing.Size(112, 22);
            this.txt_StudentID.TabIndex = 17;
            // 
            // btn_ReadCard
            // 
            this.btn_ReadCard.Location = new System.Drawing.Point(327, 116);
            this.btn_ReadCard.Name = "btn_ReadCard";
            this.btn_ReadCard.Size = new System.Drawing.Size(75, 23);
            this.btn_ReadCard.TabIndex = 29;
            this.btn_ReadCard.Text = "卡號讀取";
            this.btn_ReadCard.UseVisualStyleBackColor = true;
            this.btn_ReadCard.Click += new System.EventHandler(this.btn_ReadCard_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelect, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_clearText, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 9, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_ReadCard, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_endpage, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_pageNum, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_startpage, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_PwdRegist, 6, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1348, 721);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // btn_clearText
            // 
            this.btn_clearText.Location = new System.Drawing.Point(408, 116);
            this.btn_clearText.Name = "btn_clearText";
            this.btn_clearText.Size = new System.Drawing.Size(75, 23);
            this.btn_clearText.TabIndex = 41;
            this.btn_clearText.Text = "清空條件";
            this.btn_clearText.UseVisualStyleBackColor = true;
            this.btn_clearText.Click += new System.EventHandler(this.btn_clearText_Click);
            // 
            // lb_endpage
            // 
            this.lb_endpage.AutoSize = true;
            this.lb_endpage.Location = new System.Drawing.Point(673, 113);
            this.lb_endpage.Name = "lb_endpage";
            this.lb_endpage.Size = new System.Drawing.Size(56, 12);
            this.lb_endpage.TabIndex = 39;
            this.lb_endpage.TabStop = true;
            this.lb_endpage.Text = "    20     >>";
            this.lb_endpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_endpage_LinkClicked);
            // 
            // lb_pageNum
            // 
            this.lb_pageNum.AutoSize = true;
            this.lb_pageNum.Location = new System.Drawing.Point(635, 113);
            this.lb_pageNum.Name = "lb_pageNum";
            this.lb_pageNum.Size = new System.Drawing.Size(32, 12);
            this.lb_pageNum.TabIndex = 40;
            this.lb_pageNum.TabStop = true;
            this.lb_pageNum.Text = "第 頁";
            this.lb_pageNum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_pageNum_LinkClicked);
            // 
            // lb_startpage
            // 
            this.lb_startpage.AutoSize = true;
            this.lb_startpage.Location = new System.Drawing.Point(570, 113);
            this.lb_startpage.Name = "lb_startpage";
            this.lb_startpage.Size = new System.Drawing.Size(59, 12);
            this.lb_startpage.TabIndex = 38;
            this.lb_startpage.TabStop = true;
            this.lb_startpage.Text = "<<     20     ";
            this.lb_startpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_startpage_LinkClicked);
            // 
            // btn_PwdRegist
            // 
            this.btn_PwdRegist.Location = new System.Drawing.Point(489, 116);
            this.btn_PwdRegist.Name = "btn_PwdRegist";
            this.btn_PwdRegist.Size = new System.Drawing.Size(75, 23);
            this.btn_PwdRegist.TabIndex = 42;
            this.btn_PwdRegist.Text = "密碼註冊";
            this.btn_PwdRegist.UseVisualStyleBackColor = true;
            this.btn_PwdRegist.Click += new System.EventHandler(this.btn_PwdRegist_Click);
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "學生編號";
            this.StudentID.Name = "StudentID";
            // 
            // CardNumber
            // 
            this.CardNumber.HeaderText = "卡號";
            this.CardNumber.Name = "CardNumber";
            // 
            // TwName
            // 
            this.TwName.HeaderText = "姓名(中)";
            this.TwName.Name = "TwName";
            // 
            // EnName
            // 
            this.EnName.HeaderText = "姓名(En)";
            this.EnName.Name = "EnName";
            // 
            // Home
            // 
            this.Home.HeaderText = "住址";
            this.Home.Name = "Home";
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "電話號碼(帳號)";
            this.PhoneNumber.Name = "PhoneNumber";
            // 
            // School
            // 
            this.School.HeaderText = "學校";
            this.School.Name = "School";
            // 
            // Senior
            // 
            this.Senior.HeaderText = "年級";
            this.Senior.Name = "Senior";
            // 
            // OnSchool
            // 
            this.OnSchool.HeaderText = "在校";
            this.OnSchool.Name = "OnSchool";
            // 
            // Parents1
            // 
            this.Parents1.HeaderText = "家長(1)";
            this.Parents1.Name = "Parents1";
            // 
            // Parents1PhoneNumber
            // 
            this.Parents1PhoneNumber.HeaderText = "家長(1)電話";
            this.Parents1PhoneNumber.Name = "Parents1PhoneNumber";
            // 
            // Parents2
            // 
            this.Parents2.HeaderText = "家長(2)";
            this.Parents2.Name = "Parents2";
            // 
            // Parents2PhoneNumber
            // 
            this.Parents2PhoneNumber.HeaderText = "家長(2)電話";
            this.Parents2PhoneNumber.Name = "Parents2PhoneNumber";
            // 
            // Parents3
            // 
            this.Parents3.HeaderText = "家長(3)";
            this.Parents3.Name = "Parents3";
            // 
            // Parents3PhoneNumber
            // 
            this.Parents3PhoneNumber.HeaderText = "家長(3)電話";
            this.Parents3PhoneNumber.Name = "Parents3PhoneNumber";
            // 
            // frmStudentBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 708);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmStudentBook";
            this.Text = "--學生通訊錄--";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStudentBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_PhoneNumber;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_Parents3PhoneNumber;
        private System.Windows.Forms.TextBox txt_Parents3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_Parents2PhoneNumber;
        private System.Windows.Forms.TextBox txt_Parents2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TwName;
        private System.Windows.Forms.TextBox txt_EnName;
        private System.Windows.Forms.TextBox txt_Home;
        private System.Windows.Forms.TextBox txt_Parents1PhoneNumber;
        private System.Windows.Forms.TextBox txt_CardNumber;
        private System.Windows.Forms.TextBox txt_Parents1;
        private System.Windows.Forms.TextBox txt_StudentID;
        private System.Windows.Forms.ComboBox cbox_Onschool;
        private System.Windows.Forms.ComboBox cbox_Senior;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_School;
        private System.Windows.Forms.Button btn_ReadCard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel lb_pageNum;
        private System.Windows.Forms.LinkLabel lb_startpage;
        private System.Windows.Forms.LinkLabel lb_endpage;
        private System.Windows.Forms.Button btn_clearText;
        private System.Windows.Forms.TextBox txt_CHECKIDENT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_PwdRegist;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Home;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn School;
        private System.Windows.Forms.DataGridViewTextBoxColumn Senior;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnSchool;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parents1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parents1PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parents2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parents2PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parents3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parents3PhoneNumber;
    }
}