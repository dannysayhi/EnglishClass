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
    public partial class frmfrmClassScheduleUpdate : Form
    {
        public frmfrmClassScheduleUpdate()
        {
            InitializeComponent();
        }

        private void frmfrmClassScheduleUpdate_Load(object sender, EventArgs e)
        {

        }

        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = " Select * from Table_ClassSchedule";
            //_dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            //..dataGridView1.DataSource = _dataTable;
        }

    }
}
