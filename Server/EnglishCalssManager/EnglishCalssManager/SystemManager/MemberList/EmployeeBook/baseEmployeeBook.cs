using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCalssManager.SystemManager.MemberList.EmployeeBook
{
   public class baseEmployeeBook
    {
        public  DatabaseCore dbc = DatabaseManager._databaseCore;
        public  DatabaseTable dbt = DatabaseManager._databaseTable;
        public  List<string> _employeeID = new List<string>();
        public  string EmployeeID="";
        public  string CardNumber = "";
        public  string TwName = "";
        public  string EnName = "";
        public  string Home = "";
        public  string PhoneNumber = "";
        public  string Onjob = "";
        public  string Dep = "";
        public  string Pos = "";
     

        public void NewEmployee()
        {
            string CommandStr = string.Format(" INSERT INTO [dbo].[Table_EmployeeBasic] "
           + " ([CardNumber]"
          + " ,[TwName]"
           + " ,[EnName]"
           + " ,[Home]"
           + " ,[PhoneNumber]"
           + " ,[Onjob])"
     + " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", CardNumber,TwName,EnName,Home,PhoneNumber,Onjob);
            dbc.ExecuteNonQuery(CommandStr);

            CommandStr = string.Format("select Max([dbo].[Table_EmployeeBasic].EmployeeID) from [dbo].[Table_EmployeeBasic]");
            string maxEID = dbc.strExecuteScalar(CommandStr);

            CommandStr = string.Format("INSERT INTO [dbo].[Table_EmployeeBook] "
           + "  ([EmployeeID]"
           + " ,[Position]"
           + " ,[Dept]"
           + " ,[Vacation1]"
           + " ,[Vacation2]"
           + " ,[Vacation3]"
           + " ,[Vacation4]"
           + " ,[Vacation5]"
           + " ,[Vacation6]"
           + " ,[Vacation7])"
           + " VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
             maxEID,Pos,Dep,"","","","","","","" );
            dbc.ExecuteNonQuery(CommandStr);
        }
    }
}
