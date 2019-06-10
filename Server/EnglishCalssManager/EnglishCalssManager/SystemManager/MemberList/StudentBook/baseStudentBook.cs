using EnglishCalssManager.Utility.FireBaseSharp;
using EnglishClassManager.SystemManager.MemberList.StudentBook;
using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCalssManager.SystemManager.MemberList.StudentBook
{
    class baseStudentBook
    {
        public static DatabaseCore dbc = DatabaseManager._databaseCore;
        public static DatabaseTable dbt = DatabaseManager._databaseTable;
        funFireBaseSharp _funFireBaseSharp = new funFireBaseSharp();

        public string txt_CardNumber = "";
        public string txt_EnName = "";
        public string txt_Home = "";
        public string txt_Parents1 = "";
        public string txt_Parents1PhoneNumber = "";
        public string txt_Parents2 = "";
        public string txt_Parents2PhoneNumber = "";
        public string txt_Parents3 = "";
        public string txt_Parents3PhoneNumber = "";
        public string txt_PhoneNumber = ""; 
        public string txt_School = "";
        public string txt_StudentID = "";
        public string txt_TwName = "";
        public string cbox_Senior = "";
        public string cbox_Onschool = "";
        
        public void NewStudent()
        {
            string CommandStr = string.Format(" INSERT INTO[dbo].[Table_StudentBasic] "
           + " ([CardNumber]"
           + " ,[TwName]"
           + " ,[EnName]"
           + " ,[PhoneNumber]"
           + " ,[Home]"
           + " ,[School]"
           + " ,[Senior]"
           + " ,[Onschool])"
    + " VALUES"
          + " ( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
          , txt_CardNumber,txt_TwName,txt_EnName,txt_PhoneNumber,txt_Home,txt_School,cbox_Senior,cbox_Onschool);
            dbc.ExecuteNonQuery( CommandStr);
            
            CommandStr = string.Format("select Max([dbo].[Table_StudentBasic].StudentID) from [dbo].[Table_StudentBasic]");
            string maxStdID = dbc.strExecuteScalar(CommandStr);

            CommandStr = "Insert into "
               + dbt._table_StudentBook.TableName
               + " values('"
               + maxStdID + "','"
               + txt_Parents1 + "','"
               + txt_Parents1PhoneNumber+ "','"
               + txt_Parents2 + "','"
               + txt_Parents2PhoneNumber + "','"
               + txt_Parents3 + "','"
               + txt_Parents3PhoneNumber + "')";
            dbc.ExecuteNonQuery(CommandStr);

            //存入Firebase 

        }

        public void insertFirebaseTable(string _Firetable, Data _data)
        {
            _funFireBaseSharp.connection();
            _funFireBaseSharp.insert(_Firetable, _data);
            _funFireBaseSharp.disconnection();
        }
        public void DelStudent(string _Firetpath)
        {
            _funFireBaseSharp.connection();
            _funFireBaseSharp.delete(_Firetpath);
            _funFireBaseSharp.disconnection();
        }

        public void LeaveStudent()
        {

        }
      
    }
}
