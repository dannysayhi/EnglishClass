namespace EnglishCalssManager.Broadcast.MessageSetting
{
    partial class frmMessageSetting
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
            this.dgBtnCopy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgBtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtMsgName = new System.Windows.Forms.TextBox();
            this.txtMsgID = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1329, 573);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgBtnCopy
            // 
            this.dgBtnCopy.Name = "dgBtnCopy";
            // 
            // dgBtnEdit
            // 
            this.dgBtnEdit.Name = "dgBtnEdit";
            // 
            // dgBtnDel
            // 
            this.dgBtnDel.Name = "dgBtnDel";
            // 
            // txtMsgName
            // 
            this.txtMsgName.Font = new System.Drawing.Font("新細明體", 12F);
            this.txtMsgName.Location = new System.Drawing.Point(332, 23);
            this.txtMsgName.Name = "txtMsgName";
            this.txtMsgName.Size = new System.Drawing.Size(110, 27);
            this.txtMsgName.TabIndex = 12;
            // 
            // txtMsgID
            // 
            this.txtMsgID.Font = new System.Drawing.Font("新細明體", 12F);
            this.txtMsgID.Location = new System.Drawing.Point(122, 23);
            this.txtMsgID.Name = "txtMsgID";
            this.txtMsgID.Size = new System.Drawing.Size(110, 27);
            this.txtMsgID.TabIndex = 11;
            // 
            // txtMsg
            // 
            this.txtMsg.Font = new System.Drawing.Font("新細明體", 12F);
            this.txtMsg.Location = new System.Drawing.Point(122, 54);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtMsg.Size = new System.Drawing.Size(1097, 76);
            this.txtMsg.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(28, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "訊息內容：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(247, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "訊息名稱：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "訊息編號：";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("新細明體", 14F);
            this.btnAdd.Location = new System.Drawing.Point(1225, 54);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 76);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "新增訊息";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmMessageSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMsgName);
            this.Controls.Add(this.txtMsgID);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmMessageSetting";
            this.Text = "frmMessageSetting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMessageSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn dgBtnCopy;
        private System.Windows.Forms.DataGridViewButtonColumn dgBtnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn dgBtnDel;
        private System.Windows.Forms.TextBox txtMsgName;
        private System.Windows.Forms.TextBox txtMsgID;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
    }
}