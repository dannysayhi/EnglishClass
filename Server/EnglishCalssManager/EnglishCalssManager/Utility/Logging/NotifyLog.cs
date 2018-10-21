using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AOISystem.Utility.Logging
{
    public static class NotifyLog
    {
        public static string FilePath { get; set; }

        public static SynchronizationContext SynchronizationContext { get; set; }

        public static void Post(string format, params object[] arg)
        {
            Post(string.Format(format, arg));
        }

        public static void Post(string message)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                FilePath = Directory.GetCurrentDirectory();
            }
            string filename = FilePath +
                string.Format("\\NotifyLog\\{0:yyyy-MM-dd}.log", DateTime.Now);
            FileInfo finfo = new FileInfo(filename);
            if (finfo.Directory.Exists == false)
            {
                finfo.Directory.Create();
            }
            string writeString = string.Format("{0:yyyy.MM.dd HH:mm:ss} | {1}",
                DateTime.Now, message);
            File.AppendAllText(filename, writeString + Environment.NewLine, Encoding.Unicode);

            if (SynchronizationContext != null)
            {
                SynchronizationContext.Send((o) =>
                {
                    GetMessageNotificationWindow();
                    frmMessageNotification.GetInstance().Post(writeString);
                }, null);
            }
            else
            {
                GetMessageNotificationWindow();
                frmMessageNotification.GetInstance().Post(writeString);
            }
        }

        //判斷窗口是否已經打開
        private static bool CheckFormIsOpen(string Forms)
        {
            bool bResult = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == Forms)
                {
                    bResult = true;
                    break;
                }
            }
            return bResult;
        }

        private static void GetMessageNotificationWindow()
        {
            frmMessageNotification msgForm = null;
            bool wExist = CheckFormIsOpen("frmMessageNotification");

            if (!wExist)
            {
                msgForm = frmMessageNotification.GetInstance();
                msgForm.Name = "frmMessageNotification";
                msgForm.Show();
            }
            else
            {
                msgForm = (frmMessageNotification)Application.OpenForms["frmMessageNotification"];
                //msgForm.Show();
                msgForm.Activate();
            }
        }
        
        /// <summary>清除過期Log檔</summary>
        /// <param name="FilePath"></param>
        /// <param name="ReserveDay"></param>
        public static void Remove(string FilePath, int ReserveDay)
        {
            try
            {
                if (!Directory.Exists(FilePath))
                {
                    return;
                }
                string[] tempPaths = Directory.GetFiles(FilePath);
                int i = 0, yyyy = 0, MM = 0, dd = 0;
                DateTime tempDateTime;
                Log.Trace("過期檔案清理中==>" + DateTime.Now);
                foreach (string item in tempPaths)
                {
                    string FileName = item.Replace(FilePath  + "\\", "");
                    if (File.Exists(FilePath + @"\" + FileName))
                    {
                        yyyy = int.Parse(FileName.Substring(0, 4));
                        MM = int.Parse(FileName.Substring(5, 2));
                        dd = int.Parse(FileName.Substring(8, 2));
                        tempDateTime = DateTime.Parse(yyyy.ToString() + "/" + MM.ToString() + "/" + dd.ToString() + " 00:00:00");
                        if (tempDateTime.AddDays(ReserveDay) < DateTime.Now)
                        {
                            File.Delete(FilePath + @"\" + FileName);
                        }
                    }
                }
                Log.Trace("過期檔案清理完成==>" + DateTime.Now);
            }
            catch(Exception ex)
            {
                Log.Trace(ex.Message);
            }
        }
    }
}
