namespace EnglishCalssManager.Utility.Account
{
    partial class AccountEditorLevelForm
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
            this.FunctionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnRefreshTable = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FunctionName,
            this.AccountLevel});
            this.dataGridView1.Location = new System.Drawing.Point(31, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(673, 287);
            this.dataGridView1.TabIndex = 0;
            // 
            // FunctionName
            // 
            this.FunctionName.HeaderText = "功能名稱";
            this.FunctionName.Name = "FunctionName";
            this.FunctionName.Width = 300;
            // 
            // AccountLevel
            // 
            this.AccountLevel.HeaderText = "層級";
            this.AccountLevel.Items.AddRange(new object[] {
            "Intern",
            "Operator",
            "Engineer",
            "Manager",
            "Administrator",
            "Developer"});
            this.AccountLevel.Name = "AccountLevel";
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.Location = new System.Drawing.Point(112, 45);
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshTable.TabIndex = 1;
            this.btnRefreshTable.Text = "刷新";
            this.btnRefreshTable.UseVisualStyleBackColor = true;
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(31, 45);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // AccountEditorLevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 373);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRefreshTable);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AccountEditorLevelForm";
            this.Text = "AccountEditorLevelForm";
            this.Load += new System.EventHandler(this.AccountEditorLevelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FunctionName;
        private System.Windows.Forms.DataGridViewComboBoxColumn AccountLevel;
        private System.Windows.Forms.Button btnRefreshTable;
        private System.Windows.Forms.Button btnUpdate;
    }
}