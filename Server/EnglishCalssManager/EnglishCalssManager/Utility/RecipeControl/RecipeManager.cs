using System;
using System.Collections;
using System.Reflection;

using System.Windows;
using System.Collections.Generic;

namespace _4RobotSystem.RecipeControl
{
    public static class Recipe_Manager
    {
        private static string strFolderName_Main = "Recipe";
        private static string strAllRecipeFileName = "RecipeList";
        private static string strCurrentCode = "CurrentRecipeNo";
        //public
        public static Recipe_Functions _Recipe_Functions = new Recipe_Functions();
        public static RecipeInfoGroup _RecipeInfoGroup = new RecipeInfoGroup();

        public static bool bIsGetstrCurrentRecipe = false;

        //初始化
        public static void Initialize()
        {
            ReadAllRecipe();         
            bIsGetstrCurrentRecipe = true;
        }

        //
        public static void ReadAllRecipe()
        {            
            Hashtable _ht = _Recipe_Functions.GetRecipeAll(strFolderName_Main, strAllRecipeFileName);
            if (_RecipeInfoGroup.lsRecipeInfo.Count > 0) _RecipeInfoGroup.lsRecipeInfo.Clear();
            foreach (DictionaryEntry entry in _ht)
            {
                if (entry.Key.ToString().Equals(strCurrentCode))
                {
                    _RecipeInfoGroup.strCurrentRecipeNo = entry.Value.ToString();
                    continue;
                }
                _RecipeInfoGroup.Add(entry.Key.ToString(), entry.Value.ToString());
            }
            for (int i = 0; i < _RecipeInfoGroup.lsRecipeInfo.Count; i++)
            {
                if (_RecipeInfoGroup.lsRecipeInfo[i].strRecipeNo.Equals(_RecipeInfoGroup.strCurrentRecipeNo))
                    _RecipeInfoGroup.strCurrentRecipeName = _RecipeInfoGroup.lsRecipeInfo[i].strRecipeName;
            }
            if(_RecipeInfoGroup.lsRecipeInfo.Count > 0)
            {
                Read_Recipe_ALL_Manager();
            }
            else
            {
                _RecipeInfoGroup.Add(_RecipeInfoGroup.strCurrentRecipeNo, _RecipeInfoGroup.strCurrentRecipeName);
                WriteAllRecipe();
            }
        }

        public static void Read_Recipe_ALL_Manager()
        {
            //readFile_Algorithm(ref Algorithm_Manager.Info_Left);
            //readFile_Algorithm(ref Algorithm_Manager.Info_Right);
            //readFile_Robot(ref Robot_Manger.Info_Left);
            //readFile_Robot(ref Robot_Manger.Info_Right);
            //readFile_AOI(ref AOI_Manager.Info_Left);
            //readFile_AOI(ref AOI_Manager.Info_Right);
            //readFile_Setting(Gocator_Manager.Info_Left, Gocator_Manager.Info_Left.strFileName);
            //readFile_Setting(Gocator_Manager.Info_Right, Gocator_Manager.Info_Right.strFileName);
            ////AOI 參數設定
            //AOI_Manager.bIsReset = false;
        }

        public static void WriteAllRecipe()
        {
            WriteRecipeList();
            Write_Recipe_ALL_Manager();
        }

        public static void WriteRecipeList()
        {
            Hashtable _ht = new Hashtable();
            for (int i = 0; i < _RecipeInfoGroup.lsRecipeInfo.Count; i++)
            {
                _ht.Add(_RecipeInfoGroup.lsRecipeInfo[i].strRecipeNo, _RecipeInfoGroup.lsRecipeInfo[i].strRecipeName);
            }
            _ht.Add(strCurrentCode, _RecipeInfoGroup.strCurrentRecipeNo);
            _Recipe_Functions.SetRecipeAll(strFolderName_Main, strAllRecipeFileName, _ht);
        }

        public static void Write_Recipe_ALL_Manager()
        {
            //writeFile_Algorithm(Algorithm_Manager.Info_Left);
            //writeFile_Algorithm(Algorithm_Manager.Info_Right);
            //writeFile_Robot(Robot_Manger.Info_Left);
            //writeFile_Robot(Robot_Manger.Info_Right);
            //writeFile_AOI(AOI_Manager.Info_Left);
            //writeFile_AOI(AOI_Manager.Info_Right);
            //writeFile_Setting(Gocator_Manager.Info_Left, Gocator_Manager.Info_Left.strFileName);
            //writeFile_Setting(Gocator_Manager.Info_Right, Gocator_Manager.Info_Right.strFileName);
            ////AOI 參數設定
            //AOI_Manager.bIsReset = false;
        }

