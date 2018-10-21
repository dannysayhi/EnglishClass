namespace EnglishClassManager.SystemManager.CourseManagement
{
    partial class frmCourseManagerUpdate
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_CourseName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_DeleteStudent = new System.Windows.Forms.Button();
            this.btn_AddNewStudent = new System.Windows.Forms.Button();
            this.btn_SelectAllStudent = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TwName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_EmplyName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_NewCourseName = new System.Windows.Forms.TextBox();
            this.btn_AddCourse = new System.Windows.Forms.Button();
            this.cbox_NewEmplyName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lb_pageNum = new System.Windows.Forms.LinkLabel();
            this.lb_startpage = new System.Windows.Forms.LinkLabel();
            this.lb_endpage = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(189, 50);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "儲存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "管理者：";
            // 
            // cbox_CourseName
            // 
            this.cbox_CourseName.FormattingEnabled = true;
            this.cbox_CourseName.Location = new System.Drawing.Point(62, 24);
            this.cbox_CourseName.Name = "cbox_CourseName";
            this.cbox_CourseName.Size = new System.Drawing.Size(202, 20);
            this.cbox_CourseName.TabIndex = 2;
            this.cbox_CourseName.SelectedIndexChanged += new System.EventHandler(this.cbox_EmployeeID_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_DeleteStudent);
            this.groupBox1.Controls.Add(this.btn_AddNewStudent);
            this.groupBox1.Controls.Add(this.btn_SelectAllStudent);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_TwName);
            this.groupBox1.Location = new System.Drawing.Point(24, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 43);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜尋條件";
            // 
            // btn_DeleteStudent
            // 
            this.btn_DeleteStudent.Location = new System.Drawing.Point(465, 12);
            this.btn_DeleteStudent.Name = "btn_DeleteStudent";
            this.btn_DeleteStudent.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteStudent.TabIndex = 34;
            this.btn_DeleteStudent.Text = "移除學生";
            this.btn_DeleteStudent.UseVisualStyleBackColor = true;
            this.btn_DeleteStudent.Click += new System.EventHandler(this.btn_DeleteStudent_Click);
            // 
            // btn_AddNewStudent
            // 
            this.btn_AddNewStudent.Location = new System.Drawing.Point(378, 12);
            this.btn_AddNewStudent.Name = "btn_AddNewStudent";
            this.btn_AddNewStudent.Size = new System.Drawing.Size(75, 23);
            this.btn_AddNewStudent.TabIndex = 33;
            this.btn_AddNewStudent.Text = "新增學生";
            this.btn_AddNewStudent.UseVisualStyleBackColor = true;
            this.btn_AddNewStudent.Click += new System.EventHandler(this.btn_AddNewStudent_Click);
            // 
            // btn_SelectAllStudent
            // 
            this.btn_SelectAllStudent.Location = new System.Drawing.Point(297, 13);
            this.btn_SelectAllStudent.Name = "btn_SelectAllStudent";
            this.btn_SelectAllStudent.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectAllStudent.TabIndex = 32;
            this.btn_SelectAllStudent.Text = "搜尋全部學生";
            this.btn_SelectAllStudent.UseVisualStyleBackColor = true;
            this.btn_SelectAllStudent.Click += new System.EventHandler(this.btn_SelectAllStudent_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(208, 12);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 31;
            this.btn_Select.Text = "搜尋";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "學生姓名：";
            // 
            // txt_TwName
            // 
            this.txt_TwName.Location = new System.Drawing.Point(71, 13);
            this.txt_TwName.Name = "txt_TwName";
            this.txt_TwName.Size = new System.Drawing.Size(112, 22);
            this.txt_TwName.TabIndex = 29;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(595, 174);
            this.dataGridView1.TabIndex = 4;
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
            // cbox_EmplyName
            // 
            this.cbox_EmplyName.FormattingEnabled = true;
            this.cbox_EmplyName.Location = new System.Drawing.Point(62, 53);
            this.cbox_EmplyName.Name = "cbox_EmplyName";
            this.cbox_EmplyName.Size = new System.Drawing.Size(121, 20);
            this.cbox_EmplyName.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Save);
            this.groupBox2.Controls.Add(this.cbox_EmplyName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbox_CourseName);
            this.groupBox2.Location = new System.Drawing.Point(24, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 76);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "群組修改";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_NewCourseName);
            this.groupBox3.Controls.Add(this.btn_AddCourse);
            this.groupBox3.Controls.Add(this.cbox_NewEmplyName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(300, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 76);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "群組新增";
            // 
            // txt_NewCourseName
            // 
            this.txt_NewCourseName.Location = new System.Drawing.Point(62, 24);
            this.txt_NewCourseName.Name = "txt_NewCourseName";
            this.txt_NewCourseName.Size = new System.Drawing.Size(202, 22);
            this.txt_NewCourseName.TabIndex = 7;
            // 
            // btn_AddCourse
            // 
            this.btn_AddCourse.Location = new System.Drawing.Point(189, 50);
            this.btn_AddCourse.Name = "btn_AddCourse";
            this.btn_AddCourse.Size = new System.Drawing.Size(75, 23);
            this.btn_AddCourse.TabIndex = 0;
            this.btn_AddCourse.Text = "儲存";
            this.btn_AddCourse.UseVisualStyleBackColor = true;
            this.btn_AddCourse.Click += new System.EventHandler(this.btn_AddCourse_Click);
            // 
            // cbox_NewEmplyName
            // 
            this.cbox_NewEmplyName.FormattingEnabled = true;
            this.cbox_NewEmplyName.Location = new System.Drawing.Point(62, 53);
            this.cbox_NewEmplyName.Name = "cbox_NewEmplyName";
            this.cbox_NewEmplyName.Size = new System.Drawing.Size(121, 20);
            this.cbox_NewEmplyName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "班別：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "管理者：";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(624, 141);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(487, 174);
            this.dataGridView2.TabIndex = 9;
            // 
            // lb_pageNum
            // 
            this.lb_pageNum.AutoSize = true;
            this.lb_pageNum.Location = new System.Drawing.Point(824, 126);
            this.lb_pageNum.Name = "lb_pageNum";
            this.lb_pageNum.Size = new System.Drawing.Size(32, 12);
            this.lb_pageNum.TabIndex = 43;
            this.lb_pageNum.TabStop = true;
            this.lb_pageNum.Text = "第 頁";
            // 
            // lb_startpage
            // 
            this.lb_startpage.AutoSize = true;
            this.lb_startpage.Location = new System.Drawing.Point(759, 126);
            this.lb_startpage.Name = "lb_startpage";
            this.lb_startpage.Size = new System.Drawing.Size(59, 12);
            this.lb_startpage.TabIndex = 41;
            this.lb_startpage.TabStop = true;
            this.lb_startpage.Text = "<<     20     ";
            this.lb_startpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_startpage_LinkClicked);
            // 
            // lb_endpage
            // 
            this.lb_endpage.AutoSize = true;
            this.lb_endpage.Location = new System.Drawing.Point(862, 126);
            this.lb_endpage.Name = "lb_endpage";
            this.lb_endpage.Size = new System.Drawing.Size(56, 12);
            this.lb_endpage.TabIndex = 42;
            this.lb_endpage.TabStop = true;
            this.lb_endpage.Text = "    20     >>";
            this.lb_endpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_endpage_LinkClicked);
            // 
            // frmCourseManagerUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1121, 344);
            this.Controls.Add(this.lb_pageNum);
            this.Controls.Add(this.lb_startpage);
            this.Controls.Add(this.lb_endpage);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCourseManagerUpdate";
            this.Text = "frmCourseManagerUpdate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCourseManagerUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_CourseName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TwName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_EmplyName;
        private System.Windows.Forms.Button btn_SelectAllStudent;
        private System.Windows.Forms.Button btn_AddNewStudent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_NewCourseName;
        private System.Windows.Forms.Button btn_AddCourse;
        private System.Windows.Forms.ComboBox cbox_NewEmplyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_DeleteStudent;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.LinkLabel lb_pageNum;
        private System.Windows.Forms.LinkLabel lb_startpage;
        private System.Windows.Forms.LinkLabel lb_endpage;
    }
}