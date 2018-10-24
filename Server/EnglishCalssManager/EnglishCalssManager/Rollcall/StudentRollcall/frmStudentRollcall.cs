﻿using EnglishCalssManager.Rollcall.StudentRollcall;
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

namespace EnglishClassManager.Rollcall.StudentRollcall
{
    public partial class frmStudentRollcall : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public DatabaseCoreRollcall dbcR = DatabaseManager._databaseCoreRollcall;
        private string date = functionStudentRollcall.getDate;
        public string _studentName = "";
        public string _studentID = "";
        public string _courseID = "";
        public int _rollcallCount = 0;
        public frmStudentRollcall()
        {
            InitializeComponent();

        }

        private void frmStudentRollcall_Load(object sender, EventArgs e)
        {
            CreateTable();
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select CourseName from Table_Course";
            _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_CourseName.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_CourseName.Text = cbox_CourseName.Items[0].ToString();
            refreshTable();
            //cbox_CourseName.Text = _cboxEplyName;
            //cboxEplyName = _cboxEplyName;

            //CommandStr = "Select TwName from Table_EmployeeBasic";
            //_dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            //foreach (DataRow drw in _dataTable.Rows)
            //{
            //    cbox_EmplyName.Items.Add(drw.ItemArray[0].ToString());
            //    cbox_NewEmplyName.Items.Add(drw.ItemArray[0].ToString());
            //}
        }

        ~frmStudentRollcall()
        {
            //string CommandStr = "Drop Table #Studrollcall_temp";
            //dbcR.ExecuteNonQuery(CommandStr);
        }