        //讀取歷史資料
        public static void readFile_Algorithm()
        {
            //ref Algorithm_Info _Algorithm_Info
            //Hashtable _ht = _Recipe_Functions.GetRecipeSingle(strFolderName_Main, _Algorithm_Info.strFileName, _RecipeInfoGroup.strCurrentRecipeNo);
            //PropertyInfo[] _PropertyInfo = _Algorithm_Info.GetType().GetProperties();
            //foreach (DictionaryEntry entry in _ht)
            //{
            //    for (int i = 0; i < _PropertyInfo.Length; i++)
            //    {
            //        if (entry.Key.ToString().Equals(_PropertyInfo[i].Name))
            //        {
            //            switch (_PropertyInfo[i].PropertyType.Name)
            //            {
            //                case "Single":
            //                    _PropertyInfo[i].SetValue(_Algorithm_Info, Convert.ToSingle(entry.Value), null);
            //                    break;
            //                case "Boolean":
            //                    _PropertyInfo[i].SetValue(_Algorithm_Info, Convert.ToBoolean(entry.Value), null);
            //                    break;
            //                case "Int32":
            //                    _PropertyInfo[i].SetValue(_Algorithm_Info, Convert.ToInt32(entry.Value), null);
            //                    break;
            //                case "Double":
            //                    _PropertyInfo[i].SetValue(_Algorithm_Info, Convert.ToDouble(entry.Value), null);
            //                    break;
            //                case "String":
            //                    _PropertyInfo[i].SetValue(_Algorithm_Info, Convert.ToString(entry.Value), null);
            //                    break;
            //            }
            //        }
            //    }
            //}
        }

        public static void readFile_Robot()
        {
            //ref Robot_Info _Robot_Info
            //Hashtable _ht = _Recipe_Functions.GetRecipeSingle(strFolderName_Main, _Robot_Info.strFileName, _RecipeInfoGroup.strCurrentRecipeNo);
            //PropertyInfo[] _PropertyInfo = _Robot_Info.GetType().GetProperties();
            //foreach (DictionaryEntry entry in _ht)
            //{
            //    for (int i = 0; i < _PropertyInfo.Length; i++)
            //    {
            //        if (entry.Key.ToString().Equals(_PropertyInfo[i].Name))
            //        {
            //            switch (_PropertyInfo[i].PropertyType.Name)
            //            {
            //                case "Single":
            //                    _PropertyInfo[i].SetValue(_Robot_Info, Convert.ToSingle(entry.Value), null);
            //                    break;
            //                case "Boolean":
            //                    _PropertyInfo[i].SetValue(_Robot_Info, Convert.ToBoolean(entry.Value), null);
            //                    break;
            //                case "Int32":
            //                    _PropertyInfo[i].SetValue(_Robot_Info, Convert.ToInt32(entry.Value), null);
            //                    break;
            //                case "Double":
            //                    _PropertyInfo[i].SetValue(_Robot_Info, Convert.ToDouble(entry.Value), null);
            //                    break;
            //                case "String":
            //                    _PropertyInfo[i].SetValue(_Robot_Info, Convert.ToString(entry.Value), null);
            //                    break;
            //            }
            //        }
            //    }
            //}
        }

        public static void readFile_AOI()
        {
            //ref AOI_Info _AOI_Info
            //Hashtable _ht = _Recipe_Functions.GetRecipeSingle(strFolderName_Main, _AOI_Info.strFileName, _RecipeInfoGroup.strCurrentRecipeNo);
            //PropertyInfo[] _PropertyInfo = _AOI_Info.GetType().GetProperties();
            //foreach (DictionaryEntry entry in _ht)
            //{
            //    for (int i = 0; i < _PropertyInfo.Length; i++)
            //    {
            //        if (entry.Key.ToString().Equals(_PropertyInfo[i].Name))
            //        {
            //            switch (_PropertyInfo[i].PropertyType.Name)
            //            {
            //                case "Single":
            //                    _PropertyInfo[i].SetValue(_AOI_Info, Convert.ToSingle(entry.Value), null);
            //                    break;
            //                case "Boolean":
            //                    _PropertyInfo[i].SetValue(_AOI_Info, Convert.ToBoolean(entry.Value), null);
            //                    break;
            //                case "Int32":
            //                    _PropertyInfo[i].SetValue(_AOI_Info, Convert.ToInt32(entry.Value), null);
            //                    break;
            //                case "Double":
            //                    _PropertyInfo[i].SetValue(_AOI_Info, Convert.ToDouble(entry.Value), null);
            //                    break;
            //                case "String":
            //                    _PropertyInfo[i].SetValue(_AOI_Info, Convert.ToString(entry.Value), null);
            //                    break;
            //            }
            //        }
            //    }
            //}
        }

