using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using EnglishClassManager.DB;

namespace AOI_System.DB
{
    public class MainDB
    {
        #region - Public Constructor -
        public MainDB(string fileName)
        {
            string filePath = Application.StartupPath + @"\Init\" + fileName;
            _paramDB = new ParamDB(filePath);
            paramDB.ReadFromXml<ParamDB>(ref _paramDB);
        }
        ~MainDB()
        {
        }
        #endregion - Public Constructor -

        #region - Private Properties -
        private EnglishClassManager.DB.ParamDB _paramDB;
        #endregion - Private Properties -

        #region - Public Properties -
        public ParamDB paramDB { get { return _paramDB; } set { _paramDB = value; } }
        public string str = "1";
        #endregion - Public Properties -

        public void SetParam()
        {
            paramDB.ShowDialog(paramDB);
        }

        /// <summary>新增到DB</summary>
        public string[] InsertToDB(string dbTable, string[] tbList, string[] tbValue, string[] tbType)
        {
            string[] result = new string[3];
            try
            {
                int length = tbList.Length;
                string[] typeTemp = new string[length];

                for (int i = 0; i < length; i++)
                {
                    typeTemp[i] = "_blank";
                }

                string connectionString = CreateConString(paramDB);
                string queryString = "INSERT INTO dbo." + dbTable + " (" + ListToDBString(tbList, typeTemp) + ") ";
                queryString += "VALUES" + " (" + ListToDBString(tbValue, tbType) + ") ";
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

        /// <summary>從DB更新</summary>
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

        /// <summary>從DB讀取</summary>
        public string[] SelectFormDB(string dbTable, string[] tbList, string[] tbValue, string[] tbType)
        {
            string[] result = new string[3];
            try
            {
                string connectionString = CreateConString(paramDB);
                string queryString = "SELECT * FROM dbo." + dbTable;
                List<string> queryResult = new List<string>();
                queryString += " WHERE " + ValueToDBString(tbList, tbValue, tbType);
                result[0] = connectionString;
                result[1] = queryString;
                if (IsServerConnected(connectionString))
                {
                    using (SqlConnection myConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand myCommand = new SqlCommand(queryString, myConnection))
                        {
                            myConnection.Open();
                            var reader = myCommand.ExecuteReader();

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (result[2] != null) result[2] = result[2] + "," + reader[i];
                                    else result[2] = reader[i].ToString();
                                }
                            }
                            reader.Close();
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

        public string[] CreateDatabase(string databaseName)
        {
            string[] result = new string[3];
            try
            {
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public string[] CreateTable(string dbTable, string[] tbField, string[] tbType, string[] tbCondintion)
        {
            string[] result = new string[3];
            try
            {
                string connectionString = CreateConString(paramDB);
                string queryString = "IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES " +
                    " WHERE TABLE_NAME = \'dbo." + dbTable + "\'))" +
                    " BEGIN CREATE TABLE dbo." + dbTable +
                    "(" + CreateDBString(tbField, tbType, tbCondintion) + ") END ";

                List<string> queryResult = new List<string>();
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

        public DataTable SelectToGridView(string dbTable)
        {
            string connectionString = CreateConString(paramDB);
            string queryString = "SELECT * FROM dbo." + dbTable;
            SqlDataAdapter sAdapter;
            SqlCommandBuilder sBuilder;
            DataSet sDs = null;
            DataTable sTable = null;
            try
            {
                if (IsServerConnected(connectionString))
                {
                    using (SqlConnection myConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand myCommand = new SqlCommand(queryString, myConnection))
                        {
                            sAdapter = new SqlDataAdapter(myCommand);
                            sBuilder = new SqlCommandBuilder(sAdapter);
                            sDs = new DataSet();
                            sAdapter.Fill(sDs, dbTable);
                            sTable = sDs.Tables[dbTable];
                        }
                    }
                }
                return sTable;
            }
            catch (Exception ex)
            {
                return sTable;
            }
        }

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
            var info = "Data Source=" + paramDB.Source +
                       //";Network Library=DBMSSOCN" +
                       ";User Id=" + paramDB.User +
                       ";Password=" + paramDB.Password +
                       ";Database=" + paramDB.Database +
                       ";Integrated Security=" + paramDB.Security +
                       ";Connection Timeout=" + paramDB.Timeout;
            return info;
        }

        ///
        private string CreateDBString(string[] list, string[] type, string[] condition)
        {
            string dbString = null;
            int size = list.Length;

            for (int i = 0; i < size; i++)
            {
                if ( i == (size -1 )) dbString = dbString + list[i] + " " + type[i] + " " + condition[i] ;
                else dbString = dbString + list[i] + " " + type[i] + " " + condition[i] + ", ";
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
                if(size > 1 && i != size-1) dbString = dbString + ", ";
            }
            return dbString;
        }

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
                        else dbString = list[i] + " = " +value[i];
                        break;
                    case "_string":
                        if (i != 0) dbString = dbString + list[i] + " = " + "'" + value[i] + "'";
                        else dbString = list[i] + " = " + "'" + value[i] + "'";
                        break;
                }
                if (size > 1 && i != size - 1) dbString = dbString + " AND ";
            }
            return dbString;
        }
    }
}
