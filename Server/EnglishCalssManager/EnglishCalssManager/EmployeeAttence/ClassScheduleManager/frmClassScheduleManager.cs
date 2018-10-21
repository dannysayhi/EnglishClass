using _4RobotSystem.PCaGUtility.FileControl;
using EnglishCalssManager.EmployeeAttence.ClassScheduleManager;
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

namespace EnglishClassManager.EmployeeAttence.ClassScheduleManager
{
    public partial class frmClassScheduleManager : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        private INI INI;

        private DateTime dt;
        private DateTime currentTime = DateTime.Now;
        private int daysofmonth=31;
        private bool _biniCopF = false;
        private int CurYear;
        private int CurMonth;
        private int CurDate;
        private string CurDay;
        private int shiftYear = 0;
        private int shiftMonth = 0;
        
        public System.Windows.Forms.DataGridViewTextBoxColumn[] _D= new System.Windows.Forms.DataGridViewTextBoxColumn[31];

        

        public frmClassScheduleManager()
        {
            InitializeComponent();
            
            DataTable _dataTable = new DataTable();
            //dtBK = (DataTable)dataGridView1.DataSource;
            //列出班別ID
            string CommandStr = "Select ClassID from Table_ClassSchedule";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            cbox_classID.Items.Add("休");
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_classID.Items.Add(drw.ItemArray[0].ToString());
            }
            //初始化日期/Daysofweek
            initialDcomp();
        }

        private void frmClassScheduleManager_Load(object sender, EventArgs e)
        {
            INI = new INI(Application.StartupPath + @"\Init\"+ "ClassScheduleManager.ini");
            ResizeDG();
            CreateShiftTable();
        }
        /// <summary>
        /// 建立班別資料表
        /// </summary>
        public void CreateShiftTable()
        {
            baseClassScheduleManager.initialTable();
            //顯示員工排班表
            refreshTable();
        }
        /// <summary>
        /// 設定當日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setDay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex < dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex].Value = cbox_classID.Text;

                DataTable _dataTable = new DataTable();
                //先刪除
                string CommandStr = string.Format("DELETE FROM EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}] WHERE [EnglishClassShift].[dbo].[Table_ClassShift_{0}_{1}].EmployeeID='{2}' "
                     , CurYear, CurMonth.ToString().PadLeft(2, '0'), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                _dataTable = dbc.CommandFunctionDB("EnglishClassShift", CommandStr);
                //後新增
                string _insertValues = "";
                daysofmonth = DateTime.DaysInMonth(Convert.ToInt32(cbox_Year.Text), Convert.ToInt32(cbox_Month.Text));
                int celCout = 0;
                foreach (DataGridViewCell cel in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                {
                    //string Column1 = row.Cells[0].Value.ToString();
                    //string Column2 = row.Cells[1].Value.ToString();
                    if (celCout < daysofmonth + 1 && celCout != 1)
                    {
                        _insertValues = _insertValues + "'" + cel.Value.ToString() + "',";
                    }
                    else if (celCout == daysofmonth + 1)
                    {
                        _insertValues = _insertValues + "'" + cel.Value.ToString() + "'";

                    }
                    celCout++;
                }
                CommandStr = string.Format("Insert into EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}] Values({2})",
                     CurYear, CurMonth.ToString().PadLeft(2, '0'), _insertValues);
                _dataTable = dbc.CommandFunctionDB("EnglishClassShift", CommandStr);
                refreshTable();
            }
            else
            {
                MessageBox.Show("請點選員工！");
            }
        }
        /// <summary>
        /// 設定當月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void set_Month_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex  < dataGridView1.Rows.Count-1)
            {
                string CommandStr = string.Format(" ");
                baseClassScheduleManager.WriteEmployee(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(), cbox_classID.Text,cbox_Year.Text,cbox_Month.Text);
                if (cbox_classID.Text!="休")
                {
                     CommandStr = string.Format("select * FROM [EnglishClassDBtest].[dbo].[Table_ClassSchedule] where ClassID='{0}'",
                  cbox_classID.Text);
                }
                else
                {
                    CommandStr = string.Format("select * FROM [EnglishClassDBtest].[dbo].[Table_ClassSchedule]");
                }
                DataTable _dataTable = new DataTable();
                _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
                // MessageBox.Show( _dataTable.Rows[0]["SUN"].ToString());
                daysofmonth = DateTime.DaysInMonth(Convert.ToInt32(cbox_Year.Text), Convert.ToInt32(cbox_Month.Text));
                for (int i = 2; i < 34; i++)
                {
                    if (i < daysofmonth + 2)
                    {
                        for (int k = 7; k < 14; k++)
                        {
                            //MessageBox.Show(_dataTable.Rows[0][k].ToString());
                            if (_dataTable.Rows[0][k].ToString() == "False" && compartDayofWeek(k, ConvertDayofWeek(_D[i - 2].Name.ToString(),cbox_Year.Text,cbox_Month.Text)))
                            {
                                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[i].Value = cbox_classID.Text;
                            }
                            else if (_dataTable.Rows[0][k].ToString() == "True" && compartDayofWeek(k, ConvertDayofWeek(_D[i - 2].Name.ToString(), cbox_Year.Text, cbox_Month.Text)))
                            {
                                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[i].Value = "休";
                            }
                        }
                    }
                    else
                    {
                        //_D[i - 1].Visible = false;
                    }
                }

                //先刪除
                CommandStr = string.Format("DELETE FROM EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}] WHERE [EnglishClassShift].[dbo].[Table_ClassShift_{0}_{1}].EmployeeID='{2}' "
                     , CurYear, CurMonth.ToString().PadLeft(2, '0'), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                _dataTable = dbc.CommandFunctionDB("EnglishClassShift", CommandStr);
                //後新增
                string _insertValues = "";
                int celCout = 0;
                foreach (DataGridViewCell cel in dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells)
                {
                    //string Column1 = row.Cells[0].Value.ToString();
                    //string Column2 = row.Cells[1].Value.ToString();
                    if (celCout < daysofmonth + 1 && celCout != 1)
                    {
                        _insertValues = _insertValues + "'" + cel.Value.ToString() + "',";
                    }
                    else if (celCout == daysofmonth + 1)
                    {
                        _insertValues = _insertValues + "'" + cel.Value.ToString() + "'";

                    }
                    celCout++;
                }
                CommandStr = string.Format("Insert into EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}] Values({2})",
                     CurYear, CurMonth.ToString().PadLeft(2, '0'), _insertValues);
                _dataTable = dbc.CommandFunctionDB("EnglishClassShift", CommandStr);
                refreshTable();
            }
            else
            {
                MessageBox.Show("請點選員工！");
            }
        }

        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            //dataGridView1.DataSource = dtBK;
            //dataGridView1.Refresh();
            if (dataGridView1.Rows.Count>1)
            {
                while (dataGridView1.Rows.Count != 1)
                {
                   dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count-2);
                }
            }
            
            //列出員工ID
            //string CommandStr =string.Format( "Select *  FROM EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}]", CurYear.ToString(), CurMonth.ToString());
            string CommandStr = string.Format("Select * FROM EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}] Inner Join EnglishClassDBtest.[dbo].[Table_EmployeeBasic] on EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}].EmployeeID=EnglishClassDBtest.[dbo].[Table_EmployeeBasic].EmployeeID order by EnglishClassShift.[dbo].[Table_ClassShift_{0}_{1}].EmployeeID",
                cbox_Year.Text.ToString(), cbox_Month.Text.ToString().PadLeft(2, '0'));

            _dataTable = dbc.CommandFunctionDB("EnglishClassShift", CommandStr);
            daysofmonth = DateTime.DaysInMonth(Convert.ToInt32(cbox_Year.Text), Convert.ToInt32(cbox_Month.Text));
            //dataGridView1.Rows[0].Cells["EmployeeID"].Value = _dataTable.Rows[0][0].ToString();
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                dataGridView1.Rows.Add(drw.ItemArray[0].ToString());
                for(int j=0;j< drw.ItemArray.Count()-7;j++)
                {
                    dataGridView1.Rows[i].Cells[j+1].Value = drw.ItemArray[j].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = drw.ItemArray[daysofmonth+3].ToString();
                }
                i++;
            }
        }

        public void ResizeDG()
        {
            daysofmonth = DateTime.DaysInMonth(Convert.ToInt32(cbox_Year.Text), Convert.ToInt32(cbox_Month.Text));
            for (int i = 1; i < 32; i++)
            {
                if (i < daysofmonth + 1)
                {
                    _D[i - 1].HeaderText = string.Format("{0}({1})", i.ToString(), ConvertDayofWeek(_D[i - 1].Name.ToString(),cbox_Year.Text,cbox_Month.Text));
                    _D[i - 1].Visible = true;
                }
                else
                {
                    _D[i - 1].Visible = false;
                }
            }
        }

        private string ConvertDayofWeek(string _date,string strYear,string strMounth)
        {
            string DayofWeek = "";
            CurYear = Convert.ToInt32(strYear);
            CurMonth = Convert.ToInt32(strMounth);
            dt = new DateTime(CurYear, CurMonth, Convert.ToInt32(_date.Substring(1)));
            CurDay = dt.DayOfWeek.ToString("d");//tmp2 = 4 

            switch (CurDay)
            {
                case "1":
                    DayofWeek = "一";
                break;
                case "2":
                    DayofWeek = "二";
                    break;
                case "3":
                    DayofWeek = "三";
                    break;
                case "4":
                    DayofWeek = "四";
                    break;
                case "5":
                    DayofWeek = "五";
                    break;
                case "6":
                    DayofWeek = "六";
                    break;
                case "0":
                    DayofWeek = "日";
                    break;
            }
            return DayofWeek;
        }

        private bool compartDayofWeek(int k, string _daysofweek)
        {
            bool _bDofW = false;
            string _cdaysofweek = "";
            switch(k)
            {
                case 7:
                    _cdaysofweek = "日";
                    break;
                case 8:
                    _cdaysofweek = "一";
                    break;
                case 9:
                    _cdaysofweek = "二";
                    break;
                case 10:
                    _cdaysofweek = "三";
                    break;
                case 11:
                    _cdaysofweek = "四";
                    break;
                case 12:
                    _cdaysofweek = "五";
                    break;
                case 13:
                    _cdaysofweek = "六";
                    break;
            }
            return _bDofW= (_cdaysofweek == _daysofweek) ?true:false;
        }

        public void initialDcomp()
        {
            cbox_Year.Text = DateTime.Now.Year.ToString();
            cbox_Month.Text = DateTime.Now.ToString("MM");

            _D[0] = D01;
            _D[1] = D02;
            _D[2] = D03;
            _D[3] = D04;
            _D[4] = D05;
            _D[5] = D06;
            _D[6] = D07;
            _D[7] = D08;
            _D[8] = D09;
            _D[9] = D10;
            _D[10] = D11;
            _D[11] = D12;
            _D[12] = D13;
            _D[13] = D14;
            _D[14] = D15;
            _D[15] = D16;
            _D[16] = D17;
            _D[17] = D18;
            _D[18] = D19;
            _D[19] = D20;
            _D[20] = D21;
            _D[21] = D22;
            _D[22] = D23;
            _D[23] = D24;
            _D[24] = D25;
            _D[25] = D26;
            _D[26] = D27;
            _D[27] = D28;
            _D[28] = D29;
            _D[29] = D30;
            _D[30] = D31;
            _biniCopF = true;
        }

        private void cbox_Year_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_biniCopF)
            {
                CurYear = Convert.ToInt32(cbox_Year.Text);
                CurMonth = Convert.ToInt32(cbox_Month.Text);
                CreateShiftTable();
                ResizeDG();
            }
        }

        private void cbox_Month_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_biniCopF)
            {
                CurYear = Convert.ToInt32(cbox_Year.Text);
                CurMonth = Convert.ToInt32(cbox_Month.Text);
                CreateShiftTable();
                ResizeDG();
            }
        }

        
    }
}
