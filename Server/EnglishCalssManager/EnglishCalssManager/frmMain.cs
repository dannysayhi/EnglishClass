using AOISystem.Utility.Account;
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

namespace EnglishClassManager
{
    public partial class frmMain : Form
    {
        frmSystemLog _frmSystemLog = new frmSystemLog();
      
        public bool IsScanSsy = false;
        public DatabaseCore dbc;// = DatabaseManager._databaseCore;
        public DatabaseTable dbt;// = DatabaseManager._databaseTable;
        public DatabaseCoreRollcall dbcR;// = DatabaseManager._databaseCoreRollcall;
        //public CardNotice ;
        private bool _isMaintaining = false;       // 現在是否Maintaning
        public System.Windows.Forms.ToolStripMenuItem[] _T = new System.Windows.Forms.ToolStripMenuItem[23];
        private Hashtable _TH;
        private string[] _Ts = new string[23];
        private int _dbinitialcount = 0;

        //一定要声明成局部变量以保持对Timer的引用，否则会被垃圾收集器回收！
        private System.Threading.Timer timer;

        //private string funcStudRCdate = functionStudentRollcall.getDate;

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

            //宣告timer要做什麼事.要做什麼事呢?要做_do的事
            TimerCallback callback = new TimerCallback(_do);
            //1.function 2.開關  3.等多久再開始  4.隔多久反覆執行
            timer = new System.Threading.Timer(callback, null, 0, 600000);


            //ControlsVisible(false, false, false, false, false, false);
            ControlsVisible(true, true, true, true, true, true);
        }
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

        // 登入觸發
        private void AccountInfoManager_AccountInfoLogInOutCallback(string name, AccountLevel level)
        {
            labAccountName.Text = name;
            labAccountLevel.Text = level.ToString();
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
                functionStudentRollcall.changeUpdate("20180902", textBox1.Text, "0");
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
            frmManualBroadcast _frmManualBroadcast = new frmManualBroadcast();
            _frmManualBroadcast.ShowDialog();
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
