namespace EnglishCalssManager.Utility.FireBaseSharp
{
    partial class frmFireBaseSharp
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
            this.lb_connect = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_TotalDel = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_Retrieving = new System.Windows.Forms.Button();
            this.btn_delet = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_Groups = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.btn_disconncet = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_connect
            // 
            this.lb_connect.AutoEllipsis = true;
            this.lb_connect.AutoSize = true;
            this.lb_connect.Font = new System.Drawing.Font("新細明體", 14F);
            this.lb_connect.Location = new System.Drawing.Point(93, 28);
            this.lb_connect.Name = "lb_connect";
            this.lb_connect.Size = new System.Drawing.Size(91, 19);
            this.lb_connect.TabIndex = 28;
            this.lb_connect.Text = "Connect is ";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(12, 18);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 43);
            this.btn_Connect.TabIndex = 27;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_TotalDel
            // 
            this.btn_TotalDel.Location = new System.Drawing.Point(12, 288);
            this.btn_TotalDel.Name = "btn_TotalDel";
            this.btn_TotalDel.Size = new System.Drawing.Size(75, 43);
            this.btn_TotalDel.TabIndex = 33;
            this.btn_TotalDel.Text = "Total delete";
            this.btn_TotalDel.UseVisualStyleBackColor = true;
            this.btn_TotalDel.Click += new System.EventHandler(this.btn_TotalDel_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(12, 198);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 43);
            this.btn_update.TabIndex = 32;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            // 
            // btn_Retrieving
            // 
            this.btn_Retrieving.Location = new System.Drawing.Point(12, 108);
            this.btn_Retrieving.Name = "btn_Retrieving";
            this.btn_Retrieving.Size = new System.Drawing.Size(75, 43);
            this.btn_Retrieving.TabIndex = 31;
            this.btn_Retrieving.Text = "Retrieving";
            this.btn_Retrieving.UseVisualStyleBackColor = true;
            this.btn_Retrieving.Click += new System.EventHandler(this.btn_Retrieving_Click);
            // 
            // btn_delet
            // 
            this.btn_delet.Location = new System.Drawing.Point(12, 243);
            this.btn_delet.Name = "btn_delet";
            this.btn_delet.Size = new System.Drawing.Size(75, 43);
            this.btn_delet.TabIndex = 30;
            this.btn_delet.Text = "delete";
            this.btn_delet.UseVisualStyleBackColor = true;
            this.btn_delet.Click += new System.EventHandler(this.btn_delet_Click);
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(12, 153);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 43);
            this.btn_insert.TabIndex = 29;
            this.btn_insert.Text = "insert";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(330, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(440, 268);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "Groups";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(138, 122);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(161, 22);
            this.txt_phone.TabIndex = 37;
            // 
            // txt_Groups
            // 
            this.txt_Groups.Location = new System.Drawing.Point(138, 175);
            this.txt_Groups.Name = "txt_Groups";
            this.txt_Groups.Size = new System.Drawing.Size(161, 22);
            this.txt_Groups.TabIndex = 36;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(138, 68);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(161, 22);
            this.txt_ID.TabIndex = 35;
            this.txt_ID.TextChanged += new System.EventHandler(this.txt_ID_TextChanged);
            // 
            // btn_disconncet
            // 
            this.btn_disconncet.Location = new System.Drawing.Point(12, 64);
            this.btn_disconncet.Name = "btn_disconncet";
            this.btn_disconncet.Size = new System.Drawing.Size(75, 43);
            this.btn_disconncet.TabIndex = 41;
            this.btn_disconncet.Text = "DisConnect";
            this.btn_disconncet.UseVisualStyleBackColor = true;
            this.btn_disconncet.Click += new System.EventHandler(this.btn_disconncet_Click);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(160, 324);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 43);
            this.btn_test.TabIndex = 42;
            this.btn_test.Text = "TEST";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // frmFireBaseSharp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 605);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.btn_disconncet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_Groups);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_TotalDel);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_Retrieving);
            this.Controls.Add(this.btn_delet);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.lb_connect);
            this.Controls.Add(this.btn_Connect);
            this.Name = "frmFireBaseSharp";
            this.Text = "frmFireBaseSharp";
            this.Load += new System.EventHandler(this.frmFireBaseSharp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_connect;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_TotalDel;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_Retrieving;
        private System.Windows.Forms.Button btn_delet;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_Groups;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Button btn_disconncet;
        private System.Windows.Forms.Button btn_test;
    }
}