using System.ComponentModel;

using System;

namespace SmartCardSystem.DB
{
    public class ParamDB
    {
        #region - Public Constructor -
        public ParamDB()
            : base()
        {
        }
        #endregion - Public Constructor -

        #region - Private Properties -
        private string _User = "sa";
        private string _Password = "b22303409";
        private string _Source = System.Environment.MachineName + "\\SQLEXPRESS";
        private string _Database = "default";
        private string _Timeout = "10";
        private string _Security = "False";
        private string _Table1 = "hour_output";
        private string _Table2 = "total_output";
        private string _Table3 = "weight_" + DateTime.Now.ToString("yyyyMM");
        #endregion - Private Properties -

        #region - Private Methods -
        #endregion - Private Main Methods -

        #region - Public Properties - 資料庫基礎資訊
        [Browsable(true), Category("資料庫基礎資訊"), Description("使用者")]
        public string User { get { return _User; } set { _User = value; } }
        [Browsable(true), Category("資料庫基礎資訊"), Description("密碼")]
        public string Password { get { return _Password; } set { _Password = value; } }
        [Browsable(true), Category("資料庫基礎資訊"), Description("位置")]
        public string Source { get { return _Source; } set { _Source = value; } }
        [Browsable(true), Category("資料庫基礎資訊"), Description("連線逾時")]
        public string Timeout { get { return _Timeout; } set { _Timeout = value; } }
        [Browsable(true), Category("資料庫基礎資訊"), Description("安全性")]
        public string Security { get { return _Security; } set { _Security = value; } }
        #endregion - Public Properties - 資料庫基礎資訊

        #region - Public Properties - 資料表
        [Browsable(true), Category("資料表"), Description("DB")]
        public string Database { get { return _Database; } set { _Database = value; } }
        [Browsable(true), Category("資料表"), Description("Table 時產量")]
        public string Table_hhPP { get { return _Table1; } set { _Table1 = value; } }
        [Browsable(true), Category("資料表"), Description("Table 總產量")]
        public string Table_ttPP { get { return _Table2; } set { _Table2 = value; } }
        [Browsable(true), Category("資料表"), Description("Table 膠量")]
        public string Table_weight { get { return _Table3; } set { _Table3 = value; } }
        #endregion - Public Properties - 資料表
    }
}