using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCalssManager.Broadcast.CardNotice
{
    public partial class frmCardNotice : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public frmCardNotice()
        {
            InitializeComponent();
        }

        private void frmCardNotice_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            //dtBK = (DataTable)dataGridView1.DataSource;
            //列出班別ID
            string CommandStr = "Select * from Table_CardNoticeSet";
            _dataTable = dbc.CommandFunctionDB("Table_CardNoticeSet", CommandStr);
            dataGridView1.DataSource = _dataTable;
            this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;//(資料內容)
            this.dataGridView1.AutoResizeColumns();
            //this.dataGridView1.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dataGridView1.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;   
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;// (標題列)
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.Columns[2].Width = (dataGridView1.Width) * 65 / 100;
            this.dataGridView1.Refresh();
            dgBtn();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable _dataTable = new DataTable();

            string CommandStr = string.Format("select count(*) from EnglishClassDBtest.dbo.Table_CardNoticeSet where EnglishClassDBtest.dbo.Table_CardNoticeSet.numCardMsg='{0}'", txtMsgID.Text);
            string _msgID = dbc.strExecuteScalar(CommandStr);
            if (txtMsgID.Text != "")
            {
                if (_msgID == "0")
                {
                    CommandStr = string.Format("Insert into Table_CardNoticeSet Values ('{0}','{1}','{2}')", txtMsgID.Text, txtMsgName.Text, txtMsg.Text);
                    _dataTable = dbc.CommandFunctionDB("Table_Message", CommandStr);
                    refreshTable();
                }
                else
                {
                    MessageBox.Show("訊息編號已重覆！");
                }

            }
            else
            {
                MessageBox.Show("請輸入訊息編號");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3:
                    dgCopymsg(e.RowIndex, e.ColumnIndex);
                    refreshTable();
                    //MessageBox.Show(e.RowIndex.ToString() + ";;;" + e.ColumnIndex.ToString());
                    break;
                case 4:
                    dgEditmsg(e.RowIndex);
                    refreshTable();
                    //MessageBox.Show(e.RowIndex.ToString() + ";;;" + e.ColumnIndex.ToString());
                    break;
                case 5:
                    dgDelmsg(e.RowIndex);
                    refreshTable();
                    //MessageBox.Show(e.RowIndex.ToString() + ";;;" + e.ColumnIndex.ToString());
                    break;
            }
        }

        private void dgCopymsg(int _rowIndex, int _columnsIndex)
        {
            txtMsgName.Text = dataGridView1.Rows[_rowIndex].Cells["CardTitle"].Value.ToString();
            txtMsg.Text = dataGridView1.Rows[_rowIndex].Cells["CardMsg"].Value.ToString();
        }

        private void dgEditmsg(int _rowIndex)
        {
            //update
            string CommandStr = string.Format(
           "Update Table_CardNoticeSet"
           + " Set CardTitle='{0}',CardMsg='{1}'"
           + " Where numCardMsg='{2}'"
           , dataGridView1.Rows[_rowIndex].Cells["CardTitle"].Value.ToString(), dataGridView1.Rows[_rowIndex].Cells["CardMsg"].Value.ToString(), dataGridView1.Rows[_rowIndex].Cells["numCardMsg"].Value.ToString());
            dbc.ExecuteNonQuery(CommandStr);
        }

        private void dgDelmsg(int _rowIndex)
        {
            string CommandStr = string.Format(
          "Delete from Table_CardNoticeSet"
          + " Where numCardMsg='{0}'"
          , dataGridView1.Rows[_rowIndex].Cells["numCardMsg"].Value.ToString());
            dbc.ExecuteNonQuery(CommandStr);
        }

        private void dgBtn()
        {
            if (this.dataGridView1.Columns.Count > 3)
            {
                //this.dataGridView1.Columns.RemoveAt(4);
                //this.dataGridView1.Columns.RemoveAt(4);
                //this.dataGridView1.Columns.RemoveAt(4);
                this.dataGridView1.Columns.Remove(this.dgBtnCopy);
                this.dataGridView1.Columns.Remove(this.dgBtnEdit);
                this.dataGridView1.Columns.Remove(this.dgBtnDel);
            }

            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgBtnCopy, this.dgBtnEdit, this.dgBtnDel });

            this.dgBtnCopy.HeaderText = "複製";
            this.dgBtnCopy.Name = "dgBtnCopy";
            this.dgBtnCopy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBtnCopy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgBtnCopy.Text = "複製";
            this.dgBtnCopy.UseColumnTextForButtonValue = true;
            this.dgBtnCopy.Width = 80;
            this.dgBtnCopy.DisplayIndex = 3;

            this.dgBtnEdit.HeaderText = "修改";
            this.dgBtnEdit.Name = "dgBtnEdit";
            this.dgBtnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBtnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgBtnEdit.Text = "修改";
            this.dgBtnEdit.UseColumnTextForButtonValue = true;
            this.dgBtnEdit.Width = 80;
            this.dgBtnEdit.DisplayIndex = 4;

            this.dgBtnDel.HeaderText = "刪除";
            this.dgBtnDel.Name = "dgBtnDel";
            this.dgBtnDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBtnDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgBtnDel.Text = "刪除";
            this.dgBtnDel.UseColumnTextForButtonValue = true;
            this.dgBtnDel.Width = 80;
            this.dgBtnDel.DisplayIndex = 5;

            //this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgBtnCopy, this.dgBtnEdit, this.dgBtnDel });
            //this.dataGridView1.Columns.Insert(4, this.dgBtnCopy);
            //this.dataGridView1.Columns.Insert(5, this.dgBtnEdit);
            //this.dataGridView1.Columns.Insert(6, this.dgBtnDel);

        }

      
    }
}
