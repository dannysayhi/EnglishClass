using EnglishClassManager.Utility.Database;
using EnglishCalssManager.Broadcast.CardNotice;
using EnglishCalssManager.Broadcast.ManualBroadcast;
using EnglishCalssManager.Broadcast.MessageSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PushSharp;
using PushSharp.Apple;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using EnglishCalssManager.Utility.FireBaseSharp;
using AOISystem.Utility.Account;

namespace EnglishCalssManager.Broadcast.ManualBroadcast
{
    public partial class frmManualBroadcastStudent : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        private funFireBaseSharp _funFireBaseSharp = new funFireBaseSharp();
        private string managerName = AccountInfoManager.ActiveAccountName;
        private string _senderPhone = "";
        private List<Sent> SentCollect = new List<Sent>();

        public frmManualBroadcastStudent()
        {
            InitializeComponent();
            initialComp();
        }

        private void _frmManualBroadcast_Load(object sender, EventArgs e)
        {
             string CommandStr =string.Format( "Select PhoneNumber from Table_EmployeeBasic where TwName='{0}'", managerName);
            _senderPhone = dbc.strExecuteScalar(CommandStr);
            refreshTable();
        }

      
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if(row.Cells.Count==0)
                    {
                        MessageBox.Show("請選擇群組！");
                    }
                    if (row.Cells[1].Value != null && (Boolean)row.Cells[0].Value == true)
                    {
                        string StudentID = "";
                        try
                        {
                            //B推播提醒內容
                            string MsgName = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["MsgName"].Value.ToString();
                            string Msg = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["Msg"].Value.ToString();
                            Msg = Msg.Replace(@"""", "");
                            string msg = CardNotice.CardNotice.SendNotificationFromFirebaseCloud(MsgName, Msg);
                            MessageBox.Show("發送成功!");
                            string sendtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            
                            //Firebase funtion start!
                            string CommandStr = string.Format("Select Table_CourseManagement.StudentID from Table_CourseManagement where Table_CourseManagement.CourseID='{0}'", row.Cells[1].Value);
                            DataTable _dataTable = dbc.CommandFunctionDB("Table_CourseManagement",CommandStr);
                            Receives _Receives = new Receives();
                           
                            int i = 0;
                            foreach (DataRow drw in _dataTable.Rows)
                            {
                                //Collect firebase Parents(User/phone number/Receivers)
                                StudentID = drw.ItemArray[0].ToString();
                               
                                CommandStr = string.Format("Select Table_StudentBasic.TwName,Table_StudentBasic.PhoneNumber from Table_StudentBasic where Table_StudentBasic.StudentID='{0}'", drw.ItemArray[0].ToString());
                                DataTable _dt2 = dbc.CommandFunctionDB("Table_CourseManagement",CommandStr);

                                _Receives.content = MsgName + "：" + Msg;
                                _Receives.sender = managerName;
                                _Receives.time = sendtime;
                                _Receives.to = _dt2.Rows[0].ItemArray[0].ToString();

                                //Collect firebase manager(User/phone number/Sent)
                                Sent _sent = new Sent();
                                _sent.content = MsgName + "：" + Msg;
                                _sent.sender = managerName;
                                _sent.time = sendtime;
                                //_sent.to = _dt2.Rows[0].ItemArray[0].ToString(); /// 管理者->家長
                                SentCollect.Add(_sent);

                                var data_user_receivers = new ManagerReceives
                                {
                                    Receives = new List<Receives> { _Receives }
                                };
                                //Firebase Parents 
                                insertFirebase(_dt2.Rows[0].ItemArray[1].ToString(), data_user_receivers);
                                i++;
                            }
                            //Firebase Manager
                            var data_user_sent = new ManagerSent
                            {
                                Sent = SentCollect
                            };
                            insertFirebase(_senderPhone, data_user_sent);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(StudentID+"：不在資料庫內！");
                        }
                    }
                }
            }
        }
  
           private void insertFirebase(string _phone, object data_user)
        {
            insertFirebaseTable("User/"+ _phone, data_user);
        }

        public void insertFirebaseTable(string _Firetable, object _data)
        {
            _funFireBaseSharp.connection();
            _funFireBaseSharp.update(_Firetable, _data);
            _funFireBaseSharp.disconnection();
        }

        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            //dtBK = (DataTable)dataGridView1.DataSource;
            //列出班別ID
            string CommandStr = "Select * from Table_Message";
            _dataTable = dbc.CommandFunctionDB("Table_Message", CommandStr);
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                //cbox_CourseID.Items.Add(drw.ItemArray[0].ToString());
                this.dataGridView3.Rows.Insert(i, false, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString(), drw.ItemArray[2].ToString(),drw.ItemArray[3].ToString());
                i++;
            }

            // dgBtn();
        }

        private void initialComp()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select CourseID,CourseName from Table_Course";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                this.dataGridView2.Rows.Insert(i, false, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString());
                i++;
            }

            dataGridView3.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            //dataGridView2.DataSource = _dataTable;



        }

        private void btn_SelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = true;
            }
        }

        private void btn_CleanAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = false;
            }
        }

        private void btn_Resv_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)chk.Value == true)
                {
                    chk.Value = false;
                }
                else
                {
                    chk.Value = true;
                }
            }
        }
    }
}
