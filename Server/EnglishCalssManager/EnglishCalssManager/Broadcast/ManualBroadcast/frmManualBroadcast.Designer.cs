﻿namespace EnglishCalssManager.Broadcast.ManualBroadcast
{
    partial class frmManualBroadcast
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbox_ClassID = new System.Windows.Forms.ComboBox();
            this.dgBtnSend = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1300, 637);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "群組";
            // 
            // cbox_ClassID
            // 
            this.cbox_ClassID.FormattingEnabled = true;
            this.cbox_ClassID.Location = new System.Drawing.Point(12, 30);
            this.cbox_ClassID.Name = "cbox_ClassID";
            this.cbox_ClassID.Size = new System.Drawing.Size(200, 20);
            this.cbox_ClassID.TabIndex = 9;
            // 
            // dgBtnSend
            // 
            this.dgBtnSend.Name = "dgBtnSend";
            //this.dgBtnSend.Click += new System.EventHandler(this.dgBtnSend_Click);
            // 
            // frmManualBroadcast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbox_ClassID);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmManualBroadcast";
            this.Text = "_frmManualBroadcast";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this._frmManualBroadcast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbox_ClassID;
        private System.Windows.Forms.DataGridViewButtonColumn dgBtnSend;
    }
}