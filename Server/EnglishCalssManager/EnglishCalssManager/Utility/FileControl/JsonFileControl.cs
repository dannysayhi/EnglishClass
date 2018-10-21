using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections;

namespace _4RobotSystem.PCaGUtility.FileControl
{
    public static class JsonFileControl
    {
        private static string strFilePath = Application.StartupPath + "\\Init";
        private static string strFileName = "Json";
        private static string strFileNamePath= "";
        private static StreamWriter fsWriter;
        //
        public static void SetJsonFile(string _strFileName)
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
                CheckFile(_strFileName);
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 檢查Log File Exist
        /// </summary>
        public static void CheckFile(string _strFileName)
        {
            strFileNamePath = strFilePath + "\\" +  strFileName + ".json";
            //檢查是否占用記憶體
            if (fsWriter != null)
            {
                fsWriter.Close();
            }
            //Json檔案存在確認
            if (File.Exists(strFileNamePath))
            {
                fsWriter = File.AppendText(strFileNamePath);
            }
            else
            {
                fsWriter = File.CreateText(strFileNamePath);
            }
            fsWriter.Close();
        }

        public static void WriteJSONFile(Hashtable _Hashtable)
        {
            //clear text
            fsWriter = File.CreateText(strFileNamePath);
            //
            StringWriter sw = new StringWriter();
            JsonTextWriter jsonWriter = new JsonTextWriter(sw);
            jsonWriter.WriteStartObject();
            foreach (DictionaryEntry entry in _Hashtable)
            {
                jsonWriter.WritePropertyName(entry.Key.ToString()); jsonWriter.WriteValue(entry.Value.ToString());
            }
            jsonWriter.WriteEndObject();
            WriteFile(sw.ToString());
        }
        private static void WriteFile(string strContent)
        {
            fsWriter.Write(strContent);
            fsWriter.Flush();
        }
        public static Hashtable ReadJSONFile()
        {
            Hashtable _Hashtable = new Hashtable();
            StreamReader sr = File.OpenText(@strFileNamePath);
            string strJson = sr.ReadToEnd();
            // 關閉串流
            sr.Close();
            //解析
            JsonTextReader reader = new JsonTextReader(new StringReader(strJson));
            string strKey = "";
            string strValue = "";
            while (reader.Read())
            {
                if ((string)reader.Value == "StartObject" || reader.Value == null) continue;
                if (reader.Value != null)
                {
                    strKey = reader.Value.ToString();                    
                }
                if(reader.Read())
                    if (reader.Value != null)
                        strValue = reader.Value.ToString();
                _Hashtable.Add(strKey, strValue);
            }
            return _Hashtable;
        }

    }
}
