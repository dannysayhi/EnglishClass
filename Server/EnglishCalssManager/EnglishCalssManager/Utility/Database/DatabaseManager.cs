using _4RobotSystem.PCaGUtility.FileControl;
using AOI_System.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishClassManager.Utility.Database
{
    public static class DatabaseManager
    {
        //public static MainDB _mainDB;
        public static DatabaseCore _databaseCore;
        public static DatabaseTable _databaseTable;
        public static DatabaseCoreRollcall _databaseCoreRollcall;
        public static INI INI = new INI(Application.StartupPath + @"\Init\" + "DBinfo.ini");

        public static string _dbc_Source = INI.ReadValue("dbc","source","");
        public static string _dbc_User = INI.ReadValue("dbc", "User", "");
        public static string _dbc_DB = INI.ReadValue("dbc", "DB", "");
        public static string _dbc_PWD = INI.ReadValue("dbc", "PWD", "");
        public static string _dbcR_Source = INI.ReadValue("dbcr", "source", "");
        public static string _dbcR_User = INI.ReadValue("dbcr", "User", "");
        public static string _dbcR_DB = INI.ReadValue("dbcr", "DB", "");
        public static string _dbcR_PWD = INI.ReadValue("dbcr", "PWD", "");

        public static void Initialize()
        {
            //_databaseCore = new DatabaseCore("67-0A60507-H1\\SQLEXPRESS", "sa", "EnglishClassDBtest", "b22303409");//後面要輸入自己的資料庫密碼
            //_databaseTable = new DatabaseTable();
            //_databaseCoreRollcall = new DatabaseCoreRollcall("67-0A60507-H1\\SQLEXPRESS", "sa", "EnglishClassDBtestRollcall", "b22303409");//後面要輸入自己的資料庫密碼

            //_databaseCore = new DatabaseCore("I22-3000000371", "sa", "EnglishClassDBtest", "");
            //_databaseTable = new DatabaseTable();
            //_databaseCoreRollcall = new DatabaseCoreRollcall("I22-3000000371", "sa", "EnglishClassDBtestRollcall", "");

            _databaseCore = new DatabaseCore(_dbc_Source, _dbc_User, _dbc_DB, _dbc_PWD);
            _databaseTable = new DatabaseTable();
            _databaseCoreRollcall = new DatabaseCoreRollcall(_dbcR_Source, _dbcR_User, _dbcR_DB, _dbcR_PWD);

            // Public database
            //Data Source=ouchunhsien.ddns.net\SQL,1433;Initial Catalog=EnglishClassDBtest;User ID=sa;Password=***********

            //_databaseCore = new DatabaseCore("ouchunhsien.ddns.net\\SQL,1433", "sa", "EnglishClassDBtest", "0426322358");
            //_databaseTable = new DatabaseTable();
            //_databaseCoreRollcall = new DatabaseCoreRollcall("ouchunhsien.ddns.net\\SQL,1433", "sa", "EnglishClassDBtestRollcall", "0426322358");

        }


    }
}
