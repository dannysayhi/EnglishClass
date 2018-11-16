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

namespace EnglishCalssManager.EmployeeAttence.ClassScheduleSetting
{
    public partial class frmClassScheduleSettingNew : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        DataTable _dataTable = new DataTable();
        private string updateClassID = "";

        public frmClassScheduleSettingNew()
        {
            InitializeComponent();
            this.Location = new Point(200, 200);
            string CommandStr = "Select ClassID from Table_ClassSchedule";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
        }

        private void frmClassScheduleSettingNew_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refreshTable()
        {
            string CommandStr = "Select * from Table_ClassSchedule";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            dataGridView1.DataSource = _dataTable;
            ReSizeDG();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            chkbox_MON.Checked = (Boolean)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["MON"].Value;
            chkbox_TUE.Checked = (Boolean)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["TUE"].Value;
            chkbox_WED.Checked = (Boolean)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["WED"].Value;
            chkbox_THU.Checked = (Boolean)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["THU"].Value;
            chkbox_FRI.Checked = (Boolean)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["FRI"].Value;
            chkbox_SAT.Checked = (Boolean)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["SAT"].Value;
            chkbox_SUN.Checked = (Boolean)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["SUN"].Value;
            txt_ClassID.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ClassID"].Value.ToString();
            cbox_ClassName.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ClassName"].Value.ToString();
            cbox_ClassStartH.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ClassStartH"].Value.ToString();
            cbox_ClassStartM.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ClassStartM"].Value.ToString();
            cbox_ClassEndH.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ClassEndH"].Value.ToString();
            cbox_ClassEndM.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ClassEndM"].Value.ToString();
            cbox_NoteTime.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["NoteTime"].Value.ToString();
            updateClassID = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ClassID"].Value.ToString();
        }

        private void ReSizeDG()
        {
            this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;//(資料內容)
            this.dataGridView1.AutoResizeColumns();
            //this.dataGridView1.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dataGridView1.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;   
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;// (標題列)
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            //this.dataGridView1.Columns[3].Width = (dataGridView1.Width) * 65 / 100;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string CommandStr = string.Format("Select Count(*) from Table_ClassSchedule where Table_ClassSchedule.ClassID='{0}' ", txt_ClassID.Text);
            string ReClassName = dbc.strExecuteScalar(CommandStr);
            if (ReClassName == "0")
            {
                DataTable _dataTable = new DataTable();
                CommandStr = string.Format("Insert into Table_ClassSchedule Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')"
                  , txt_ClassID.Text,
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                             dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString(),
                             chkbox_SUN.Checked,chkbox_MON.Checked,chkbox_TUE.Checked,chkbox_WED.Checked,chkbox_THU.Checked,chkbox_FRI.Checked,chkbox_SAT.Checked  
                             );
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
                          , txt_ClassID.Text,
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString(),
                          chkbox_SUN.Checked, chkbox_MON.Checked, chkbox_TUE.Checked, chkbox_WED.Checked, chkbox_THU.Checked, chkbox_FRI.Checked, chkbox_SAT.Checked,
                          updateClassID);
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            refreshTable();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("Delete from Table_ClassSchedule Where ClassID='{0}'",
                 txt_ClassID.Text);
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            refreshTable();
        }
    }
}
