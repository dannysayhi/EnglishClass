using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnglishClassManager.Utility.Database;
using AOI_System.DB;
using EnglishCalssManager.SystemManager.MemberList.StudentBook;
using AOISystem.Utility.Logging;

namespace EnglishClassManager.SystemManager.MemberList.StudentBook
{
    public partial class frmStudentBook : Form
    {
        baseStudentBook _baseStudentBook = new baseStudentBook();
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public string[] studentSelectField;
        public string startpage = "0";
        public int nextpage = 20;
        private string logTitle = "學生通訊錄：";

        public frmStudentBook()
        {
            InitializeComponent();
        }

        private void frmStudentBook_Load(object sender, EventArgs e)
        {
            Log.Trace(logTitle+ "frmStudentBook_Load");
            cbox_Onschool.Text = "Y";
            refreshTable(txt_StudentID.Text);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btnSelect.Name.ToString());
            refreshTable(txt_StudentID.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btnAdd.Name.ToString());
            initialText();
            if (cbox_Onschool.Text == "Y")
            {
                _baseStudentBook.NewStudent();
            }
            else if (cbox_Onschool.Text == "N")
            {

            }
            string CommandStr = string.Format("select Max([dbo].[Table_StudentBasic].StudentID) from [dbo].[Table_StudentBasic]");
            string maxStdID = dbc.strExecuteScalar(CommandStr);
            refreshTable(maxStdID);
            //dataGridView1.DataSource = _dataTable;
            //dataGridView1.Update(); dataGridView1.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btnUpdate.Name.ToString());
            DataTable _dataTable = new DataTable();
            initialText();
            string CommandStr = string.Format("update Table_StudentBasic set " +
                          " CardNumber='{1}', TwName='{2}', EnName='{3}' " +
                          ", PhoneNumber='{4}',Home='{5}',School='{6}',Senior='{7}',Onschool='{8}' "
                          + " where StudentID='{9}'"
                         , txt_StudentID.Text,
                         txt_CardNumber.Text,
                         txt_TwName.Text,
                         txt_EnName.Text,
                         txt_PhoneNumber.Text,
                         txt_Home.Text,
                         txt_School.Text,
                         cbox_Senior.Text,
                         cbox_Onschool.Text,
                         txt_StudentID.Text);

            _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
            CommandStr = string.Format("update Table_StudentBook set " +
                          " Parents1='{1}',Parents1PhoneNumber='{2}' " +
                          ", Parents2='{3}',Parents2PhoneNumber='{4}', Parents3='{5}',Parents3PhoneNumber='{6}' "
                          + " where StudentID='{7}'"
                          , txt_StudentID.Text,
                          txt_Parents1.Text,
                          txt_Parents1PhoneNumber.Text,
                          txt_Parents2.Text,
                          txt_Parents2PhoneNumber.Text,
                          txt_Parents3.Text,
                          txt_Parents3PhoneNumber.Text,
                          txt_StudentID.Text);
            _dataTable = dbc.CommandFunctionDB("Table_StudentBook", CommandStr);
            refreshTable(txt_StudentID.Text);
            //_dataTable = dbc.InsertToDB("Table_StudentBasic", FieldDD, ValueDD, TypeATT);
            //dataGridView1.DataSource = _dataTable;
           // dataGridView1.Update(); dataGridView1.Refresh();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btnDelete.Name.ToString());
            if (txt_StudentID.Text == "")
            {
                MessageBox.Show("請選擇學生");
                return;
            }

