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

namespace EnglishCalssManager.SystemManager.MemberList.EmployeeBook
{
    public partial class frmDepPosEdit : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public frmDepPosEdit()
        {
            InitializeComponent();
        }

        private void frmDepPosEdit_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string CommandStr = string.Format("update Table_SelectParam set "
                + " Position = '{0}',Dept = '{1}'"
                + " where SN = '{2}'",
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            dbc.ExecuteNonQuery(CommandStr);
            refreshTable();
        }

        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select SN,Position,Dept from Table_SelectParam";
            _dataTable = dbc.CommandFunctionDB("Table_SelectParam", CommandStr);
            dataGridView1.DataSource = _dataTable;
        }
    }
}
