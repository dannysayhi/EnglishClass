namespace EnglishClassManager.Rollcall.EmployeeRollcall
{
    partial class frmEmployeeRollcall
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollcallDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollCallState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollcallStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollcallEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollCallLate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollCallEarly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollcallHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollCallManul = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RollCallVaction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckb_WorkEnd = new System.Windows.Forms.CheckBox();
            this.ckb_WorkStart = new System.Windows.Forms.CheckBox();
            this.btn_Leave = new System.Windows.Forms.Button();
            this.btn_OFF = new System.Windows.Forms.Button();
            this.btn_ON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_EmployeeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_EmployeeID = new System.Windows.Forms.TextBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_ClassID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.ClassID,
            this.TwName,
            this.Dept,
            this.Position,
            this.RollcallDate,
            this.RollCallState,
            this.ClassStart,
            this.ClassEnd,
            this.RollcallStart,
            this.RollcallEnd,
            this.RollCallLate,
            this.RollCallEarly,
            this.RollcallHR,
            this.RollCallManul,
            this.RollCallVaction});
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 547);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EmployeeID
            // 
            this.EmployeeID.HeaderText = "員工編號";
            this.EmployeeID.Name = "EmployeeID";
            // 
            // ClassID
            // 
            this.ClassID.HeaderText = "班別";
            this.ClassID.Name = "ClassID";
            this.ClassID.Width = 50;
            // 
            // TwName
            // 
            this.TwName.HeaderText = "員工姓名";
            this.TwName.Name = "TwName";
            // 
            // Dept
            // 
            this.Dept.HeaderText = "部門";
            this.Dept.Name = "Dept";
            this.Dept.Width = 50;
            // 
            // Position
            // 
            this.Position.HeaderText = "職稱";
            this.Position.Name = "Position";
            this.Position.Width = 50;
            // 
            // RollcallDate
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            this.RollcallDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.RollcallDate.HeaderText = "刷卡日期";
            this.RollcallDate.Name = "RollcallDate";
            // 
            // RollCallState
            // 
            this.RollCallState.HeaderText = "狀態";
            this.RollCallState.Name = "RollCallState";
            this.RollCallState.Width = 70;
            // 
            // ClassStart
            // 
            this.ClassStart.HeaderText = "上班時間";
            this.ClassStart.Name = "ClassStart";
            this.ClassStart.Width = 80;
            // 
            // ClassEnd
            // 
            this.ClassEnd.HeaderText = "下班時間";
            this.ClassEnd.Name = "ClassEnd";
            this.ClassEnd.Width = 80;
            // 
            // RollcallStart
            // 
            this.RollcallStart.HeaderText = "刷卡上班時間";
            this.RollcallStart.Name = "RollcallStart";
            this.RollcallStart.Width = 80;
            // 
            // RollcallEnd
            // 
            this.RollcallEnd.HeaderText = "刷卡下班時間";
            this.RollcallEnd.Name = "RollcallEnd";
            this.RollcallEnd.Width = 80;
            // 
            // RollCallLate
            // 
            this.RollCallLate.HeaderText = "遲到";
            this.RollCallLate.Name = "RollCallLate";
            // 
            // RollCallEarly
            // 
            this.RollCallEarly.HeaderText = "早退";
            this.RollCallEarly.Name = "RollCallEarly";
            // 
            // RollcallHR
            // 
            this.RollcallHR.HeaderText = "工作時數";
            this.RollcallHR.Name = "RollcallHR";
            this.RollcallHR.Visible = false;
            this.RollcallHR.Width = 80;
            // 
            // RollCallManul
            // 
            this.RollCallManul.HeaderText = "當日補登";
            this.RollCallManul.Name = "RollCallManul";
            this.RollCallManul.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RollCallManul.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RollCallManul.Text = "當日補登";
            this.RollCallManul.UseColumnTextForButtonValue = true;
            this.RollCallManul.Width = 80;
            // 
            // RollCallVaction
            // 
            this.RollCallVaction.HeaderText = "當日請假";
            this.RollCallVaction.Name = "RollCallVaction";
            this.RollCallVaction.Text = "當日請假";
            this.RollCallVaction.UseColumnTextForButtonValue = true;
            this.RollCallVaction.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckb_WorkEnd);
            this.groupBox2.Controls.Add(this.ckb_WorkStart);
            this.groupBox2.Controls.Add(this.btn_Leave);
            this.groupBox2.Controls.Add(this.btn_OFF);
            this.groupBox2.Controls.Add(this.btn_ON);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_EmployeeName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_EmployeeID);
            this.groupBox2.Controls.Add(this.btn_Select);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbox_ClassID);
            this.groupBox2.Location = new System.Drawing.Point(12, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(733, 83);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "班別查詢";
            // 
            // ckb_WorkEnd
            // 
            this.ckb_WorkEnd.AutoSize = true;
            this.ckb_WorkEnd.Location = new System.Drawing.Point(396, 57);
            this.ckb_WorkEnd.Name = "ckb_WorkEnd";
            this.ckb_WorkEnd.Size = new System.Drawing.Size(48, 16);
            this.ckb_WorkEnd.TabIndex = 39;
            this.ckb_WorkEnd.Text = "下班";
            this.ckb_WorkEnd.UseVisualStyleBackColor = true;
            this.ckb_WorkEnd.Click += new System.EventHandler(this.ckb_WorkEnd_Click);
            // 
            // ckb_WorkStart
            // 
            this.ckb_WorkStart.AutoSize = true;
            this.ckb_WorkStart.Checked = true;
            this.ckb_WorkStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_WorkStart.Location = new System.Drawing.Point(332, 57);
            this.ckb_WorkStart.Name = "ckb_WorkStart";
            this.ckb_WorkStart.Size = new System.Drawing.Size(48, 16);
            this.ckb_WorkStart.TabIndex = 38;
            this.ckb_WorkStart.Text = "上班";
            this.ckb_WorkStart.UseVisualStyleBackColor = true;
            this.ckb_WorkStart.Click += new System.EventHandler(this.ckb_WorkStart_Click);
            // 
            // btn_Leave
            // 
            this.btn_Leave.Location = new System.Drawing.Point(251, 50);
            this.btn_Leave.Name = "btn_Leave";
            this.btn_Leave.Size = new System.Drawing.Size(75, 23);
            this.btn_Leave.TabIndex = 37;
            this.btn_Leave.Text = "請假";
            this.btn_Leave.UseVisualStyleBackColor = true;
            this.btn_Leave.Click += new System.EventHandler(this.btn_Leave_Click);
            // 
            // btn_OFF
            // 
            this.btn_OFF.Location = new System.Drawing.Point(170, 50);
            this.btn_OFF.Name = "btn_OFF";
            this.btn_OFF.Size = new System.Drawing.Size(75, 23);
            this.btn_OFF.TabIndex = 36;
            this.btn_OFF.Text = "未到";
            this.btn_OFF.UseVisualStyleBackColor = true;
            this.btn_OFF.Click += new System.EventHandler(this.btn_OFF_Click);
            // 
            // btn_ON
            // 
            this.btn_ON.Location = new System.Drawing.Point(89, 50);
            this.btn_ON.Name = "btn_ON";
            this.btn_ON.Size = new System.Drawing.Size(75, 23);
            this.btn_ON.TabIndex = 35;
            this.btn_ON.Text = "點名";
            this.btn_ON.UseVisualStyleBackColor = true;
            this.btn_ON.Click += new System.EventHandler(this.btn_ON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "員工編號：";
            // 
            // txt_EmployeeName
            // 
            this.txt_EmployeeName.Location = new System.Drawing.Point(479, 22);
            this.txt_EmployeeName.Name = "txt_EmployeeName";
            this.txt_EmployeeName.Size = new System.Drawing.Size(112, 22);
            this.txt_EmployeeName.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "員工姓名：";
            // 
            // txt_EmployeeID
            // 
            this.txt_EmployeeID.Location = new System.Drawing.Point(279, 22);
            this.txt_EmployeeID.Name = "txt_EmployeeID";
            this.txt_EmployeeID.Size = new System.Drawing.Size(112, 22);
            this.txt_EmployeeID.TabIndex = 31;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(8, 50);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.Text = "查詢";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "班別：";
            // 
            // cbox_ClassID
            // 
            this.cbox_ClassID.FormattingEnabled = true;
            this.cbox_ClassID.Location = new System.Drawing.Point(62, 24);
            this.cbox_ClassID.Name = "cbox_ClassID";
            this.cbox_ClassID.Size = new System.Drawing.Size(140, 20);
            this.cbox_ClassID.TabIndex = 2;
            this.cbox_ClassID.SelectedIndexChanged += new System.EventHandler(this.cbox_ClassID_SelectedIndexChanged);
            // 
            // frmEmployeeRollcall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1354, 656);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmEmployeeRollcall";
            this.Text = "frmEmployeeRollcall";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployeeRollcall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Leave;
        private System.Windows.Forms.Button btn_OFF;
        private System.Windows.Forms.Button btn_ON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_EmployeeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_EmployeeID;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_ClassID;
        private System.Windows.Forms.CheckBox ckb_WorkStart;
        private System.Windows.Forms.CheckBox ckb_WorkEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollcallDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollCallState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollcallStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollcallEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollCallLate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollCallEarly;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollcallHR;
        private System.Windows.Forms.DataGridViewButtonColumn RollCallManul;
        private System.Windows.Forms.DataGridViewButtonColumn RollCallVaction;
    }
}