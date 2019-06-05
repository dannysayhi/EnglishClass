using EnglishClassManager.Rollcall.EmployeeRollcall;
using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCalssManager.Rollcall.EmployeeRollcall
{
    public static class baseEmployeeRollcall
    {
        public static DatabaseCore dbc = DatabaseManager._databaseCore;
        public static DatabaseTable dbt = DatabaseManager._databaseTable;
        
        public static DatabaseCoreRollcall dbcR = DatabaseManager._databaseCoreRollcall;
        public static string date = DateTime.Now.ToString("dd");
        public static string datelong = DateTime.Now.ToString("yyyyMMdd");
        public static string dateshort = DateTime.Now.ToString("yyyy_MM");
       // public static frmEmployeeRollcall _frmEmployeeRollcall = new frmEmployeeRollcall();

        public static void CreateTable()
        {
            ///創建Talbe
            string CommandStr = string.Format(" select count(*) from sysobjects where name='Table_EmployeeRollcall_{0}' "
                , datelong);
            if (dbcR.strExecuteScalar(CommandStr) == "0")
            {
                CommandStr = string.Format(" CREATE TABLE[dbo].[Table_EmployeeRollcall_{0}]("
               + " [EmployeeID][int] NULL,"
               + " [ClassID][varchar](2) NULL,"
               + " [RollcallDate][datetime] , "
               + " [RollCallStart][datetime] NULL, "
               + " [RollCallEnd][datetime] NULL,"
               + "[RollCallLate][time](7) NULL,"
               + "[RollCallEarly][time](7) NULL,"
               + "[RollcallHR][time](7) NULL,"
               + "[RollCallState][varchar](6) NULL,"
               + "[RollCallRemark][varchar](50) NULL"
               + " ) ON[PRIMARY]"
                               , datelong);
                dbcR.ExecuteNonQuery(CommandStr);
            }

            ///寫入當天上班人員基本資訊
            string _countEmployee = "";
            DataTable _dataTable = new DataTable();
            CommandStr = string.Format("Select EnglishClassShift.dbo.Table_ClassShift_{0}.EmployeeID,"
               + " EnglishClassShift.dbo.Table_ClassShift_{0}.D{1} "
               + " from  EnglishClassShift.dbo.Table_ClassShift_{0}", dateshort, date);
            _dataTable = dbc.CommandFunctionDB("Table_ClassShift_", CommandStr);

            ///確認是否有在班表內，有：update/沒有：Insert
            foreach (DataRow drw in _dataTable.Rows)
            {
                // int t = Convert.ToInt16( date.TrimStart('0'))+1;
                // MessageBox.Show(drw.ItemArray[t].ToString());
                CommandStr = string.Format("select count(*) from EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0} where EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID='{1}'", datelong, drw.ItemArray[0].ToString());
                _countEmployee = dbcR.strExecuteScalar(CommandStr);
                if (_countEmployee == "1")
                {
                    //update
                    CommandStr = string.Format(
                   "Update EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
                   + " Set EmployeeID='{1}',ClassID='{2}'"
                   + " Where EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID='{1}'"
                   , datelong, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString());
                    dbcR.ExecuteNonQuery(CommandStr);
                }
                else if (_countEmployee == "0")
                {
                    // insert
                    CommandStr = string.Format(
                   "Insert into EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
                   + " values('{1}','{2}',Default,Default,Default,Default,Default,Default,'未刷卡','')"
                   , datelong, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString());
                    dbcR.ExecuteNonQuery(CommandStr);
                }
            }
        }
        public static void DelTable()
        {
            string datelong_del_start = "";
            string CommandStr = "";
            for (int i = 0; i < 70; i++)
            {
                datelong_del_start = DateTime.Now.AddDays(-200 - i).ToString("yyyyMMdd");
                CommandStr = string.Format(" select count(*) from sysobjects where name='Table_EmployeeRollcall_{0}' "
               , datelong_del_start);
                if (dbcR.strExecuteScalar(CommandStr) != "0")
                {
                    CommandStr = string.Format(" DROP TABLE EnglishClassDBtestRollcall.[dbo].[Table_EmployeeRollcall_{0}]", datelong_del_start);
                    dbcR.ExecuteNonQuery(CommandStr);
                }
            }
        }
    }
}
