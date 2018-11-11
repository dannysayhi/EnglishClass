using EnglishCalssManager.SystemManager.CourseManagement;
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

namespace EnglishClassManager.SystemManager.CourseManagement
{
    public partial class frmCourseManagement : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public frmCourseManagement()
        {
            InitializeComponent();

            DataTable _dataTable = new DataTable();
            string CommandStr = "Select CourseName from Table_Course";
            _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            cbox_CourseName.Items.Add("全部");
            foreach (DataRow drw in _dataTable.Rows)
            {
                if(drw.ItemArray[0].ToString()!="")
                cbox_CourseName.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_CourseName.Text = "全部";
        }

        private void frmCourseManagement_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCourseManagerUpdate _frmCourseManagerUpdate = new frmCourseManagerUpdate(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
            _frmCourseManagerUpdate.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            frmCourseManagerUpdate _frmCourseManagerUpdate = new frmCourseManagerUpdate(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
            _frmCourseManagerUpdate.ShowDialog();
            //refreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定刪除此群組？", "警告！",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DataTable _dataTable = new DataTable();
                string CommandStr = string.Format("delete from Table_Course where CourseID='{0}'"
                           , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
                CommandStr = string.Format("delete from Table_CourseManagement where CourseID='{0}'"
                           , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
            }
            else if (result == DialogResult.No)
            {
                //code for No
            }
            else if (result == DialogResult.Cancel)
            {
                //code for Cancel
            }

            
            refreshTable();
        }

        public void refreshTable()
        {
           string selCond = (cbox_CourseName.Text == "全部") ? "" : cbox_CourseName.Text;
            DataTable _dataTable = new DataTable();
              string CommandStr = "  Select Table_CourseManagement.CourseID,"
    + " Table_Course.CourseName ,"
    + " Table_CourseManagement.StudentID, "
    + " Table_StudentBasic.TwName,"
    + "  Table_Course.EmployeeID,  "
    + " Table_EmployeeBasic.TwName"
    + "  From Table_CourseManagement "
    + " left outer join Table_Course "
    + "  on Table_Course.CourseID=Table_CourseManagement.CourseID  "
    + "  left outer join Table_EmployeeBasic "
    + "  on Table_Course.EmployeeID=Table_EmployeeBasic.EmployeeID "
    + "  left outer join Table_StudentBasic  on Table_StudentBasic.StudentID=Table_CourseManagement.StudentID    "
    + "Where  Table_Course.CourseName like '%"
    + selCond
    + "%' ";
            _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            dataGridView1.DataSource = _dataTable;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void btn_EmployeeCourse_Click(object sender, EventArgs e)
        {
            frmEmployeeCourseManager _frmEmployeeCourseManager = new frmEmployeeCourseManager();
            _frmEmployeeCourseManager.Show();
        }
    }
}
