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


namespace EnglishCalssManager.Report.StudentRecord
{
    public partial class frmStudentRecord : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public DatabaseCoreRollcall dbcR = DatabaseManager._databaseCoreRollcall;
        private string date = DateTime.Now.ToString("yyyyMMdd");
        public string _studentName = "";
        public string _studentID = "";
        public string _courseID = "";
        public int _rollcallCount = 0;
        private string startpage = "0";
        private int nextpage = 20;

        public frmStudentRecord()
        {
            InitializeComponent();
        }

        private void frmStudentRecord_Load(object sender, EventArgs e)
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select CourseName from Table_Course";
            _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_CourseName.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_CourseName.Text = cbox_CourseName.Items[0].ToString();
            selectStudentFromCourse();
            refreshTable();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.FileName = cbox_TwName.Text + " "+ cbox_CourseName.Text + " 學生刷卡紀錄 "+ date;
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
            Sheet.Cells[1, 1] = "學生ID"; Sheet.Cells[1, 2] = "學生姓名"; Sheet.Cells[1, 3] = "刷卡次數";
            Sheet.Cells[1, 4] = "刷卡時間"; Sheet.Cells[1, 5] = "點名方式"; Sheet.Cells[1, 6] = "備註";
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    string value = dataGridView1[j, i].Value.ToString();
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


        private void btnSelect_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void refreshTable()
        {
            DataTable _dataTableNew = new DataTable();
            DataTable _dataTable = new DataTable();
            string datelong = "";
            string dateshort = "";
            //string CommandStr = string.Format(" select count(*) from sysobjects where name='Table_StudentRollcall_{0}'", date);
            TimeSpan ts = dateTimePicker2.Value - dateTimePicker1.Value;
            int _intTs = Convert.ToInt16(Math.Ceiling(ts.TotalDays)) + 1;
            for (int i = 0; i < _intTs; i++)
            {
                ts = dateTimePicker2.Value - dateTimePicker1.Value.AddDays(i);
                if (ts.TotalDays > -1)
                {
                    //date = dateTimePicker1.Value.AddDays(i).ToString("dd");
                    datelong = dateTimePicker1.Value.AddDays(i).ToString("yyyyMMdd");
                    //dateshort = dateTimePicker1.Value.AddDays(i).ToString("yyyy_MM");
                    string CommandStr = string.Format("select count(*) from EnglishClassDBtestRollcall.sys.tables where name='Table_StudentRollcall_{0}'", datelong);
                    string _exit = dbc.strExecuteScalar(CommandStr);
                    if (_exit != "0")
                    {
                       _dataTableNew = selectLoop(datelong);
                        _dataTable.Merge(_dataTableNew);
                    }
                }
            }

            dataGridView1.DataSource = _dataTable;
            if (dataGridView1.ColumnCount>4)
            {
                this.dataGridView1.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
                this.dataGridView1.Columns[5].Width = dataGridView1.Width * 40 / 100;
            }
        }

        private DataTable selectLoop(string date)
        {
            DataTable _dataTable = new DataTable();

            string CommandStr = " Select EnglishClassDBtest.dbo.Table_Course.CourseID "
  + " From EnglishClassDBtest.dbo.Table_Course "
  + " Where  EnglishClassDBtest.dbo.Table_Course.CourseName = '"
  + cbox_CourseName.Text.ToString()
  + "' ";
            ///搜尋當班學生是否點名
            string _studentNameCond = "";
            if (cbox_TwName.Text!="全部")
            {
                _studentNameCond = string.Format(" and EnglishClassDBtest.dbo.Table_StudentBasic.TwName='{0}'", cbox_TwName.Text);
            }
            _courseID = dbc.strExecuteScalar(CommandStr);
            //string strtimeNow = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            //string strtimeToday = DateTime.Today.ToString("yyyy.MM.dd HH:mm:ss");
            CommandStr = string.Format("Select EnglishClassDBtest.dbo.Table_CourseManagement.StudentID,EnglishClassDBtest.dbo.Table_StudentBasic.TwName,"
               + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallCount, "
               + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.Rollcalltimes,"
               + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallType,"
               + " EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallMsg"
+ " from EnglishClassDBtest.dbo.Table_CourseManagement"
+ " left outer join EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
+ " on EnglishClassDBtest.dbo.Table_CourseManagement.StudentID = EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID"
+ " left outer join EnglishClassDBtest.dbo.Table_StudentBasic"
+ " on EnglishClassDBtest.dbo.Table_StudentBasic.StudentID = EnglishClassDBtest.dbo.Table_CourseManagement.StudentID"
+ " where EnglishClassDBtest.dbo.Table_CourseManagement.CourseID = '{1}'"
//+ " ORDER BY Table_StudentBasic.StudentID"
//+ " OFFSET " + startpage + " ROWS"
//+ " FETCH NEXT " + nextpage + " ROWS ONLY"
+ _studentNameCond, date, _courseID);
            _dataTable = dbc.CommandFunctionDB("Table_CourseManagement", CommandStr);

            return _dataTable;

        }

        private void selectStudentFromCourse()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "  Select Table_CourseManagement.CourseID,"
  + " Table_Course.CourseName ,"
  + " Table_CourseManagement.StudentID, "
  + "  Table_Course.EmployeeID , "
  + " Table_StudentBasic.TwName"
  + "  From Table_CourseManagement "
  + " left outer join Table_Course "
  + "  on Table_Course.CourseID=Table_CourseManagement.CourseID  "
  + "  left outer join Table_EmployeeBasic "
  + "  on Table_Course.EmployeeID=Table_EmployeeBasic.EmployeeID "
  + "  left outer join Table_StudentBasic  "
  + " on  Table_CourseManagement.StudentID=Table_StudentBasic.StudentID "
  + " Where  Table_Course.CourseName ='"
  + cbox_CourseName.Text.ToString()
  + "' ";
            _dataTable = dbc.CommandFunctionDB("Table_Course", CommandStr);
            cbox_TwName.Items.Add("全部");
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_TwName.Items.Add(drw.ItemArray[4].ToString());
            }
            cbox_TwName.Text = cbox_TwName.Items[0].ToString();
        }

        private void lb_endpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            startpage = (Convert.ToInt16(startpage) + nextpage).ToString();
            refreshTable();
        }

        private void lb_startpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Convert.ToInt16(startpage) > 4)
            {
                startpage = (Convert.ToInt16(startpage) - nextpage).ToString();
                refreshTable();
            }
        }
    }
}
