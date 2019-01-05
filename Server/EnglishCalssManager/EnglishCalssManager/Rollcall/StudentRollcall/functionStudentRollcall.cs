using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCalssManager.Rollcall.StudentRollcall
{
    public static class functionStudentRollcall
    {
        /// <summary>
        /// 取得當天日期
        /// </summary>
        public static string getDate
        {
            get { return DateTime.Now.ToString("yyyyMMdd"); }
           // get { return "20180902"; }

        }
        /// <summary>
        /// 取得刷卡次數
        /// </summary>
        /// <param name="date"></param>
        /// <param name="StudentID"></param>
        /// <returns></returns>
        public static string getCount(string date, string StudentID)
        {
            try
            {
                string CommandStr = string.Format("select Max( EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallCount) "
    + " from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID = '{1}'", date, StudentID);
                string _getCount = DatabaseManager._databaseCore.strExecuteScalar(CommandStr);
                return _getCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ex.ToString();
            }

        }

        //取得刷卡紀錄是否更新
        public static String getUpdate(string date, string StudentID)
        {
            try
            {
                string CommandStr = string.Format("select EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.IsUpdate"
    + " from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID = '{1}'", date, StudentID);
                string _getUpdate = DatabaseManager._databaseCore.strExecuteScalar(CommandStr);
                return _getUpdate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ex.ToString();
            }

        }

        // 更換更新flag
        public static void changeUpdate(string date, string StudentID, string _getChange)
        {
            string CommandStr = string.Format(
            "Update EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
            + " Set IsUpdate={1} "
            //+ " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CourseID={3}"
            //+ " and "
            + " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID={4}"
            , date
            , _getChange
            , "SYSDATETIME()"
            , " "
            , StudentID
            );
            DatabaseManager._databaseCore.ExecuteNonQuery(CommandStr);
        }
        /// <summary>
        /// 再次刷卡
        /// </summary>
        public static void studRCagain(string date, string StudentID, string _getCount)
        {
            int _rollcallCount = Convert.ToInt32(_getCount);
            _rollcallCount = Convert.ToInt32(_getCount);
            string CommandStr = string.Format(
            "Update EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
            + " Set RollcallCount={1},RollcallTimes={2},IsUpdate={3} "
            //+ " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CourseID={3}"
            //+ " and "
            + " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID={4}"
            , date
            , (_rollcallCount + 1).ToString()
            , "SYSDATETIME()"
            , "0"
            , StudentID
            );
            DatabaseManager._databaseCore.ExecuteNonQuery(CommandStr);
        }
        /// <summary>
        /// 第一次刷卡
        /// </summary>
        public static void studRCstart(string date, string StudentID, string _getCount, string _type)
        {
            string CommandStr = string.Format("Select EnglishClassDBtest.dbo.Table_CardNoticeSet.CardTitle from  EnglishClassDBtest.dbo.Table_CardNoticeSet where EnglishClassDBtest.dbo.Table_CardNoticeSet.numCardMsg = '{0}'", _getCount);
            string CardTitle = DatabaseManager._databaseCore.strExecuteScalar(CommandStr);
            if (CardTitle == "")
            {
                CommandStr = string.Format("select Max( EnglishClassDBtest.dbo.Table_CardNoticeSet.numCardMsg) from EnglishClassDBtest.dbo.Table_CardNoticeSet ");
                CardTitle = DatabaseManager._databaseCore.strExecuteScalar(CommandStr);
            }
            bool _bgetCount = true;
            if (_getCount == "未到"|| _getCount == "請假")
            {
                _bgetCount = false;
                CardTitle = "";
            }

            string _getCount2 = _getCount;
            if (_getCount2 != "")
            {
                if (CardTitle == ""&& _bgetCount==true)
                {
                    do
                    {
                        _getCount2 = (Convert.ToInt16(_getCount2) - 1).ToString();
                        CommandStr = string.Format("Select EnglishClassDBtest.dbo.Table_CardNoticeSet.CardTitle from  EnglishClassDBtest.dbo.Table_CardNoticeSet where EnglishClassDBtest.dbo.Table_CardNoticeSet.numCardMsg = '{0}'", _getCount2);
                        CardTitle = DatabaseManager._databaseCore.strExecuteScalar(CommandStr);
                    } while (CardTitle == "");
                }
                CommandStr = string.Format(
                       "insert into EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0} values('{1}', '{2}', '{3}', {4}, '{5}','{6}')"
                       , date
                       , " "
                       , StudentID
                       , _getCount
                       , "SYSDATETIME()"
                       , _type
                       , CardTitle
                       // , "0"
                       );
                DatabaseManager._databaseCore.ExecuteNonQuery(CommandStr);
            }

        }
    }
}
