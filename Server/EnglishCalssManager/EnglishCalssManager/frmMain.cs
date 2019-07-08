﻿using AOISystem.Utility.Account;
using AOISystem.Utility.Logging;
using AOISystem.Utility.Logging.Presenter;
using EnglishCalssManager.Broadcast.CardNotice;
using EnglishCalssManager.Broadcast.HistoryMessage;
using EnglishCalssManager.Broadcast.ManualBroadcast;
using EnglishCalssManager.Broadcast.MessageSetting;
using EnglishCalssManager.EmployeeAttence.ClassEmployeeManager;
using EnglishCalssManager.EmployeeAttence.ClassScheduleManager;
using EnglishCalssManager.EmployeeAttence.ClassScheduleSetting;
using EnglishCalssManager.Report.EmployeeRecord;
using EnglishCalssManager.Report.StudentRecord;
using EnglishCalssManager.Rollcall.EmployeeRollcall;
using EnglishCalssManager.Rollcall.StudentRollcall;
using EnglishCalssManager.SystemConfig.SystemLog;
using EnglishCalssManager.Utility.Database;
using EnglishClassManager.EmployeeAttence.ClassScheduleManager;
using EnglishClassManager.EmployeeAttence.ClassScheduleSetting;
using EnglishClassManager.Rollcall.EmployeeRollcall;
using EnglishClassManager.Rollcall.StudentRollcall;
using EnglishClassManager.SystemManager.CourseManagement;
using EnglishClassManager.SystemManager.MemberList.EmployeeBook;
using EnglishClassManager.SystemManager.MemberList.StudentBook;
using EnglishClassManager.Utility.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartCardSystem;
using EnglishCalssManager.Utility.FireBaseSharp;

namespace EnglishClassManager
{
    public partial class frmMain : Form
    {
        frmSystemLog _frmSystemLog = new frmSystemLog();
      
        public bool IsScanSsy = false;
        public DatabaseCore dbc;// = DatabaseManager._databaseCore;
        public DatabaseTable dbt;// = DatabaseManager._databaseTable;
        public DatabaseCoreRollcall dbcR;// = DatabaseManager._databaseCoreRollcall;
        private List<Data> _vehicles_new = new List<Data>();
        private string _accountPhoneNum;
        //public CardNotice ;
        private bool _isMaintaining = false;       // 現在是否Maintaning
        public System.Windows.Forms.ToolStripMenuItem[] _T = new System.Windows.Forms.ToolStripMenuItem[23];
        private Hashtable _TH;
        private string[] _Ts = new string[23];
        private int _dbinitialcount = 0;

        //一定要声明成局部变量以保持对Timer的引用，否则会被垃圾收集器回收！
         private System.Threading.Timer timer_do;
        //一定要声明成局部变量以保持对Timer的引用，否则会被垃圾收集器回收！
        private System.Threading.Timer timer_smartCardReader;
        //一定要声明成局部变量以保持对Timer的引用，否则会被垃圾收集器回收！
        private System.Threading.Timer timer_pickup;

        //private string funcStudRCdate = functionStudentRollcall.getDate;
        funFireBaseSharp _funFireBaseSharp = new funFireBaseSharp();

        public frmMain()
        {
            InitializeComponent();
            _frmSystemLog.FormClosing += _frmSystemLog_FormClosing;
            _frmSystemLog.Show();
            
            label1.Text = "現在時間： xxxx ";
            DatabaseManager.Initialize();
            AccountInfoManager.IsTestMode = true;
            AccountInfoManager.AccountInfoLogInOutCallback += new Action<string, AccountLevel>(AccountInfoManager_AccountInfoLogInOutCallback);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Log.SetLogFile("EnglishClass", "log",90);
            Log.Trace("start log");
            dbc = DatabaseManager._databaseCore;
            dbt = DatabaseManager._databaseTable;
            dbcR = DatabaseManager._databaseCoreRollcall;
            initialComp();
            initialTalbe();
            if (!_funFireBaseSharp.IsConnect()) 
             _funFireBaseSharp.connection();



            //宣告timer要做什麼事.要做什麼事呢?要做_do的事
            TimerCallback callback = new TimerCallback(_do);
            //1.function 2.開關  3.等多久再開始  4.隔多久反覆執行
            timer_do = new System.Threading.Timer(callback, null, 0, 600000);


            //宣告timer要做什麼事.要做什麼事呢?要做_do的事
            TimerCallback callbackSmartCardReader = new TimerCallback(_doSmartCardReader);
            //1.function 2.開關  3.等多久再開始  4.隔多久反覆執行
            timer_smartCardReader = new System.Threading.Timer(callbackSmartCardReader, null, 0, 2500);

            //宣告timer要做什麼事.要做什麼事呢?要做_do的事
            TimerCallback callbackpickup = new TimerCallback(_pickupNotice);
            //1.function 2.開關  3.等多久再開始  4.隔多久反覆執行
            timer_pickup = new System.Threading.Timer(callbackpickup, null, 0, 2000);

            //ControlsVisible(false, false, false, false, false, false);
            ControlsVisible(true, true, true, true, true, true);
        }
        #region threading DB initail 所以資料庫初始化

