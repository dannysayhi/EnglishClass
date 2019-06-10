namespace EnglishClassManager.SystemManager.CourseManagement
{
    partial class frmCourseManagement
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
            this.cbox_CourseName = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeTwName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_CourseIntro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CourseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CourseName = new System.Windows.Forms.TextBox();
            this.btn_AddCourse = new System.Windows.Forms.Button();
            this.cbox_NewEmplyName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox_CourseName
            // 
            this.cbox_CourseName.FormattingEnabled = true;
            this.cbox_CourseName.Location = new System.Drawing.Point(89, 21);
            this.cbox_CourseName.Name = "cbox_CourseName";
            this.cbox_CourseName.Size = new System.Drawing.Size(170, 20);
            this.cbox_CourseName.TabIndex = 0;
            this.cbox_CourseName.SelectedIndexChanged += new System.EventHandler(this.cbox_CourseName_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseID,
            this.CourseName,
            this.StudentID,
            this.TwName,
            this.EmployeeID,
            this.EmployeeTwName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(892, 572);
            this.dataGridView1.TabIndex = 1;
            // 
            // CourseID
            // 
            this.CourseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CourseID.FillWeight = 10F;
            this.CourseID.HeaderText = "群組ID";
            this.CourseID.Name = "CourseID";
            // 
            // CourseName
            // 
            this.CourseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CourseName.FillWeight = 20F;
            this.CourseName.HeaderText = "群組名稱";
            this.CourseName.Name = "CourseName";
            // 
            // StudentID
            // 
            this.StudentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentID.FillWeight = 10F;
            this.StudentID.HeaderText = "學生ID";
            this.StudentID.Name = "StudentID";
            // 
            // TwName
            // 
            this.TwName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TwName.FillWeight = 25F;
            this.TwName.HeaderText = "學生姓名";
            this.TwName.Name = "TwName";
            // 
            // EmployeeID
            // 
            this.EmployeeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmployeeID.FillWeight = 10F;
            this.EmployeeID.HeaderText = "員工ID";
            this.EmployeeID.Name = "EmployeeID";
            // 
            // EmployeeTwName
            // 
            this.EmployeeTwName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmployeeTwName.FillWeight = 25F;
            this.EmployeeTwName.HeaderText = "員工姓名";
            this.EmployeeTwName.Name = "EmployeeTwName";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(102, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 34);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(38, 163);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 23);
            this.btnUpdate.TabIndex = 35;
            this.btnUpdate.Text = "學生群組修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 34);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "編輯";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(183, 57);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 34);
            this.btn_refresh.TabIndex = 38;
            this.btn_refresh.Text = "重新整理";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_CourseIntro);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txt_CourseID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txt_CourseName);
            this.groupBox3.Controls.Add(this.btn_AddCourse);
            this.groupBox3.Controls.Add(this.cbox_NewEmplyName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(275, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(629, 86);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "群組新增";
            // 
            // txt_CourseIntro
            // 
            this.txt_CourseIntro.Location = new System.Drawing.Point(250, 40);
            this.txt_CourseIntro.Multiline = true;
            this.txt_CourseIntro.Name = "txt_CourseIntro";
            this.txt_CourseIntro.Size = new System.Drawing.Size(292, 40);
            this.txt_CourseIntro.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "群組說明：";
            // 
            // txt_CourseID
            // 
            this.txt_CourseID.Location = new System.Drawing.Point(62, 14);
            this.txt_CourseID.Name = "txt_CourseID";
            this.txt_CourseID.Size = new System.Drawing.Size(117, 22);
            this.txt_CourseID.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "群組ID：";
            // 
            // txt_CourseName
            // 
            this.txt_CourseName.Location = new System.Drawing.Point(250, 14);
            this.txt_CourseName.Name = "txt_CourseName";
            this.txt_CourseName.Size = new System.Drawing.Size(292, 22);
            this.txt_CourseName.TabIndex = 7;
            // 
            // btn_AddCourse
            // 
            this.btn_AddCourse.Location = new System.Drawing.Point(548, 14);
            this.btn_AddCourse.Name = "btn_AddCourse";
            this.btn_AddCourse.Size = new System.Drawing.Size(75, 66);
            this.btn_AddCourse.TabIndex = 0;
            this.btn_AddCourse.Text = "儲存";
            this.btn_AddCourse.UseVisualStyleBackColor = true;
            this.btn_AddCourse.Click += new System.EventHandler(this.btn_AddCourse_Click);
            // 
            // cbox_NewEmplyName
            // 
            this.cbox_NewEmplyName.FormattingEnabled = true;
            this.cbox_NewEmplyName.Location = new System.Drawing.Point(62, 42);
            this.cbox_NewEmplyName.Name = "cbox_NewEmplyName";
            this.cbox_NewEmplyName.Size = new System.Drawing.Size(117, 20);
            this.cbox_NewEmplyName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "群組名稱：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "管理者：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "選擇群組：";
            // 
            // frmCourseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(925, 701);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbox_CourseName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCourseManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmCourseManagement";
            this.Load += new System.EventHandler(this.frmCourseManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_CourseName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeTwName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_CourseName;
        private System.Windows.Forms.Button btn_AddCourse;
        private System.Windows.Forms.ComboBox cbox_NewEmplyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_CourseIntro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CourseID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}