using _4RobotSystem.PCaGUtility.FileControl;
using EnglishClassManager.EmployeeAttence.ClassScheduleManager;
using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCalssManager.EmployeeAttence.ClassScheduleManager
{
    public static class baseClassScheduleManager
    {
        public static DatabaseCore dbc = DatabaseManager._databaseCore;
        public static DatabaseTable dbt = DatabaseManager._databaseTable;
        public static DatabaseCoreRollcall dbcR = DatabaseManager._databaseCoreRollcall;
        public static frmClassScheduleManager _frmClassScheduleManager = new frmClassScheduleManager();
        

        private static DateTime dt;
        private static DateTime currentTime = DateTime.Now;
        private static int daysofmonth = 31;
        private static bool _biniCopF = false;
        private static int CurYear;
        private static int CurMonth;
        private static int CurDate;
        private static string CurDay;
        private static int shiftYear = 0;
        private static int shiftMonth = 0;
        private static int LastYear = 0;
        private static int LastMonth = 0;
        private static System.Windows.Forms.DataGridViewTextBoxColumn[] _D = _frmClassScheduleManager._D;
        

        public static INI INI = new INI(Application.StartupPath + @"\Init\" + "ClassScheduleManager.ini");

        public static string cbox_Year = DateTime.Now.Year.ToString();
        public static string cbox_Month = DateTime.Now.ToString("MM");

        /// 初始化排班表
        public static void initialTable()
        {
           string strCurY = DateTime.Now.ToString("yyyy");
           string strCurM = DateTime.Now.ToString("MM");
            bool nextMonthUpdate = false;
            for (int m = 0; m < 13; m++)
            {
                strCurY = DateTime.Now.AddMonths(m).ToString("yyyy");
                strCurM = DateTime.Now.AddMonths(m).ToString("MM");
                //確認talbe是否存在
                if (!checkTalbe(strCurY,strCurM))
                {
                    CreateShiftTable(strCurY, strCurM);   
                }
                //更新員工排班表
                string _tableName = string.Format("Table_ClassShift_{0}_{1}", strCurY, strCurM);
                if (m == 0)
                    nextMonthUpdate = false;
                else
                    nextMonthUpdate = true;

                InsertEmployeeIDtoShiftTable(_tableName, strCurY, strCurM,nextMonthUpdate);
            }
        }

        public static bool checkTalbe(string strCurY,string strCurM)
        {
           string CommandStr = string.Format("SELECT count(*) FROM EnglishClassShift.sys.tables WHERE name = 'Table_ClassShift_{0}_{1}' ", strCurY, strCurM);
            if (dbc.strExecuteScalar(CommandStr) == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void CreateShiftTable(string strCurY, string strCurM)
        {
            string CommandStr = "";
            string dateofmonthe = "";
            string com = ",";
            com = ",";
            daysofmonth = DateTime.DaysInMonth(Convert.ToInt16(strCurY), Convert.ToInt16(strCurM));
            for (int i = 1; i < daysofmonth + 1; i++)
            {
                if (i > daysofmonth - 1)
                {
                    com = " ";
                }
                dateofmonthe = dateofmonthe + string.Format("[D{0}] [varchar](2) NULL{1}", i.ToString().PadLeft(2, '0'), com);
            }

            CommandStr = string.Format("CREATE TABLE EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}]([EmployeeID] [int] NULL,{2}) ON [PRIMARY]"
       , strCurY, strCurM, dateofmonthe);
            dbc.ExecuteNonQuery(CommandStr);
        }

        public static void WriteEmployee(string employeeID,string classID,string strCurY, string strCurM)
        {
            //確認員工ID存在？
            string CommandStr = string.Format("select count(*) from Table_ClassScheduleManagement where EmployeeID='{0}'", employeeID);
             if( dbc.strExecuteScalar(CommandStr)=="0")
            {
                //不存在寫入員工ID
                CommandStr = string.Format("INSERT INTO [dbo].[Table_ClassScheduleManagement] ([ClassID],[EmployeeID]) VALUES ('{0}','{1}')", classID,employeeID);
                dbc.ExecuteNonQuery(CommandStr);
            }
             else
            {
                //存在更新ClassID
                CommandStr = string.Format("UPDATE [dbo].[Table_ClassScheduleManagement] SET [ClassID] = '{0}'  WHERE EmployeeID='{1}'",classID, employeeID);
                dbc.ExecuteNonQuery(CommandStr);
            }
        }

        public static string ReadEmployee(string employeeID,string strCurY, string strCurM)
        {
            string _classID = "";
            //確認員工ID存在？
            string CommandStr = string.Format("select count(*) from Table_ClassScheduleManagement where EmployeeID='{0}'", employeeID);
            if (dbc.strExecuteScalar(CommandStr) == "0")
            {
                MessageBox.Show(string.Format("請先設定員工 {0} 排班表班別",employeeID));
            }
            else
            {
                //存在更新ClassID
                CommandStr = string.Format("select ClassID from Table_ClassScheduleManagement where EmployeeID='{0}'",employeeID);
                _classID = dbc.strExecuteScalar(CommandStr);
            }
            return _classID;
        }

      
        /// <summary>
        /// 傳送員工ID到班別資料表
        /// </summary>
        public static void InsertEmployeeIDtoShiftTable(string _tableName, string strCurY, string strCurM, bool nextMonthUpdate)
        {
            DataTable _dataTable = new DataTable();
            //列出員工ID
            string CommandStr = "Select EmployeeID from EnglishClassDBtest.[dbo].[Table_EmployeeBasic]";
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                //cbox_classID.Items.Add(drw.ItemArray[0].ToString())
                CommandStr = string.Format("SELECT count(*) FROM EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}] WHERE EmployeeID = '{2}'", strCurY, strCurM, drw.ItemArray[0].ToString());
                //if 0，寫入Table
                string _eid = dbcR.strExecuteScalar(CommandStr);
                if(_eid=="0")
                {
                    CommandStr = string.Format("insert into EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}]([EmployeeID]) values('{2}') ", strCurY, strCurM, drw.ItemArray[0].ToString());
                    dbc.ExecuteNonQuery(CommandStr);
                    //InsertEmployeeClassSchedule(drw.ItemArray[0].ToString(), strCurY, strCurM);
                }
                if(nextMonthUpdate)
                InsertEmployeeClassSchedule(drw.ItemArray[0].ToString(), strCurY, strCurM);
            }
        }


        /// <summary>
        /// 存入排班代號
        /// </summary>
        public static void InsertEmployeeClassSchedule(string _EID, string strCurY, string strCurM)
        {
            string CommandStr = "";
            DataTable _dataTable = new DataTable();
            // string test = INI.ReadValue("ClassScheduleManager", Application.StartupPath + @"\Init\" + "ClassScheduleManager.ini",_EID);
            //string _classID = INI.ReadValue("ClassScheduleManager", _EID, "");
            string _classID = ReadEmployee(_EID,strCurY,strCurM);
            if(_classID!="")
            {
                List<String> _listclassID = new List<String>();
                CommandStr = string.Format("select * FROM [EnglishClassDBtest].[dbo].[Table_ClassSchedule]");
                _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);

                daysofmonth = DateTime.DaysInMonth(Convert.ToInt16(strCurY), Convert.ToInt16(strCurM));
                for (int i = 2; i < 34; i++)
                {
                    if (i < daysofmonth + 2)
                    {
                        for (int k = 7; k < 14; k++)
                        {
                            _D = _frmClassScheduleManager._D;
                            //MessageBox.Show(_dataTable.Rows[0][k].ToString());
                            if (_dataTable.Rows[0][k].ToString() == "False" && compartDayofWeek(k, ConvertDayofWeek(_D[i - 2].Name.ToString(), strCurY, strCurM)))
                            {
                                //dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[i].Value = _classID;
                                _listclassID.Add(_classID);

                            }
                            else if (_dataTable.Rows[0][k].ToString() == "True" && compartDayofWeek(k, ConvertDayofWeek(_D[i - 2].Name.ToString(), strCurY, strCurM)))
                            {
                                // dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[i].Value = "休";
                                _listclassID.Add("休");
                            }
                        }
                    }
                    else
                    {
                        //_D[i - 1].Visible = false;
                    }
                }

                //先刪除
                CommandStr = string.Format("DELETE FROM EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}] WHERE [EnglishClassShift].[dbo].[Table_ClassShift_{0}_{1}].EmployeeID='{2}' "
                     , CurYear, CurMonth.ToString().PadLeft(2, '0'), _EID);
                _dataTable = dbc.CommandFunctionDB("EnglishClassShift", CommandStr);
                //後新增
                string _insertValues = _EID + ",";
                int celCout = 0;
                foreach (String cel in _listclassID)
                {
                    //string Column1 = row.Cells[0].Value.ToString();
                    //string Column2 = row.Cells[1].Value.ToString();
                    if (celCout < daysofmonth - 1)
                    {
                        _insertValues = _insertValues + "'" + cel + "',";
                        celCout++;
                    }
                    else if (celCout == daysofmonth - 1)
                    {
                        _insertValues = _insertValues + "'" + cel + "'";
                        celCout++;
                    }

                }
                CommandStr = string.Format("Insert into EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}] Values({2})",
                     CurYear, CurMonth.ToString().PadLeft(2, '0'), _insertValues);
                _dataTable = dbc.CommandFunctionDB("EnglishClassShift", CommandStr);
                //refreshTable();
            }
        }

        private static bool compartDayofWeek(int k, string _daysofweek)
        {
            bool _bDofW = false;
            string _cdaysofweek = "";
            switch (k)
            {
                case 7:
                    _cdaysofweek = "日";
                    break;
                case 8:
                    _cdaysofweek = "一";
                    break;
                case 9:
                    _cdaysofweek = "二";
                    break;
                case 10:
                    _cdaysofweek = "三";
                    break;
                case 11:
                    _cdaysofweek = "四";
                    break;
                case 12:
                    _cdaysofweek = "五";
                    break;
                case 13:
                    _cdaysofweek = "六";
                    break;
            }
            return _bDofW = (_cdaysofweek == _daysofweek) ? true : false;
        }

        private static string ConvertDayofWeek(string _date, string strYear, string strMounth)
        {
            string DayofWeek = "";
            CurYear = Convert.ToInt32(strYear);
            CurMonth = Convert.ToInt32(strMounth);
            dt = new DateTime(CurYear, CurMonth, Convert.ToInt32(_date.Substring(1)));
            CurDay = dt.DayOfWeek.ToString("d");//tmp2 = 4 

            switch (CurDay)
            {
                case "1":
                    DayofWeek = "一";
                    break;
                case "2":
                    DayofWeek = "二";
                    break;
                case "3":
                    DayofWeek = "三";
                    break;
                case "4":
                    DayofWeek = "四";
                    break;
                case "5":
                    DayofWeek = "五";
                    break;
                case "6":
                    DayofWeek = "六";
                    break;
                case "0":
                    DayofWeek = "日";
                    break;
            }
            return DayofWeek;
        }
    }
}
