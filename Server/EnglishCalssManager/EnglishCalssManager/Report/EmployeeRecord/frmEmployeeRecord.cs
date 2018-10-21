using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace EnglishCalssManager.Report.EmployeeRecord
{
    public partial class frmEmployeeRecord : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public DatabaseCoreRollcall dbcR = DatabaseManager._databaseCoreRollcall;
        public string date = DateTime.Now.ToString("dd");
        public string datelong = DateTime.Now.ToString("yyyyMMdd");
        public string dateshort = DateTime.Now.ToString("yyyy_MM");
        public string _classSelect;

        public frmEmployeeRecord()
        {
            InitializeComponent();
        }

        private void frmEmployeeRecord_Load(object sender, EventArgs e)
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select ClassID from Table_ClassSchedule";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            cbox_ClassID.Items.Add("*");
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_ClassID.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_ClassID.Text = cbox_ClassID.Items[0].ToString();

            CommandStr = "Select TwName from Table_EmployeeBasic";
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            //cbox_EmployeeName.Items.Add("*");
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_EmployeeName.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_EmployeeName.Text = cbox_EmployeeName.Items[0].ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.ToString("dd");
            datelong = dateTimePicker1.Value.ToString("yyyyMMdd");
            dateshort = dateTimePicker1.Value.ToString("yyyy_MM");
            _classSelect = cbox_ClassID.Text;

            if (cbox_ClassID.Text=="*")
            {
                MessageBox.Show("請選擇一個群組");
            }
            else
            {
                refreshTable();
            }
           
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.FileName = cbox_EmployeeName.Text + " " + cbox_ClassID.Text + " 員工刷卡紀錄 " + datelong;
            save.Filter = "*.xlsx|*.xlsx";
            if (save.ShowDialog() != DialogResult.OK) return;

            // Excel 物件 
            Excel.Application xls = null;
            try
            {
                xls = new Excel.Application();
                // Excel WorkBook 
                Excel.Workbook book = xls.Workbooks.Add();
                // Excel WorkBook，預設會產生一個 WorkSheet，索引從 1 開始，而非 0 
                // 寫法1 
                Excel.Worksheet Sheet = (Excel.Worksheet)book.Worksheets.Item[1];
                // 寫法2 
                //Excel.Worksheet Sheet = (Excel.Worksheet)book.Worksheets[1];
                // 寫法3 
                //Excel.Worksheet Sheet = xls.ActiveSheet;

                // 把 DataGridView 資料塞進 Excel 內 
                DataGridView2Excel(Sheet);
                // 儲存檔案 
                book.SaveAs(save.FileName);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                xls.Quit();
            }
        }

        private void DataGridView2Excel(Excel.Worksheet Sheet)
        {
            // 下面方法二選一使用 
            // 利用 DataGridView  
            Sheet.Cells[1, 1] = "員工ID"; Sheet.Cells[1, 2] = "員工班別"; Sheet.Cells[1, 3] = "員工姓名";
            Sheet.Cells[1, 4] = "部門"; Sheet.Cells[1, 5] = "職稱"; Sheet.Cells[1, 6] = "刷卡日期";
            Sheet.Cells[1, 7] = "狀態"; Sheet.Cells[1, 8] = "表定上班時間"; Sheet.Cells[1, 9] = "表定下班時間註";
            Sheet.Cells[1, 10] = "刷卡上班時間"; Sheet.Cells[1, 11] = "刷卡下班時間"; Sheet.Cells[1, 12] = "遲到";
            Sheet.Cells[1, 13] = "早退"; Sheet.Cells[1, 14] = "上班時數"; 
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count-3; j++)
                {
                    string value = "";
                    if (dataGridView1[j, i].Value!=null)
                    { value = dataGridView1[j, i].Value.ToString(); }
                   Sheet.Cells[i + 2, j + 1] = value;
                }
            }

            //// 利用 List<Employ> 
            //List<Employ> empList = (List<Employ>)dataGridView1.DataSource;
            //foreach (Employ emp in empList)
            //{
            //    int
            //        rowindex = empList.IndexOf(emp) + 1,
            //        colindex = 1;

            //    Sheet.Cells[rowindex, colindex++] = emp.EmpNO;
            //    Sheet.Cells[rowindex, colindex++] = emp.EmpName;
            //    Sheet.Cells[rowindex, colindex++] = emp.Birthday;
            //    Sheet.Cells[rowindex, colindex++] = emp.Salary;
            //}
        }

        public void refreshTable()
        {
            if (dataGridView1.Rows.Count > 1)
            {
                while (dataGridView1.Rows.Count != 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                }
            }

            TimeSpan ts = dateTimePicker2.Value-dateTimePicker1.Value;
            int _intTs =Convert.ToInt16( Math.Ceiling( ts.TotalDays))+1;
            int stratdate = 0;
            for(int i=0; i<_intTs;i++)
            {
                ts = dateTimePicker2.Value - dateTimePicker1.Value.AddDays(i);
                if (ts.TotalDays>-1)
                {
                    date = dateTimePicker1.Value.AddDays(i).ToString("dd");
                    datelong = dateTimePicker1.Value.AddDays(i).ToString("yyyyMMdd");
                    dateshort = dateTimePicker1.Value.AddDays(i).ToString("yyyy_MM");
                    string CommandStr = string.Format("select count(*) from EnglishClassDBtestRollcall.sys.tables  where name='Table_EmployeeRollcall_{0}' ", datelong);
                    string _exit = dbc.strExecuteScalar(CommandStr);
                    if(_exit!="0")
                    {
                        selectLoop(ref stratdate);
                    }
                }
            }
        }
        
        private void selectLoop(ref int i)
        {
            //int _dataCurRowIndex = dataGridView1.CurrentCell.RowIndex;
            //string CommandStr = string.Format("select TwName from Table_EmployeeBasic where EmployeeID='{0}'", _dataCurRowIndex);
            string _selectClassShift = string.Format("and EnglishClassShift.dbo.Table_ClassShift_{0}.D{1} != ''", dateshort, date);

             string CommandStr = string.Format(" select distinct * from EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
                + " left outer join EnglishClassDBtest.dbo.Table_ClassSchedule"
                + " on  EnglishClassDBtest.dbo.Table_ClassSchedule.ClassID = EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.ClassID"
                + " left outer join EnglishClassDBtest.dbo.Table_EmployeeBasic"
                + " on  EnglishClassDBtest.dbo.Table_EmployeeBasic.EmployeeID = EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID"
                + " left outer join EnglishClassDBtest.dbo.Table_EmployeeBook"
                + " on  EnglishClassDBtest.dbo.Table_EmployeeBook.EmployeeID = EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID"
                + " left outer join EnglishClassShift.dbo.Table_ClassShift_{1}"
                + " on  EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID = EnglishClassShift.dbo.Table_ClassShift_{1}.EmployeeID"
                + " where EnglishClassDBtest.dbo.Table_EmployeeBasic.TwName='{2}'"
                +" {3}",
                datelong, dateshort,cbox_EmployeeName.Text ,_selectClassShift);
            DataTable _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            // dataGridView1.DataSource = _dataTable;

            foreach (DataRow drw in _dataTable.Rows)
            {
                //string mon = DateTime.Parse(drw.ItemArray[2].ToString()).ToString("yyyy-MM-dd");
                try
                {
                    dataGridView1.Rows[i].Cells["EmployeeID"].Value = drw.ItemArray[0].ToString();// _dataTable.Rows[0][0];
                    string _workStart = drw.ItemArray[11].ToString() + ":" + drw.ItemArray[12].ToString();
                    string _workEnd = drw.ItemArray[13].ToString() + ":" + drw.ItemArray[14].ToString();
                    string _rollcallStart = drw.ItemArray[3].ToString();//DateTime.Parse(drw.ItemArray[3].ToString()).ToString("HH:mm:ss");
                    string _rollcallEnd = drw.ItemArray[4].ToString();//DateTime.Parse(drw.ItemArray[4].ToString()).ToString("HH:mm:ss");
                    string _rollcallDatetime = drw.ItemArray[2].ToString();
                    //string _rollcallEarly = "";
                    //string _rollcallLate = "";
                    // diffTimeFunction(_workStart,_workEnd,_rollcallStart,_rollcallEnd,ref _rollcallEarly,ref _rollcallLate, drw.ItemArray[0].ToString(),ref _rollcallDatetime);
                    dataGridView1.Rows.Add(drw.ItemArray[0].ToString());
                    dataGridView1.Rows[i].Cells["ClassID"].Value = drw.ItemArray[1].ToString();// _dataTable.Rows[0][0];
                    dataGridView1.Rows[i].Cells["TwName"].Value = drw.ItemArray[25].ToString(); ;// _dataTable.Rows[0][11];
                    dataGridView1.Rows[i].Cells["Dept"].Value = drw.ItemArray[32].ToString();// _dataTable.Rows[0][18];
                    dataGridView1.Rows[i].Cells["Position"].Value = drw.ItemArray[31].ToString(); //_dataTable.Rows[0][17];
                    dataGridView1.Rows[i].Cells["ClassStart"].Value = _workStart; //_dataTable.Rows[0][17];
                    dataGridView1.Rows[i].Cells["ClassEnd"].Value = _workEnd; //_dataTable.Rows[0][17];
                    dataGridView1.Rows[i].Cells["RollcallDate"].Value = _rollcallDatetime; // _dataTable.Rows[0][2];
                    dataGridView1.Rows[i].Cells["RollCallState"].Value = drw.ItemArray[8].ToString();//_dataTable.Rows[0][8];
                    dataGridView1.Rows[i].Cells["RollcallStart"].Value = _rollcallStart; //_dataTable.Rows[0][3];
                    dataGridView1.Rows[i].Cells["RollcallEnd"].Value = _rollcallEnd; // _dataTable.Rows[0][4];
                    dataGridView1.Rows[i].Cells["RollCallLate"].Value = drw.ItemArray[5].ToString().Substring(0, 8); //_dataTable.Rows[0][5];
                    dataGridView1.Rows[i].Cells["RollCallEarly"].Value = drw.ItemArray[6].ToString().Substring(0, 8); ; //_dataTable.Rows[0][6];
                    dataGridView1.Rows[i].Cells["RollcallHR"].Value = drw.ItemArray[7].ToString();// _dataTable.Rows[0][7];
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.ToString());
                }

                i++;
            }
        }
    }
}