        private void cbox_CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void btn_ON_Click(object sender, EventArgs e)
        {
            try
            {
                string CommandStr = " Select EnglishClassDBtest.dbo.Table_Course.CourseID "
+ " From EnglishClassDBtest.dbo.Table_Course "
+ " Where  EnglishClassDBtest.dbo.Table_Course.CourseName = '"
+ cbox_CourseName.Text.ToString()
+ "' ";
                _courseID = dbc.strExecuteScalar(CommandStr);//找出群組代碼
                CommandStr = string.Format("select EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallCount "
    + " from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID = '{1}'", date
    , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString());
                _rollcallCount = 0;
                string _getCount = functionStudentRollcall.getCount(date, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString());

                if (_getCount != "")
                {
                    if (_getCount == "請假" || _getCount == "未到")
                    {
                        CommandStr = string.Format(
                        "Update EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
                        + " Set RollcallCount='{1}',RollcallTimes={2}"
                        //+ " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CourseID={3}"
                        //+ " and "
                        + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID={4}"
                        , date
                        , "1"
                        , "SYSDATETIME()"
                        , _courseID
                        , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString()
                        );
                        dbcR.ExecuteNonQuery(CommandStr);
                        //MessageBox.Show("請假/未到");
                    }
                    else
                    {
                        _getCount = (Convert.ToInt16(_getCount) + 1).ToString();
                        functionStudentRollcall.studRCstart(date, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString(), _getCount, "M");
                        //functionStudentRollcall.studRCagain(date, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString(), _getCount);
                        //_rollcallCount = Convert.ToInt32(_getCount);
                        //CommandStr = string.Format(
                        //"Update EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
                        //+ " Set RollcallCount={1},RollcallTimes={2} "
                        ////+ " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CourseID={3}"
                        ////+ " and "
                        //+ " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID={4}"
                        //, date
                        //, (_rollcallCount + 1).ToString()
                        //, "SYSDATETIME()"
                        //, _courseID
                        //, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString()
                        //);
                        //dbcR.ExecuteNonQuery(CommandStr);
                        //MessageBox.Show("學生："+ dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString()+ "已點過" + _rollcallCount.ToString()+"次");
                    }
                }
                else
                {
                    _getCount = "0";
                    _getCount = (Convert.ToInt16(_getCount) + 1).ToString();
                    functionStudentRollcall.studRCstart(date, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString(), _getCount, "M");

                    //CommandStr = string.Format(
                    //    "insert into EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0} values('{1}', '{2}', '{3}', {4})"
                    //    , date
                    //    , _courseID
                    //    , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString()
                    //    , '1'
                    //    , "SYSDATETIME()"
                    //    );
                    //dbcR.ExecuteNonQuery(CommandStr);
                    //MessageBox.Show("學生：" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString() + "未點過" + _rollcallCount.ToString() + "次");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            refreshTable();
        }

        private void btn_OFF_Click(object sender, EventArgs e)
        {
            try
            {
                string CommandStr = " Select EnglishClassDBtest.dbo.Table_Course.CourseID "
    + " From EnglishClassDBtest.dbo.Table_Course "
    + " Where  EnglishClassDBtest.dbo.Table_Course.CourseName = '"
    + cbox_CourseName.Text.ToString()
    + "' ";
                _courseID = dbc.strExecuteScalar(CommandStr);//找出群組代碼
                CommandStr = string.Format("select EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallCount "
    + " from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID = '{1}'", date
    , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString());

                if (dbc.strExecuteScalar(CommandStr).ToString() != "")
                {
                    CommandStr = string.Format(
                    "Update EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
                    + " Set RollcallCount={1},RollcallTimes={2} "
                    // + " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CourseID={3}"
                    //+ " and"
                    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID={4}"
                    , date
                    , "'未到'"
                    , "SYSDATETIME()"
                    , _courseID
                    , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString()
                    );
                    dbcR.ExecuteNonQuery(CommandStr);
                }
                else if (dbc.strExecuteScalar(CommandStr).ToString() == "")
                {
                    CommandStr = string.Format(
                        "insert into EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0} values('{1}', '{2}', '{3}', {4},'M','')"
                        , date
                        , _courseID
                        , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString()
                        , "未到"
                        , "SYSDATETIME()"
                        );
                    dbcR.ExecuteNonQuery(CommandStr);
                }
                else if (dbc.strExecuteScalar(CommandStr).ToString() == "未到")
                {
                    MessageBox.Show("未到！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            refreshTable();
        }

        private void btn_Leave_Click(object sender, EventArgs e)
        {
            try
            {
                string CommandStr = " Select EnglishClassDBtest.dbo.Table_Course.CourseID "
    + " From EnglishClassDBtest.dbo.Table_Course "
    + " Where  EnglishClassDBtest.dbo.Table_Course.CourseName = '"
    + cbox_CourseName.Text.ToString()
    + "' ";
                _courseID = dbc.strExecuteScalar(CommandStr);//找出群組代碼
                CommandStr = string.Format("select EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallCount "
    + " from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID = '{1}'", date
    , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString());

                if (dbc.strExecuteScalar(CommandStr).ToString() != "")
                {
                    CommandStr = string.Format(
                    "Update EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
                    + " Set RollcallCount={1},RollcallTimes={2} "
                    // + " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CourseID={3},"
                    // + " and"
                    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID={4}"
                    , date
                    , "'請假'"
                    , "SYSDATETIME()"
                    , _courseID
                    , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString()
                    );
                    dbcR.ExecuteNonQuery(CommandStr);
                }
                else if (dbc.strExecuteScalar(CommandStr).ToString() == "")
                {
                    CommandStr = string.Format(
                        "insert into EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0} values('{1}', '{2}', '{3}', {4},'M','')"
                        , date
                        , _courseID
                        , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString()
                        , "請假"
                        , "SYSDATETIME()"
                        );
                    dbcR.ExecuteNonQuery(CommandStr);
                }
                else if (dbc.strExecuteScalar(CommandStr).ToString() == "請假")
                {
                    MessageBox.Show("已請假過了！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            refreshTable();
        }

        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();

            string CommandStr = " Select EnglishClassDBtest.dbo.Table_Course.CourseID "
  + " From EnglishClassDBtest.dbo.Table_Course "
  + " Where  EnglishClassDBtest.dbo.Table_Course.CourseName = '"
  + cbox_CourseName.Text.ToString()
  + "' ";
            ///搜尋當班學生是否點名
            _courseID = dbc.strExecuteScalar(CommandStr);
            string strtimeNow = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            string strtimeToday = DateTime.Today.ToString("yyyy.MM.dd HH:mm:ss");
             CommandStr = string.Format("Select EnglishClassDBtest.dbo.Table_CourseManagement.StudentID,EnglishClassDBtest.dbo.Table_StudentBasic.TwName,"
                +" EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallCount, "
                +" EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.Rollcalltimes,"
                + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallType,"
                + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallMsg"
+ " from EnglishClassDBtest.dbo.Table_CourseManagement"
+ " left outer join EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
+ " on EnglishClassDBtest.dbo.Table_CourseManagement.StudentID = EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID"
+ " left outer join EnglishClassDBtest.dbo.Table_StudentBasic"
+ " on EnglishClassDBtest.dbo.Table_StudentBasic.StudentID = EnglishClassDBtest.dbo.Table_CourseManagement.StudentID"
+ " where EnglishClassDBtest.dbo.Table_CourseManagement.CourseID = '{1}'", date, _courseID);

            //_dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);

            createTempTable("Studrollcall_temp0");
            createTempTable("Studrollcall_temp2");
            CommandStr = string.Format("Insert into #Studrollcall_temp0 "
             + " Select EnglishClassDBtest.dbo.Table_CourseManagement.CourseID,"
             + " EnglishClassDBtest.dbo.Table_CourseManagement.StudentID,"
             + " EnglishClassDBtest.dbo.Table_StudentBasic.TwName,"
             + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallCount, "
             + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.Rollcalltimes,"
             + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallType,"
             + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallMsg"
             + " from EnglishClassDBtest.dbo.Table_CourseManagement"
             + " left outer join EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
             + " on EnglishClassDBtest.dbo.Table_CourseManagement.StudentID = EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID"
             + " left outer join EnglishClassDBtest.dbo.Table_StudentBasic"
             + " on EnglishClassDBtest.dbo.Table_StudentBasic.StudentID = EnglishClassDBtest.dbo.Table_CourseManagement.StudentID"
             + " where EnglishClassDBtest.dbo.Table_CourseManagement.CourseID = '{1}'", date, _courseID);
            dbcR.ExecuteNonQueryCon(CommandStr, true);

            CommandStr = "select DISTINCT  StudentID into #Studrollcall_temp1 from #Studrollcall_temp0";
            dbcR.ExecuteNonQueryCon(CommandStr, true);

            CommandStr = string.Format("insert into #Studrollcall_temp2 Select * From #Studrollcall_temp0 Where [RollcallTimes] In (Select Max([RollcallTimes]) From #Studrollcall_temp0 Group By [StudentID])");
            dbcR.ExecuteNonQueryCon(CommandStr, true);

            CommandStr = string.Format("Select #Studrollcall_temp2.CourseID,#Studrollcall_temp1.StudentID,#Studrollcall_temp2.TwName,#Studrollcall_temp2.RollcallCount,#Studrollcall_temp2.RollcallTimes,#Studrollcall_temp2.RollcallType,#Studrollcall_temp2.RollcallMsg "
                    + " from #Studrollcall_temp1  left join #Studrollcall_temp2 on #Studrollcall_temp2.StudentID=#Studrollcall_temp1.StudentID"
                    + " left join  EnglishClassDBtest.dbo.Table_CardNoticeSet on Table_CardNoticeSet.numCardMsg=#Studrollcall_temp2.RollcallCount");
            _dataTable = dbcR.CommandFunctionTempDB("Table_CourseManagement", CommandStr, _dataTable, true);

            ///Rollcall Datatable to DB,and output Datatable
            //CommandStr = string.Format("select * into #Table_StudentRollcall_temp from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}", date);
            //_dataTable = dbc.CommandFunctionTempDB("Table_CourseManagement", CommandStr, _dataTable, true);
            //CommandStr = string.Format("SELECT #Table_StudentRollcall_temp.CourseID,#Table_StudentRollcall_temp.StudentID,#Table_StudentRollcall_temp.RollcallCount, MAX(#Table_StudentRollcall_temp.RollcallTimes),#Table_StudentRollcall_temp.RollcallType FROM #Table_StudentRollcall_temp "
            //+ " GROUP BY #Table_StudentRollcall_temp.CourseID,#Table_StudentRollcall_temp.StudentID,#Table_StudentRollcall_temp.RollcallCount,#Table_StudentRollcall_temp.RollcallType");

            //_dataTable = dbc.CommandFunctionTempDB("Table_CourseManagement", CommandStr, _dataTable, true);
            //dbcR.ExecuteNonQueryCon(CommandStr, true);
            //CommandStr = "select * from #Studrollcall_temp";
            //CommandStr = string.Format("Select * From #Studrollcall_temp Where [RollcallTimes] In (Select Max([RollcallTimes])"
             //   +" From #Studrollcall_temp Group By [StudentID])");

           // _dataTable = dbcR.CommandFunctionTempDB("Table_CourseManagement", CommandStr, _dataTable, true);

            dataGridView1.DataSource = _dataTable;
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
            //createTempTable();
            closeTempTable();

        }

        public void CreateTable()
        {
            baseStudentRollcall.CreateTable();
        }

        private void createTempTable(string numTemp)
        {
            string CommandStr = string.Format(" CREATE TABLE #{0}("
                             + " [CourseID] [int] ,"
                             + " [StudentID] [int] ,"
                             + " [TwName] [varchar](20) ,"
                             + " [RollcallCount]  [varchar](5) ,"
                             + " [RollcallTimes] [datetime] ,"
                             + " [RollcallType] [varchar](2), "
                             + " [RollcallMsg] [varchar](100) "
                             + " ) "
                             , numTemp);
            dbcR.ExecuteNonQueryCon(CommandStr,true);
        }

        private void closeTempTable()
        {
            string CommandStr = "Drop Table #Studrollcall_temp0";
            dbcR.ExecuteNonQueryCon(CommandStr, true);
            CommandStr = "Drop Table #Studrollcall_temp1";
            dbcR.ExecuteNonQueryCon(CommandStr, true);
            CommandStr = "Drop Table #Studrollcall_temp2";
            dbcR.ExecuteNonQueryCon(CommandStr,false);
        }

        private void frmStudentRollcall_FormClosed(object sender, FormClosedEventArgs e)
        {
            //string CommandStr = "Drop Table #Studrollcall_temp";
            //dbcR.ExecuteNonQuery(CommandStr);
        }
    }
}