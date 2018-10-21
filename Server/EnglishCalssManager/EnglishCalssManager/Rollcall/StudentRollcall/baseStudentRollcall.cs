using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCalssManager.Rollcall.StudentRollcall
{
   public static class baseStudentRollcall
    {
        public static DatabaseCore dbc = DatabaseManager._databaseCore;
        public static DatabaseTable dbt = DatabaseManager._databaseTable;
        public static DatabaseCoreRollcall dbcR = DatabaseManager._databaseCoreRollcall;
        private static string date = functionStudentRollcall.getDate;

        public static void CreateTable()
        {
            string CommandStr = string.Format(" select count(*) from sysobjects where name='Table_StudentRollcall_{0}' "
                , date);
            if (dbcR.strExecuteScalar(CommandStr) == "0")
            {
                CommandStr = string.Format(" CREATE TABLE[dbo].[Table_StudentRollcall_{0}]("
                               + " [CourseID] [int] NULL,"
                               + " [StudentID] [int] NULL,"
                               + " [RollcallCount]  [varchar](5) NULL,"
                               + " [RollcallTimes] [datetime] NULL,"
                               + " [RollcallType] [varchar](2) NULL,"
                               + " [RollcallMsg] [varchar](100) NULL"
                               + " ) ON[PRIMARY]"
                               , date);
                dbcR.ExecuteNonQuery(CommandStr);
            }
        }
    }
}
