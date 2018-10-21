using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AOISystem.Utility.Encryption;
using AOISystem.Utility.IO;

namespace AOISystem.Utility.Account
{
    public class AccountInfoManager
    {
        private const string Developer_User_Name = "administrator";
        private const string Developer_User_Password = "wisepioneer";

        private static List<AccountInfo> _accountInfoCollection;

        public static event Action<string, AccountLevel> AccountInfoLogInOutCallback;

        public static string ActiveAccountName { get; set; }

        public static AccountLevel ActiveAccountLevel { get; set; }

        public static bool IsTestMode { get; set; }

        public static List<AccountInfo> GetAccountInfoCollection()
        {
            try
            {
                _accountInfoCollection = new List<AccountInfo>();
                IniFile iniFile = new IniFile("Init", "AccountInfo");
                int accountInfoCount = iniFile.GetInt32("General", "Count");
                if (accountInfoCount > 0)
                {
                    string key = iniFile.GetString("General", "Key");
                    for (int i = 0; i < accountInfoCount; i++)
                    {
                        _accountInfoCollection.Add(new AccountInfo() 
                        {
                            Name = AESEncryption.AESDecoder(iniFile.GetString("User" + (i + 1).ToString(), "Name", ""), key),
                            Password = AESEncryption.AESDecoder(iniFile.GetString("User" + (i + 1).ToString(), "Password", "0"), key),
                            Level = (AccountLevel)Enum.Parse(typeof(AccountLevel), AESEncryption.AESDecoder(iniFile.GetString("User" + (i + 1).ToString(), "Level", "0"), key))
                        });
                    }
                }
                return _accountInfoCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                return _accountInfoCollection;
            }
        }

        public static void SetAccountInfoCollection(List<AccountInfo> accountInfoCollection)
        {
            try
            {
                int accountInfoCount = accountInfoCollection.Count;
                IniFile iniFile = new IniFile("Init", "AccountInfo");
                iniFile.WriteValue("General", "Count", accountInfoCount);
                string key = AESEncryption.GenerateKey();
                iniFile.WriteValue("General", "Key", key);
                for (int i = 0; i < accountInfoCount; i++)
                {
                    iniFile.WriteValue("User" + (i + 1).ToString(), "Name", AESEncryption.AESEncoder(accountInfoCollection[i].Name, key));
                    iniFile.WriteValue("User" + (i + 1).ToString(), "Password", AESEncryption.AESEncoder(accountInfoCollection[i].Password, key));
                    iniFile.WriteValue("User" + (i + 1).ToString(), "Level", AESEncryption.AESEncoder(accountInfoCollection[i].Level.ToString(), key));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static bool LogIn()
        {
            LogInForm logInForm = new LogInForm();
            if (logInForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("登入成功! Success!");
                return true;
            }
            return false;
        }

        public static bool LogIn(string name, string password)
        {
            if (name == Developer_User_Name)
            {
                if (password == Developer_User_Password)
                {
                    OnAccountInfoLogInOutCallback(name, AccountLevel.Developer);
                    return true;
                }
                else
                {
                    MessageBox.Show("密码错误 Password Error!!");
                    return false;
                }
            }
            AccountInfo accountInfo = _accountInfoCollection.Find(x => { return x.Name == name && x.Password == password; });
            if (accountInfo != null)
            {
                OnAccountInfoLogInOutCallback(accountInfo.Name, accountInfo.Level);
                return true;
            }
            else
            {
                MessageBox.Show("账号或密码错误! Account or Password Error!");
                return false;
            }
        }

        public static void LogOut()
        {
            LogOut(false);
        }

        public static void LogOut(bool isLogOutCheck)
        {
            if (isLogOutCheck)
            {
                if (MessageBox.Show("是否立即注销? Logout?", "注销 Yes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }
            if (IsTestMode)
            {
                OnAccountInfoLogInOutCallback(string.Empty, AccountLevel.Developer);
            }
            else
            {
                OnAccountInfoLogInOutCallback(string.Empty, AccountLevel.Operator);
            }
        }

        public static void AccountEditor()
        {
            if (TestPermission(AccountLevel.Administrator))
            {
                AccountEditorForm accountEditorForm = new AccountEditorForm();
                accountEditorForm.ShowDialog();
            }
        }

        public static bool TestPermission(AccountLevel limitLevel)
        {
            if (IsTestMode)
            {
                return true;
            }

            if (ActiveAccountLevel >= limitLevel)
            {
                return true;
            }

            if (MessageBox.Show("此账号无操作权限, 请切换更高权限账号! Access Denied!", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                return LogIn() && TestPermission(limitLevel);
            }

            return false;
        }

        private static void OnAccountInfoLogInOutCallback(string name, AccountLevel level)
        {
            if (AccountInfoLogInOutCallback != null)
            {
                ActiveAccountName = name;
                ActiveAccountLevel = level;
                AccountInfoLogInOutCallback(name, level);
            }
        }
    }
}
