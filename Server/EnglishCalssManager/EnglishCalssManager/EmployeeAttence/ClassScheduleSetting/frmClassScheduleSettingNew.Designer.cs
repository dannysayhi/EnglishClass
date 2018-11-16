namespace EnglishCalssManager.EmployeeAttence.ClassScheduleSetting
{
    partial class frmClassScheduleSettingNew
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ClassID = new System.Windows.Forms.TextBox();
            this.chkbox_MON = new System.Windows.Forms.CheckBox();
            this.chkbox_TUE = new System.Windows.Forms.CheckBox();
            this.chkbox_THU = new System.Windows.Forms.CheckBox();
            this.chkbox_WED = new System.Windows.Forms.CheckBox();
            this.chkbox_SAT = new System.Windows.Forms.CheckBox();
            this.chkbox_FRI = new System.Windows.Forms.CheckBox();
            this.chkbox_SUN = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbox_ClassStartH = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbox_ClassStartM = new System.Windows.Forms.ComboBox();
            this.cbox_ClassEndM = new System.Windows.Forms.ComboBox();
            this.cbox_ClassEndH = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbox_NoteTime = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbox_ClassName = new System.Windows.Forms.ComboBox();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(831, 357);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "班別：";
            // 
            // txt_ClassID
            // 
            this.txt_ClassID.Location = new System.Drawing.Point(77, 8);
            this.txt_ClassID.Name = "txt_ClassID";
            this.txt_ClassID.Size = new System.Drawing.Size(108, 22);
            this.txt_ClassID.TabIndex = 9;
            // 
            // chkbox_MON
            // 
            this.chkbox_MON.AutoSize = true;
            this.chkbox_MON.Location = new System.Drawing.Point(16, 90);
            this.chkbox_MON.Name = "chkbox_MON";
            this.chkbox_MON.Size = new System.Drawing.Size(60, 16);
            this.chkbox_MON.TabIndex = 10;
            this.chkbox_MON.Text = "星期一";
            this.chkbox_MON.UseVisualStyleBackColor = true;
            // 
            // chkbox_TUE
            // 
            this.chkbox_TUE.AutoSize = true;
            this.chkbox_TUE.Location = new System.Drawing.Point(88, 90);
            this.chkbox_TUE.Name = "chkbox_TUE";
            this.chkbox_TUE.Size = new System.Drawing.Size(60, 16);
            this.chkbox_TUE.TabIndex = 11;
            this.chkbox_TUE.Text = "星期二";
            this.chkbox_TUE.UseVisualStyleBackColor = true;
            // 
            // chkbox_THU
            // 
            this.chkbox_THU.AutoSize = true;
            this.chkbox_THU.Location = new System.Drawing.Point(234, 90);
            this.chkbox_THU.Name = "chkbox_THU";
            this.chkbox_THU.Size = new System.Drawing.Size(60, 16);
            this.chkbox_THU.TabIndex = 13;
            this.chkbox_THU.Text = "星期四";
            this.chkbox_THU.UseVisualStyleBackColor = true;
            // 
            // chkbox_WED
            // 
            this.chkbox_WED.AutoSize = true;
            this.chkbox_WED.Location = new System.Drawing.Point(162, 90);
            this.chkbox_WED.Name = "chkbox_WED";
            this.chkbox_WED.Size = new System.Drawing.Size(60, 16);
            this.chkbox_WED.TabIndex = 12;
            this.chkbox_WED.Text = "星期三";
            this.chkbox_WED.UseVisualStyleBackColor = true;
            // 
            // chkbox_SAT
            // 
            this.chkbox_SAT.AutoSize = true;
            this.chkbox_SAT.Location = new System.Drawing.Point(380, 90);
            this.chkbox_SAT.Name = "chkbox_SAT";
            this.chkbox_SAT.Size = new System.Drawing.Size(60, 16);
            this.chkbox_SAT.TabIndex = 15;
            this.chkbox_SAT.Text = "星期六";
            this.chkbox_SAT.UseVisualStyleBackColor = true;
            // 
            // chkbox_FRI
            // 
            this.chkbox_FRI.AutoSize = true;
            this.chkbox_FRI.Location = new System.Drawing.Point(308, 90);
            this.chkbox_FRI.Name = "chkbox_FRI";
            this.chkbox_FRI.Size = new System.Drawing.Size(60, 16);
            this.chkbox_FRI.TabIndex = 14;
            this.chkbox_FRI.Text = "星期五";
            this.chkbox_FRI.UseVisualStyleBackColor = true;
            // 
            // chkbox_SUN
            // 
            this.chkbox_SUN.AutoSize = true;
            this.chkbox_SUN.Location = new System.Drawing.Point(454, 90);
            this.chkbox_SUN.Name = "chkbox_SUN";
            this.chkbox_SUN.Size = new System.Drawing.Size(60, 16);
            this.chkbox_SUN.TabIndex = 16;
            this.chkbox_SUN.Text = "星期日";
            this.chkbox_SUN.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(200, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "班級名稱：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "上課時間：";
            // 
            // cbox_ClassStartH
            // 
            this.cbox_ClassStartH.FormattingEnabled = true;
            this.cbox_ClassStartH.Items.AddRange(new object[] {
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21"});
            this.cbox_ClassStartH.Location = new System.Drawing.Point(123, 52);
            this.cbox_ClassStartH.Name = "cbox_ClassStartH";
            this.cbox_ClassStartH.Size = new System.Drawing.Size(51, 20);
            this.cbox_ClassStartH.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(169, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "：";
            // 
            // cbox_ClassStartM
            // 
            this.cbox_ClassStartM.FormattingEnabled = true;
            this.cbox_ClassStartM.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbox_ClassStartM.Location = new System.Drawing.Point(194, 52);
            this.cbox_ClassStartM.Name = "cbox_ClassStartM";
            this.cbox_ClassStartM.Size = new System.Drawing.Size(51, 20);
            this.cbox_ClassStartM.TabIndex = 22;
            // 
            // cbox_ClassEndM
            // 
            this.cbox_ClassEndM.FormattingEnabled = true;
            this.cbox_ClassEndM.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbox_ClassEndM.Location = new System.Drawing.Point(449, 52);
            this.cbox_ClassEndM.Name = "cbox_ClassEndM";
            this.cbox_ClassEndM.Size = new System.Drawing.Size(51, 20);
            this.cbox_ClassEndM.TabIndex = 26;
            // 
            // cbox_ClassEndH
            // 
            this.cbox_ClassEndH.FormattingEnabled = true;
            this.cbox_ClassEndH.Items.AddRange(new object[] {
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21"});
            this.cbox_ClassEndH.Location = new System.Drawing.Point(378, 52);
            this.cbox_ClassEndH.Name = "cbox_ClassEndH";
            this.cbox_ClassEndH.Size = new System.Drawing.Size(51, 20);
            this.cbox_ClassEndH.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(424, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(267, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "下課時間：";
            // 
            // cbox_NoteTime
            // 
            this.cbox_NoteTime.FormattingEnabled = true;
            this.cbox_NoteTime.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60"});
            this.cbox_NoteTime.Location = new System.Drawing.Point(602, 10);
            this.cbox_NoteTime.Name = "cbox_NoteTime";
            this.cbox_NoteTime.Size = new System.Drawing.Size(51, 20);
            this.cbox_NoteTime.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(445, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 21);
            this.label8.TabIndex = 27;
            this.label8.Text = "提醒上課時間：";
            // 
            // cbox_ClassName
            // 
            this.cbox_ClassName.FormattingEnabled = true;
            this.cbox_ClassName.Items.AddRange(new object[] {
            "正常班",
            "輪班"});
            this.cbox_ClassName.Location = new System.Drawing.Point(308, 9);
            this.cbox_ClassName.Name = "cbox_ClassName";
            this.cbox_ClassName.Size = new System.Drawing.Size(121, 20);
            this.cbox_ClassName.TabIndex = 29;
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(220, 119);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 23);
            this.btn_Del.TabIndex = 32;
            this.btn_Del.Text = "刪除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(115, 119);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 31;
            this.btn_update.Text = "修改";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(16, 119);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 30;
            this.btn_Add.Text = "新增";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // frmClassScheduleSettingNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 517);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.cbox_ClassName);
            this.Controls.Add(this.cbox_NoteTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbox_ClassEndM);
            this.Controls.Add(this.cbox_ClassEndH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbox_ClassStartM);
            this.Controls.Add(this.cbox_ClassStartH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkbox_SUN);
            this.Controls.Add(this.chkbox_SAT);
            this.Controls.Add(this.chkbox_FRI);
            this.Controls.Add(this.chkbox_THU);
            this.Controls.Add(this.chkbox_WED);
            this.Controls.Add(this.chkbox_TUE);
            this.Controls.Add(this.chkbox_MON);
            this.Controls.Add(this.txt_ClassID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmClassScheduleSettingNew";
            this.Text = "frmClassScheduleSettingNew";
            this.Load += new System.EventHandler(this.frmClassScheduleSettingNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ClassID;
        private System.Windows.Forms.CheckBox chkbox_MON;
        private System.Windows.Forms.CheckBox chkbox_TUE;
        private System.Windows.Forms.CheckBox chkbox_THU;
        private System.Windows.Forms.CheckBox chkbox_WED;
        private System.Windows.Forms.CheckBox chkbox_SAT;
        private System.Windows.Forms.CheckBox chkbox_FRI;
        private System.Windows.Forms.CheckBox chkbox_SUN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbox_ClassStartH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbox_ClassStartM;
        private System.Windows.Forms.ComboBox cbox_ClassEndM;
        private System.Windows.Forms.ComboBox cbox_ClassEndH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbox_NoteTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbox_ClassName;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_Add;
    }
}