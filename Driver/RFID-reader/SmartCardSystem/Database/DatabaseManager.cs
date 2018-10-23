
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardSystem.Database
{
    public static class DatabaseManager
    {
        //public static MainDB _mainDB;
        public static DatabaseCore _databaseCore;
        public static DatabaseTable _databaseTable;
        public static DatabaseCoreRollcall _databaseCoreRollcall;
        public static void Initialize()
        {
            _databaseCore = new DatabaseCore("DESKTOP-2LEACOS\\SQLEXPRESS", "sa", "EnglishClassDBtest", "");//後面要輸入自己的資料庫密碼
            _databaseTable = new DatabaseTable();
            _databaseCoreRollcall = new DatabaseCoreRollcall("DESKTOP-2LEACOS\\SQLEXPRESS", "sa", "EnglishClassDBtestRollcall", "");//後面要輸入自己的資料庫密碼
        }

     
    }
}