            DataTable _dataTable = new DataTable();
            string CommandStr = string.Format("delete from Table_StudentBasic where StudentID='{0}' and CardNumber='{1}'"
                       , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString()
                       , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
            _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
            CommandStr = string.Format("delete from Table_StudentBook where StudentID='{0}'"
          , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
            clearFun();
            refreshTable(txt_StudentID.Text);
            //dataGridView1.DataSource = _dataTable;
            //dataGridView1.Update(); dataGridView1.Refresh();
        }

        private void btn_ReadCard_Click(object sender, EventArgs e)
        {

        }

        public void initialfrmValue()
        {
            studentSelectField = new string[17]{"StudentID","CardNumber","TwName", "EnName", "PhoneNumber","Home","School",
                                                "Senior", "Onschool","Parents1","Parents1PhoneNumber","Parents2","Parents2PhoneNumber",
                                                "Parents3","Parents3PhoneNumber","Parents4","Parents4PhoneNumber"};
        }

        public void refreshTable(string std)
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = " Select Table_StudentBasic.StudentID"
                + ", Table_StudentBasic.CardNumber,"
                + " Table_StudentBasic.TwName, "
                + "Table_StudentBasic.EnName,"
                + " Table_StudentBasic.Home, "
                + "Table_StudentBasic.PhoneNumber,"
                + "Table_StudentBasic.School,"
                + "Table_StudentBasic.Senior, "
                + "Table_StudentBasic.Onschool,"
                + " Table_StudentBook.Parents1,"
                + " Table_StudentBook.Parents1PhoneNumber,"
                + "Table_StudentBook.Parents2, "
                + "Table_StudentBook.Parents2PhoneNumber, "
                + "Table_StudentBook.Parents3, "
                + "Table_StudentBook.Parents3PhoneNumber "
                + "From Table_StudentBasic "
                + "left join Table_StudentBook "
                + "On  Table_StudentBasic.StudentID =  Table_StudentBook.StudentID "
                + "Where  Table_StudentBasic.StudentID like '%"
                + std
                + "%' "
                + " And Table_StudentBasic.TwName like '%"
                + txt_TwName.Text.ToString()
                + "%' "
                + " And Table_StudentBasic.Onschool like '%"
                + cbox_Onschool.Text.ToString()
                + "%' "
                + " ORDER BY Table_StudentBasic.StudentID"
                + " OFFSET " + startpage + " ROWS"
                + " FETCH NEXT " + nextpage + " ROWS ONLY"
                ;
            _dataTable = dbc.CommandFunctionDB("Table_StudentBasic", CommandStr);
            dataGridView1.DataSource = _dataTable;
        }

        private void lb_endpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Log.Trace(logTitle + lb_endpage.Name.ToString());
            startpage = (Convert.ToInt16(startpage) + nextpage).ToString();
            refreshTable(txt_StudentID.Text);
        }

