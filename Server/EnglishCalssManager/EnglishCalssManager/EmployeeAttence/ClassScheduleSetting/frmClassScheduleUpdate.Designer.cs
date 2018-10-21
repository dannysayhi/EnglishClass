namespace EnglishClassManager.EmployeeAttence.ClassScheduleSetting
{
    partial class frmfrmClassScheduleUpdate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckb_Weedend = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbox_ClassStartH = new System.Windows.Forms.ComboBox();
            this.cbox_ClassStartM = new System.Windows.Forms.ComboBox();
            this.cbox_ClassEndM = new System.Windows.Forms.ComboBox();
            this.cbox_ClassEndH = new System.Windows.Forms.ComboBox();
            this.txt_ClassID = new System.Windows.Forms.TextBox();
            this.txt_NoteTime = new System.Windows.Forms.TextBox();
            this.cbox_ClassName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "班別代碼：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "設定提前提醒分鐘：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "班制：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Tag = "";
            this.label4.Text = "休假日：";
            // 
            // ckb_Weedend
            // 
            this.ckb_Weedend.FormattingEnabled = true;
            this.ckb_Weedend.Items.AddRange(new object[] {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期日"});
            this.ckb_Weedend.Location = new System.Drawing.Point(90, 78);
            this.ckb_Weedend.Name = "ckb_Weedend";
            this.ckb_Weedend.Size = new System.Drawing.Size(92, 123);
            this.ckb_Weedend.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "上班：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "下班：";
            // 
            // cbox_ClassStartH
            // 
            this.cbox_ClassStartH.FormattingEnabled = true;
            this.cbox_ClassStartH.Items.AddRange(new object[] {
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
            "19"});
            this.cbox_ClassStartH.Location = new System.Drawing.Point(279, 78);
            this.cbox_ClassStartH.Name = "cbox_ClassStartH";
            this.cbox_ClassStartH.Size = new System.Drawing.Size(62, 20);
            this.cbox_ClassStartH.TabIndex = 7;
            // 
            // cbox_ClassStartM
            // 
            this.cbox_ClassStartM.FormattingEnabled = true;
            this.cbox_ClassStartM.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbox_ClassStartM.Location = new System.Drawing.Point(359, 78);
            this.cbox_ClassStartM.Name = "cbox_ClassStartM";
            this.cbox_ClassStartM.Size = new System.Drawing.Size(62, 20);
            this.cbox_ClassStartM.TabIndex = 8;
            // 
            // cbox_ClassEndM
            // 
            this.cbox_ClassEndM.FormattingEnabled = true;
            this.cbox_ClassEndM.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbox_ClassEndM.Location = new System.Drawing.Point(568, 78);
            this.cbox_ClassEndM.Name = "cbox_ClassEndM";
            this.cbox_ClassEndM.Size = new System.Drawing.Size(62, 20);
            this.cbox_ClassEndM.TabIndex = 10;
            // 
            // cbox_ClassEndH
            // 
            this.cbox_ClassEndH.FormattingEnabled = true;
            this.cbox_ClassEndH.Items.AddRange(new object[] {
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
            "19"});
            this.cbox_ClassEndH.Location = new System.Drawing.Point(488, 78);
            this.cbox_ClassEndH.Name = "cbox_ClassEndH";
            this.cbox_ClassEndH.Size = new System.Drawing.Size(62, 20);
            this.cbox_ClassEndH.TabIndex = 9;
            // 
            // txt_ClassID
            // 
            this.txt_ClassID.Location = new System.Drawing.Point(103, 20);
            this.txt_ClassID.Name = "txt_ClassID";
            this.txt_ClassID.Size = new System.Drawing.Size(100, 22);
            this.txt_ClassID.TabIndex = 11;
            // 
            // txt_NoteTime
            // 
            this.txt_NoteTime.Location = new System.Drawing.Point(336, 23);
            this.txt_NoteTime.Name = "txt_NoteTime";
            this.txt_NoteTime.Size = new System.Drawing.Size(58, 22);
            this.txt_NoteTime.TabIndex = 12;
            // 
            // cbox_ClassName
            // 
            this.cbox_ClassName.FormattingEnabled = true;
            this.cbox_ClassName.Items.AddRange(new object[] {
            "正常班",
            "輪班"});
            this.cbox_ClassName.Location = new System.Drawing.Point(448, 23);
            this.cbox_ClassName.Name = "cbox_ClassName";
            this.cbox_ClassName.Size = new System.Drawing.Size(115, 20);
            this.cbox_ClassName.TabIndex = 13;
            // 
            // frmfrmClassScheduleUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 399);
            this.Controls.Add(this.cbox_ClassName);
            this.Controls.Add(this.txt_NoteTime);
            this.Controls.Add(this.txt_ClassID);
            this.Controls.Add(this.cbox_ClassEndM);
            this.Controls.Add(this.cbox_ClassEndH);
            this.Controls.Add(this.cbox_ClassStartM);
            this.Controls.Add(this.cbox_ClassStartH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ckb_Weedend);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmfrmClassScheduleUpdate";
            this.Text = "frmfrmClassScheduleUpdate";
            this.Load += new System.EventHandler(this.frmfrmClassScheduleUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox ckb_Weedend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbox_ClassStartH;
        private System.Windows.Forms.ComboBox cbox_ClassStartM;
        private System.Windows.Forms.ComboBox cbox_ClassEndM;
        private System.Windows.Forms.ComboBox cbox_ClassEndH;
        private System.Windows.Forms.TextBox txt_ClassID;
        private System.Windows.Forms.TextBox txt_NoteTime;
        private System.Windows.Forms.ComboBox cbox_ClassName;
    }
}