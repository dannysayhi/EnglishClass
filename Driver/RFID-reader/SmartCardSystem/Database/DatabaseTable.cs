using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardSystem.Database
{
   public class DatabaseTable
    {
        public Table_StudentBasic _table_StudentBasic = new Table_StudentBasic();
        public Table_StudentBook _table_StudentBook = new Table_StudentBook();
    }
    public class Table_StudentBasic
    {
        public string StudentID = "";
        public string CardNumber = "";
        public string TwName = "";
        public string EnName = "";
        public string PhoneNumber = "";
        public string Home = "";
        public string School = "";
        public string Senior = "";
        public string Onschool = "";
        public string TableName = "Table_StudentBasic";
        public string StudentIDStr = "StudentID";
        public string CardNumberStr = "CardNumber";
        public string TwNameStr = "TwName";
        public string EnNameStr = "EnName";
        public string PhoneNumberStr = "PhoneNumber";
        public string HomeStr = "Home";
        public string SchoolStr = "School";
        public string SeniorStr = "Senior";
        public string OnschoolStr = "Onschool";
    }
    public class Table_StudentBook
    {
        public string StudentID = "";
        public string Parents1 = "";
        public string Parents1PhoneNumber = "";
        public string Parents2 = "";
        public string Parents2PhoneNumber = "";
        public string Parents3 = "";
        public string Parents3PhoneNumber = "";
        public string Parents4 = "";
        public string Parents4PhoneNumber = "";
        public string TableName = "Table_StudentBook";
        public string StudentIDStr = "StudentID";
        public string Parents1Str = "Parents1";
        public string Parents1PhoneNumberStr = "Parents1PhoneNumber";
        public string Parents2Str = "Parents2";
        public string Parents2PhoneNumberStr = "Parents2PhoneNumber";
        public string Parents3Str = "Parents3";
        public string Parents3PhoneNumberStr = "Parents3PhoneNumber";
        public string Parents4Str = "Parents4";
        public string Parents4PhoneNumberStr = "Parents4PhoneNumber";
    }
}
