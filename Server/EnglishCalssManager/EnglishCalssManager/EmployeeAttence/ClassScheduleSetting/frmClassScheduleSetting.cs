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

namespace EnglishClassManager.EmployeeAttence.ClassScheduleSetting
{
    public partial class frmClassScheduleSetting : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        private string _updateID = "";
        public frmClassScheduleSetting()
        {
            InitializeComponent();
            //refreshTable();
        }

        private void frmClassScheduleSetting_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'EnglishClassDBtestDataSet3.Table_SelectParam' 資料表。您可以視需要進行移動或移除。
            this.table_SelectParamTableAdapter.Fill(this.EnglishClassDBtestDataSet3.Table_SelectParam);
            // TODO: 這行程式碼會將資料載入 'EnglishClassDBtestDataSet2.Table_ClassSchedule' 資料表。您可以視需要進行移動或移除。
            this.table_ClassScheduleTableAdapter.Fill(this.EnglishClassDBtestDataSet2.Table_ClassSchedule);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            //frmfrmClassScheduleUpdate _frmfrmClassScheduleUpdate = new frmfrmClassScheduleUpdate();
            //_frmfrmClassScheduleUpdate.ShowDialog();

            string CommandStr = string.Format("Select Count(*) from Table_ClassSchedule where Table_ClassSchedule.ClassID='{0}' ", txt_ClassName.Text);
            string ReClassName = dbc.strExecuteScalar(CommandStr);
            if (ReClassName == "0")
            {
                DataTable _dataTable = new DataTable();
                CommandStr = string.Format("Insert into Table_ClassSchedule Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')"
                  , txt_ClassName.Text,
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString());
                _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            }
            else
            {
                MessageBox.Show("班級ID重複！");
            }
            refreshTable();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("update Table_ClassSchedule set " +
                          " ClassID='{0}', ClassName='{1}', ClassStartH='{2}', ClassStartM='{3}' " +
                          ", ClassEndH='{4}',ClassEndM='{5}',NoteTime='{6}',SUN='{7}',MON='{8}',TUE='{9}',WED='{10}',THU='{11}',FRI='{12}', SAT='{13}'"
                          + " where ClassID='{14}'"
                          , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString(),
                          _updateID
                          );
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            refreshTable();
        }
        private void btn_Del_Click(object sender, EventArgs e)
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("Delete from Table_ClassSchedule Where ClassID='{0}'",
                 dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            refreshTable();
        }
        public void refreshTable()
        {
            // TODO: 這行程式碼會將資料載入 'EnglishClassDBtestDataSet3.Table_SelectParam' 資料表。您可以視需要進行移動或移除。
            this.table_SelectParamTableAdapter.Fill(this.EnglishClassDBtestDataSet3.Table_SelectParam);
            // TODO: 這行程式碼會將資料載入 'EnglishClassDBtestDataSet2.Table_ClassSchedule' 資料表。您可以視需要進行移動或移除。
            this.table_ClassScheduleTableAdapter.Fill(this.EnglishClassDBtestDataSet2.Table_ClassSchedule);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _updateID = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
        }
    }
}
