using AOI_System.DB;
using AOISystem.Utility.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishClassManager.Utility.Database
{
   
   public class DatabaseCoreRollcall
    {
        #region DB property 
        public struct ParamDB
        {
            public string Source;
            public string User;
            public string Password;
            public string Database;
            public string Security;
            public string Timeout;
        }
        ParamDB paramDB = new ParamDB();
        public string connectionString, queryString;
        private static SqlConnection connection_temp;
        private static SqlCommand myCommand_temp;
        private string logTitle = "DatabaseCoreRollcall：";
        #endregion DB property 

        #region DB Constructor
        public DatabaseCoreRollcall(string Source, string User, string Database, string Password)
        {
            paramDB.Source = Source;
            paramDB.Password = Password;
            paramDB.Security = "False";
            paramDB.Timeout = "5";
            paramDB.User = User;
            paramDB.Database = Database;
            connectionString = CreateConString(paramDB);
        }
        ~DatabaseCoreRollcall()
        {

        }
        #endregion DB Constructor

        #region - DB function -
        ///<summary> DB Command Function </summary>
        public DataTable CommandFunctionDB(string dbTable, string CommandStr)
        {
            string[] result = new string[3];
            DataTable _dataTable = new DataTable();
            try
            {
                connectionString = CreateConString(paramDB);
                result[0] = connectionString;
                result[1] = queryString;
                if (IsServerConnected(connectionString))
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand myCommand = new SqlCommand(CommandStr, connection);
                    connection.Open();
                    SqlDataAdapter sAdapter;
                    DataSet sDs = null;
                    sAdapter = new SqlDataAdapter(myCommand);
                    sDs = new DataSet();
                    sAdapter.Fill(sDs, dbTable);
                    _dataTable = sDs.Tables[dbTable];
                    connection.Close();
                    connection.Dispose();
                }
                return _dataTable;
            }
            catch (Exception ex)
            {
                Log.Trace(logTitle + ex.ToString());
                MessageBox.Show(ex.ToString());
                return _dataTable;
            }
        }

        ///<summary> DB Command Function--strExecuteScalar </summary>
        public string strExecuteScalar(string CommandStr)
        {
            string[] result = new string[3];
            string strES = "";
            try
            {
                connectionString = CreateConString(paramDB);
                result[0] = connectionString;
                result[1] = queryString;
                if (IsServerConnected(connectionString))
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand myCommand = new SqlCommand(CommandStr, connection);
                    connection.Open();
                    strES = myCommand.ExecuteScalar().ToString();
                    connection.Close();
                    connection.Dispose();
                }
                return strES;
            }
            catch (Exception ex)
            {
                Log.Trace(logTitle + ex.ToString());
                MessageBox.Show(ex.ToString());
                return strES;
            }
        }

        ///<summary> DB Command Function --ExecuteNonQuery  </summary>
        public void ExecuteNonQuery(string CommandStr)
        {
            string[] result = new string[3];
            string strES = "";
            try
            {
                connectionString = CreateConString(paramDB);
                result[0] = connectionString;
                result[1] = queryString;
                if (IsServerConnected(connectionString))
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand myCommand = new SqlCommand(CommandStr, connection);
                    connection.Open();
                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                    //Log.Trace(logTitle + CommandStr);
                }
            }
            catch (Exception ex)
            {
                Log.Trace(logTitle + ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        ///<summary> DB Command Function Update</summary>
        public DataTable CommandFunctionTempDB(string dbTable, string CommandStr, DataTable _oldDT, bool _bCon)
        {
            string[] result = new string[3];
            DataTable _dataTable = new DataTable();
            try
            {
                connectionString = CreateConString(paramDB);
                result[0] = connectionString;
                result[1] = queryString;
                if (IsServerConnected(connectionString))
                {
                    if (_bCon)
                    {
                        SqlDataAdapter sAdapter;
                        DataSet sDs = null;
                        myCommand_temp = new SqlCommand(CommandStr, connection_temp);
                        sAdapter = new SqlDataAdapter(myCommand_temp);
                        sDs = new DataSet();
                        sAdapter.Fill(sDs, dbTable);
                        _dataTable = sDs.Tables[dbTable];
                        //connection_temp.Close();
                        //connection_temp.Dispose();

                        //connection_temp = new SqlConnection(connectionString);
                        //myCommand_temp = new SqlCommand(CommandStr, connection_temp);
                        //connection_temp.Open();
                        //_dataTable = _oldDT.Copy();
                        //DataSet ds = null;
                        //ds = new DataSet("dbTable");
                        ////送入就Datatable到DataSet
                        //ds.Tables.Add(_dataTable);
                        //SqlDataAdapter sAdapter;
                        //DataSet sDs = null;
                        ////執行MSsql 程式碼
                        //sAdapter = new SqlDataAdapter(myCommand_temp);
                        //sDs = new DataSet();
                        //sAdapter.Fill(sDs, dbTable);
                        //sAdapter.Update(ds, dbTable);
                    }
                    else
                    {
                        SqlDataAdapter sAdapter;
                        DataSet sDs = null;
                        myCommand_temp = new SqlCommand(CommandStr, connection_temp);
                        sAdapter = new SqlDataAdapter(myCommand_temp);
                        sDs = new DataSet();
                        sAdapter.Fill(sDs, dbTable);
                        _dataTable = sDs.Tables[dbTable];
                        connection_temp.Close();
                        connection_temp.Dispose();
                    }


                }
                return _dataTable;
            }
            catch (Exception ex)
            {
                Log.Trace(logTitle + ex.ToString());
                MessageBox.Show(ex.ToString());
                return _dataTable;
            }
        }
        /// <summary>
        /// 是否需保留連線
        /// </summary>
        /// <param name="CommandStr"></param>
        /// <param name="_bCon"  </param>
        ///  是否需保留連線>
        public void ExecuteNonQueryCon(string CommandStr,bool _bCon)
        {
            string[] result = new string[3];
            string strES = "";
            try
            {
                connectionString = CreateConString(paramDB);
                result[0] = connectionString;
                result[1] = queryString;
                if (IsServerConnected(connectionString))
                {
                    if (_bCon)
                    {
                        if (connection_temp == null)
                        {
                            connection_temp = new SqlConnection(connectionString);
                            connection_temp.Open();
                        }

                        myCommand_temp = new SqlCommand(CommandStr, connection_temp);
                        myCommand_temp.ExecuteNonQuery();
                    }
                    else
                    {
                        myCommand_temp = new SqlCommand(CommandStr, connection_temp);
                        myCommand_temp.ExecuteNonQuery();
                        connection_temp.Close();
                        connection_temp.Dispose();
                        connection_temp = null;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Log.Trace(logTitle + ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>從DB讀取</summary>
        public DataTable SelectFormDB(string dbTable, string[] tbList, string[] tbValue, string[] tbType)
        {
            string[] result = new string[3];
            DataTable _dataTable = new DataTable();
            try
            {
                connectionString = CreateConString(paramDB);
                queryString = "SELECT * FROM " + dbTable;
                List<string> queryResult = new List<string>();
                if(tbList.Length>0)
                {
                    queryString += " WHERE " + ValueToDBString(tbList, tbValue, tbType);
                }
                result[0] = connectionString;
                result[1] = queryString;
                if (IsServerConnected(connectionString))
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand myCommand = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataAdapter sAdapter;
                    DataSet sDs = null;
                    sAdapter = new SqlDataAdapter(myCommand);
                    sDs = new DataSet();
                    sAdapter.Fill(sDs, dbTable);
                    _dataTable = sDs.Tables[dbTable];
                    connection.Close();
                    connection.Dispose();
                }
                return  _dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return _dataTable;
            }
        }
        /// <summary>新增到DB</summary>
        public DataTable InsertToDB(string dbTable, string[] tbList, string[] tbValue, string[] tbType)
        {
            DataTable _dataTable = new DataTable();
            string[] result = new string[3];
            try
            {
                int length = tbList.Length;
                string[] typeTemp = new string[length];
                for (int i = 0; i < length; i++)
                {
                    typeTemp[i] = "_blank";
                }
                connectionString = CreateConString(paramDB);
                string queryString = "INSERT INTO " + dbTable + " (" + ListToDBString(tbList, typeTemp) + ") ";
                queryString += "VALUES" + " (" + ListToDBString(tbValue, tbType) + ") ";
                queryString += string.Format("Select * from {0} Where {1}='{2}'",dbTable,tbList[0],tbValue[0]);
                result[0] = connectionString;
                result[1] = queryString;
                if (IsServerConnected(connectionString))
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand myCommand = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataAdapter sAdapter;
                    DataSet sDs = null;
                    sAdapter = new SqlDataAdapter(myCommand);
                    sDs = new DataSet();
                    sAdapter.Fill(sDs, dbTable);
                    _dataTable = sDs.Tables[dbTable];
                    connection.Close();
                    connection.Dispose();
                }
                return _dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return _dataTable;
            }
        }
        /// <summary>修改到DB</summary>
        public string[] UpdateToDB(string dbTable, string[] tbList, string[] tbValue, string[] tbType
                  , string[] wbList, string[] wbValue, string[] wbType)
        {
            string[] result = new string[3];
            try
            {
                string connectionString = CreateConString(paramDB);
                string queryString = "UPDATE dbo." + dbTable + " SET " + ValueToDBString(tbList, tbValue, tbType);
                queryString += " WHERE " + ValueToDBString(wbList, wbValue, wbType);
                result[0] = connectionString;
                result[1] = queryString;

                if (IsServerConnected(connectionString))
                {
                    using (SqlConnection myConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand myCommand = new SqlCommand(queryString, myConnection))
                        {
                            myConnection.Open();
                            result[2] = "Count: " + Convert.ToString(myCommand.ExecuteNonQuery());
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        /// <summary>從DB刪除</summary>
        public string[] DeleteToDB(string dbTable, string[] wbList, string[] wbValue, string[] wbType)
        {
            string[] result = new string[3];
            try
            {
                string connectionString = CreateConString(paramDB);
                string queryString = "DELETE FROM dbo." + dbTable + " WHERE " + ValueToDBString(wbList, wbValue, wbType);
                result[0] = connectionString;
                result[1] = queryString;

                if (IsServerConnected(connectionString))
                {
                    using (SqlConnection myConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand myCommand = new SqlCommand(queryString, myConnection))
                        {
                            myConnection.Open();
                            result[2] = "Count: " + Convert.ToString(myCommand.ExecuteNonQuery());
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        #endregion - DB function -

        #region old function
        public void UpdateToDB(ref DataTable _dataTable, string sQL, string sTable)
        {
            connectionString = CreateConString(paramDB);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand(sQL, connection);
            connection.Open();
            SqlDataAdapter sAdapter;
            DataSet sDs = null;
            sAdapter = new SqlDataAdapter(myCommand);
            sDs = new DataSet();
            sAdapter.Fill(sDs, sTable);
            _dataTable = sDs.Tables[sTable];
            connection.Close();
            connection.Dispose();
        }
        public void DeleteToDB(ref DataTable _dataTable, string sQL, string sTable)
        {
            connectionString = CreateConString(paramDB);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand(sQL, connection);
            connection.Open();
            SqlDataAdapter sAdapter;
            DataSet sDs = null;
            sAdapter = new SqlDataAdapter(myCommand);
            sDs = new DataSet();
            sAdapter.Fill(sDs, sTable);
            _dataTable = sDs.Tables[sTable];
            connection.Close();
            connection.Dispose();
        }
        public void AddToDB(ref DataTable _dataTable, string sQL, string sTable)
        {
            connectionString = CreateConString(paramDB);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand(sQL, connection);
            connection.Open();
            SqlDataAdapter sAdapter;
            DataSet sDs = null;
            sAdapter = new SqlDataAdapter(myCommand);
            sDs = new DataSet();
            sAdapter.Fill(sDs, sTable);
            _dataTable = sDs.Tables[sTable];
            connection.Close();
            connection.Dispose();
        }
        #endregion old funtion

        #region DB string transfer function
        /// <summary>將文字字串轉為DB用字串：list = value  _blank:空白 _string:文字</summary>
        private string ValueToDBString(string[] list, string[] value, string[] type)
        {
            string dbString = null;
            string _type = null;
            int size = list.Length;

            for (int i = 0; i < size; i++)
            {
                _type = type[i];
                switch (_type)
                {
                    case "_blank":
                        if (i != 0) dbString = dbString + list[i] + " = " + value[i];
                        else dbString = list[i] + " = " + value[i];
                        break;
                    case "_string":
                        if (i != 0) dbString = dbString + list[i] + " like " + "'%" + value[i] + "%'";
                        else dbString = list[i] + " like " + "'%" + value[i] + "%'";
                        break;
                }
                if (size > 1 && i != size - 1) dbString = dbString + " or ";
            }
            return dbString;
        }
        /// <summary>將文字字串轉為DB用字串：list, list _blank:空白 _string:文字</summary>
        private string ListToDBString(string[] list, string[] type)
        {
            string dbString = null;
            string _type = null;
            int size = list.Length;

            for (int i = 0; i < size; i++)
            {
                _type = type[i];
                switch (_type)
                {
                    case "_blank":
                        if (i != 0) dbString = dbString + list[i];
                        else dbString = list[i];
                        break;
                    case "_string":
                        if (i != 0) dbString = dbString + "'" + list[i] + "'";
                        else dbString = "'" + list[i] + "'";
                        break;
                }
                if (size > 1 && i != size - 1) dbString = dbString + ", ";
            }
            return dbString;
        }
        /// <summary>確認資料庫是否連線</summary>
        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
        /// <summary>建立DB登入字串</summary>
        private string CreateConString(ParamDB paramDB)
        {
            var info = String.Format("Data Source ={0}; Initial Catalog ={1}; User ID ={2}; Password ={3}", paramDB.Source, paramDB.Database, paramDB.User, paramDB.Password);
            //var info = String.Format("Data Source ={0}; Initial Catalog ={1}; User ID ={2}", paramDB.Source, paramDB.Database, paramDB.User);
            //var info = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringRollcall"].ToString();
            return info;
        }
        #endregion DB string transfer function

    }
}
