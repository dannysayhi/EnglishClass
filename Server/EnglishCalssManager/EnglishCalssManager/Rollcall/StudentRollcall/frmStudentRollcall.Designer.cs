namespace EnglishClassManager.Rollcall.StudentRollcall
{
    partial class frmStudentRollcall
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Leave = new System.Windows.Forms.Button();
            this.btn_OFF = new System.Windows.Forms.Button();
            this.btn_ON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_StudentID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TwName = new System.Windows.Forms.TextBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_CourseName = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Leave);
            this.groupBox2.Controls.Add(this.btn_OFF);
            this.groupBox2.Controls.Add(this.btn_ON);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_StudentID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_TwName);
            this.groupBox2.Controls.Add(this.btn_Select);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbox_CourseName);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 83);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "群組";
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
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "學號：";
            // 
            // txt_StudentID
            // 
            this.txt_StudentID.Location = new System.Drawing.Point(454, 22);
            this.txt_StudentID.Name = "txt_StudentID";
            this.txt_StudentID.Size = new System.Drawing.Size(112, 22);
            this.txt_StudentID.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "學生姓名：";
            // 
            // txt_TwName
            // 
            this.txt_TwName.Location = new System.Drawing.Point(279, 22);
            this.txt_TwName.Name = "txt_TwName";
            this.txt_TwName.Size = new System.Drawing.Size(112, 22);
            this.txt_TwName.TabIndex = 31;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(8, 50);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.Text = "查詢";
            this.btn_Select.UseVisualStyleBackColor = true;
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
            // cbox_CourseName
            // 
            this.cbox_CourseName.FormattingEnabled = true;
            this.cbox_CourseName.Location = new System.Drawing.Point(62, 24);
            this.cbox_CourseName.Name = "cbox_CourseName";
            this.cbox_CourseName.Size = new System.Drawing.Size(140, 20);
            this.cbox_CourseName.TabIndex = 2;
            this.cbox_CourseName.SelectedIndexChanged += new System.EventHandler(this.cbox_CourseName_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(749, 606);
            this.dataGridView1.TabIndex = 9;
            // 
            // frmStudentRollcall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(773, 741);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmStudentRollcall";
            this.Text = "frmStudentRollcall";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStudentRollcall_FormClosed);
            this.Load += new System.EventHandler(this.frmStudentRollcall_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_CourseName;
        private System.Windows.Forms.Button btn_OFF;
        private System.Windows.Forms.Button btn_ON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_StudentID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TwName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Leave;
    }
}