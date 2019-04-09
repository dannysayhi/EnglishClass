﻿using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCalssManager.SystemManager.MemberList.StudentBook
{
    public partial class frmMobilePwdRegist : Form
    {
        public static DatabaseCore dbc = DatabaseManager._databaseCore;
        public static DatabaseTable dbt = DatabaseManager._databaseTable;
        private string _studentID = "";
        private string _twName = "";
        private string lb_txtOldPwd = "舊密碼：";
        public frmMobilePwdRegist(string studentID,string twName)
        {
            InitializeComponent();
            _studentID = studentID;
            _twName = twName;
        }

        private void frmMobilePwdRegist_Load(object sender, EventArgs e)
        {
            string CommandStr = string.Format("select Table_StudentPasswordManagement.Password from Table_StudentPasswordManagement where StudentID = '{0}'", _studentID);
            lb_oldPwd.Text = lb_txtOldPwd+ dbc.strExecuteScalar(CommandStr);
            lb_StdID.Text = lb_StdID.Text + _studentID;
            lb_TWname.Text = lb_TWname.Text + _twName;
            //MessageBox.Show(txt_oldPwd.Text);
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
            Environment.Exit(Environment.ExitCode);
            InitializeComponent();
        }

        private void sendPwd()
        {
            string CommandStr = string.Format("select Count(*) from Table_StudentPasswordManagement  where StudentID = '{0}'", _studentID);
            if (dbc.strExecuteScalar(CommandStr) == "0")
            {
                CommandStr = string.Format("insert into Table_StudentPasswordManagement values ('{0}','{1}')", _studentID, txt_NewPwd.Text);
                dbc.ExecuteNonQuery(CommandStr);
            }
            else
            {
                CommandStr = string.Format("update Table_StudentPasswordManagement set "
                          + " Password='{0}'"
                          + " where StudentID='{1}'", txt_NewPwd.Text, _studentID);
                dbc.ExecuteNonQuery(CommandStr);
            }
            //MessageBox.Show(string.Format("寫入密碼：'{0}'",txt_NewPwd.Text));
            lb_oldPwd.Text = lb_txtOldPwd + txt_NewPwd.Text;
            txt_NewPwd.Text = "";
        }
    }
}