        private void _do(object state)
        {
            this.BeginInvoke(new setLable2(setLabel2));
            initialTalbe();
        }
        delegate void setLable2();
        private void setLabel2()
        {
            _dbinitialcount++;
            Log.Trace("DB initial count："+ _dbinitialcount.ToString());
            lb_DBinitialCount.Text = lb_DBinitialCount.Text + _dbinitialcount.ToString();
        }
        #endregion threading DB initail 所以資料庫初始化

        #region threading SmartCardReader 讀卡機讀取

        private void _doSmartCardReader(object state)
        {
            this.BeginInvoke(new setLable3(setLabel3));
            SmartCardReader.funSmartCardReader();
        }
        delegate void setLable3();
        private void setLabel3()
        {
            //_dbinitialcount++;
            //Log.Trace("DB initial count：" + _dbinitialcount.ToString());
            //lb_DBinitialCount.Text = lb_DBinitialCount.Text + _dbinitialcount.ToString();
        }
        #endregion threading SmartCardReader 讀卡機讀取

        #region Parent Pickup 家長接送通知
        private void _pickupNotice(object state)
        {
            this.BeginInvoke(new setPickup(setfunPickup));
            
        }
        delegate void setPickup();
        private async void setfunPickup()
        {
            DataTable dt_temp = new DataTable();
            DataTable dt = new DataTable();
            DataTable dt_history = new DataTable();
            List<Data> _vehicles = new List<Data>();
            _vehicles_new.Clear();
            if (_funFireBaseSharp.IsConnect())
            {
                if (await _funFireBaseSharp.ISresponse() !="null")
                {
                    try//確認Manager是否要讀取刷卡歷史紀錄 1:Y 2:N
                    {
                        string _cardMsgHistory = await _funFireBaseSharp.getData("User/" + _accountPhoneNum + "/CardMsgs_history/");
                        if(_cardMsgHistory=="1")
                        {
                            //collect history card message to list
                            string CommandStr = string.Format("select * from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0} left join EnglishClassDBtest.dbo.Table_StudentBasic on  EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID = EnglishClassDBtest.dbo.Table_StudentBasic.StudentID", DateTime.Now.ToString("yyyyMMdd"));
                            dt_history = dbc.CommandFunctionDB("Table_StudentBasic",CommandStr);
                            ListCardMsg lcm = new ListCardMsg();
                            List<CardMsgs> lcm2 = new List<CardMsgs>();
                            CardMsgs_historyClass hiscd = new CardMsgs_historyClass();
                            CardMsgs cm = new CardMsgs();
                            int hi = 0;
                            foreach (DataRow drw in dt_history.Rows)
                            {
                                cm.time = drw.ItemArray[3].ToString();
                                cm.title = drw.ItemArray[8].ToString() + " " + drw.ItemArray[4].ToString() + drw.ItemArray[5].ToString();
                                cm.content = drw.ItemArray[8].ToString() + " " + drw.ItemArray[4].ToString() + drw.ItemArray[5].ToString()+"第" + drw.ItemArray[4].ToString() + drw.ItemArray[2].ToString() +"次 刷卡";
                                cm.student = drw.ItemArray[10].ToString();
                                lcm2.Add(cm);
                                hi++;
                                if(hi>20)
                                {
                                    lcm2.RemoveAt(hi-21);
                                }
                            }
                            lcm.CardMsgs = lcm2;
                            lcm.CardMsgs_history = "0";
                            //insert firebase
                            _funFireBaseSharp.connection();
                            _funFireBaseSharp.update("User/" + _accountPhoneNum ,lcm);//User/0988123123/CardMsgs
                            _funFireBaseSharp.disconnection();
                        }
                    }
                    catch (Exception ex)
                    { }
                    _vehicles = await _funFireBaseSharp.Retrieving();
                    if (_vehicles != null)
                    {
                        foreach (Data d in _vehicles)
                        {
                            if (d != null && d.ID != null)
                            {
                                //確認學生刷卡是否晚於家長Pickup時間，並刪除Firebase
                                if (!checkStudentRollCallLast(d.ID.ToString(), d.sendTime) && d.sendTime!=null)
                                {
                                    d.TwName = "Test";
                                    d.Parent = "Test";
                                    //d.sendTime = "Text";
                                    dt_temp = selectPickup(d.Phone.ToString(), d.ID.ToString());

                                    foreach (DataRow od in dt_temp.Rows)
                                    {
                                        try
                                        {
                                            d.TwName = od[1].ToString();
                                            d.Parent = od[2].ToString();
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                        _vehicles_new.Add(d);
                                    }
                                }
                            }
                        }
                        dt = ConvertToDataTable(_vehicles_new);
                    }
                    dataGridView1.Rows.Clear();//清空DG
                    int i = 0;
                    foreach (DataRow drw in dt.Rows)
                    {
                        this.dataGridView1.Rows.Insert(i, drw.ItemArray[0].ToString(), drw.ItemArray[3].ToString(), drw.ItemArray[4].ToString(), drw.ItemArray[1].ToString(), drw.ItemArray[2].ToString(), drw.ItemArray[5].ToString());
                        i++;
                    }
                    lb_parentNotice.ForeColor = Color.Black;
                    lb_parentNotice.Text = "家長接送通知---已連線！";
                }
                else
                {
                    lb_parentNotice.ForeColor = Color.Red;
                    lb_parentNotice.Text = "家長接送通知---斷線！";
                }
            }
            else
            {
                lb_parentNotice.ForeColor = Color.Red;
                lb_parentNotice.Text = "家長接送通知---斷線！";
            }
            label1.Text = "現在時間： " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private DataTable selectPickup(string _phone,string _id)
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("select EnglishClassDBtest.dbo.Table_StudentBasic.StudentID, "+
                " EnglishClassDBtest.dbo.Table_StudentBasic.TwName,"+
                " EnglishClassDBtest.dbo.Table_StudentBook.Parents1" +
                " From Table_StudentBasic left join Table_StudentBook On" +
                " Table_StudentBasic.StudentID =  Table_StudentBook.StudentID" +
                " where EnglishClassDBtest.dbo.Table_StudentBasic.PhoneNumber='{0}'"+
                " or EnglishClassDBtest.dbo.Table_StudentBasic.StudentID = '{1}'"
                , _phone,_id);
            _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
            return _dataTable;
        }

        /// <summary>
        /// List to Table 轉換
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void btn_delet_Click(object sender, EventArgs e)
        {
            _funFireBaseSharp.delete("Pickup/" + txt_ID.Text+"ID");
            txt_ID.Text = "";
        }
        /// <summary>
        /// 比對學生刷卡是否比家長pickup 還晚，若比較晚，則delete firebase上 pickup data
        /// </summary>
        /// <param name="_sid"></param>
        /// <param name="_sendTime"></param>
        /// <returns></returns>
        private bool checkStudentRollCallLast(string _sid, string _sendTime)
        {
            bool _bPick = false;
            string Commandstr = string.Format("select MAX( Table_StudentRollcall_{0}.RollcallTimes) from Table_StudentRollcall_{0} where Table_StudentRollcall_{0}.StudentID='{1}'",baseStudentRollcall.date,_sid);
            string studentRollCallLastTime = dbcR.strExecuteScalar(Commandstr);
            if (studentRollCallLastTime!="")
            {
                //DateTime LastRCDate = DateTime.ParseExact(studentRollCallLastTime, "yyyy-MMdd HH:mm:ss", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                DateTime LastRCDate = Convert.ToDateTime(studentRollCallLastTime);
                if(LastRCDate> Convert.ToDateTime(_sendTime))
                {
                    _funFireBaseSharp.delete("Pickup/" + _sid+"ID");
                    _bPick = true;
                }
            }
            return _bPick;
        }

        #endregion Parent Pickup 家長接送通知

        // 登入觸發
        private void AccountInfoManager_AccountInfoLogInOutCallback(string name, AccountLevel level)
        {
            labAccountName.Text = name;
            labAccountLevel.Text = level.ToString();
            _accountPhoneNum = "";
            string CommandStr = string.Format("Select PhoneNumber from Table_EmployeeBasic where TwName='{0}'", name);
            _accountPhoneNum = dbc.strExecuteScalar(CommandStr);

            switch (level)
            {
                case AccountLevel.Intern:
                    ControlsVisible(false, false, false, false, false, true);
                    break;
                case AccountLevel.Operator:
                    ControlsVisible(false, false, false, false, true, true);
                    break;
                case AccountLevel.Engineer:
                    _isMaintaining = false;
                    ControlsVisible(false, false, false, true, true, true);
                    break;
                case AccountLevel.Manager:
                    _isMaintaining = false;
                    ControlsVisible(false, false, true, true, true, true);
                    break;
                case AccountLevel.Administrator:
                    _isMaintaining = false;
                    ControlsVisible(false, true, true, true, true, true);
                    break;
                case AccountLevel.Developer:
                    _isMaintaining = false;
                    ControlsVisible(true, true, true, true, true, true);
                    break;
                default:
                    break;
            }
        }

        //登入
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            initialComp();
            AccountInfoManager.LogIn();
        }

