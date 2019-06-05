namespace EnglishCalssManager.Broadcast.ManualBroadcast
{
    partial class frmManualBroadcastStudent
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
            this.dgBtnSend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ItemNum = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.datagSend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MsgID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Msg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_SelAll = new System.Windows.Forms.Button();
            this.btn_CleanAll = new System.Windows.Forms.Button();
            this.btn_Resv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBtnSend
            // 
            this.dgBtnSend.Name = "dgBtnSend";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNum,
            this.CourseID,
            this.CourseName});
            this.dataGridView2.Location = new System.Drawing.Point(9, 30);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(207, 666);
            this.dataGridView2.TabIndex = 11;
            // 
            // ItemNum
            // 
            this.ItemNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemNum.HeaderText = "發送";
            this.ItemNum.Name = "ItemNum";
            // 
            // CourseID
            // 
            this.CourseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CourseID.HeaderText = "群組ID";
            this.CourseID.Name = "CourseID";
            // 
            // CourseName
            // 
            this.CourseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CourseName.HeaderText = "群組名稱";
            this.CourseName.Name = "CourseName";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datagSend,
            this.MsgID,
            this.MsgCourse,
            this.MsgName,
            this.Msg});
            this.dataGridView3.Location = new System.Drawing.Point(233, 30);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(1100, 666);
            this.dataGridView3.TabIndex = 13;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // datagSend
            // 
            this.datagSend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datagSend.FillWeight = 5F;
            this.datagSend.HeaderText = "發送";
            this.datagSend.Name = "datagSend";
            this.datagSend.Text = "發送";
            this.datagSend.UseColumnTextForButtonValue = true;
            // 
            // MsgID
            // 
            this.MsgID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MsgID.FillWeight = 5F;
            this.MsgID.HeaderText = "訊息編號";
            this.MsgID.Name = "MsgID";
            // 
            // MsgCourse
            // 
            this.MsgCourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MsgCourse.FillWeight = 5F;
            this.MsgCourse.HeaderText = "發送群組ID";
            this.MsgCourse.Name = "MsgCourse";
            // 
            // MsgName
            // 
            this.MsgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MsgName.FillWeight = 10F;
            this.MsgName.HeaderText = "發送群組名稱";
            this.MsgName.Name = "MsgName";
            // 
            // Msg
            // 
            this.Msg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Msg.FillWeight = 65F;
            this.Msg.HeaderText = "訊息內容";
            this.Msg.Name = "Msg";
            // 
            // btn_SelAll
            // 
            this.btn_SelAll.Location = new System.Drawing.Point(9, 1);
            this.btn_SelAll.Name = "btn_SelAll";
            this.btn_SelAll.Size = new System.Drawing.Size(64, 23);
            this.btn_SelAll.TabIndex = 14;
            this.btn_SelAll.Text = "全選";
            this.btn_SelAll.UseVisualStyleBackColor = true;
            this.btn_SelAll.Click += new System.EventHandler(this.btn_SelAll_Click);
            // 
            // btn_CleanAll
            // 
            this.btn_CleanAll.Location = new System.Drawing.Point(79, 1);
            this.btn_CleanAll.Name = "btn_CleanAll";
            this.btn_CleanAll.Size = new System.Drawing.Size(72, 23);
            this.btn_CleanAll.TabIndex = 15;
            this.btn_CleanAll.Text = "清除";
            this.btn_CleanAll.UseVisualStyleBackColor = true;
            this.btn_CleanAll.Click += new System.EventHandler(this.btn_CleanAll_Click);
            // 
            // btn_Resv
            // 
            this.btn_Resv.Location = new System.Drawing.Point(157, 1);
            this.btn_Resv.Name = "btn_Resv";
            this.btn_Resv.Size = new System.Drawing.Size(72, 23);
            this.btn_Resv.TabIndex = 16;
            this.btn_Resv.Text = "反向";
            this.btn_Resv.UseVisualStyleBackColor = true;
            this.btn_Resv.Click += new System.EventHandler(this.btn_Resv_Click);
            // 
            // frmManualBroadcastStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1362, 708);
            this.Controls.Add(this.btn_Resv);
            this.Controls.Add(this.btn_CleanAll);
            this.Controls.Add(this.btn_SelAll);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Name = "frmManualBroadcastStudent";
            this.Text = "_frmManualBroadcast";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this._frmManualBroadcast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewButtonColumn dgBtnSend;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseName;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewButtonColumn datagSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Msg;
        private System.Windows.Forms.Button btn_SelAll;
        private System.Windows.Forms.Button btn_CleanAll;
        private System.Windows.Forms.Button btn_Resv;
    }
}