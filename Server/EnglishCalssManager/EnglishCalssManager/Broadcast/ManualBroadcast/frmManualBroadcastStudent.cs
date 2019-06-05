using EnglishClassManager.Utility.Database;
using EnglishCalssManager.Broadcast.CardNotice;
using EnglishCalssManager.Broadcast.ManualBroadcast;
using EnglishCalssManager.Broadcast.MessageSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PushSharp;
using PushSharp.Apple;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace EnglishCalssManager.Broadcast.ManualBroadcast
{
    public partial class frmManualBroadcastStudent : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;

        public frmManualBroadcastStudent()
        {
            InitializeComponent();
            initialComp();
        }

        private void _frmManualBroadcast_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

      
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if(row.Cells.Count==0)
                    {
                        MessageBox.Show("請選擇群組！");
                    }
                    if (row.Cells[1].Value != null && (Boolean)row.Cells[0].Value == true)
                    {
                        try
                        {
                            string MsgName = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["MsgName"].Value.ToString();
                            string Msg = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["Msg"].Value.ToString();
                            Msg = Msg.Replace(@"""", "");
                            string msg = CardNotice.CardNotice.SendNotificationFromFirebaseCloud(MsgName, Msg);
                            MessageBox.Show("發送成功!");
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
        }
  


        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            //dtBK = (DataTable)dataGridView1.DataSource;
            //列出班別ID
            string CommandStr = "Select * from Table_Message";
            _dataTable = dbc.CommandFunctionDB("Table_Message", CommandStr);
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                //cbox_CourseID.Items.Add(drw.ItemArray[0].ToString());
                this.dataGridView3.Rows.Insert(i, false, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString(), drw.ItemArray[2].ToString(),drw.ItemArray[3].ToString());
                i++;
            }

            // dgBtn();
        }

        private void initialComp()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select CourseID,CourseName from Table_Course";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                this.dataGridView2.Rows.Insert(i, false, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString());
                i++;
            }

            dataGridView3.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            //dataGridView2.DataSource = _dataTable;


        }

        private void btn_SelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = true;
            }
        }

        private void btn_CleanAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = false;
            }
        }

        private void btn_Resv_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)chk.Value == true)
                {
                    chk.Value = false;
                }
                else
                {
                    chk.Value = true;
                }
            }
        }
    }
}
