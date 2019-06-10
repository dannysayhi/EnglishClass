﻿using AOISystem.Utility.Logging;
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
    public partial class frmCourseManagerUpdate : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        funFireBaseSharp _funFireBaseSharp = new funFireBaseSharp();
        public string cboxEplyName = "";
        public string cboxEplyID = "";
        public string courseID = "";
        private string startpage = "0";
        private int nextpage = 20;
        private string logTitle = "frmCourseManagerUpdate";
        private List<string> studentCourse = new List<string>();

        public frmCourseManagerUpdate(string cboxEplyID, string _cboxEplyName)
        {
            Log.Trace(logTitle);
            InitializeComponent();
            initailDGview();

            DataTable _dataTable = new DataTable();

            //Select EmployeeName add Cbox
            string CommandStr = "Select TwName from Table_EmployeeBasic";
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            cbox_EmplyName.Items.Add("所有人");
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_EmplyName.Items.Add(drw.ItemArray[0].ToString());
            }

            //Select Course Table to Cbox
            CommandStr = "Select CourseID,CourseName from Table_Course";
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_CourseID.Items.Add(drw.ItemArray[0].ToString());
                cbox_CourseName.Items.Add(drw.ItemArray[1].ToString());
            }
            cbox_CourseName.Text = cbox_CourseName.Items[0].ToString();

            refreshTable();
            //DataTable _dataTable = new DataTable();
            //string CommandStr = "Select CourseID,CourseName from Table_Course";
            //_dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            //foreach (DataRow drw in _dataTable.Rows)
            //{
            //    cbox_CourseName.Items.Add(drw.ItemArray[0].ToString());
            //    cbox_CourseID.Items.Add(drw.ItemArray[1].ToString());
            //    cbox_EmplyName.Items.Add(drw.ItemArray[2].ToString());
            //}
            //cbox_CourseName.Text = _cboxEplyName;
            //cboxEplyName = _cboxEplyName;

            //CommandStr = "Select TwName from Table_EmployeeBasic";
            //_dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            //foreach (DataRow drw in _dataTable.Rows)
            //{
            //    cbox_EmplyName.Items.Add(drw.ItemArray[0].ToString());
            //}
            refreshAllStudentInfo();
        }

        ~frmCourseManagerUpdate()
        {

        }

        private void frmCourseManagerUpdate_Load(object sender, EventArgs e)
        {
            refreshTable();
        }
       
        private void btn_Select_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btn_Select.Name.ToString());
            refreshStudentInfo();
        }

        private void cbox_EmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btn_Save.Name.ToString());
            string CommandStr = " Select Table_Course.CourseID "
+ " From Table_Course "
+ " Where  Table_Course.CourseName = '"
+ cbox_CourseName.Text.ToString()
+ "' ";
            DataTable _dataTable = new DataTable();
            _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            courseID = _dataTable.Rows[0][0].ToString();

            CommandStr = " Select Table_EmployeeBasic.EmployeeID,Table_EmployeeBasic.TwName "
