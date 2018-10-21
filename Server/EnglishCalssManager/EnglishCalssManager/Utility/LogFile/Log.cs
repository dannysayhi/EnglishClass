using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace _4RobotSystem.PCaGUtility.LogFile
{
    public static class Log
    {
        //
        private static object objLock1 = new object();
        private static object objLockCheckFile = new object();
        //
        private static System.Diagnostics.TextWriterTraceListener myListener;
        private static string strFilePath = Application.StartupPath + "\\Log";
        private static string strFileName = "Lab_Pai";
        private static string strFileNamePath;
        private static StreamWriter fsWriter;
        public static ListBox lbMSG = new ListBox();

        #region Public Function
        public static void SetLogFile(string _strFileName)
        {
            if (!_strFileName.Equals(""))
            {
                strFileName = _strFileName;
            }
            try
            {
                //Log資料夾存在確認
                if (!Directory.Exists(strFilePath))
                {
                    Directory.CreateDirectory(strFilePath);
                }
                //
                CheckLogFile();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 檢查Log File Exist
        /// </summary>
        public static void CheckLogFile()
        {
            string strFileDate = DateTime.Now.ToString("yyyyMMdd");
            strFileNamePath = strFilePath + "\\" + strFileDate + "-" + strFileName + ".txt";
            //檢查是否占用記憶體
            if (fsWriter != null)
            {
                fsWriter.Close();
            }
            //Log檔案存在確認
            if (File.Exists(strFileNamePath))
            {
                fsWriter = File.AppendText(strFileNamePath);
            }
            else
            {
                fsWriter = File.CreateText(strFileNamePath);
            }
            //
            myListener = new System.Diagnostics.TextWriterTraceListener(fsWriter);
            System.Diagnostics.Trace.Listeners.Add(myListener);
        }

        /// <summary>
        /// 刪除過期Log檔案
        /// </summary>
        /// <param name="_iExpiredDay"></param>
        public static void DeleteExpiredFile(int _iExpiredDay)
        {
            try
            {
                if (!Directory.Exists(strFilePath))
                {
                    return;
                }
                string[] tempPaths = Directory.GetFiles(strFilePath);
                int yyyy = 0, MM = 0, dd = 0;
                DateTime tempDateTime;
                Log.Trace("過期檔案清理中==>" + DateTime.Now);
                foreach (string item in tempPaths)
                {
                    string FileName = item.Replace(strFilePath + "\\", "");
                    if (File.Exists(strFilePath + @"\" + FileName))
                    {
                        yyyy = int.Parse(FileName.Substring(0, 4));
                        MM = int.Parse(FileName.Substring(5, 2));
                        dd = int.Parse(FileName.Substring(8, 2));
                        tempDateTime = DateTime.Parse(yyyy.ToString() + "/" + MM.ToString() + "/" + dd.ToString() + " 00:00:00");
                        if (tempDateTime.AddDays(_iExpiredDay) < DateTime.Now)
                        {
                            File.Delete(strFilePath + @"\" + FileName);
                        }
                    }
                }
                Log.Trace("過期檔案清理完成==>" + DateTime.Now);
            }
            catch (Exception ex)
            {
                Log.Trace(ex.Message);
            }
        }

        /// <summary>
        /// 異常記錄
        /// </summary>
        /// <param key="strMSG"></param>
        public static void Error(string strMSG)
        {
            Log.WriteLineToFile(DateTime.Now, CategoryFilterMode.ERR, Thread.CurrentThread.GetHashCode(), Thread.CurrentThread.Name, strMSG);
        }

        /// <summary>
        /// 警告訊息記錄
        /// </summary>
        /// <param key="strMSG"></param>
        public static void Warring(string strMSG)
        {
            Log.WriteLineToFile(DateTime.Now, CategoryFilterMode.WRN, Thread.CurrentThread.GetHashCode(), Thread.CurrentThread.Name, strMSG);
        }

        /// <summary>
        /// 系統訊息記錄
        /// </summary>
        /// <param key="strMSG"></param>
        public static void Info(string strMSG)
        {
            Log.WriteLineToFile(DateTime.Now, CategoryFilterMode.INF, Thread.CurrentThread.GetHashCode(), Thread.CurrentThread.Name, strMSG);
        }

        /// <summary>
        /// 歷程訊息記錄
        /// </summary>
        /// <param key="strMSG"></param>
        public static void Trace(string strMSG)
        {
            Log.WriteLineToFile(DateTime.Now, CategoryFilterMode.TRC, Thread.CurrentThread.GetHashCode(), Thread.CurrentThread.Name, strMSG);
        }
        /// <summary>
        /// 顯示動作記錄
        /// </summary>
        /// <param key="strMSG"></param>
        public static void ActiveInfo(string strMSG)
        {
            Log.WriteLineToFile(DateTime.Now, CategoryFilterMode.TRC, Thread.CurrentThread.GetHashCode(), Thread.CurrentThread.Name, strMSG);
        }
        #endregion

        /// <summary>
        /// 寫入檔案
        /// </summary>
        /// <param name="msgTime"></param>
        /// <param name="msglvl"></param>
        /// <param name="threadid"></param>
        /// <param name="threadName"></param>
        /// <param name="msg"></param>
        private static void WriteLineToFile(DateTime msgTime, CategoryFilterMode msglvl, int threadid, string threadName, string msg)
        {
            try
            {
                string strMessage;
                string strMSGtime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                strMessage = strMSGtime + " | " + msglvl + " | " + threadid + " | " + threadName + " | " + msg;
                lock (objLock1)
                {
                    //
                    if (lbMSG.Items.Count > 100) lbMSG.Items.Clear();
                    lbMSG.Items.Insert(0, strMessage);
                    //
                    CheckLogFile();
                    myListener.WriteLine(strMessage);
                    myListener.Flush();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    public enum CategoryFilterMode
    {
        /// <summary>
        /// 異常訊息
        /// </summary>
        ERR = 1,

        /// <summary>
        /// 警告訊息
        /// </summary>
        WRN = 2,

        /// <summary>
        /// 系統訊息記錄
        /// </summary>
        INF = 3,

        /// <summary>
        /// 歷程訊息記錄
        /// </summary>
        TRC = 4,
        /// <summary>
        /// 顯示動作記錄
        /// </summary>
        ACT = 5
    }
}
