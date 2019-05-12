using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _4RobotSystem.RecipeControl
{
    /**********************************/
    //參數結構
    public class RecipeInfo
    {
        public string strDefaultRecipeNo = "000000";
        public string strDefaultRecipeName = "Default";
        //
        public string strRecipeNo = "";
        public string strRecipeName = "";
        //
        public RecipeInfo()
        {
            strRecipeNo = strDefaultRecipeNo;
            strRecipeName = strDefaultRecipeName;
        }
        public RecipeInfo(string _strRecipeNo,string _strRecipeName)
        {
            strRecipeNo = _strRecipeNo;
            strRecipeName = _strRecipeName;
        }
    }
    public class RecipeInfoGroup
    {
        
        public string strCurrentRecipeNo;
        public string strCurrentRecipeName;
        RecipeInfo _RecipeInfo = new RecipeInfo();
        public List<RecipeInfo> lsRecipeInfo = new List<RecipeInfo>();
        //
        public RecipeInfoGroup()
        {
            strCurrentRecipeNo = _RecipeInfo.strDefaultRecipeNo;
            strCurrentRecipeName = _RecipeInfo.strDefaultRecipeName;
        }
        //
        public void SetCurrentRecipe(string _strRecipeNo, string _strRecipeName)
        {
            strCurrentRecipeNo = _strRecipeNo;
            strCurrentRecipeName = _strRecipeName;
        }
        public void Add(string _strRecipeNo, string _strRecipeName)
        {
            _RecipeInfo = new RecipeInfo(_strRecipeNo, _strRecipeName);
            lsRecipeInfo.Add(_RecipeInfo);
        }
        public void Modify(int iIndex, string _strRecipeNo, string _strRecipeName)
        {
            _RecipeInfo = new RecipeInfo(_strRecipeNo, _strRecipeName);
            if (iIndex < 0) iIndex = 0;
            lsRecipeInfo[iIndex] = _RecipeInfo;
        }
        public void Delete(int iIndex)
        {
            if (lsRecipeInfo.Count > iIndex)
                lsRecipeInfo.RemoveAt(iIndex);           
        }
    }
    /**********************************/
}
