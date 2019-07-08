using EnglishCalssManager.Utility.Account;
using EnglishClassManager.Utility.Database;

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AOISystem.Utility.Account
{
    public partial class AccountEditorForm : Form
    {
        private List<AccountInfo> _accountInfoCollection;
        private AccountInfo _selectedAccountInfo;
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;

        public AccountEditorForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void AccountEditorForm_Load(object sender, EventArgs e)
        {
            //Select EmployeeName add Cbox
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select TwName from Table_EmployeeBasic";
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_managerName.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_managerName.Text = cbox_managerName.Items[0].ToString();

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                AccountInfoManager.SetAccountInfoCollection(_accountInfoCollection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbox_managerName.Text == "" || this.txtPassword.Text == "")
                {
                    MessageBox.Show("不能有空白!");
                    return;
                }
                if (_accountInfoCollection.Find(x => { return x.Name == this.cbox_managerName.Text; }) != null)
                {
                    MessageBox.Show("Name 重覆~");
                    return;
                }
                _accountInfoCollection.Add(new AccountInfo() 
                {
                    Name = this.cbox_managerName.Text,
                    Password = this.txtPassword.Text,
                    Level = (AccountLevel)Enum.Parse(typeof(AccountLevel), this.cboAccountLevel.Text)
                });
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvwAccount.SelectedItems.Count > 0)
                {
                    if (this.cbox_managerName.Text == "" || this.txtPassword.Text == "")
                    {
                        MessageBox.Show("不能有空白!");
                        return;
                    }
                    AccountInfo accountInfo = _accountInfoCollection.Find(x => { return x.Name == _selectedAccountInfo.Name; });
                    if (accountInfo != null)
                    {
                        accountInfo.Name = this.cbox_managerName.Text;
                        accountInfo.Password = this.txtPassword.Text;
                        accountInfo.Level = (AccountLevel)Enum.Parse(typeof(AccountLevel), this.cboAccountLevel.Text);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("不存在該帳號[{0}]", this.cbox_managerName.Text));
                        return;
                    }
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void lvwAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvwAccount.SelectedItems.Count > 0)
            {
                this.cbox_managerName.Text = this.lvwAccount.SelectedItems[0].SubItems[0].Text;
                this.cboAccountLevel.Text = this.lvwAccount.SelectedItems[0].SubItems[1].Text;
                _selectedAccountInfo = _accountInfoCollection.Find(x => { return x.Name == this.cbox_managerName.Text; });
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AccountInfo accountInfoFount = _accountInfoCollection.Find(x => { return x.Name == this.cbox_managerName.Text; });
            if (accountInfoFount != null)
            {
                _accountInfoCollection.Remove(accountInfoFount);
            }
            else
            {
                MessageBox.Show(string.Format("不存在該帳號[{0}]", this.cbox_managerName.Text));
            }
            RefreshData();
        }

        private void Initialize()
        {
            try
            {
                _accountInfoCollection = AccountInfoManager.GetAccountInfoCollection();
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void RefreshData()
        {
            //if (_accountInfoCollection.Count <= 0)
            //    return;

            _accountInfoCollection.Sort((x, y) => { return x.Level.CompareTo(y.Level); });
            this.lvwAccount.Items.Clear();
            foreach (AccountInfo accountInfo in _accountInfoCollection)
            {
                ListViewItem list = new ListViewItem();
                list.Text = accountInfo.Name;
                //list.SubItems.Add(accountInfo.Password);
                list.SubItems.Add(accountInfo.Level.ToString());
                this.lvwAccount.Items.Add(list);
            }

            this.txtPassword.Text = "";
            this.cbox_managerName.Text = "";
            this.cboAccountLevel.SelectedIndex = 0;
        }

        private void btnAccountLevel_Click(object sender, EventArgs e)
        {
            AccountEditorLevelForm _accountEditorLevelForm = new AccountEditorLevelForm();
            _accountEditorLevelForm.ShowDialog();
        }
    }
}
