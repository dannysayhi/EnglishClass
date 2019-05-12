using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace _4RobotSystem.RecipeControl
{
    public class Recipe_Functions
    {
        /******************************************************/
        //工單大綱功能
        /******************************************************/
        public void SetRecipeAll(string strFolderName_Main, string strAllRecipeFileName, Hashtable _Hashtable)
        {

            CheckFolderExist(Application.StartupPath, strFolderName_Main);
            //
            string strFileNamePath = Application.StartupPath + "\\" + strFolderName_Main;
            WriteJSONFile(strFileNamePath, strAllRecipeFileName + ".json", _Hashtable);
        }
        public Hashtable GetRecipeAll(string strFolderName_Main, string strAllRecipeFileName)
        {
            Hashtable _Hashtable = new Hashtable();
            CheckFolderExist(Application.StartupPath, strFolderName_Main);
            //
            string strFileNamePath = Application.StartupPath + "\\" + strFolderName_Main;
            CheckFileExist(strFileNamePath, strAllRecipeFileName + ".json");
            return ReadJSONFile(strFileNamePath, strAllRecipeFileName + ".json");
        }

        /******************************************************/
        //工單單一Manager功能
        /******************************************************/
        public void SetRecipeSingle(string strFolderName_Main, string strManagerName, string RecipeNo, Hashtable _Hashtable)
        {
            CheckFolderExist(Application.StartupPath, strFolderName_Main);
            CheckFolderExist(Application.StartupPath, strFolderName_Main + "\\" + RecipeNo);
            //
            string strFileNamePath = Application.StartupPath + "\\" + strFolderName_Main + "\\" + RecipeNo;
            WriteJSONFile(strFileNamePath, strManagerName + ".json", _Hashtable);
        }
        public Hashtable GetRecipeSingle(string strFolderName_Main, string strManagerName, string RecipeNo)
        {
            Hashtable _Hashtable = new Hashtable();
            CheckFolderExist(Application.StartupPath, strFolderName_Main);
            CheckFolderExist(Application.StartupPath, strFolderName_Main + "\\" + RecipeNo);
            //
            string strFileNamePath = Application.StartupPath + "\\" + strFolderName_Main + "\\" + RecipeNo;
            CheckFileExist(strFileNamePath, strManagerName + ".json");
            return ReadJSONFile(strFileNamePath, strManagerName + ".json");
        }


        /******************************************************/
        //JSON資料讀取
        /******************************************************/

        /// <summary>
        /// 檢查資料夾是否存在
        /// </summary>
        /// <param name="_strFileName"></param>
        private void CheckFolderExist(string strFilePath, string _strFileName)
        {
            string strFileNamePath = "";
            strFileNamePath = strFilePath + "\\" + _strFileName;
            if (!Directory.Exists(strFileNamePath))
            {
                Directory.CreateDirectory(strFileNamePath);
            }
        }

        /// <summary>
        /// 檢查檔案是否存在
        /// </summary>
        /// <param name="_strFileName"></param>
        private void CheckFileExist(string strFilePath, string _strFileName)
        {
            string strFileNamePath = "";
            strFileNamePath = strFilePath + "\\" + _strFileName;
            StreamWriter fsWriter;
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
        /// <summary>
        /// JSON寫入資料
        /// </summary>
        /// <param name="_Hashtable"></param>
        private void WriteJSONFile(string strFilePath, string _strFileName, Hashtable _Hashtable)
        {
            string strFileNamePath = "";
            strFileNamePath = strFilePath + "\\" + _strFileName;
            //clear text
            StreamWriter fsWriter = File.CreateText(strFileNamePath);
            //
            StringWriter sw = new StringWriter();
            JsonTextWriter jsonWriter = new JsonTextWriter(sw);
            jsonWriter.WriteStartObject();
            foreach (DictionaryEntry entry in _Hashtable)
            {
                if (entry.Value.GetType() == typeof(List<int>))
                {
                    var value = (List<int>)entry.Value;
                    string temp = null;
                    foreach (int x in value)
                    {   
                        if(temp!=null) { temp = temp + ","; }
                        temp = temp + x.ToString();
                    }
                    jsonWriter.WritePropertyName(entry.Key.ToString()); jsonWriter.WriteValue(temp);
                }
                else
                {
                    jsonWriter.WritePropertyName(entry.Key.ToString()); jsonWriter.WriteValue(entry.Value.ToString());
                }
            }
            jsonWriter.WriteEndObject();
            fsWriter.Write(sw.ToString());
            fsWriter.Flush();

            jsonWriter.Close();
            sw.Close();
            fsWriter.Close();
        }

        /// <summary>
        /// 讀取JSON檔案
        /// </summary>
        /// <returns></returns>
        private Hashtable ReadJSONFile(string strFilePath, string _strFileName)
        {
            Hashtable _Hashtable = new Hashtable();
            string strFileNamePath = "";
            strFileNamePath = strFilePath + "\\" + _strFileName;
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
                if (reader.Read())
                    if (reader.Value != null)
                        strValue = reader.Value.ToString();
                _Hashtable.Add(strKey, strValue);
            }
            //
            reader.Close();
            //
            return _Hashtable;
        }
    }
}