+ " From Table_EmployeeBasic "
+ " Where  Table_EmployeeBasic.TwName = '"
+ cbox_EmplyName.Text.ToString()
+ "' ";
            _dataTable = new DataTable();
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            cboxEplyID = _dataTable.Rows[0][0].ToString();

            CommandStr = string.Format(" update Table_Course set EmployeeID='{0}',CourseIntro='{1}' Where CourseID = '{2}'", cboxEplyID, txt_CourseInto.Text, courseID);
            _dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);
            refreshTable();
        }

        private void btn_SelectAllStudent_Click(object sender, EventArgs e)
        {
            refreshAllStudentInfo();
        }

    private void btn_AddNewStudent_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btn_AddNewStudent.Name.ToString());
            DataTable _dataTable = new DataTable();
            string CommandStr;
            
            foreach (DataGridViewCell oneCell in dataGridView2.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    try
                    {
                        studentCourse.Clear();
                        // MessageBox.Show(oneCell.RowIndex.ToString());
                        CommandStr = string.Format("if not exists(select Table_CourseManagement.CourseID, Table_CourseManagement.StudentID "
                                                  + " from Table_CourseManagement"
                                                  + " where Table_CourseManagement.CourseID='{0}' and Table_CourseManagement.StudentID='{1}' )"
                                                  + " insert into Table_CourseManagement values('{2}', '{3}') ", cbox_CourseID.Text, dataGridView2.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString(),
                                                  cbox_CourseID.Text, dataGridView2.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString());
                        dbc.ExecuteNonQuery(CommandStr);

                        //select studentID in this Course
                        CommandStr = string.Format("select Table_CourseManagement.StudentID from Table_CourseManagement where Table_CourseManagement.CourseID='{0}'", cbox_CourseID.Text);
                        _dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);
                        foreach (DataRow drw in _dataTable.Rows)
                        {
                            CommandStr = string.Format("select Table_StudentBasic.PhoneNumber from Table_StudentBasic where Table_StudentBasic.StudentID='{0}'", drw.ItemArray[0].ToString());
                            studentCourse.Add(dbc.strExecuteScalar(CommandStr));
                        }
                    }
                    catch(Exception ex)
                    { }
                }
            }

             //delete Firebase
            _funFireBaseSharp.connection();
            _funFireBaseSharp.delete("Topic/Course_" + cbox_CourseID.Text);
            var data_TopicCourseID = new Course
            {
                subscribers = studentCourse,
            };
            _funFireBaseSharp.insert("Topic/Course_" + cbox_CourseID.Text, data_TopicCourseID);
            _funFireBaseSharp.disconnection();
            refreshTable();
            //dataGridView1.DataSource = _dataTable;
        }

        //private void btn_AddCourse_Click(object sender, EventArgs e)
        //{
        //    Log.Trace(logTitle + btn_AddCourse.Name.ToString());
        //    string CommandStr = string.Format("Select Max(CourseID) from Table_Course");
        //    int CourseIDmax = Convert.ToInt32( dbc.strExecuteScalar( CommandStr));
        //    CommandStr = string.Format(" Select Table_EmployeeBasic.EmployeeID From Table_EmployeeBasic  Where  Table_EmployeeBasic.TwName = '{0}'", cbox_NewEmplyName.Text);
        //    cboxEplyID = dbc.strExecuteScalar(CommandStr).ToString();
        //    CommandStr = string.Format("Insert into Table_Course Values('{0}','{1}','{2}','{3}','{4}')", CourseIDmax+1, txt_NewCourseName.Text,
        //        "","", Convert.ToInt32(cboxEplyID));
        //    dbc.ExecuteNonQuery(CommandStr);
        //    //MessageBox.Show(dbc.strExecuteScalar(CommandStr).ToString());
        //    refreshTableNewCourse();
        //}

        private void btn_DeleteStudent_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btn_DeleteStudent.Name.ToString());
            try
            {
                DataTable _dataTable = new DataTable();
                string CommandStr = string.Format("delete from Table_CourseManagement where StudentID='{0}' and CourseID='{1}'"
                           , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString()
                           , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString());
                _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);

                string strStuID = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string strCourseID = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();

                //select studentID in this Course
                studentCourse.Clear();
                CommandStr = string.Format("select Table_CourseManagement.StudentID from Table_CourseManagement where Table_CourseManagement.CourseID='{0}'", cbox_CourseID.Text);
                _dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);
                foreach (DataRow drw in _dataTable.Rows)
                {
                    CommandStr = string.Format("select Table_StudentBasic.PhoneNumber from Table_StudentBasic where Table_StudentBasic.StudentID='{0}'", drw.ItemArray[0].ToString());
                    studentCourse.Add(dbc.strExecuteScalar(CommandStr));
                }

                //delete Firebase
                _funFireBaseSharp.connection();
                _funFireBaseSharp.delete("Topic/Course_" + cbox_CourseID.Text);
                var data_TopicCourseID = new Course
                {
                    subscribers = studentCourse,
                };
                _funFireBaseSharp.insert("Topic/Course_" + cbox_CourseID.Text, data_TopicCourseID);
                _funFireBaseSharp.disconnection();

                refreshTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show("請點選要刪除的學生");
            }
           
        }
        private void insertFirebase()
        {
            // Insert to Firebase Course
            var data_Course = new Course
            {
                ID = cbox_CourseID.Text,
                Name = cbox_CourseID.Text,
            };
            _funFireBaseSharp.connection();
            _funFireBaseSharp.insert("Course/" + data_Course.ID, data_Course);

            // Insert to Firebase 
            var data_TopicCourseID = new Course
            {
                subscribers = new List<string> { "1", "2", "3" },
            };
            _funFireBaseSharp.insert("Topic/Course_" + cbox_CourseID.Text, data_TopicCourseID);
            _funFireBaseSharp.disconnection();
        }
        private void deleteFirebase(string _courseid)
        {
            _funFireBaseSharp.connection();
            _funFireBaseSharp.delete("Course/" + _courseid);
            _funFireBaseSharp.delete("Topic/Course_" + _courseid);
            _funFireBaseSharp.disconnection();
        }

        public void refreshTable()
        {

            //string CommandStr = string.Format("select * from Table_Course where Table_Course.CourseName='{0}'", cbox_CourseName.Text);
            // DataTable _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            // foreach (DataRow drw in _dataTable.Rows)
            // {
            //     cbox_CourseName.Items.Add(drw.ItemArray[0].ToString());
            //     cbox_CourseID.Items.Add(drw.ItemArray[1].ToString());
            //     cbox_EmplyName.Items.Add(drw.ItemArray[2].ToString());
            // }

            //Select Condition
            //Select Course ID
            //string CommandStr = string.Format("select Table_Course.CourseID from Table_Course where Table_Course.CourseName='{0}'", cbox_CourseName.Text);
            //cbox_CourseID.Text = dbc.strExecuteScalar(CommandStr);

            //Get Course ID/EmployeeID/
            string CommandStr = string.Format("select * from Table_Course where Table_Course.CourseName = '{0}'", cbox_CourseName.Text);
            DataTable _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            DataRow drw_temp = _dataTable.Rows[0];
            cbox_CourseID.Text = drw_temp.ItemArray[0].ToString();
            txt_CourseInto.Text = drw_temp.ItemArray[2].ToString();
            string EmployyID = drw_temp.ItemArray[4].ToString();

            //Get EmployeeName
            CommandStr = string.Format("select Table_EmployeeBasic.TwName from Table_EmployeeBasic where Table_EmployeeBasic.EmployeeID = '{0}'", EmployyID);
            string strEmployeeName = dbc.strExecuteScalar(CommandStr);
            cbox_EmplyName.Text = strEmployeeName;
            //Select union table
            CommandStr = string.Format("SELECT Table_CourseManagement.StudentID,Table_StudentBasic.CardNumber,Table_CourseManagement.CourseID,  Table_StudentBasic.TwName, Table_StudentBasic.EnName FROM Table_CourseManagement  LEFT OUTER JOIN Table_StudentBasic ON Table_CourseManagement.StudentID = Table_StudentBasic.StudentID  where  Table_CourseManagement.CourseID='{0}'", cbox_CourseID.Text);

            //            CommandStr = " Select Table_Course.EmployeeID "
            //   + " From Table_Course "
            //   + " Where  Table_Course.CourseName = '"
            //   + cbox_CourseName.Text.ToString()
            //   + "' ";
            //            cboxEplyID = dbc.strExecuteScalar(CommandStr);

            //            CommandStr = " Select Table_EmployeeBasic.TwName "
            //+ " From Table_EmployeeBasic "
            //+ " Where  Table_EmployeeBasic.EmployeeID = '"
            //+ cboxEplyID
            //+ "' ";
            //            cbox_EmplyName.Text = dbc.strExecuteScalar(CommandStr);

            //            CommandStr = " Select Table_Course.CourseID "
            //+ " From Table_Course "
            //+ " Where  Table_Course.CourseName = '"
            //+ cbox_CourseName.Text.ToString()
            //+ "' ";
            //            courseID = dbc.strExecuteScalar(CommandStr);


            //CommandStr = string.Format("SELECT Table_CourseManagement.StudentID,Table_StudentBasic.CardNumber,Table_CourseManagement.CourseID,"
            //    + " Table_StudentBasic.TwName, Table_StudentBasic.EnName FROM Table_CourseManagement "
            //    + " LEFT OUTER JOIN Table_StudentBasic ON Table_CourseManagement.StudentID = Table_StudentBasic.StudentID"
            //    + " where  Table_CourseManagement.CourseID='{0}'", courseID);
            _dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);
            //dataGridView1.DataSource = _dataTable;

            dataGridView1.Rows.Clear();//清空DG
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                this.dataGridView1.Rows.Insert(i, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString(), drw.ItemArray[2].ToString(), drw.ItemArray[3].ToString(), drw.ItemArray[4].ToString());
                i++;
            }

        }

