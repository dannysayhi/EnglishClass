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

namespace EnglishCalssManager.EmployeeAttence.ClassEmployeeManager
{
    public partial class frmClassEmployeeManager : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
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
        private string SelCond = "全部";
        
        public frmClassEmployeeManager()
        {
            InitializeComponent();
            InitialSelectCondition();
        }

        private void frmClassEmployeeManager_Load(object sender, EventArgs e)
        {
            refreshTable();
            EmployeeSource();
        }

        private void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            string _selcond = "";
            if (cbox_ClassID.Text != "全部")
                _selcond = string.Format( " where EnglishClassDBtest.[dbo].[Table_ClassScheduleManagement].ClassID = '{0}'",cbox_ClassID.Text);
            string CommandStr = string.Format("SELECT * FROM EnglishClassDBtest.[dbo].[Table_ClassScheduleManagement] "
                + _selcond);
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            dataGridViewResult.DataSource = _dataTable;
        }

        private void EmployeeSource()
        {

            DataTable _dataTable = new DataTable();
            initailSelectCond();
            string CommandStr = string.Format("Select * from Table_EmployeeBasic{0} "
               + " inner join Table_EmployeeBook{0}  On Table_EmployeeBasic{0}.EmployeeID = Table_EmployeeBook{0}.EmployeeID "
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
            dataGridViewSource.DataSource = _dataTable;
            lb_pageNum.Text = "第- " + ((Convert.ToInt16(startpage) / Convert.ToInt16(nextpage) + 1).ToString()) + " -頁";
        }

        private void InitialSelectCondition()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select ClassID from Table_ClassSchedule";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            cbox_ClassID.Items.Add(SelCond);
            cbox_ClassID.Text = SelCond;
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_ClassID.Items.Add(drw.ItemArray[0].ToString());
            }
        }

        private void cbox_ClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void btn_insertToClass_Click(object sender, EventArgs e)
        {
           // DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("if not exists(select Table_ClassScheduleManagement.ClassID, Table_ClassScheduleManagement.EmployeeID "
                + " from Table_ClassScheduleManagement"
                + " where Table_ClassScheduleManagement.ClassID='{0}' and Table_ClassScheduleManagement.EmployeeID='{1}' )"
                + " insert into Table_ClassScheduleManagement values('{2}', '{3}') ", cbox_ClassID.Text, dataGridViewResult.Rows[dataGridViewResult.CurrentCell.RowIndex].Cells["EmployeeID"].Value.ToString(),
                 cbox_ClassID.Text, dataGridViewResult.Rows[dataGridViewResult.CurrentCell.RowIndex].Cells["EmployeeID"].Value.ToString());
            dbc.ExecuteNonQuery(CommandStr);
            refreshTable();
        }

        private void btn_DelFromClass_Click(object sender, EventArgs e)
        {
            string CommandStr = string.Format("delete from Table_ClassScheduleManagement where ClassID='{0}' and EmployeeID='{1}'"
                       , cbox_ClassID.Text, dataGridViewResult.Rows[dataGridViewResult.CurrentCell.RowIndex].Cells["EmployeeID"].Value.ToString());
            dbc.ExecuteNonQuery(CommandStr);
            refreshTable();
        }

        private void lb_endpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            startpage = (Convert.ToInt16(startpage) + nextpage).ToString();
            initailSelectCond();
        }
        private void lb_startpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Convert.ToInt16(startpage) > 4)
            {
                startpage = (Convert.ToInt16(startpage) - nextpage).ToString();
                initailSelectCond();
            }
        }
        /// <summary>
        /// 初始化搜尋條件
        /// </summary>
        private void initailSelectCond()
        {
            if (cbox_Onjob.Text == "N") flagOnjob = "Leave";
            selectTwName = string.Format("and Table_EmployeeBasic{0}.TwName like '%{1}%'", flagOnjob, txt_TwName.Text);
            selectEmployeeID = string.Format("and Table_EmployeeBasic{0}.EmployeeID like '%{1}%'", flagOnjob, txt_EmployeeID.Text);
            selectCardNumbere = string.Format("and Table_EmployeeBasic{0}.CardNumber like '%{1}%'", flagOnjob, txt_CardNumber.Text);
            selectEnName = string.Format("and Table_EmployeeBasic{0}.EnName like '%{1}%'", flagOnjob, txt_EnName.Text);
            selectPhoneNumber = string.Format("and Table_EmployeeBasic{0}.PhoneNumber like '%{1}%'", flagOnjob, txt_PhoneNumber.Text);
            selectDep = string.Format("and Table_EmployeeBook{0}.Dept like '%{1}%'", flagOnjob, cbox_Dep.Text);
            selectPos = string.Format("and Table_EmployeeBook{0}.Position like '%{1}%'", flagOnjob, cbox_Pos.Text);
        }

        private void btn_clearText_Click(object sender, EventArgs e)
        {
            txt_CardNumber.Text = "";
            txt_EmployeeID.Text = "";
            txt_EnName.Text = "";
            txt_PhoneNumber.Text = "";
            txt_TwName.Text = "";
            cbox_Dep.Text = "";
            cbox_Pos.Text = "";
            startpage = "0";
            nextpage = 20;
            initailSelectCond();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            initailSelectCond();
        }
    }
}
