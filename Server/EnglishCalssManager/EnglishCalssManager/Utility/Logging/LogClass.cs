/*類別說明:Log檔案類型讀寫及存檔功能。
 * 
 * 
 */
using System;
using System.IO;
using System.Windows.Forms;

namespace AOISystem.Utility.Logging
{

    /// <summary>
    /// 歷史紀錄類別
    /// </summary>
    public class LogClass
    {
        public delegate void logMessageDelegate(DateTime date, string logCategory, string logText);
        public event logMessageDelegate LogMessageEvent;

        private static LogClass logClass;

        private string logfilename = "";
        /// <summary>
        /// Log 類別建立
        /// </summary>
        /// <param name="filename">Log儲存檔案名稱</param>
        public LogClass(string filename)
        {
            logfilename = filename;
        }

        public static LogClass GetInstance()
        {
            if (logClass == null)
            {
                logClass = new LogClass("DebugLog");
            }
            return logClass;
        }

        /// <summary>
        /// Log輸出
        /// </summary>
        public string LogMessage
        {
            set
            {

                StreamWriter sw;
                DateTime logDate = DateTime.Now;
                //文字檔輸出
                string filename = logfilename + "_" + logDate.ToString("yyyyMMdd") + ".Log";
                try
                {
                OnLogMessageEvent(logDate, logfilename, value);
                value = logDate.ToString("HH:mm:ss ") + value;

                if (!Directory.Exists(Application.StartupPath + @"\LOG\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\LOG\");
                }
                JudgeDirectorySaveDate(Application.StartupPath + @"\LOG\");

                    sw = new StreamWriter(Application.StartupPath + @"\LOG\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + filename, true);
                    sw.WriteLine(value);
                    sw.Flush();
                    sw.Close();

                    sw.Dispose();
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\LOG\" + DateTime.Now.ToString("yyyyMMdd") + "\\");
                    sw = new StreamWriter(Application.StartupPath + @"\LOG\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + filename, true);
                    sw.WriteLine(value);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 刪除資料夾及所有檔案
        /// </summary>
        /// <param name="path"></param>
        public void DeleteDirectoryFiles(string path)
        {
            try
            {
                string[] tempDirectorys, tempDirectorys2, tempNames;
                if (Directory.Exists(path))
                {
                    tempDirectorys = Directory.GetDirectories(path);
                    for (int j = 0; j < tempDirectorys.Length; j++)
                    {
                        tempDirectorys2 = Directory.GetDirectories(tempDirectorys[j]);
                        if (tempDirectorys2.Length > 0)
                        {
                            DeleteDirectoryFiles(tempDirectorys2[j]);
                        }
                        DeleteFiles(tempDirectorys[j]);
                        Directory.Delete(tempDirectorys[j]);
                    }

                    DeleteFiles(path);
                    Directory.Delete(path);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
        }
        private void DeleteFiles(string path)
        {
            try
            {
                string[] tempNames;
                if (Directory.Exists(path))
                {
                    tempNames = Directory.GetFiles(path);
                    for (int i = 0; i < tempNames.Length; i++)
                    {
                        File.Delete(tempNames[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 判斷Log資料保存日期並做刪除動作
        /// </summary>
        /// <param name="path"></param>
        void JudgeDirectorySaveDate(string path)
        {
            try
            {
                string[] tempPaths = Directory.GetDirectories(path);
                string directoryStr;
                DateTime tempDateTime;

                for (int i = 0; i < tempPaths.Length; i++)
                {
                    int index = tempPaths[0].LastIndexOf('\\');
                    directoryStr = tempPaths[0].Substring(index + 1, tempPaths[0].Length - index - 1);
                    int yy = 2010, mm = 1, dd = 1;
                    yy = int.Parse(directoryStr.Substring(0, 4));
                    mm = int.Parse(directoryStr.Substring(4, 2));
                    dd = int.Parse(directoryStr.Substring(6, 2));
                    tempDateTime = DateTime.Parse(mm.ToString() + "/" + dd.ToString() + "/" + yy.ToString() + " 00:00:00");
                    if (tempDateTime.AddDays(ReserveDay) < DateTime.Now)
                    {
                        DeleteDirectoryFiles(path + directoryStr + "\\");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Log檔案名稱
        /// </summary>
        public string LogFileName
        {
            get
            {
                return logfilename;
            }
            set
            {
                logfilename = value;
            }
        }


        private int reserverDay = 30;
        /// <summary>
        ///保存期限
        /// </summary>
        public int ReserveDay
        {
            get
            {
                return GetInstance().reserverDay;
            }
            set
            {
                GetInstance().reserverDay = value;
            }
        }

        void OnLogMessageEvent(DateTime date, string logCategory, string logText)
        {
            if (GetInstance().LogMessageEvent != null)
            {
                GetInstance().LogMessageEvent(date, logCategory, logText);
            }
        }

    }

}