//        public void refreshTableNewCourse()
//        {
//            cbox_CourseName.Text = txt_NewCourseName.Text;
//            cbox_EmplyName.Text = cbox_NewEmplyName.Text;
//            DataTable _dataTable = new DataTable();
//            string CommandStr = " Select Table_Course.EmployeeID "
//   + " From Table_Course "
//   + " Where  Table_Course.CourseName = '"
//   + cbox_CourseName.Text.ToString()
//   + "' ";
//            cboxEplyID = dbc.strExecuteScalar(CommandStr);

//            CommandStr = " Select Table_EmployeeBasic.TwName "
//+ " From Table_EmployeeBasic "
//+ " Where  Table_EmployeeBasic.EmployeeID = '"
//+ cboxEplyID
//+ "' ";
//            cbox_NewEmplyName.Text = dbc.strExecuteScalar(CommandStr);

//            CommandStr = " Select Table_Course.CourseID "
//+ " From Table_Course "
//+ " Where  Table_Course.CourseName = '"
//+ txt_NewCourseName.Text.ToString()
//+ "' ";
//            courseID = dbc.strExecuteScalar(CommandStr);


//            CommandStr = string.Format("SELECT Table_CourseManagement.StudentID,Table_StudentBasic.CardNumber,Table_CourseManagement.CourseID,"
//                + " Table_StudentBasic.TwName, Table_StudentBasic.EnName FROM Table_CourseManagement "
//                + " LEFT OUTER JOIN Table_StudentBasic ON Table_CourseManagement.StudentID = Table_StudentBasic.StudentID"
//                + " where  Table_CourseManagement.CourseID='{0}'", courseID);
//            _dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);
//            dataGridView1.DataSource = _dataTable;
//        }

        public void refreshAllStudentInfo()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = " Select Table_StudentBasic.StudentID"
               + ", Table_StudentBasic.CardNumber,"
               + " Table_StudentBasic.TwName, "
               + "Table_StudentBasic.EnName "
               + " From Table_StudentBasic"
               + " ORDER BY Table_StudentBasic.StudentID"
                + " OFFSET " + startpage + " ROWS"
                + " FETCH NEXT " + nextpage + " ROWS ONLY";
            _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
            dataGridView2.DataSource = _dataTable;
            lb_pageNum.Text = "第- " + ((Convert.ToInt16(startpage) / Convert.ToInt16(nextpage) + 1).ToString()) + " -頁";

        }

        public void refreshStudentInfo()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = " Select Table_StudentBasic.StudentID,Table_StudentBasic.CardNumber,"
                + " Table_StudentBasic.TwName, Table_StudentBasic.EnName "
   + " From Table_StudentBasic "
   + " Where  Table_StudentBasic.TwName like '%"
   + txt_TwName.Text.ToString()
   + "%' ";
            _dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);
            dataGridView2.DataSource = _dataTable;
        }

        private void initailDGview()
        {
            dataGridView1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height-250;
            dataGridView2.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 250;
        }

        private void lb_endpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Log.Trace(logTitle + lb_endpage.Name.ToString());
            startpage = (Convert.ToInt16(startpage) + nextpage).ToString();
            refreshAllStudentInfo();
        }

        private void lb_startpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Convert.ToInt16(startpage) > 4)
            {
                Log.Trace(logTitle + lb_startpage.Name.ToString());
                startpage = (Convert.ToInt16(startpage) - nextpage).ToString();
                refreshAllStudentInfo();
            }
        }

        private bool checkDataExist()
        {
            bool _bChk = false;
            object obj = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value;
            if(obj!=null)
            {
               _bChk=true;
            }
            return _bChk;
        }

    }
}