        public static void readFile_Setting(Object _Object, string _FileName)
        {
            Hashtable _ht = _Recipe_Functions.GetRecipeSingle(strFolderName_Main, _FileName, _RecipeInfoGroup.strCurrentRecipeNo);
            PropertyInfo[] _PropertyInfo = _Object.GetType().GetProperties();
            foreach (DictionaryEntry entry in _ht)
            {
                for (int i = 0; i < _PropertyInfo.Length; i++)
                {
                    if (entry.Key.ToString().Equals(_PropertyInfo[i].Name))
                    {
                        switch (_PropertyInfo[i].PropertyType.Name)
                        {
                            case "Single":
                                _PropertyInfo[i].SetValue(_Object, Convert.ToSingle(entry.Value), null);
                                break;
                            case "Boolean":
                                _PropertyInfo[i].SetValue(_Object, Convert.ToBoolean(entry.Value), null);
                                break;
                            case "Int32":
                                _PropertyInfo[i].SetValue(_Object, Convert.ToInt32(entry.Value), null);
                                break;
                            case "Double":
                                _PropertyInfo[i].SetValue(_Object, Convert.ToDouble(entry.Value), null);
                                break;
                            case "String":
                                _PropertyInfo[i].SetValue(_Object, Convert.ToString(entry.Value), null);
                                break;
                            case "List`1":
                                string[] ary = entry.Value.ToString().Split(',');
                                List<int> temp = new List<int>();
                                foreach (string x in ary)
                                {
                                    temp.Add(Convert.ToInt32(x));
                                }
                                _PropertyInfo[i].SetValue(_Object, temp, null);
                                break;
                        }
                    }
                }
            }
        }

        //寫入歷史資料
        public static void writeFile_Algorithm()
        {
            //Algorithm_Info _Algorithm_Info
            //PropertyInfo[] _PropertyInfo = _Algorithm_Info.GetType().GetProperties();
            //Hashtable _ht = new Hashtable();
            //for (int i = 0; i < _PropertyInfo.Length; i++)
            //{
            //    _ht[_PropertyInfo[i].Name] = _PropertyInfo[i].GetValue(_Algorithm_Info, null);
            //}
            //_Recipe_Functions.SetRecipeSingle(strFolderName_Main, _Algorithm_Info.strFileName, _RecipeInfoGroup.strCurrentRecipeNo, _ht);
        }

        public static void writeFile_Robot()
        {
            //Robot_Info _Robot_Info
            //PropertyInfo[] _PropertyInfo = _Robot_Info.GetType().GetProperties();
            //Hashtable _ht = new Hashtable();
            //for (int i = 0; i < _PropertyInfo.Length; i++)
            //{
            //    _ht[_PropertyInfo[i].Name] = _PropertyInfo[i].GetValue(_Robot_Info, null);
            //}
            //_Recipe_Functions.SetRecipeSingle(strFolderName_Main, _Robot_Info.strFileName, _RecipeInfoGroup.strCurrentRecipeNo, _ht);
        }

        public static void writeFile_AOI()
        {
        //    AOI_Info _AOI_Info
        //    PropertyInfo[] _PropertyInfo = _AOI_Info.GetType().GetProperties();
        //    Hashtable _ht = new Hashtable();
        //    for (int i = 0; i < _PropertyInfo.Length; i++)
        //    {
        //        _ht[_PropertyInfo[i].Name] = _PropertyInfo[i].GetValue(_AOI_Info, null);
        //    }
        //    _Recipe_Functions.SetRecipeSingle(strFolderName_Main, _AOI_Info.strFileName, _RecipeInfoGroup.strCurrentRecipeNo, _ht);
        }

        public static void writeFile_Setting(Object _Object, string _FileName)
        {
            PropertyInfo[] _PropertyInfo = _Object.GetType().GetProperties();
            Hashtable _ht = new Hashtable();
            for (int i = 0; i < _PropertyInfo.Length; i++)
            {
                _ht[_PropertyInfo[i].Name] = _PropertyInfo[i].GetValue(_Object, null);
            }
            _Recipe_Functions.SetRecipeSingle(strFolderName_Main, _FileName, _RecipeInfoGroup.strCurrentRecipeNo, _ht);
        }

    }
}
