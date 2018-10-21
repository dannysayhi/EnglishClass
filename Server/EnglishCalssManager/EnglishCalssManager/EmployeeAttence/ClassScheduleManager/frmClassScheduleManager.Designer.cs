namespace EnglishClassManager.EmployeeAttence.ClassScheduleManager
{
    partial class frmClassScheduleManager
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
        public void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbox_Year = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_Month = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_classID = new System.Windows.Forms.ComboBox();
            this.btn_setDay = new System.Windows.Forms.Button();
            this.set_Month = new System.Windows.Forms.Button();
            this.employeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeID,
            this.employeeName,
            this.D01,
            this.D02,
            this.D03,
            this.D04,
            this.D05,
            this.D06,
            this.D07,
            this.D08,
            this.D09,
            this.D10,
            this.D11,
            this.D12,
            this.D13,
            this.D14,
            this.D15,
            this.D16,
            this.D17,
            this.D18,
            this.D19,
            this.D20,
            this.D21,
            this.D22,
            this.D23,
            this.D24,
            this.D25,
            this.D26,
            this.D27,
            this.D28,
            this.D29,
            this.D30,
            this.D31});
            this.dataGridView1.Location = new System.Drawing.Point(5, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1356, 421);
            this.dataGridView1.TabIndex = 0;
            // 
            // cbox_Year
            // 
            this.cbox_Year.FormattingEnabled = true;
            this.cbox_Year.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cbox_Year.Location = new System.Drawing.Point(132, 10);
            this.cbox_Year.Name = "cbox_Year";
            this.cbox_Year.Size = new System.Drawing.Size(60, 20);
            this.cbox_Year.TabIndex = 2;
            this.cbox_Year.SelectedValueChanged += new System.EventHandler(this.cbox_Year_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "查詢年月：";
            // 
            // cbox_Month
            // 
            this.cbox_Month.FormattingEnabled = true;
            this.cbox_Month.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbox_Month.Location = new System.Drawing.Point(198, 10);
            this.cbox_Month.Name = "cbox_Month";
            this.cbox_Month.Size = new System.Drawing.Size(63, 20);
            this.cbox_Month.TabIndex = 4;
            this.cbox_Month.SelectedValueChanged += new System.EventHandler(this.cbox_Month_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "班別：";
            // 
            // cbox_classID
            // 
            this.cbox_classID.FormattingEnabled = true;
            this.cbox_classID.Location = new System.Drawing.Point(80, 41);
            this.cbox_classID.Name = "cbox_classID";
            this.cbox_classID.Size = new System.Drawing.Size(60, 20);
            this.cbox_classID.TabIndex = 6;
            // 
            // btn_setDay
            // 
            this.btn_setDay.Location = new System.Drawing.Point(146, 39);
            this.btn_setDay.Name = "btn_setDay";
            this.btn_setDay.Size = new System.Drawing.Size(75, 23);
            this.btn_setDay.TabIndex = 7;
            this.btn_setDay.Text = "套用當日";
            this.btn_setDay.UseVisualStyleBackColor = true;
            this.btn_setDay.Click += new System.EventHandler(this.btn_setDay_Click);
            // 
            // set_Month
            // 
            this.set_Month.Location = new System.Drawing.Point(227, 38);
            this.set_Month.Name = "set_Month";
            this.set_Month.Size = new System.Drawing.Size(75, 23);
            this.set_Month.TabIndex = 8;
            this.set_Month.Text = "套用當月";
            this.set_Month.UseVisualStyleBackColor = true;
            this.set_Month.Click += new System.EventHandler(this.set_Month_Click);
            // 
            // employeeID
            // 
            this.employeeID.HeaderText = "員工編號";
            this.employeeID.Name = "employeeID";
            this.employeeID.Width = 80;
            // 
            // employeeName
            // 
            this.employeeName.HeaderText = "員工姓名";
            this.employeeName.Name = "employeeName";
            this.employeeName.Width = 80;
            // 
            // D01
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.NullValue = null;
            this.D01.DefaultCellStyle = dataGridViewCellStyle1;
            this.D01.HeaderText = "1";
            this.D01.Name = "D01";
            this.D01.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.D01.Width = 37;
            // 
            // D02
            // 
            this.D02.HeaderText = "2";
            this.D02.Name = "D02";
            this.D02.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.D02.Width = 37;
            // 
            // D03
            // 
            this.D03.HeaderText = "3";
            this.D03.Name = "D03";
            this.D03.Width = 37;
            // 
            // D04
            // 
            this.D04.HeaderText = "4";
            this.D04.Name = "D04";
            this.D04.Width = 37;
            // 
            // D05
            // 
            this.D05.HeaderText = "5";
            this.D05.Name = "D05";
            this.D05.Width = 37;
            // 
            // D06
            // 
            this.D06.HeaderText = "6";
            this.D06.Name = "D06";
            this.D06.Width = 37;
            // 
            // D07
            // 
            this.D07.HeaderText = "7";
            this.D07.Name = "D07";
            this.D07.Width = 37;
            // 
            // D08
            // 
            this.D08.HeaderText = "8";
            this.D08.Name = "D08";
            this.D08.Width = 37;
            // 
            // D09
            // 
            this.D09.HeaderText = "9";
            this.D09.Name = "D09";
            this.D09.Width = 37;
            // 
            // D10
            // 
            this.D10.HeaderText = "10";
            this.D10.Name = "D10";
            this.D10.Width = 37;
            // 
            // D11
            // 
            this.D11.HeaderText = "11";
            this.D11.Name = "D11";
            this.D11.Width = 37;
            // 
            // D12
            // 
            this.D12.HeaderText = "12";
            this.D12.Name = "D12";
            this.D12.Width = 37;
            // 
            // D13
            // 
            this.D13.HeaderText = "13";
            this.D13.Name = "D13";
            this.D13.Width = 37;
            // 
            // D14
            // 
            this.D14.HeaderText = "14";
            this.D14.Name = "D14";
            this.D14.Width = 37;
            // 
            // D15
            // 
            this.D15.HeaderText = "15";
            this.D15.Name = "D15";
            this.D15.Width = 37;
            // 
            // D16
            // 
            this.D16.HeaderText = "16";
            this.D16.Name = "D16";
            this.D16.Width = 37;
            // 
            // D17
            // 
            this.D17.HeaderText = "17";
            this.D17.Name = "D17";
            this.D17.Width = 37;
            // 
            // D18
            // 
            this.D18.HeaderText = "18";
            this.D18.Name = "D18";
            this.D18.Width = 37;
            // 
            // D19
            // 
            this.D19.HeaderText = "19";
            this.D19.Name = "D19";
            this.D19.Width = 37;
            // 
            // D20
            // 
            this.D20.HeaderText = "20";
            this.D20.Name = "D20";
            this.D20.Width = 37;
            // 
            // D21
            // 
            this.D21.HeaderText = "21";
            this.D21.Name = "D21";
            this.D21.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.D21.Width = 37;
            // 
            // D22
            // 
            this.D22.HeaderText = "22";
            this.D22.Name = "D22";
            this.D22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.D22.Width = 37;
            // 
            // D23
            // 
            this.D23.HeaderText = "23";
            this.D23.Name = "D23";
            this.D23.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.D23.Width = 37;
            // 
            // D24
            // 
            this.D24.HeaderText = "24";
            this.D24.Name = "D24";
            this.D24.Width = 37;
            // 
            // D25
            // 
            this.D25.HeaderText = "25";
            this.D25.Name = "D25";
            this.D25.Width = 37;
            // 
            // D26
            // 
            this.D26.HeaderText = "26";
            this.D26.Name = "D26";
            this.D26.Width = 37;
            // 
            // D27
            // 
            this.D27.HeaderText = "27";
            this.D27.Name = "D27";
            this.D27.Width = 37;
            // 
            // D28
            // 
            this.D28.HeaderText = "28";
            this.D28.Name = "D28";
            this.D28.Width = 37;
            // 
            // D29
            // 
            this.D29.HeaderText = "29";
            this.D29.Name = "D29";
            this.D29.Width = 37;
            // 
            // D30
            // 
            this.D30.HeaderText = "30";
            this.D30.Name = "D30";
            this.D30.Width = 37;
            // 
            // D31
            // 
            this.D31.HeaderText = "31";
            this.D31.Name = "D31";
            this.D31.Width = 37;
            // 
            // frmClassScheduleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 544);
            this.Controls.Add(this.set_Month);
            this.Controls.Add(this.btn_setDay);
            this.Controls.Add(this.cbox_classID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbox_Month);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_Year);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmClassScheduleManager";
            this.Text = "frmClassScheduleManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClassScheduleManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbox_Year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_Month;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_classID;
        private System.Windows.Forms.Button btn_setDay;
        private System.Windows.Forms.Button set_Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn D01;
        private System.Windows.Forms.DataGridViewTextBoxColumn D02;
        private System.Windows.Forms.DataGridViewTextBoxColumn D03;
        private System.Windows.Forms.DataGridViewTextBoxColumn D04;
        private System.Windows.Forms.DataGridViewTextBoxColumn D05;
        private System.Windows.Forms.DataGridViewTextBoxColumn D06;
        private System.Windows.Forms.DataGridViewTextBoxColumn D07;
        private System.Windows.Forms.DataGridViewTextBoxColumn D08;
        private System.Windows.Forms.DataGridViewTextBoxColumn D09;
        private System.Windows.Forms.DataGridViewTextBoxColumn D10;
        private System.Windows.Forms.DataGridViewTextBoxColumn D11;
        private System.Windows.Forms.DataGridViewTextBoxColumn D12;
        private System.Windows.Forms.DataGridViewTextBoxColumn D13;
        private System.Windows.Forms.DataGridViewTextBoxColumn D14;
        private System.Windows.Forms.DataGridViewTextBoxColumn D15;
        private System.Windows.Forms.DataGridViewTextBoxColumn D16;
        private System.Windows.Forms.DataGridViewTextBoxColumn D17;
        private System.Windows.Forms.DataGridViewTextBoxColumn D18;
        private System.Windows.Forms.DataGridViewTextBoxColumn D19;
        private System.Windows.Forms.DataGridViewTextBoxColumn D20;
        private System.Windows.Forms.DataGridViewTextBoxColumn D21;
        private System.Windows.Forms.DataGridViewTextBoxColumn D22;
        private System.Windows.Forms.DataGridViewTextBoxColumn D23;
        private System.Windows.Forms.DataGridViewTextBoxColumn D24;
        private System.Windows.Forms.DataGridViewTextBoxColumn D25;
        private System.Windows.Forms.DataGridViewTextBoxColumn D26;
        private System.Windows.Forms.DataGridViewTextBoxColumn D27;
        private System.Windows.Forms.DataGridViewTextBoxColumn D28;
        private System.Windows.Forms.DataGridViewTextBoxColumn D29;
        private System.Windows.Forms.DataGridViewTextBoxColumn D30;
        private System.Windows.Forms.DataGridViewTextBoxColumn D31;
    }
}