        private void lb_startpage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Log.Trace(logTitle + lb_startpage.Name.ToString());
            if (Convert.ToInt16(startpage) > 4)
            {
                startpage = (Convert.ToInt16(startpage) - nextpage).ToString();
                refreshTable(txt_StudentID.Text);
            }
        }

        private void btn_clearText_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + btn_clearText.Name.ToString());
            txt_CardNumber.Text = "";
            txt_EnName.Text = "";
            txt_Home.Text = "";
            txt_Parents1.Text = "";
            txt_Parents1PhoneNumber.Text = "";
            txt_Parents2.Text = "";
            txt_Parents2PhoneNumber.Text = "";
            txt_Parents3.Text = "";
            txt_Parents3PhoneNumber.Text = "";
            txt_PhoneNumber.Text = ""; ;
            txt_School.Text = "";
            txt_StudentID.Text = "";
            txt_TwName.Text = "";
            refreshTable(txt_StudentID.Text);
        }

        private void lb_pageNum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void initialText()
        {
            if (txt_CardNumber.Text == "")
            {
                txt_CardNumber.Text = "---";
            }
            if (txt_EnName.Text == "")
            {
                txt_EnName.Text = "---";
            }
            if (txt_Home.Text == "")
            {
                txt_Home.Text = "---";
            }
            if (txt_Parents1.Text == "")
            {
                txt_Parents1.Text = "---";
            }
            if (txt_Parents1PhoneNumber.Text == "")
            {
                txt_Parents1PhoneNumber.Text = "---";
            }
            if (txt_Parents2.Text == "")
            {
                txt_Parents2.Text = "---";
            }
            if (txt_Parents2PhoneNumber.Text == "")
            {
                txt_Parents2PhoneNumber.Text = "---";
            }
            if (txt_Parents3.Text == "")
            {
                txt_Parents3.Text = "---";
            }
            if (txt_Parents3PhoneNumber.Text == "")
            {
                txt_Parents3PhoneNumber.Text = "---";
            }
            if (txt_PhoneNumber.Text == "")
            {
                txt_PhoneNumber.Text = "---";
            }
            if (txt_School.Text == "")
            {
                txt_School.Text = "---";
            }
            if (txt_StudentID.Text == "")
            {
                txt_StudentID.Text = "---";
            }
            if (txt_TwName.Text == "")
            {
                txt_TwName.Text = "---";
            }
            _baseStudentBook.txt_CardNumber = txt_CardNumber.Text;
            _baseStudentBook.txt_EnName = txt_EnName.Text;
            _baseStudentBook.txt_Home = txt_Home.Text;
            _baseStudentBook.txt_Parents1 = txt_Parents1.Text;
            _baseStudentBook.txt_Parents1PhoneNumber= txt_Parents1PhoneNumber.Text ;
            _baseStudentBook.txt_Parents2= txt_Parents2.Text;
            _baseStudentBook.txt_Parents2PhoneNumber = txt_Parents2PhoneNumber.Text;
            _baseStudentBook.txt_Parents3=txt_Parents3.Text ;
            _baseStudentBook.txt_Parents3PhoneNumber= txt_Parents3PhoneNumber.Text ;
            _baseStudentBook.txt_PhoneNumber= txt_PhoneNumber.Text ;
            _baseStudentBook.txt_School= txt_School.Text ;
            _baseStudentBook.txt_StudentID= txt_StudentID.Text;
            _baseStudentBook.txt_TwName= txt_TwName.Text;
            _baseStudentBook.cbox_Onschool = cbox_Onschool.Text;
            _baseStudentBook.cbox_Senior = cbox_Senior.Text;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string CommandStr = string.Format("update Table_StudentBasic set " +
                         " StudentID='{0}', CardNumber='{1}', TwName='{2}', EnName='{3}' " +
                         ", PhoneNumber='{4}',Home='{5}',School='{6}',Senior='{7}',Onschool='{8}' "
                         + " where StudentID='{9}'"
                         , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            CommandStr = string.Format("update Table_StudentBook set " +
                         " StudentID='{0}', Parents1='{1}',Parents1PhoneNumber='{2}' " +
                         ", Parents2='{3}',Parents2PhoneNumber='{4}', Parents3='{5}',Parents3PhoneNumber='{6}' "
                         + " where StudentID='{7}'"
                         , dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[14].Value.ToString(),
                         dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());

            txt_CardNumber.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txt_EnName.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            txt_Home.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            txt_Parents1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();
            txt_Parents1PhoneNumber.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
            txt_Parents2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString();
            txt_Parents2PhoneNumber.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString();
             txt_Parents3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString();
             txt_Parents3PhoneNumber.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[14].Value.ToString();
             txt_PhoneNumber.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
            txt_School.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
             txt_StudentID.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            txt_TwName.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
             cbox_Onschool.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
             cbox_Senior.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();

        }

        private void clearFun()
        {
            txt_CardNumber.Text = "";
            txt_EnName.Text = "";
            txt_Home.Text = "";
            txt_Parents1.Text = "";
            txt_Parents1PhoneNumber.Text = "";
            txt_Parents2.Text = "";
            txt_Parents2PhoneNumber.Text = "";
            txt_Parents3.Text = "";
            txt_Parents3PhoneNumber.Text = "";
            txt_PhoneNumber.Text = ""; ;
            txt_School.Text = "";
            txt_StudentID.Text = "";
            txt_TwName.Text = "";
            refreshTable(txt_StudentID.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log.Trace(logTitle + button1.Name.ToString());
            string CommandStr = string.Format( "DBCC CHECKIDENT([Table_StudentBasic], RESEED, {0})",txt_CHECKIDENT.Text);
            dbc.ExecuteNonQuery(CommandStr);
            CommandStr = string.Format("DBCC CHECKIDENT([Table_StudentBook], RESEED, {0})", txt_CHECKIDENT.Text);
            dbc.ExecuteNonQuery(CommandStr);
        }
    }
}
