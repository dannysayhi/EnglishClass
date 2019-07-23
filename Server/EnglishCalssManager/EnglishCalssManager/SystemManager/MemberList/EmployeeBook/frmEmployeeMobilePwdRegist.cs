using EnglishCalssManager.Utility.FireBaseSharp;
using EnglishClassManager.Utility.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCalssManager.SystemManager.MemberList.EmployeeBook
{
    public partial class frmEmployeeMobilePwdRegist : Form
    {
        public static DatabaseCore dbc = DatabaseManager._databaseCore;
        public static DatabaseTable dbt = DatabaseManager._databaseTable;
        funFireBaseSharp _funFireBaseSharp = new funFireBaseSharp();

        private string _empID = "";
        private string _twName = "";
        private string _phoneNum = "";
        private string lb_txtOldPwd = "舊密碼：";
        private string _tempPwd = "";
        public frmEmployeeMobilePwdRegist(string employeeID, string twName, string phoneNum)
        {
            InitializeComponent();
            _empID = employeeID;
            _twName = twName;
            _phoneNum = phoneNum;
        }

        private void frmEmployeeMobilePwdRegist_Load(object sender, EventArgs e)
        {
            string CommandStr = string.Format("select Table_EmployeePasswordManagement.Password from Table_EmployeePasswordManagement where EmployeeID = '{0}'", _empID);
            lb_oldPwd.Text = lb_txtOldPwd + dbc.strExecuteScalar(CommandStr);
            lb_EmpID.Text = lb_EmpID.Text + _empID;
            lb_TWname.Text = lb_TWname.Text + _twName;
            lb_phoneNum.Text = lb_phoneNum.Text + _phoneNum;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (txt_NewPwd.Text != "")
            {
                sendPwd();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("無密碼輸入，確認是否新增？", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    sendPwd();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendPwd()
        {
            string CommandStr = string.Format("select Count(*) from Table_EmployeePasswordManagement  where EmployeeID = '{0}'", _empID);
            if (dbc.strExecuteScalar(CommandStr) == "0")
            {
                CommandStr = string.Format("insert into Table_EmployeePasswordManagement values ('{0}','{1}','{2}')", _empID, txt_NewPwd.Text, _phoneNum);
                dbc.ExecuteNonQuery(CommandStr);
            }
            else
            {
                CommandStr = string.Format("update Table_EmployeePasswordManagement set "
                          + " Password='{0}',phoneNum='{2}'"
                          + " where EmployeeID='{1}'", txt_NewPwd.Text, _empID, _phoneNum);
                dbc.ExecuteNonQuery(CommandStr);
            }
            //MessageBox.Show(string.Format("寫入密碼：'{0}'",txt_NewPwd.Text));
            _tempPwd = txt_NewPwd.Text;
            insertFirebase();
            lb_oldPwd.Text = lb_txtOldPwd + txt_NewPwd.Text;
            txt_NewPwd.Text = "";

        }
        private async void insertFirebase()
        {
            object tempData = new object();
            Data data_user = new Data();
            _funFireBaseSharp.connection();
            tempData = await getFirebaseTable("User/" + _phoneNum);
            data_user = (Data)tempData;
            data_user.Password = _tempPwd;
            data_user.sendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // Insert to Firebase
            updateFirebaseTable("User/" + _phoneNum, data_user);
        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="_Firetalbe"></param>
        /// <param name="_data"></param>
        public async Task<object> getFirebaseTable(string _Firetalbe)
        {
            // _funFireBaseSharp.connection();
            //string resultstr = await _funFireBaseSharp.getData(_Firetalbe);
            object mList;
            mList = JsonConvert.DeserializeObject<Data>(await _funFireBaseSharp.getData(_Firetalbe));
            _funFireBaseSharp.disconnection();
            return mList;
        }
        public void updateFirebaseTable(string _Firetable, object _data)
        {
            //_funFireBaseSharp.connection();
            _funFireBaseSharp.update(_Firetable, _data);
            _funFireBaseSharp.disconnection();
        }
        public void DelEmployee(string _Firetpath)
        {
            //_funFireBaseSharp.connection();
            _funFireBaseSharp.delete(_Firetpath);
            _funFireBaseSharp.disconnection();
        }
    }
}
