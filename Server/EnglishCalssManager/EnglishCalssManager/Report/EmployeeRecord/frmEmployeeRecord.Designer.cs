namespace EnglishCalssManager.Report.EmployeeRecord
{
    partial class frmEmployeeRecord
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cbox_EmployeeName = new System.Windows.Forms.ComboBox();
            this.cbox_ClassID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Hsalary = new System.Windows.Forms.TextBox();
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
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollCallManul = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RollCallVaction = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(256, 34);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // cbox_EmployeeName
            // 
            this.cbox_EmployeeName.FormattingEnabled = true;
            this.cbox_EmployeeName.Location = new System.Drawing.Point(34, 87);
            this.cbox_EmployeeName.Name = "cbox_EmployeeName";
            this.cbox_EmployeeName.Size = new System.Drawing.Size(200, 20);
            this.cbox_EmployeeName.TabIndex = 2;
            // 
            // cbox_ClassID
            // 
            this.cbox_ClassID.FormattingEnabled = true;
            this.cbox_ClassID.Location = new System.Drawing.Point(256, 87);
            this.cbox_ClassID.Name = "cbox_ClassID";
            this.cbox_ClassID.Size = new System.Drawing.Size(84, 20);
            this.cbox_ClassID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "起始日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "結束日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "員工姓名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "班別：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(484, 32);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "查詢";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(484, 85);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 10;
            this.btn_Export.Text = "匯出Excel";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
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
            this.Salary,
            this.RollCallManul,
            this.RollCallVaction});
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 574);
            this.dataGridView1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "時薪：";
            // 
            // txt_Hsalary
            // 
            this.txt_Hsalary.Location = new System.Drawing.Point(355, 85);
            this.txt_Hsalary.Name = "txt_Hsalary";
            this.txt_Hsalary.Size = new System.Drawing.Size(100, 22);
            this.txt_Hsalary.TabIndex = 13;
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
            this.RollcallHR.Width = 80;
            // 
            // Salary
            // 
            this.Salary.HeaderText = "薪資";
            this.Salary.Name = "Salary";
            this.Salary.Width = 70;
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
            // frmEmployeeRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1354, 723);
            this.Controls.Add(this.txt_Hsalary);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_ClassID);
            this.Controls.Add(this.cbox_EmployeeName);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "frmEmployeeRecord";
            this.Text = "frmEmployeeRecord";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployeeRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cbox_EmployeeName;
        private System.Windows.Forms.ComboBox cbox_ClassID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Hsalary;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewButtonColumn RollCallManul;
        private System.Windows.Forms.DataGridViewButtonColumn RollCallVaction;
    }
}