using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AOISystem.Utility.IO
{
    public class CSVFile
    {
        #region - Export CSV File -
        /// <summary>
        /// Exports the DataGridView to CSV.
        /// </summary>
        /// <param name="dataGridView">The data grid view.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="ColumnName">Name of the column.</param>
        /// <param name="HasColumnName">if set to <c>true</c> [has column name].</param>
        public static void ExportDataGridViewToCsv(DataGridView dataGridView, string FileName, string[] ColumnName, bool HasColumnName)
        {
            string strValue = string.Empty;
            //CSV 匯出的標題 要先塞一樣的格式字串 充當標題
            if (HasColumnName == true)
                strValue = string.Join(",", ColumnName);
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView.Rows[i].Cells.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dataGridView[j, i].Value.ToString()))
                    {
                        if (j > 0)
                            strValue = strValue + "," + dataGridView[j, i].Value.ToString();
                        else
                        {
                            if (string.IsNullOrEmpty(strValue))
                                strValue = dataGridView[j, i].Value.ToString();
                            else
                                strValue = strValue + Environment.NewLine + dataGridView[j, i].Value.ToString();
                        }
                    }
                    else
                    {
                        if (j > 0)
                            strValue = strValue + ",";
                        else
                            strValue = strValue + Environment.NewLine;
                    }
                }
            }
            //存成檔案
            string strFile = FileName;
            if (!string.IsNullOrEmpty(strValue))
            {
                File.WriteAllText(strFile, strValue, Encoding.Default);
            }
        }
        /// <summary>
        /// Exports the data table to CSV.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="ColumnName">Name of the column.</param>
        /// <param name="HasColumnName">if set to <c>true</c> [has column name].</param>
        public static void ExportDataTableToCsv(DataTable dt, string FileName, string[] ColumnName, bool HasColumnName)
        {
            string strValue = string.Empty;
            //CSV 匯出的標題 要先塞一樣的格式字串 充當標題
            if (HasColumnName == true)
                strValue = string.Join(",", ColumnName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                    {
                        if (j > 0)
                            strValue = strValue + "," + dt.Rows[i][j].ToString();
                        else
                        {
                            if (string.IsNullOrEmpty(strValue))
                                strValue = dt.Rows[i][j].ToString();
                            else
                                strValue = strValue + Environment.NewLine + dt.Rows[i][j].ToString();
                        }
                    }
                    else
                    {
                        if (j > 0)
                            strValue = strValue + ",";
                        else
                            strValue = strValue + Environment.NewLine;
                    }
                }

            }
            //存成檔案
            string strFile = FileName;
            if (!string.IsNullOrEmpty(strValue))
            {
                File.WriteAllText(strFile, strValue, Encoding.Default);
            }
        }
        /// <summary>Reads the CSV to list.</summary>
        /// <param name="FileName">Name of the file.</param>
        /// <returns></returns>
        public static List<string> ReadCsvToList(string FileName)
        {
            FileInfo fi = new FileInfo(FileName);
            if (fi.Exists)
            {
                List<string> result = new List<string>();
                using (StreamReader sr = new StreamReader(FileName))
                {
                    while (sr.Peek() >= 0)
                    {
                        result.Add(sr.ReadLine());
                    }
                }
                return result;
            }
            else return null;
        }
        /// <summary>Write List Data to CSV.</summary>
        /// <param name="list"></param>
        /// <param name="FileName"></param>
        public static void ExportDataListToCsv(List<string> dataList, string FileName, string[] ColumnName, bool HasColumnName)
        {
            string strValue = string.Empty;
            //CSV 匯出的標題 要先塞一樣的格式字串 充當標題
            if (HasColumnName == true)
                strValue = string.Join(",", ColumnName) + Environment.NewLine;
            for (int i = 0; i < dataList.Count; i++)
            {
                strValue += dataList[i] + Environment.NewLine;
            }
            //存成檔案
            string strFile = FileName;
            if (!string.IsNullOrEmpty(strValue))
            {
                File.WriteAllText(strFile, strValue, Encoding.Default);
            }
        }
        /// <summary>
        /// Reads the CSV to data table.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="HasColumnName">if set to <c>true</c> [has column name].</param>
        /// <returns></returns>
        public static DataTable ReadCsvToDataTable(string FileName, bool HasColumnName)
        {
            List<string> Input = ReadCsvToList(FileName);
            if (Input != null)
            {
                string[] sep = new string[] { "," };
                DataTable dt = new DataTable();
                int StartCount = (HasColumnName == true) ? 1 : 0;
                string[] ColumnName = Input[0].Split(sep, StringSplitOptions.None);
                for (int i = 0; i < ColumnName.Length; i++)
                    dt.Columns.Add((HasColumnName == true) ? ColumnName[i] : "C" + i.ToString(), typeof(string));
                for (int j = StartCount; j < Input.Count; j++)
                {
                    string[] valuetemp = Input[j].Split(sep, StringSplitOptions.None);
                    dt.Rows.Add(valuetemp);
                }
                return dt;
            }
            else return null;
        }

        public static void AddData(string filePath, string fileName, string format, params object[] args)
        {
            StreamWriter sw;
            DateTime csvDate = DateTime.Now;
            try
            {
                string data = string.Format(format, args);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                sw = new StreamWriter(string.Format(@"{0}\{1}", filePath, fileName), true, Encoding.Default);
                sw.WriteLine(data);
                sw.Flush();
                sw.Close();

                sw.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddData(string filePath, string fileName, params object[] args)
        {
            StringBuilder format = new StringBuilder(args.Length);
            format.Append("{0}");
            for (int i = 1; i < args.Length; i++)
            {
                format.Append(",{" + i.ToString() + "}");
            }
            AddData(filePath, fileName, format.ToString(), args);
        }
        #endregion -  Export CSV File -

        public static string[] GetStringArrayValueFormParseString(string parseString)
        {
            return parseString.Split(',');
        }

        public static string GetParseStringFormStringArrayValue<T>(T[] array)
        {
            return String.Join(",", array);
        }

        public static int[] GetInt32ArrayValueFormParseString(string parseString)
        {
            string[] parseArray = parseString.Split(',', ';');
            int[] returnValue = new int[parseArray.Length];
            for (int i = 0; i < parseArray.Length; i++)
            {
                returnValue[i] = int.Parse(parseArray[i]);
            }
            return returnValue;
        }

        public static string GetParseStringFormInt32ArrayValue(int[] array)
        {
            string[] parseArray = new string[array.Length];
            for (int i = 0; i < parseArray.Length; i++)
            {
                parseArray[i] = array[i].ToString();
            }
            return String.Join(",", parseArray);
        }

        public static bool[] GetBooleanArrayValueFormParseString(string parseString)
        {
            string[] parseArray = parseString.Split(',', ';');
            bool[] returnValue = new bool[parseArray.Length];
            for (int i = 0; i < parseArray.Length; i++)
            {
                returnValue[i] = bool.Parse(parseArray[i]);
            }
            return returnValue;
        }

        public static string GetParseStringFormBooleanArrayValue(bool[] array)
        {
            string[] parseArray = new string[array.Length];
            for (int i = 0; i < parseArray.Length; i++)
            {
                parseArray[i] = array[i].ToString();
            }
            return String.Join(",", parseArray);
        }
    }
}
