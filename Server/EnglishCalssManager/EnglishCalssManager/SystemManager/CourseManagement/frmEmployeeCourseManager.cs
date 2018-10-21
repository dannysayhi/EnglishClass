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

namespace EnglishCalssManager.SystemManager.CourseManagement
{
    public partial class frmEmployeeCourseManager : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public frmEmployeeCourseManager()
        {
            InitializeComponent();
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select CourseName from Table_Course";
            _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            cbox_CourseName.Items.Add("全部");
            foreach (DataRow drw in _dataTable.Rows)
            {
                if (drw.ItemArray[0].ToString() != "")
                    cbox_CourseName.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_CourseName.Text = "全部";
        }

        private void frmEmployeeCourseManager_Load(object sender, EventArgs e)
        {
            refreshTable();
        }
        public void refreshTable()
        {
            string selCond = (cbox_CourseName.Text == "全部") ? "" : cbox_CourseName.Text;
            DataTable _dataTable = new DataTable();
            string CommandStr = "  Select Table_CourseManagement.CourseID,"
  + " Table_Course.CourseName ,"
  + " Table_CourseManagement.StudentID, "
  + "  Table_Course.EmployeeID  "
  + "  From Table_CourseManagement "
  + " left outer join Table_Course "
  + "  on Table_Course.CourseID=Table_CourseManagement.CourseID  "
  + "  left outer join Table_EmployeeBasic "
  + "  on Table_Course.EmployeeID=Table_EmployeeBasic.EmployeeID "
  + "Where  Table_Course.CourseName like '%"
  + selCond
  + "%' ";
            _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            dataGridViewSource.DataSource = _dataTable;
        }
    }
}