        //編輯權限
        private void btnAccountEditor_Click(object sender, EventArgs e)
        {
            initialComp();
            AccountInfoManager.AccountEditor();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            initialComp();
            AccountInfoManager.LogOut(true);
        }

        // 自定義根據使用者權限開放的操控項
        private void ControlsVisible(bool developerVisible, bool administratorVisible, bool managerVisible, bool engineerVisible, bool operatorVisible, bool Intern)
        {
            string level = "";
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select * from Table_AuthorityManagement";
            _dataTable = dbc.CommandFunctionDB("EnglishClassDBtest", CommandStr);

            if (Intern)
            {
                level = "Intern";
                filterAccountLevel(_dataTable, level);
            }
            if (developerVisible)
            {
                level = "Developer";
                filterAccountLevel(_dataTable, level);
            }
            if (administratorVisible)
            {
                level = "Administrator";
                filterAccountLevel(_dataTable, level);
            }
            if (managerVisible)
            {
                level = "Manager";
                filterAccountLevel(_dataTable, level);
            }
            if (engineerVisible)
            {
                level = "Engineer";
                filterAccountLevel(_dataTable, level);
            }
            if (operatorVisible)
            {
                level = "Operator";
                filterAccountLevel(_dataTable, level);
            }
        }

        private void Systimer_Tick(object sender, EventArgs e)
        {
            if (IsScanSsy)
            {
                //label1.Text = strNJson;
                label1.Text = "現在時間： " + DateTime.Now.ToString("yyyyMM/dd HH:mm:ss");
                scanStudRC();
            }
        }
        private void DBinitial_Tick(object sender, EventArgs e)
        {

        }

