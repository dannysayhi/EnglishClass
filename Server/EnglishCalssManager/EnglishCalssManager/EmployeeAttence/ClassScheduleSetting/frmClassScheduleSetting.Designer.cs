using EnglishCalssManager;

namespace EnglishClassManager.EmployeeAttence.ClassScheduleSetting
{
    partial class frmClassScheduleSetting
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
            this.txt_ClassName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.classIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.classStartHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.classStartMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.classEndHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.classEndMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.noteTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableSelectParamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnglishClassDBtestDataSet3 = new EnglishClassManager.EnglishClassDBtestDataSet3();
            this.sUNDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mONDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tUEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wEDDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tHUDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fRIDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sATDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableClassScheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnglishClassDBtestDataSet2 = new EnglishClassManager.EnglishClassDBtestDataSet2();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.table_ClassScheduleTableAdapter = new EnglishClassManager.EnglishClassDBtestDataSet2TableAdapters.Table_ClassScheduleTableAdapter();
            this.table_SelectParamTableAdapter = new EnglishClassManager.EnglishClassDBtestDataSet3TableAdapters.Table_SelectParamTableAdapter();
            this.btn_Del = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableSelectParamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishClassDBtestDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableClassScheduleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishClassDBtestDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ClassName
            // 
            this.txt_ClassName.Location = new System.Drawing.Point(104, 12);
            this.txt_ClassName.Name = "txt_ClassName";
            this.txt_ClassName.Size = new System.Drawing.Size(126, 22);
            this.txt_ClassName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "班別簡碼：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.classIDDataGridViewTextBoxColumn,
            this.classNameDataGridViewTextBoxColumn,
            this.classStartHDataGridViewTextBoxColumn,
            this.classStartMDataGridViewTextBoxColumn,
            this.classEndHDataGridViewTextBoxColumn,
            this.classEndMDataGridViewTextBoxColumn,
            this.noteTimeDataGridViewTextBoxColumn,
            this.sUNDataGridViewCheckBoxColumn,
            this.mONDataGridViewCheckBoxColumn,
            this.tUEDataGridViewCheckBoxColumn,
            this.wEDDataGridViewCheckBoxColumn,
            this.tHUDataGridViewCheckBoxColumn,
            this.fRIDataGridViewCheckBoxColumn,
            this.sATDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.tableClassScheduleBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(35, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1096, 505);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // classIDDataGridViewTextBoxColumn
            // 
            this.classIDDataGridViewTextBoxColumn.DataPropertyName = "ClassID";
            this.classIDDataGridViewTextBoxColumn.HeaderText = "ClassID";
            this.classIDDataGridViewTextBoxColumn.Name = "classIDDataGridViewTextBoxColumn";
            // 
            // classNameDataGridViewTextBoxColumn
            // 
            this.classNameDataGridViewTextBoxColumn.DataPropertyName = "ClassName";
            this.classNameDataGridViewTextBoxColumn.HeaderText = "ClassName";
            this.classNameDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "正常班",
            "輪班"});
            this.classNameDataGridViewTextBoxColumn.Name = "classNameDataGridViewTextBoxColumn";
            this.classNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.classNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // classStartHDataGridViewTextBoxColumn
            // 
            this.classStartHDataGridViewTextBoxColumn.DataPropertyName = "ClassStartH";
            this.classStartHDataGridViewTextBoxColumn.HeaderText = "ClassStartH";
            this.classStartHDataGridViewTextBoxColumn.Items.AddRange(new object[] {
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
            "20"});
            this.classStartHDataGridViewTextBoxColumn.Name = "classStartHDataGridViewTextBoxColumn";
            this.classStartHDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.classStartHDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // classStartMDataGridViewTextBoxColumn
            // 
            this.classStartMDataGridViewTextBoxColumn.DataPropertyName = "ClassStartM";
            this.classStartMDataGridViewTextBoxColumn.HeaderText = "ClassStartM";
            this.classStartMDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.classStartMDataGridViewTextBoxColumn.Name = "classStartMDataGridViewTextBoxColumn";
            this.classStartMDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.classStartMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // classEndHDataGridViewTextBoxColumn
            // 
            this.classEndHDataGridViewTextBoxColumn.DataPropertyName = "ClassEndH";
            this.classEndHDataGridViewTextBoxColumn.HeaderText = "ClassEndH";
            this.classEndHDataGridViewTextBoxColumn.Items.AddRange(new object[] {
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
            "20"});
            this.classEndHDataGridViewTextBoxColumn.Name = "classEndHDataGridViewTextBoxColumn";
            this.classEndHDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.classEndHDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // classEndMDataGridViewTextBoxColumn
            // 
            this.classEndMDataGridViewTextBoxColumn.DataPropertyName = "ClassEndM";
            this.classEndMDataGridViewTextBoxColumn.HeaderText = "ClassEndM";
            this.classEndMDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.classEndMDataGridViewTextBoxColumn.Name = "classEndMDataGridViewTextBoxColumn";
            this.classEndMDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.classEndMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // noteTimeDataGridViewTextBoxColumn
            // 
            this.noteTimeDataGridViewTextBoxColumn.DataPropertyName = "NoteTime";
            this.noteTimeDataGridViewTextBoxColumn.DataSource = this.tableSelectParamBindingSource;
            this.noteTimeDataGridViewTextBoxColumn.HeaderText = "NoteTime";
            this.noteTimeDataGridViewTextBoxColumn.Name = "noteTimeDataGridViewTextBoxColumn";
            this.noteTimeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.noteTimeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.noteTimeDataGridViewTextBoxColumn.ValueMember = "NoteTime";
            // 
            // tableSelectParamBindingSource
            // 
            this.tableSelectParamBindingSource.DataMember = "Table_SelectParam";
            this.tableSelectParamBindingSource.DataSource = this.EnglishClassDBtestDataSet3;
            // 
            // EnglishClassDBtestDataSet3
            // 
            this.EnglishClassDBtestDataSet3.DataSetName = "EnglishClassDBtestDataSet3";
            this.EnglishClassDBtestDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sUNDataGridViewCheckBoxColumn
            // 
            this.sUNDataGridViewCheckBoxColumn.DataPropertyName = "SUN";
            this.sUNDataGridViewCheckBoxColumn.HeaderText = "SUN";
            this.sUNDataGridViewCheckBoxColumn.Name = "sUNDataGridViewCheckBoxColumn";
            this.sUNDataGridViewCheckBoxColumn.Width = 50;
            // 
            // mONDataGridViewCheckBoxColumn
            // 
            this.mONDataGridViewCheckBoxColumn.DataPropertyName = "MON";
            this.mONDataGridViewCheckBoxColumn.HeaderText = "MON";
            this.mONDataGridViewCheckBoxColumn.Name = "mONDataGridViewCheckBoxColumn";
            this.mONDataGridViewCheckBoxColumn.Width = 50;
            // 
            // tUEDataGridViewCheckBoxColumn
            // 
            this.tUEDataGridViewCheckBoxColumn.DataPropertyName = "TUE";
            this.tUEDataGridViewCheckBoxColumn.HeaderText = "TUE";
            this.tUEDataGridViewCheckBoxColumn.Name = "tUEDataGridViewCheckBoxColumn";
            this.tUEDataGridViewCheckBoxColumn.Width = 50;
            // 
            // wEDDataGridViewCheckBoxColumn
            // 
            this.wEDDataGridViewCheckBoxColumn.DataPropertyName = "WED";
            this.wEDDataGridViewCheckBoxColumn.HeaderText = "WED";
            this.wEDDataGridViewCheckBoxColumn.Name = "wEDDataGridViewCheckBoxColumn";
            this.wEDDataGridViewCheckBoxColumn.Width = 50;
            // 
            // tHUDataGridViewCheckBoxColumn
            // 
            this.tHUDataGridViewCheckBoxColumn.DataPropertyName = "THU";
            this.tHUDataGridViewCheckBoxColumn.HeaderText = "THU";
            this.tHUDataGridViewCheckBoxColumn.Name = "tHUDataGridViewCheckBoxColumn";
            this.tHUDataGridViewCheckBoxColumn.Width = 50;
            // 
            // fRIDataGridViewCheckBoxColumn
            // 
            this.fRIDataGridViewCheckBoxColumn.DataPropertyName = "FRI";
            this.fRIDataGridViewCheckBoxColumn.HeaderText = "FRI";
            this.fRIDataGridViewCheckBoxColumn.Name = "fRIDataGridViewCheckBoxColumn";
            this.fRIDataGridViewCheckBoxColumn.Width = 50;
            // 
            // sATDataGridViewCheckBoxColumn
            // 
            this.sATDataGridViewCheckBoxColumn.DataPropertyName = "SAT";
            this.sATDataGridViewCheckBoxColumn.HeaderText = "SAT";
            this.sATDataGridViewCheckBoxColumn.Name = "sATDataGridViewCheckBoxColumn";
            this.sATDataGridViewCheckBoxColumn.Width = 50;
            // 
            // tableClassScheduleBindingSource
            // 
            this.tableClassScheduleBindingSource.DataMember = "Table_ClassSchedule";
            this.tableClassScheduleBindingSource.DataSource = this.EnglishClassDBtestDataSet2;
            // 
            // EnglishClassDBtestDataSet2
            // 
            this.EnglishClassDBtestDataSet2.DataSetName = "EnglishClassDBtestDataSet2";
            this.EnglishClassDBtestDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(260, 12);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 8;
            this.btn_Add.Text = "新增";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(359, 12);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "修改";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // table_ClassScheduleTableAdapter
            // 
            this.table_ClassScheduleTableAdapter.ClearBeforeFill = true;
            // 
            // table_SelectParamTableAdapter
            // 
            this.table_SelectParamTableAdapter.ClearBeforeFill = true;
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(464, 12);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 23);
            this.btn_Del.TabIndex = 10;
            this.btn_Del.Text = "刪除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // frmClassScheduleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 570);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ClassName);
            this.Name = "frmClassScheduleSetting";
            this.Text = "frmClassScheduleSetting";
            this.Load += new System.EventHandler(this.frmClassScheduleSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableSelectParamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishClassDBtestDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableClassScheduleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishClassDBtestDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ClassName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_update;
        private EnglishClassDBtestDataSet2 EnglishClassDBtestDataSet2;
        private System.Windows.Forms.BindingSource tableClassScheduleBindingSource;
        private EnglishClassDBtestDataSet3 EnglishClassDBtestDataSet3;
        private System.Windows.Forms.BindingSource tableSelectParamBindingSource;
        private EnglishClassDBtestDataSet3TableAdapters.Table_SelectParamTableAdapter table_SelectParamTableAdapter;
        private System.Windows.Forms.Button btn_Del;
        private EnglishClassDBtestDataSet2TableAdapters.Table_ClassScheduleTableAdapter table_ClassScheduleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn classIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn classNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn classStartHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn classStartMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn classEndHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn classEndMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn noteTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sUNDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mONDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tUEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn wEDDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tHUDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fRIDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sATDataGridViewCheckBoxColumn;
    }
}