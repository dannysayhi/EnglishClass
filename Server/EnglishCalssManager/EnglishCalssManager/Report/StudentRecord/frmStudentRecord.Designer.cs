namespace EnglishCalssManager.Report.StudentRecord
{
    partial class frmStudentRecord
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_CourseName = new System.Windows.Forms.ComboBox();
            this.cbox_TwName = new System.Windows.Forms.ComboBox();
            this.lb_pageNum = new System.Windows.Forms.LinkLabel();
            this.lb_startpage = new System.Windows.Forms.LinkLabel();
            this.lb_endpage = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1018, 583);
            this.dataGridView1.TabIndex = 11;
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(565, 24);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 21;
            this.btn_Export.Text = "匯出Excel";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(474, 24);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "查詢";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "結束日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "起始日期";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(242, 24);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(20, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 39;
            this.label8.Text = "學生姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "班別：";
            // 
            // cbox_CourseName
            // 
            this.cbox_CourseName.FormattingEnabled = true;
            this.cbox_CourseName.Location = new System.Drawing.Point(242, 75);
            this.cbox_CourseName.Name = "cbox_CourseName";
            this.cbox_CourseName.Size = new System.Drawing.Size(200, 20);
            this.cbox_CourseName.TabIndex = 40;
            // 
            // cbox_TwName
            // 
            this.cbox_TwName.FormattingEnabled = true;
            this.cbox_TwName.Location = new System.Drawing.Point(20, 75);
            this.cbox_TwName.Name = "cbox_TwName";
            this.cbox_TwName.Size = new System.Drawing.Size(200, 20);
            this.cbox_TwName.TabIndex = 42;
            // 
            // lb_pageNum
            // 
            this.lb_pageNum.AutoSize = true;
            this.lb_pageNum.Location = new System.Drawing.Point(537, 83);
            this.lb_pageNum.Name = "lb_pageNum";
            this.lb_pageNum.Size = new System.Drawing.Size(32, 12);
            this.lb_pageNum.TabIndex = 45;
            this.lb_pageNum.TabStop = true;
            this.lb_pageNum.Text = "第 頁";
            // 
            // lb_startpage
            // 
            this.lb_startpage.AutoSize = true;
            this.lb_startpage.Location = new System.Drawing.Point(472, 83);
            this.lb_startpage.Name = "lb_startpage";
            this.lb_startpage.Size = new System.Drawing.Size(59, 12);
            this.lb_startpage.TabIndex = 43;
            this.lb_startpage.TabStop = true;
            this.lb_startpage.Text = "<<     20     ";
            this.lb_startpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_startpage_LinkClicked);
            // 
            // lb_endpage
            // 
            this.lb_endpage.AutoSize = true;
            this.lb_endpage.Location = new System.Drawing.Point(575, 83);
            this.lb_endpage.Name = "lb_endpage";
            this.lb_endpage.Size = new System.Drawing.Size(56, 12);
            this.lb_endpage.TabIndex = 44;
            this.lb_endpage.TabStop = true;
            this.lb_endpage.Text = "    20     >>";
            this.lb_endpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_endpage_LinkClicked);
            // 
            // frmStudentRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1060, 741);
            this.Controls.Add(this.lb_pageNum);
            this.Controls.Add(this.lb_startpage);
            this.Controls.Add(this.lb_endpage);
            this.Controls.Add(this.cbox_TwName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbox_CourseName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmStudentRecord";
            this.Text = "frmStudentRecord";
            this.Load += new System.EventHandler(this.frmStudentRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_CourseName;
        private System.Windows.Forms.ComboBox cbox_TwName;
        private System.Windows.Forms.LinkLabel lb_pageNum;
        private System.Windows.Forms.LinkLabel lb_startpage;
        private System.Windows.Forms.LinkLabel lb_endpage;
    }
}