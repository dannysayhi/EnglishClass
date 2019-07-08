using AOISystem.Utility.Logging;
using EnglishCalssManager.Rollcall.StudentRollcall;
using EnglishClassManager.Utility.Database;
using EnglishCalssManager.Broadcast.CardNotice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnglishCalssManager.Utility.FireBaseSharp;
using AOISystem.Utility.Account;

namespace EnglishClassManager.Rollcall.StudentRollcall
{
    public partial class frmStudentRollcall : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public DatabaseCoreRollcall dbcR = DatabaseManager._databaseCoreRollcall;
        private funFireBaseSharp _funFireBaseSharp = new funFireBaseSharp();
        private string managerName = AccountInfoManager.ActiveAccountName;
        private string _senderPhone = "";
        private List<CardMsgs> cardManager = new List<CardMsgs>();
        private string date = functionStudentRollcall.getDate;
        public string _studentName = "";
        public string _studentID = "";
        public string _courseID = "";
        public int _rollcallCount = 0;
        private string logTitle = "frmStudentRollcall：";
        public frmStudentRollcall()
        {
            InitializeComponent();

        }

        private void frmStudentRollcall_Load(object sender, EventArgs e)
        {
            Log.Trace(logTitle + "frmStudentRollcall_Load");
            string CommandStr = string.Format("Select PhoneNumber from Table_EmployeeBasic where TwName='{0}'", managerName);
            _senderPhone = dbc.strExecuteScalar(CommandStr);
            CreateTable();
            DataTable _dataTable = new DataTable();
            CommandStr = "Select CourseName from Table_Course";
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
            Log.Trace(logTitle + btn_ON.Name.ToString());
            try
            {
                foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                {
                    if (oneCell.Selected)
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
    , dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString());
                _rollcallCount = 0;
                string _getCount = functionStudentRollcall.getCount(date, dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString());

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
                        , dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString()
                        );
                        dbcR.ExecuteNonQuery(CommandStr);
                        functionStudentRollcall.studRCstart(date, dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString(), "1", "M");
                        string msg = CardNotice.SendNotificationFromFirebaseCloud("人工點名通知", dataGridView1.Rows[oneCell.RowIndex].Cells["TwName"].Value.ToString() + "第1次點名成功！--人工點名通知").ToString();

                                //Firebase Start!
                                insertFirebase(dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString(), "人工點名通知", "第" + _getCount + "次點名成功--人工點名通知！");

                                MessageBox.Show(dataGridView1.Rows[oneCell.RowIndex].Cells["TwName"].Value.ToString() + "第1次點名成功！--人工點名通知", "人工點名通知");
                     }
                            else
                    {

                                //判斷第二次點名以上的時間是否>通知區間
                                CommandStr = string.Format("select EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallTimes "
            + " from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
            + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID = '{1}'", date
            , dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString());

                                string strdt1 = dbcR.strExecuteScalar(CommandStr);
                                //MessageBox.Show(strdt1);
                                DateTime dtRollcall = Convert.ToDateTime(strdt1);
                                // dtRollcall = DateTime.ParseExact(dtRollcall.ToString(), "yyyy-MM-dd HH:mm:ss", null);
                                if (new TimeSpan(DateTime.Now.Ticks - dtRollcall.Ticks).TotalMinutes > 0)
                                {
                                    _getCount = (Convert.ToInt16(_getCount) + 1).ToString();
                                    functionStudentRollcall.studRCstart(date, dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString(), _getCount, "M");
                                    string msg = CardNotice.SendNotificationFromFirebaseCloud("人工點名通知", dataGridView1.Rows[oneCell.RowIndex].Cells["TwName"].Value.ToString() + "第" + _getCount + "次點名成功！--人工點名通知").ToString();
                                    
                                    //Firebase Start!
                                    insertFirebase(dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString(), "人工點名通知", "第" + _getCount + "次點名成功--人工點名通知！");

                                    MessageBox.Show(dataGridView1.Rows[oneCell.RowIndex].Cells["TwName"].Value.ToString() + "第" + _getCount + "次點名成功--人工點名通知！", "人工點名通知");
                                }
                            }
                        }
                        else
                {
                            _getCount = "0";
                            _getCount = (Convert.ToInt16(_getCount) + 1).ToString();

                            functionStudentRollcall.studRCstart(date, dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString(), _getCount, "M");
                            string msg = CardNotice.SendNotificationFromFirebaseCloud("人工點名通知", dataGridView1.Rows[oneCell.RowIndex].Cells["TwName"].Value.ToString() + "第" + _getCount + "次點名成功！--人工點名通知").ToString();

                            //Firebase Start!
                            insertFirebase(dataGridView1.Rows[oneCell.RowIndex].Cells["StudentID"].Value.ToString(), "人工點名通知", "第" + _getCount + "次點名成功--人工點名通知！");

                            MessageBox.Show(dataGridView1.Rows[oneCell.RowIndex].Cells["TwName"].Value.ToString() + "第" + _getCount + "次點名成功--人工點名通知！", "人工點名通知");
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log.Trace(logTitle +  btn_ON.Name.ToString()+"："+ex.ToString());
            }
            refreshTable();
        }

        private void btn_OFF_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btn_OFF.Name.ToString());
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
                    functionStudentRollcall.studRCstart(date, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString(), "未到", "M");
                    string msg = CardNotice.SendNotificationFromFirebaseCloud("點名通知", dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["TwName"].Value.ToString() + "未出席！");
                    MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["TwName"].Value.ToString() + "未出席！", "點名通知");
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
                Log.Trace(logTitle + btn_OFF.Name.ToString() + "：" + ex.ToString());
            }
            refreshTable();
        }

        private void btn_Leave_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btn_Leave.Name.ToString());
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
                    functionStudentRollcall.studRCstart(date, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["StudentID"].Value.ToString(), "請假", "M");
                    string msg = CardNotice.SendNotificationFromFirebaseCloud("點名通知", dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["TwName"].Value.ToString() + "請假！");
                    MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["TwName"].Value.ToString() + "請假！", "點名通知");
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
                Log.Trace(logTitle + btn_Leave.Name.ToString() + "：" + ex.ToString());
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
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Visible = true;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    if (row.Cells[3].Value.ToString() == ""|| row.Cells[3].Value.ToString() == "未到")
                    {
                        row.Cells[1].Style.BackColor = Color.Red;
                    }
                }
            }


            this.dataGridView1.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
            //createTempTable();
            closeTempTable();

        }

        private void insertFirebase(string _studentID,string _title,string _content)
        {
            string _name = "";
            string _phoneNum = "";

            //get Student Name、phoneNum
            string CommandStr = string.Format("Select Table_StudentBasic.TwName,Table_StudentBasic.PhoneNumber from Table_StudentBasic where Table_StudentBasic.StudentID='{0}'", _studentID);
            DataTable _dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);
            int i = 0;
            _name = _dataTable.Rows[0].ItemArray[0].ToString();
            _phoneNum = _dataTable.Rows[0].ItemArray[1].ToString();

            //mapping title、content
            CardMsgs _CardMsgs = new CardMsgs();
            _CardMsgs.content = _content;
            _CardMsgs.student = _name;
            _CardMsgs.title = _title;
            _CardMsgs.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var data_user_parents = new ListCardMsg
            {
                CardMsgs = new List<CardMsgs> { _CardMsgs }
            };


            insertFirebaseTable("User/" + _phoneNum, data_user_parents);//insert parents
        }

        public void insertFirebaseTable(string _Firetable, object _data)
        {
            _funFireBaseSharp.connection();
            _funFireBaseSharp.update(_Firetable, _data);
            _funFireBaseSharp.disconnection();
        }

        public void insertFirebaseTable_push(string _Firetable, object _data)
        {
            _funFireBaseSharp.connection();
            //_funFireBaseSharp.insert(_Firetable, _data);
            _funFireBaseSharp.push(_Firetable,_data);
            _funFireBaseSharp.disconnection();
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
