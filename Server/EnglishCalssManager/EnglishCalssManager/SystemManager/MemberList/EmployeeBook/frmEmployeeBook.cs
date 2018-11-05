using AOISystem.Utility.Logging;
using EnglishCalssManager.EmployeeAttence.ClassScheduleManager;
using EnglishCalssManager.SystemManager.MemberList.EmployeeBook;
using EnglishClassManager.SystemManager.CourseManagement;
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

namespace EnglishClassManager.SystemManager.MemberList.EmployeeBook
{
    public partial class frmEmployeeBook : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public baseEmployeeBook _baseEmployeeBook = new baseEmployeeBook();
        public static List<string> _employeeID = new List<string>();
        public string selectTwName = "";
        public string selectCardNumbere = "";
        public string selectEmployeeID = "";
        public string selectEnName = "";
        public string selectPhoneNumber = "";
        public string selectOnjob = "";
        public string selectHome = "";
        public string selectDep = "";
        public string selectPos = "";
        public string flagOnjob = "";
        private string startpage = "0";
        private int nextpage = 20;
        private string logTitle = "frmEmployeeBook：";

        public frmEmployeeBook()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }
        private void frmEmployeeBook_Load(object sender, EventArgs e)
        {
            Log.Trace(logTitle + "frmEmployeeBook_Load");
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select Dept from Table_SelectParam";
            _dataTable = dbc.CommandFunctionDB("Table_SelectParam", CommandStr);

            foreach (DataRow drw in _dataTable.Rows)
            {
                if(drw.ItemArray[0].ToString()!="" )
                cbox_Dep.Items.Add(drw.ItemArray[0].ToString());
            }

            CommandStr = "Select Position from Table_SelectParam";
            _dataTable = dbc.CommandFunctionDB("Table_SelectParam", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                if (drw.ItemArray[0].ToString() != "")
                    cbox_Pos.Items.Add(drw.ItemArray[0].ToString());
            }

            CommandStr = "Select EmployeeID from Table_EmployeeBasic";
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                _employeeID.Add(drw.ItemArray[0].ToString());
            }

            refreshTable();
            CreateClassScheduleManagerTalbe();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btnSelect.Name.ToString());
            refreshTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btnAdd.Name.ToString());
            initialText();
            if (checkReData()&& checkTextData())
            {
                insertData();
                refreshTable();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btnUpdate.Name.ToString());
            // if (checkReData())
            {
                updateData();
                refreshTable();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                txt_CardNumber.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                txt_EmployeeID.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txt_EnName.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(); 
                txt_Home.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString(); 
                txt_PhoneNumber.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString(); 
                txt_TwName.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                cbox_Dep.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();
                cbox_Pos.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
                cbox_Onjob.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void lb_startpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Log.Trace(logTitle + lb_startpage.Name.ToString());
            if (Convert.ToInt16(startpage) > 4)
            {
                startpage = (Convert.ToInt16(startpage) - nextpage).ToString();
                refreshTable();
            }
        }

        private void lb_endpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Log.Trace(logTitle + lb_endpage.Name.ToString());
            startpage = (Convert.ToInt16(startpage) + nextpage).ToString();
            refreshTable();
        }

        /// <summary>
        /// 新增員工資料
        /// </summary>
        private void insertData()
        {
            _baseEmployeeBook.NewEmployee();
            baseClassScheduleManager.initialTable();
        }
        /// <summary>
        /// 更新員工資料
        /// </summary>
        private void updateData()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("update Table_EmployeeBasic set " +
                          " CardNumber='{1}', TwName='{2}', EnName='{3}' " +
                          ", Home='{4}',PhoneNumber='{5}',Onjob='{6}' "
                          + " where EmployeeID='{7}'"
                          , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                          cbox_Onjob.Text,
                          dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            CommandStr = string.Format("update Table_EmployeeBook set " +
                          " EmployeeID='{0}', Position='{1}',Dept='{2}' " +
                          ",Vacation1='',Vacation2='',Vacation3='',Vacation4='',Vacation5='',Vacation6='',Vacation7=''"
                          + " where EmployeeID='{0}'"
                          , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(),
                          cbox_Pos.Text,cbox_Dep.Text);
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBook", CommandStr);
            refreshTable();
            //_dataTable = dbc.InsertToDB("Table_StudentBasic", FieldDD, ValueDD, TypeATT);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btnDelete.Name.ToString());
            DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("delete from Table_EmployeeBasic where EmployeeID='{0}' and CardNumber='{1}'"
                       , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString()
                       , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            CommandStr = string.Format("delete from Table_EmployeeBook where EmployeeID='{0}'"
          , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBook", CommandStr);
            refreshTable();
        }

        private void btn_CourseManager_Click(object sender, EventArgs e)
        {
            frmCourseManagement _frmCourseManagement = new frmCourseManagement();
            _frmCourseManagement.ShowDialog();
        }

        private void btn_clearText_Click(object sender, EventArgs e)
        {
            txt_CardNumber.Text = "";
            txt_EmployeeID.Text = "";
            txt_EnName.Text = "";
            txt_Home.Text = "";
            txt_PhoneNumber.Text = "";
            txt_TwName.Text = "";
            cbox_Dep.Text = "";
            cbox_Pos.Text = "";
            startpage = "0";
            nextpage = 20;
            refreshTable();
    }

        /// <summary>
        /// 更新DG
        /// </summary>
        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            initailSelectCond();
            string CommandStr = string.Format("Select * from Table_EmployeeBasic{0} "
               + " left join Table_EmployeeBook{0}  On Table_EmployeeBasic{0}.EmployeeID = Table_EmployeeBook{0}.EmployeeID "
               + " Where  Table_EmployeeBasic{0}.Onjob = '{1}'"
               + " {2}"
               + " {3}"
               + " {4}"
               + " {5}"
               + " {6}"
               + " {7}"
               + " {8}"
               + " {9}"
               + " ORDER BY Table_EmployeeBook{0}.EmployeeID"
               + " OFFSET {10} ROWS"
               + " FETCH NEXT {11} ROWS ONLY", flagOnjob, cbox_Onjob.Text,
               selectEmployeeID, selectTwName, selectCardNumbere, selectHome,
               selectPhoneNumber, selectDep, selectPos, selectEnName, startpage, nextpage
               );
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            dataGridView1.DataSource = _dataTable;
            this.dataGridView1.Columns[7].Visible = false;
            lb_pageNum.Text = "第- " + ((Convert.ToInt16(startpage) / Convert.ToInt16(nextpage) + 1).ToString()) + " -頁";
        }

        /// <summary>
        /// 檢查是否有重覆ID或卡號
        /// </summary>
        /// <returns></returns>
        private bool checkReData()
        {
            bool bReData = true;
            string ReCardNumber = "";
            string ReEmployeeID = "";
            string CommandStr = string.Format("Select Count(*) from Table_EmployeeBasic where Table_EmployeeBasic.CardNumber='{0}' ", txt_CardNumber.Text);
            ReCardNumber = dbc.strExecuteScalar(CommandStr);
            //CommandStr = string.Format("Select Count(*) from Table_EmployeeBasic where Table_EmployeeBasic.EmployeeID='{0}' ", txt_EmployeeID.Text);
            //ReEmployeeID = dbc.strExecuteScalar(CommandStr);
            if (ReCardNumber != "0")
            {
                MessageBox.Show("員工卡號重覆！");
                bReData = false;
            }
            //if (ReEmployeeID != "0")
            //{
            //    MessageBox.Show("員工編號重覆！");
            //    bReData = false;
            //}
            return bReData;
        }

        /// <summary>
        /// 初始化搜尋條件
        /// </summary>
        private void initailSelectCond()
        {
            if (cbox_Onjob.Text == "N") flagOnjob = "";
            selectTwName = string.Format("and Table_EmployeeBasic{0}.TwName like '%{1}%'", flagOnjob, txt_TwName.Text);
            selectEmployeeID = string.Format("and Table_EmployeeBasic{0}.EmployeeID like '%{1}%'", flagOnjob, txt_EmployeeID.Text);
            selectCardNumbere = string.Format("and Table_EmployeeBasic{0}.CardNumber like '%{1}%'", flagOnjob, txt_CardNumber.Text);
            selectEnName = string.Format("and Table_EmployeeBasic{0}.EnName like '%{1}%'", flagOnjob, txt_EnName.Text);
            selectPhoneNumber = string.Format("and Table_EmployeeBasic{0}.PhoneNumber like '%{1}%'", flagOnjob, txt_PhoneNumber.Text);
            selectHome = string.Format("and Table_EmployeeBasic{0}.Home like '%{1}%'", flagOnjob, txt_Home.Text);
            selectDep = string.Format("and Table_EmployeeBook{0}.Dept like '%{1}%'", flagOnjob, cbox_Dep.Text);
            selectPos = string.Format("and Table_EmployeeBook{0}.Position like '%{1}%'", flagOnjob, cbox_Pos.Text);
        }

        /// <summary>
        ///預先創建員工班別表 
        /// </summary>
        public void CreateClassScheduleManagerTalbe()
        {
            string CommandStr = "";
            for (int i = 0; i < _employeeID.Count; i++)
            {
                CommandStr = string.Format("SELECT count(*) FROM EnglishClassShift.sys.tables WHERE name = 'Table_ClassShift_{0}' ", _employeeID[i]);
                if (dbc.strExecuteScalar(CommandStr) == "0")
                {
                    CommandStr = string.Format("CREATE TABLE EnglishClassShift.[dbo].[Table_ClassShift_{0}](" +
                        "[EmployeeID][int] NULL," +
                        "[ClassID]" +
                        "[int] NULL" +
                        ") ON[PRIMARY]", _employeeID[i]);
                    dbc.ExecuteNonQuery(CommandStr);
                }
            }
        }

        private void btn_DepPosEdit_Click(object sender, EventArgs e)
        {
            frmDepPosEdit _frmDepPosEdit = new frmDepPosEdit();
            _frmDepPosEdit.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_EmployeeID.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            txt_CardNumber.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txt_TwName.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            txt_EnName.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            txt_Home.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            txt_PhoneNumber.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            cbox_Onjob.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            cbox_Dep.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Dept"].Value.ToString();
            cbox_Pos.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Position"].Value.ToString();
        }

        public void initialText()
        {
           _baseEmployeeBook.CardNumber = txt_CardNumber.Text;
            _baseEmployeeBook.EmployeeID = txt_EmployeeID.Text;
            _baseEmployeeBook.EnName= txt_EnName.Text;
            _baseEmployeeBook.Home=txt_Home.Text;
            _baseEmployeeBook.PhoneNumber = txt_PhoneNumber.Text;
            _baseEmployeeBook.TwName = txt_TwName.Text;
            _baseEmployeeBook.Dep = cbox_Dep.Text;
            _baseEmployeeBook.Pos = cbox_Pos.Text;
            _baseEmployeeBook.Onjob = cbox_Onjob.Text;
        }

        private bool checkTextData()
        {
            if (txt_CardNumber.Text == "" || txt_TwName.Text == "")
            {
                MessageBox.Show("卡號/名字不可空白");
                    return false;
            }
            else
                return true;
        }
    }
}
