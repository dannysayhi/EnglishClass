using AOISystem.Utility.Logging;
using EnglishCalssManager.SystemManager.CourseManagement;
using EnglishCalssManager.Utility.FireBaseSharp;
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
        funFireBaseSharp _funFireBaseSharp = new funFireBaseSharp();
        private string logTitle = "";
        public frmCourseManagement()
        {
            InitializeComponent();
            logTitle = this.Name + "群組管理：";
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

            _dataTable = new DataTable();

            //Select EmployeeName add Cbox
            CommandStr = "Select TwName from Table_EmployeeBasic";
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_NewEmplyName.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_NewEmplyName.Text = cbox_NewEmplyName.Items[0].ToString();
        }

        private void frmCourseManagement_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //refreshTable();
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
        private void btn_AddCourse_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btn_AddCourse.Name.ToString());
            string CommandStr = string.Format(" Select Table_EmployeeBasic.EmployeeID From Table_EmployeeBasic  Where  Table_EmployeeBasic.TwName = '{0}'", cbox_NewEmplyName.Text);
            string EmplyID = dbc.strExecuteScalar(CommandStr).ToString();
            CommandStr = string.Format("Insert into Table_Course Values('{0}','{1}','{2}','{3}','{4}')", txt_CourseID.Text, txt_CourseName.Text,
               txt_CourseIntro.Text, "", Convert.ToInt32(EmplyID));
            dbc.ExecuteNonQuery(CommandStr);
            //MessageBox.Show(dbc.strExecuteScalar(CommandStr).ToString());
            cbox_CourseName.Items.Add(txt_CourseName.Text);
            //insert to firebase
            insertFirebase();

            refreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定刪除此群組？", "警告！",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if(cbox_CourseName.Text!="全部")
                {
                    DataTable _dataTable = new DataTable();
                    string CommandStr = string.Format("select CourseID from Table_Course where CourseName='{0}'"
                               , cbox_CourseName.Text);
                    string _courseid = dbc.strExecuteScalar(CommandStr);
                    CommandStr = string.Format("delete from Table_Course where CourseID='{0}'"
                               , _courseid);
                    _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
                    CommandStr = string.Format("delete from Table_CourseManagement where CourseID='{0}'"
                               , _courseid);
                    _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
                    //refresh combox list
                    cbox_CourseName.Items.Remove(cbox_CourseName.Text);
                    cbox_CourseName.Text="全部";
                    //delete firebase table
                    deleteFirebase(_courseid);
                }
                
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
            //dataGridView1.DataSource = _dataTable;

            dataGridView1.Rows.Clear();//清空DG
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                this.dataGridView1.Rows.Insert(i, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString(), drw.ItemArray[2].ToString(), drw.ItemArray[3].ToString(), drw.ItemArray[4].ToString(), drw.ItemArray[5].ToString());
                i++;
            }

             CommandStr = string.Format("Select Max(CourseID) from Table_Course");
            int CourseIDmax = Convert.ToInt32(dbc.strExecuteScalar(CommandStr));
            txt_CourseID.Text = (CourseIDmax+1).ToString();

        }
        private void cbox_CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshTable();
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

       
        private void insertFirebase()
        {
            // Insert to Firebase Course
            var data_Course = new Course
            {
                ID = txt_CourseID.Text,
                Name = txt_CourseName.Text,
            };
            _funFireBaseSharp.connection();
            _funFireBaseSharp.insert("Course/" + data_Course.ID, data_Course);

            // Insert to Firebase 
            var data_TopicCourseID = new Course
            {
                subscribers = new List<string> {},
            };
            _funFireBaseSharp.insert("Topic/Course_" + txt_CourseID.Text, data_TopicCourseID);
            _funFireBaseSharp.disconnection();
        }
        private void deleteFirebase(string _courseid)
        {
            _funFireBaseSharp.connection();
            _funFireBaseSharp.delete("Course/" + _courseid);
            _funFireBaseSharp.delete("Topic/Course_" + _courseid);
            _funFireBaseSharp.disconnection();
        }
    }
    }
