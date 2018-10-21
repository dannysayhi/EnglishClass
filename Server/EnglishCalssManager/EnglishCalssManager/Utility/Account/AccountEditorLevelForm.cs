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

namespace EnglishCalssManager.Utility.Account
{
    public partial class AccountEditorLevelForm : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;

        public AccountEditorLevelForm()
        {
            InitializeComponent();
        }

        private void AccountEditorLevelForm_Load(object sender, EventArgs e)
        {
            refreshTable();
        }
        public void refreshTable()
        {
            replaceTable();
            int i = 0;
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select * from Table_AuthorityManagement";
            _dataTable = dbc.CommandFunctionDB("EnglishClassDBtest", CommandStr);
            
            foreach (DataRow drw in _dataTable.Rows)
            {
                dataGridView1.Rows.Insert(i, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString());
                i++;
            }
        }

        private void replaceTable()
        {
            if (dataGridView1.Rows.Count > 1)
            {
                while (dataGridView1.Rows.Count != 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("update Table_AuthorityManagement set " +
                          " FunctionName='{0}', AccountLevel='{1}' "
                          + " where FunctionName='{0}'"
                          , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString()
                          );
            _dataTable = dbc.CommandFunctionDB("Table_AuthorityManagement", CommandStr);
            refreshTable();
        }
        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

       
    }
}