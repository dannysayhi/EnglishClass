namespace _4RobotSystem.DataBase
{
    partial class frmParamDB
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParamDB));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnReadParam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnWriteParam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExitParam = new System.Windows.Forms.ToolStripMenuItem();
            this.houroutputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabTest = new System.Windows.Forms.TabPage();
            this.buttonDBAddTT = new System.Windows.Forms.Button();
            this.buttonTBCreate = new System.Windows.Forms.Button();
            this.buttonDBAddHH = new System.Windows.Forms.Button();
            this.textField2 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDBSelect = new System.Windows.Forms.Button();
            this.buttonDBDelete = new System.Windows.Forms.Button();
            this.textValue2 = new System.Windows.Forms.MaskedTextBox();
            this.textValue1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textField1 = new System.Windows.Forms.TextBox();
            this.textDes = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.textTable = new System.Windows.Forms.TextBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.buttonDBUpdate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonDBInsert = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabDB = new System.Windows.Forms.TabPage();
            this.label = new System.Windows.Forms.Label();
            this.PropertySystem = new System.Windows.Forms.PropertyGrid();
            this.tabParamDB = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.houroutputBindingSource)).BeginInit();
            this.tabTest.SuspendLayout();
            this.tabDB.SuspendLayout();
            this.tabParamDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnReadParam,
            this.mnWriteParam,
            this.mnExitParam});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(739, 29);
            this.menuStrip1.TabIndex = 191;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnReadParam
            // 
            this.mnReadParam.Name = "mnReadParam";
            this.mnReadParam.Size = new System.Drawing.Size(71, 23);
            this.mnReadParam.Text = "讀取(&R)";
            this.mnReadParam.Click += new System.EventHandler(this.mnReadParam_Click);
            // 
            // mnWriteParam
            // 
            this.mnWriteParam.Name = "mnWriteParam";
            this.mnWriteParam.Size = new System.Drawing.Size(76, 23);
            this.mnWriteParam.Text = "寫入(&W)";
            this.mnWriteParam.Click += new System.EventHandler(this.mnWriteParam_Click);
            // 
            // mnExitParam
            // 
            this.mnExitParam.Name = "mnExitParam";
            this.mnExitParam.Size = new System.Drawing.Size(69, 23);
            this.mnExitParam.Text = "離開(&E)";
            this.mnExitParam.Click += new System.EventHandler(this.mnExitParam_Click);
            // 
            // tabTest
            // 
            this.tabTest.Controls.Add(this.buttonDBAddTT);
            this.tabTest.Controls.Add(this.buttonTBCreate);
            this.tabTest.Controls.Add(this.buttonDBAddHH);
            this.tabTest.Controls.Add(this.textField2);
            this.tabTest.Controls.Add(this.label4);
            this.tabTest.Controls.Add(this.label3);
            this.tabTest.Controls.Add(this.buttonDBSelect);
            this.tabTest.Controls.Add(this.buttonDBDelete);
            this.tabTest.Controls.Add(this.textValue2);
            this.tabTest.Controls.Add(this.textValue1);
            this.tabTest.Controls.Add(this.label2);
            this.tabTest.Controls.Add(this.label1);
            this.tabTest.Controls.Add(this.textField1);
            this.tabTest.Controls.Add(this.textDes);
            this.tabTest.Controls.Add(this.textID);
            this.tabTest.Controls.Add(this.textTable);
            this.tabTest.Controls.Add(this.textResult);
            this.tabTest.Controls.Add(this.buttonDBUpdate);
            this.tabTest.Controls.Add(this.label9);
            this.tabTest.Controls.Add(this.label8);
            this.tabTest.Controls.Add(this.buttonDBInsert);
            this.tabTest.Controls.Add(this.label7);
            this.tabTest.Location = new System.Drawing.Point(4, 25);
            this.tabTest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabTest.Size = new System.Drawing.Size(731, 634);
            this.tabTest.TabIndex = 1;
            this.tabTest.Text = "測試";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // buttonDBAddTT
            // 
            this.buttonDBAddTT.Location = new System.Drawing.Point(560, 320);
            this.buttonDBAddTT.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonDBAddTT.Name = "buttonDBAddTT";
            this.buttonDBAddTT.Size = new System.Drawing.Size(125, 95);
            this.buttonDBAddTT.TabIndex = 78;
            this.buttonDBAddTT.Text = "Add TT";
            this.buttonDBAddTT.UseVisualStyleBackColor = true;
            this.buttonDBAddTT.Click += new System.EventHandler(this.buttonDBAddTT_Click);
            // 
            // buttonTBCreate
            // 
            this.buttonTBCreate.Location = new System.Drawing.Point(560, 131);
            this.buttonTBCreate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonTBCreate.Name = "buttonTBCreate";
            this.buttonTBCreate.Size = new System.Drawing.Size(125, 43);
            this.buttonTBCreate.TabIndex = 77;
            this.buttonTBCreate.Text = "Create Test";
            this.buttonTBCreate.UseVisualStyleBackColor = true;
            this.buttonTBCreate.Click += new System.EventHandler(this.buttonTBCreate_Click);
            // 
            // buttonDBAddHH
            // 
            this.buttonDBAddHH.Location = new System.Drawing.Point(560, 214);
            this.buttonDBAddHH.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonDBAddHH.Name = "buttonDBAddHH";
            this.buttonDBAddHH.Size = new System.Drawing.Size(125, 95);
            this.buttonDBAddHH.TabIndex = 76;
            this.buttonDBAddHH.Text = "Add HH";
            this.buttonDBAddHH.UseVisualStyleBackColor = true;
            this.buttonDBAddHH.Click += new System.EventHandler(this.buttonDBAdd_Click);
            // 
            // textField2
            // 
            this.textField2.Location = new System.Drawing.Point(294, 219);
            this.textField2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textField2.Mask = "\"00\"";
            this.textField2.Name = "textField2";
            this.textField2.Size = new System.Drawing.Size(164, 30);
            this.textField2.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 22);
            this.label4.TabIndex = 74;
            this.label4.Text = "In/UpN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 191);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 22);
            this.label3.TabIndex = 73;
            this.label3.Text = "In/UpO/Del/Sel";
            // 
            // buttonDBSelect
            // 
            this.buttonDBSelect.Location = new System.Drawing.Point(560, 543);
            this.buttonDBSelect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonDBSelect.Name = "buttonDBSelect";
            this.buttonDBSelect.Size = new System.Drawing.Size(125, 43);
            this.buttonDBSelect.TabIndex = 70;
            this.buttonDBSelect.Text = "Select Test";
            this.buttonDBSelect.UseVisualStyleBackColor = true;
            this.buttonDBSelect.Click += new System.EventHandler(this.buttonDBSelect_Click);
            // 
            // buttonDBDelete
            // 
            this.buttonDBDelete.Location = new System.Drawing.Point(384, 543);
            this.buttonDBDelete.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonDBDelete.Name = "buttonDBDelete";
            this.buttonDBDelete.Size = new System.Drawing.Size(125, 43);
            this.buttonDBDelete.TabIndex = 69;
            this.buttonDBDelete.Text = "Delete Test";
            this.buttonDBDelete.UseVisualStyleBackColor = true;
            this.buttonDBDelete.Click += new System.EventHandler(this.buttonDBDelete_Click);
            // 
            // textValue2
            // 
            this.textValue2.Location = new System.Drawing.Point(294, 270);
            this.textValue2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textValue2.Mask = "000";
            this.textValue2.Name = "textValue2";
            this.textValue2.Size = new System.Drawing.Size(164, 30);
            this.textValue2.TabIndex = 68;
            // 
            // textValue1
            // 
            this.textValue1.Location = new System.Drawing.Point(116, 270);
            this.textValue1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textValue1.Mask = "2000000000";
            this.textValue1.Name = "textValue1";
            this.textValue1.Size = new System.Drawing.Size(164, 30);
            this.textValue1.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 276);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 22);
            this.label2.TabIndex = 64;
            this.label2.Text = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 223);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 22);
            this.label1.TabIndex = 62;
            this.label1.Text = "Field";
            // 
            // textField1
            // 
            this.textField1.Location = new System.Drawing.Point(116, 219);
            this.textField1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textField1.MaxLength = 20;
            this.textField1.Name = "textField1";
            this.textField1.ReadOnly = true;
            this.textField1.Size = new System.Drawing.Size(164, 30);
            this.textField1.TabIndex = 61;
            this.textField1.Text = "dateDD";
            this.textField1.WordWrap = false;
            // 
            // textDes
            // 
            this.textDes.Location = new System.Drawing.Point(374, 23);
            this.textDes.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textDes.MaxLength = 20;
            this.textDes.Name = "textDes";
            this.textDes.Size = new System.Drawing.Size(285, 30);
            this.textDes.TabIndex = 57;
            this.textDes.Text = "2RS系統";
            this.textDes.WordWrap = false;
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(94, 23);
            this.textID.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textID.MaxLength = 20;
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(164, 30);
            this.textID.TabIndex = 55;
            this.textID.Text = "88888888";
            this.textID.WordWrap = false;
            // 
            // textTable
            // 
            this.textTable.Location = new System.Drawing.Point(116, 125);
            this.textTable.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textTable.MaxLength = 20;
            this.textTable.Name = "textTable";
            this.textTable.Size = new System.Drawing.Size(164, 30);
            this.textTable.TabIndex = 52;
            this.textTable.Text = "hour_output";
            this.textTable.WordWrap = false;
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(36, 425);
            this.textResult.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textResult.MaxLength = 2;
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.ReadOnly = true;
            this.textResult.Size = new System.Drawing.Size(645, 104);
            this.textResult.TabIndex = 51;
            this.textResult.WordWrap = false;
            // 
            // buttonDBUpdate
            // 
            this.buttonDBUpdate.Location = new System.Drawing.Point(206, 543);
            this.buttonDBUpdate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonDBUpdate.Name = "buttonDBUpdate";
            this.buttonDBUpdate.Size = new System.Drawing.Size(125, 43);
            this.buttonDBUpdate.TabIndex = 60;
            this.buttonDBUpdate.Text = "Update Test";
            this.buttonDBUpdate.UseVisualStyleBackColor = true;
            this.buttonDBUpdate.Click += new System.EventHandler(this.buttonDBUpdate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 29);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 22);
            this.label9.TabIndex = 58;
            this.label9.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 22);
            this.label8.TabIndex = 56;
            this.label8.Text = "ID";
            // 
            // buttonDBInsert
            // 
            this.buttonDBInsert.Location = new System.Drawing.Point(36, 543);
            this.buttonDBInsert.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonDBInsert.Name = "buttonDBInsert";
            this.buttonDBInsert.Size = new System.Drawing.Size(125, 43);
            this.buttonDBInsert.TabIndex = 54;
            this.buttonDBInsert.Text = "Insert Test";
            this.buttonDBInsert.UseVisualStyleBackColor = true;
            this.buttonDBInsert.Click += new System.EventHandler(this.buttonDBInsert_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 131);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 22);
            this.label7.TabIndex = 53;
            this.label7.Text = "Table";
            // 
            // tabDB
            // 
            this.tabDB.Controls.Add(this.label);
            this.tabDB.Controls.Add(this.PropertySystem);
            this.tabDB.Location = new System.Drawing.Point(4, 31);
            this.tabDB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabDB.Name = "tabDB";
            this.tabDB.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabDB.Size = new System.Drawing.Size(731, 639);
            this.tabDB.TabIndex = 0;
            this.tabDB.Text = "資料庫參數";
            this.tabDB.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.SystemColors.Control;
            this.label.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label.ForeColor = System.Drawing.Color.Red;
            this.label.Location = new System.Drawing.Point(335, 6);
            this.label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(418, 24);
            this.label.TabIndex = 188;
            this.label.Text = "※系統參數設定僅開放給程式開發者※";
            // 
            // PropertySystem
            // 
            this.PropertySystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertySystem.LineColor = System.Drawing.SystemColors.ControlDark;
            this.PropertySystem.Location = new System.Drawing.Point(5, 6);
            this.PropertySystem.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PropertySystem.Name = "PropertySystem";
            this.PropertySystem.Size = new System.Drawing.Size(721, 627);
            this.PropertySystem.TabIndex = 187;
            // 
            // tabParamDB
            // 
            this.tabParamDB.Controls.Add(this.tabDB);
            this.tabParamDB.Controls.Add(this.tabTest);
            this.tabParamDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabParamDB.Location = new System.Drawing.Point(0, 29);
            this.tabParamDB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabParamDB.Name = "tabParamDB";
            this.tabParamDB.SelectedIndex = 0;
            this.tabParamDB.Size = new System.Drawing.Size(739, 674);
            this.tabParamDB.TabIndex = 192;
            // 
            // frmParamDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 703);
            this.Controls.Add(this.tabParamDB);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmParamDB";
            this.Text = "数据库设定";
            this.Load += new System.EventHandler(this.frmParamDB_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.houroutputBindingSource)).EndInit();
            this.tabTest.ResumeLayout(false);
            this.tabTest.PerformLayout();
            this.tabDB.ResumeLayout(false);
            this.tabDB.PerformLayout();
            this.tabParamDB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnReadParam;
        private System.Windows.Forms.ToolStripMenuItem mnWriteParam;
        private System.Windows.Forms.ToolStripMenuItem mnExitParam;
        private System.Windows.Forms.BindingSource houroutputBindingSource;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.MaskedTextBox textField2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDBSelect;
        private System.Windows.Forms.Button buttonDBDelete;
        private System.Windows.Forms.MaskedTextBox textValue2;
        private System.Windows.Forms.MaskedTextBox textValue1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textField1;
        private System.Windows.Forms.TextBox textDes;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.TextBox textTable;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Button buttonDBUpdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDBInsert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabDB;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PropertyGrid PropertySystem;
        private System.Windows.Forms.TabControl tabParamDB;
        private System.Windows.Forms.Button buttonDBAddHH;
        private System.Windows.Forms.Button buttonTBCreate;
        private System.Windows.Forms.Button buttonDBAddTT;
    }
}