        private void ckb_Systimer_CheckedChanged(object sender, EventArgs e)
        {
            Systimer.Enabled = true;
            if (ckb_Systimer.Checked)
            {
                IsScanSsy = true;
            }
            else
            {
                IsScanSsy = false;
                Systimer.Enabled = false;
            }
        }

        private void scanStudRC()
        {
            string _is_update = functionStudentRollcall.getUpdate(functionStudentRollcall.getDate, textBox1.Text);
            if (_is_update == "1")
            {
                string _getCount = functionStudentRollcall.getCount(functionStudentRollcall.getDate, textBox1.Text);
                functionStudentRollcall.changeUpdate(functionStudentRollcall.getDate, textBox1.Text, "0");
                CardNotice.SendNotificationFromFirebaseCloud("刷卡通知", textBox1.Text + "第" + _getCount + "次簽到成功！");
                MessageBox.Show(textBox1.Text + "第" + _getCount + "次簽到成功！");
            }

            //家長接送通知


            /*string _getCount = functionStudentRollcall.getCount(functionStudentRollcall.getDate, textBox1.Text);

            if (_getCount != "")
            {
                string _is_update = functionStudentRollcall.getUpdate(functionStudentRollcall.getDate, textBox1.Text);
                //functionStudentRollcall.studRCstart(functionStudentRollcall.getDate, textBox1.Text, _getCount, "A");
                if (_is_update == "1")
                {
                    functionStudentRollcall.studRCagain(functionStudentRollcall.getDate, textBox1.Text, _getCount);
                    string _getCount_update = functionStudentRollcall.getCount(functionStudentRollcall.getDate, textBox1.Text);
                    if (_getCount_update != "")
                        MessageBox.Show(textBox1.Text + "第" + _getCount_update + "次簽到成功！");
                }
            }
            else
            {
                functionStudentRollcall.studRCstart(functionStudentRollcall.getDate, textBox1.Text, "1", "A");
                MessageBox.Show(textBox1.Text + "第1次簽到成功！");
                //MessageBox.Show(textBox1.Text + "資料不存在，請確認該學生建檔資訊");
            }
*/
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            if (AccountInfoManager.TestPermission(AccountLevel.Developer))
            {
                functionStudentRollcall.changeUpdate(functionStudentRollcall.getDate, textBox1.Text, "1");
                scanStudRC();
            }
        }

