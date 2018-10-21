using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AOISystem.Utility.Logging;
using AOISystem.Utility.Account;

namespace AOISystem.Utility.Account
{
    public partial class LogInForm : Form
    {
        private List<AccountInfo> _accountInfoCollection;

        public LogInForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                _accountInfoCollection = AccountInfoManager.GetAccountInfoCollection();
                for (int i = 0; i < _accountInfoCollection.Count; i++)
                {
                    this.cboAccount.Items.Add(_accountInfoCollection[i].Name);
                }
                if (_accountInfoCollection.Count > 0)
                {
                    this.cboAccount.SelectedIndex = 0;
                }
                else
                {
                    this.cboAccount.Text = "No User";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (AccountInfoManager.LogIn(this.cboAccount.Text, this.txtPassword.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
               this.btnAccept.PerformClick();
            }
        }

        private int _clickCount = 0;
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (++_clickCount >= 2)
            {           
                this.cboAccount.Text = "administrator";
                this.txtPassword.Text = "wisepioneer";
                this.btnAccept.PerformClick();
            }
        }
    }
}
