using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace _4RobotSystem.PCaGUtility.FileControl
{
    public class INI
    {
        #region Import DLL
        [DllImport("Kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, uint nSize, string lpFileName);
        #endregion
        //
        private bool bDisposed = false;
        private string _FilePath = string.Empty;
        private static string strFilePath = Application.StartupPath + "\\INI";
        private static string strFileName = "PLC_Para";
        private static string strFileNamePath;
        //
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="path"> 檔案路徑 </param>
        public INI(string path)
        {
            _FilePath = path;
        }
        ~INI()
        {

        }

        public static void SetINIFile(string _strFileName)
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
                //CheckLogFile(_strFileName);
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 檢查Log File Exist
        /// </summary>
        //public static void CheckLogFile(string _strFileName)
        //{
        //    strFileNamePath = strFilePath + "\\" + _strFileName + ".ini";
        //    //檢查是否占用記憶體
        //    if (fsWriter != null)
        //    {
        //        fsWriter.Close();
        //    }
        //    //Log檔案存在確認
        //    if (File.Exists(strFileNamePath))
        //    {
        //        fsWriter = File.AppendText(strFileNamePath);
        //    }
        //    else
        //    {
        //        fsWriter = File.CreateText(strFileNamePath);
        //    }
        //    //
        //    myListener = new System.Diagnostics.TextWriterTraceListener(fsWriter);
        //    System.Diagnostics.Trace.Listeners.Add(myListener);
        //}

        /// <summary>
        /// 使用者呼叫
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            //告訴GC此物件的Finalize方法不再需要呼叫
            //GC.SuppressFinalize(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 系統呼叫
        /// </summary>
        protected virtual void Dispose(bool IsDisposing)
        {
            // 當物件已經被解構時，不再執行
            if (bDisposed)
            {
                return;
            }
            if (IsDisposing)
            {
                //在這裡釋放託管資源
                //只在使用者呼叫Dispose方法時執行
            }

            //在這裡釋放非託管資源
            //

            //標記物件已被釋放
            bDisposed = true;
        }



        public void WriteValue(String Section, String Key, String Value)
        {
            WritePrivateProfileString(Section, Key, Value, this._FilePath);
        }

        /// <summary>
        /// 取得Key相對的Value
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public String ReadValue(String Section, String Key, String DefaultValue)
        {
            try
            {
                StringBuilder sResult = new StringBuilder(255);
                GetPrivateProfileString(Section, Key, "", sResult, 255, this._FilePath);
                if (sResult.Length > 0)
                {
                    return sResult.ToString();
                }
                else
                {
                    return DefaultValue;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>  
        /// 获取INI文件中指定节点(Section)中的所有条目的Key列表  
        /// </summary>  
        /// <param name="iniFile">Ini文件</param>  
        /// <param name="section">节点名称</param>  
        /// <returns>如果没有内容,反回string[0]</returns>  
        public string[] INIGetAllItemKeys(string iniFile, string section)
        {
            StringBuilder sResult = new StringBuilder(255);
            string[] value = new string[0];
            const int SIZE = 1024 * 10;

            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            char[] chars = new char[SIZE];
            uint bytesReturned = GetPrivateProfileString(section, null, null, chars, SIZE, iniFile);

            if (bytesReturned != 0)
            {
                value = new string(chars).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }
            chars = null;

            return value;
        }
    }
}
