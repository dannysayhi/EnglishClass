namespace AOISystem.Utility.Logging
{
    partial class uctrlTactTimeTable
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvTactTime = new System.Windows.Forms.DataGridView();
            this.colDataNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTactTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTactTimeAverage = new System.Windows.Forms.TextBox();
            this.labTactTimeAverage = new System.Windows.Forms.Label();
            this.txtCurrectTactTime = new System.Windows.Forms.TextBox();
            this.txtProgramOpenTime = new System.Windows.Forms.TextBox();
            this.labCurrectTactTime = new System.Windows.Forms.Label();
            this.timerCurrectTactTimeRefresh = new System.Windows.Forms.Timer(this.components);
            this.tlpTactTimeBase = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTactTimelist = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTactTime)).BeginInit();
            this.tlpTactTimeBase.SuspendLayout();
            this.tlpTactTimelist.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTactTime
            // 
            this.dgvTactTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTactTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDataNo,
            this.colTactTime});
            this.dgvTactTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTactTime.Location = new System.Drawing.Point(4, 4);
            this.dgvTactTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTactTime.Name = "dgvTactTime";
            this.dgvTactTime.RowTemplate.Height = 24;
            this.dgvTactTime.Size = new System.Drawing.Size(248, 380);
            this.dgvTactTime.TabIndex = 0;
            // 
            // colDataNo
            // 
            this.colDataNo.HeaderText = "";
            this.colDataNo.Name = "colDataNo";
            this.colDataNo.ReadOnly = true;
            this.colDataNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDataNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDataNo.Width = 50;
            // 
            // colTactTime
            // 
            this.colTactTime.HeaderText = "Tact Time(s)";
            this.colTactTime.Name = "colTactTime";
            this.colTactTime.ReadOnly = true;
            this.colTactTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTactTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTactTime.Width = 90;
            // 
            // txtTactTimeAverage
            // 
            this.txtTactTimeAverage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTactTimeAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTactTimeAverage.Enabled = false;
            this.txtTactTimeAverage.Location = new System.Drawing.Point(4, 79);
            this.txtTactTimeAverage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTactTimeAverage.Name = "txtTactTimeAverage";
            this.txtTactTimeAverage.Size = new System.Drawing.Size(256, 18);
            this.txtTactTimeAverage.TabIndex = 1;
            // 
            // labTactTimeAverage
            // 
            this.labTactTimeAverage.AutoSize = true;
            this.labTactTimeAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTactTimeAverage.Location = new System.Drawing.Point(0, 50);
            this.labTactTimeAverage.Margin = new System.Windows.Forms.Padding(0);
            this.labTactTimeAverage.Name = "labTactTimeAverage";
            this.labTactTimeAverage.Size = new System.Drawing.Size(264, 25);
            this.labTactTimeAverage.TabIndex = 2;
            this.labTactTimeAverage.Text = "平均(s)：";
            this.labTactTimeAverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrectTactTime
            // 
            this.txtCurrectTactTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrectTactTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurrectTactTime.Enabled = false;
            this.txtCurrectTactTime.Location = new System.Drawing.Point(4, 29);
            this.txtCurrectTactTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCurrectTactTime.Name = "txtCurrectTactTime";
            this.txtCurrectTactTime.Size = new System.Drawing.Size(256, 18);
            this.txtCurrectTactTime.TabIndex = 3;
            // 
            // txtProgramOpenTime
            // 
            this.txtProgramOpenTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProgramOpenTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgramOpenTime.Enabled = false;
            this.txtProgramOpenTime.Location = new System.Drawing.Point(5, 5);
            this.txtProgramOpenTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProgramOpenTime.Name = "txtProgramOpenTime";
            this.txtProgramOpenTime.Size = new System.Drawing.Size(528, 18);
            this.txtProgramOpenTime.TabIndex = 5;
            this.txtProgramOpenTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labCurrectTactTime
            // 
            this.labCurrectTactTime.AutoSize = true;
            this.labCurrectTactTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCurrectTactTime.Location = new System.Drawing.Point(0, 0);
            this.labCurrectTactTime.Margin = new System.Windows.Forms.Padding(0);
            this.labCurrectTactTime.Name = "labCurrectTactTime";
            this.labCurrectTactTime.Size = new System.Drawing.Size(264, 25);
            this.labCurrectTactTime.TabIndex = 6;
            this.labCurrectTactTime.Text = "計時(s)：";
            this.labCurrectTactTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerCurrectTactTimeRefresh
            // 
            this.timerCurrectTactTimeRefresh.Tick += new System.EventHandler(this.timerCurrectTactTimeRefresh_Tick);
            // 
            // tlpTactTimeBase
            // 
            this.tlpTactTimeBase.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpTactTimeBase.ColumnCount = 1;
            this.tlpTactTimeBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 536F));
            this.tlpTactTimeBase.Controls.Add(this.txtProgramOpenTime, 0, 0);
            this.tlpTactTimeBase.Controls.Add(this.tlpTactTimelist, 0, 1);
            this.tlpTactTimeBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTactTimeBase.Location = new System.Drawing.Point(0, 0);
            this.tlpTactTimeBase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpTactTimeBase.Name = "tlpTactTimeBase";
            this.tlpTactTimeBase.RowCount = 2;
            this.tlpTactTimeBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpTactTimeBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpTactTimeBase.Size = new System.Drawing.Size(533, 424);
            this.tlpTactTimeBase.TabIndex = 7;
            // 
            // tlpTactTimelist
            // 
            this.tlpTactTimelist.ColumnCount = 2;
            this.tlpTactTimelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tlpTactTimelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTactTimelist.Controls.Add(this.dgvTactTime, 0, 0);
            this.tlpTactTimelist.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlpTactTimelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTactTimelist.Location = new System.Drawing.Point(5, 31);
            this.tlpTactTimelist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpTactTimelist.Name = "tlpTactTimelist";
            this.tlpTactTimelist.RowCount = 1;
            this.tlpTactTimelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTactTimelist.Size = new System.Drawing.Size(528, 388);
            this.tlpTactTimelist.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labCurrectTactTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTactTimeAverage, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labTactTimeAverage, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCurrectTactTime, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(260, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 380);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // uctrlTactTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpTactTimeBase);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "uctrlTactTimeTable";
            this.Size = new System.Drawing.Size(533, 424);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTactTime)).EndInit();
            this.tlpTactTimeBase.ResumeLayout(false);
            this.tlpTactTimeBase.PerformLayout();
            this.tlpTactTimelist.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTactTime;
        private System.Windows.Forms.TextBox txtTactTimeAverage;
        private System.Windows.Forms.Label labTactTimeAverage;
        private System.Windows.Forms.TextBox txtCurrectTactTime;
        private System.Windows.Forms.TextBox txtProgramOpenTime;
        private System.Windows.Forms.Label labCurrectTactTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTactTime;
        private System.Windows.Forms.Timer timerCurrectTactTimeRefresh;
        private System.Windows.Forms.TableLayoutPanel tlpTactTimeBase;
        private System.Windows.Forms.TableLayoutPanel tlpTactTimelist;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