        #region ToolStripMenuItem

        private void 學生通訊錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentBook _frmStudentBook = new frmStudentBook();
            _frmStudentBook.ShowDialog();
        }

        private void 群組設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourseManagement _frmCourseManagement = new frmCourseManagement();
            _frmCourseManagement.ShowDialog();
        }

        private void 員工通訊錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeBook _frmEmployeeBook = new frmEmployeeBook();
            _frmEmployeeBook.ShowDialog();
        }

        private void 出缺勤查勤ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 排班表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassScheduleManager _frmClassScheduleManager = new frmClassScheduleManager();
            _frmClassScheduleManager.ShowDialog();
        }

        private void 班別設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassScheduleSettingNew _frmClassScheduleSettingNew = new frmClassScheduleSettingNew();
            _frmClassScheduleSettingNew.ShowDialog();

           // frmClassScheduleSetting _frmClassScheduleSetting = new frmClassScheduleSetting();
           //_frmClassScheduleSetting.ShowDialog();
        }

        private void 權限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountInfoManager.AccountEditor();
        }

        private void 學生線上打卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentRollcall _frmStudentRollcall = new frmStudentRollcall();
            _frmStudentRollcall.ShowDialog();
        }

        private void 員工線上打卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccountInfoManager.TestPermission(AccountLevel.Operator))
            {
                frmEmployeeRollcall _frmEmployeeRollcall = new frmEmployeeRollcall();
                _frmEmployeeRollcall.ShowDialog();
            }
        }

        private void 訊息預設ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 推播訊息設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMessageSetting _frmMessageSetting = new frmMessageSetting();
            _frmMessageSetting.ShowDialog();
        }

        private void 刷卡通知設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCardNotice _frmCardNotice = new frmCardNotice();
            _frmCardNotice.ShowDialog();
        }

        private void 通訊錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 手動推播ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 刷卡通知ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 學生出勤紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentRecord _frmStudentRecord = new frmStudentRecord();
            _frmStudentRecord.ShowDialog();
        }

        private void 員工出勤紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeRecord _frmEmployeeRecord = new frmEmployeeRecord();
            _frmEmployeeRecord.ShowDialog();
        }
        private void 員工班別管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassEmployeeManager _frmClassEmployeeManager = new frmClassEmployeeManager();
            _frmClassEmployeeManager.ShowDialog();
        }
        private void 系統紀錄ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Log.Trace("show Form");
            _frmSystemLog.Show();
        }
        private void 歷史訊息紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistoryMessage _frmHistoryMessage = new frmHistoryMessage();
            _frmHistoryMessage.ShowDialog();
        }

        private void 資料庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDBconfig _frmDBconfig = new frmDBconfig();
            _frmDBconfig.Show();
        }
        private void 家長ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManualBroadcastStudent _frmManualBroadcast = new frmManualBroadcastStudent();
            _frmManualBroadcast.ShowDialog();
        }

        private void 員工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManualBroadcastEmployee _frmManualemployeeBroadcast = new frmManualBroadcastEmployee();
            _frmManualemployeeBroadcast.ShowDialog();
        }
        private void firebase設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFireBaseSharp _frmFireBaseSharp = new frmFireBaseSharp();
            _frmFireBaseSharp.Show();
        }
        #endregion ToolStripMenuItem

        private void initialComp()
        {
            //系統管理ToolStripMenuItem.Visible = false;
            通訊錄ToolStripMenuItem.Visible = true;
            學生通訊錄ToolStripMenuItem.Enabled = false;
            員工通訊錄ToolStripMenuItem.Enabled = false;
            群組設定ToolStripMenuItem.Enabled = false;
            //員工考勤管理ToolStripMenuItem.Visible = false;
            出缺勤查勤ToolStripMenuItem.Enabled = false;
            排班表ToolStripMenuItem.Enabled = false;
            班別設定ToolStripMenuItem.Enabled = false;
            權限管理ToolStripMenuItem.Enabled = false;
            //線上打卡ToolStripMenuItem.Visible = false;
            學生線上打卡ToolStripMenuItem.Enabled = false;
            員工線上打卡ToolStripMenuItem.Enabled = false;
            //推播管理ToolStripMenuItem.Visible = false;
            手動推播ToolStripMenuItem.Enabled = false;
            刷卡通知ToolStripMenuItem.Enabled = false;
            //訊息預設ToolStripMenuItem.Enabled = false;
            //報表管理ToolStripMenuItem.Visible = false;
            學生出勤紀錄ToolStripMenuItem.Enabled = false;
            員工出勤紀錄ToolStripMenuItem.Enabled = false;
            推播訊息設定ToolStripMenuItem.Enabled = false;
            刷卡通知設定ToolStripMenuItem.Enabled = false;
            firebase設定ToolStripMenuItem.Enabled = false;
        }

        private void initialTalbe()
        {
            baseClassScheduleManager.initialTable();
            baseEmployeeRollcall.CreateTable();
            baseEmployeeRollcall.DelTable();
            baseStudentRollcall.CreateTable();
            baseStudentRollcall.DelTable();
        }

        #region Account Method

        private void filterAccountLevel(DataTable _dataTable, string level)
        {
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                if (drw.ItemArray[1].ToString() == level)
                {
                    swMenuItem(drw.ItemArray[0].ToString());
                }
                i++;
            }
        }

        private void swMenuItem(string functionName)
        {
            //btn_test.Visible = false;
            switch (functionName)
            {
                case "通訊錄":
                    this.通訊錄ToolStripMenuItem.Enabled = true;
                    break;
                case "學生通訊錄":
                    this.學生通訊錄ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "員工通訊錄":
                    this.員工通訊錄ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "群組設定":
                    this.群組設定ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "出缺勤查勤":
                    this.出缺勤查勤ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "排班表":
                    this.排班表ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "班別設定":
                    this.班別設定ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "權限管理":
                    this.權限管理ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "學生線上打卡":
                    this.學生線上打卡ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "員工線上打卡":
                    this.員工線上打卡ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "手動推播":
                    this.手動推播ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "刷卡通知":
                    this.刷卡通知ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "訊息預設":
                    this.訊息預設ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "學生出勤紀錄":
                    this.學生出勤紀錄ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "員工出勤紀錄":
                    this.員工出勤紀錄ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "推播訊息設定":
                    this.推播訊息設定ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "刷卡通知設定":
                    this.刷卡通知設定ToolStripMenuItem.Enabled = true;
                    //Application.DoEvents();
                    break;
                case "Firebase設定":
                    this.firebase設定ToolStripMenuItem.Enabled = true;
                    break;
            }
        }
        #endregion Account Method


        private void _frmSystemLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Trace("hide form");
            e.Cancel = true; //關閉視窗時取消
            _frmSystemLog.Hide(); //隱藏式窗,下次再show出
        }

       
    }
}
