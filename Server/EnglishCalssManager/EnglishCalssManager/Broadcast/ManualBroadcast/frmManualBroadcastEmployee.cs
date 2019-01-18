using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCalssManager.Broadcast.ManualBroadcast
{
    public partial class frmManualBroadcastEmployee : Form
    {

        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        //private SslStream _apnsStream;

        //public ApplePushChannelSettings;
        private X509Certificate _certificate;
        private X509CertificateCollection _certificates;

        public frmManualBroadcastEmployee()
        {
            InitializeComponent();
            initialComp();
        }

        private void frmManualBroadcastEmployee_Load(object sender, EventArgs e)
        {
            refreshTable();

            //this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;//(資料內容)
            this.dataGridView1.AutoResizeColumns();
            //this.dataGridView1.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dataGridView1.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;   
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;// (標題列)
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.Columns[3].Width = (dataGridView1.Width) * 65 / 100;
            this.dataGridView1.Refresh();

            dataGridView1.Refresh();
        }

        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();

            string CommandStr = string.Format( "Select * from Table_Message where MsgID>{0}",Convert.ToInt16(textBox1.Text));
            _dataTable = dbc.CommandFunctionDB("Table_Message", CommandStr);
            dataGridView1.DataSource = _dataTable;

           // dgBtn();
        }

        private void dgBtn()
        {
            if (this.dataGridView1.Columns.Count > 4)
            {
                //this.dataGridView1.Columns.RemoveAt(4);
                //this.dataGridView1.Columns.RemoveAt(4);
                //this.dataGridView1.Columns.RemoveAt(4);
                this.dataGridView1.Columns.Remove(this.dgBtnSend);
            }

            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgBtnSend });

            this.dgBtnSend.HeaderText = "發送";
            this.dgBtnSend.Name = "dgBtnSend";
            this.dgBtnSend.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBtnSend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgBtnSend.Text = "發送";
            this.dgBtnSend.UseColumnTextForButtonValue = true;
            this.dgBtnSend.Width = 80;
            this.dgBtnSend.DisplayIndex = 4;

            //this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgBtnCopy, this.dgBtnEdit, this.dgBtnDel });
            //this.dataGridView1.Columns.Insert(4, this.dgBtnCopy);
            //this.dataGridView1.Columns.Insert(5, this.dgBtnEdit);
            //this.dataGridView1.Columns.Insert(6, this.dgBtnDel);

        }
        private void initialComp()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select EmployeeID,TwName from Table_EmployeeBasic";
            int i = 0;
            _dataTable = dbc.CommandFunctionDB("Table_EmployeeBasic", CommandStr);
            foreach (DataRow drw in _dataTable.Rows)
            {
                this.dataGridView2.Rows.Insert(i, false, drw.ItemArray[0].ToString(), drw.ItemArray[1].ToString());
                i++;
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_MsgID.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["MsgID"].Value.ToString();
            txt_MsgName.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["MsgName"].Value.ToString();
            txt_MsgClass.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["MsgClass"].Value.ToString();
            txt_msg.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Msg"].Value.ToString();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string CommandStr;
            int n = 999;
            string b;
            CommandStr = string.Format("select count(*) from [dbo].[Table_Message] WHERE  [MsgID] = {0}", txt_MsgID.Text);
            b = dbc.strExecuteScalar(CommandStr);

            if (int.TryParse(txt_MsgID.Text, out n) && b!="0")
            {
                CommandStr = string.Format("UPDATE [dbo].[Table_Message] SET [MsgClass] = {0},[MsgName] = '{1}' ,[Msg] = '{2}' WHERE  [MsgID] = {3}",txt_MsgClass.Text,txt_MsgName.Text,txt_msg.Text,txt_MsgID.Text);
                dbc.ExecuteNonQuery(CommandStr);
            }
            else
            {
                if(txt_MsgID.Text!=""&&txt_msg.Text!=""&&txt_MsgName.Text!="")
                {
                    CommandStr = string.Format("INSERT INTO[dbo].[Table_Message]([MsgID],[MsgClass],[MsgName],[Msg]) "+
                                            " VALUES ({0},{1},'{2}','{3}')",txt_MsgID.Text,txt_MsgClass.Text,txt_MsgName.Text,txt_msg.Text);
                    dbc.ExecuteNonQuery(CommandStr);
                }
                else
                {
                    MessageBox.Show("非數字");
                }
            }
            refreshTable();
        }

        private void dgSend()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && (Boolean)row.Cells[0].Value == true)
                {
                    string MsgName = "<員工通知>"+txt_MsgName.Text;
                    string Msg = txt_msg.Text;
                    Msg = Msg.Replace(@"""", "");
                    CardNotice.CardNotice.SendNotificationFromFirebaseCloud(MsgName, Msg);
                }
            }
            MessageBox.Show("訊息發送完畢！");
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            dgSend();
        }
    }
    }
