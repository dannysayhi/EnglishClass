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
    public partial class frmManualBroadcast : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        //private SslStream _apnsStream;
      
        //public ApplePushChannelSettings;
        private X509Certificate _certificate;
        private X509CertificateCollection _certificates;
        public frmManualBroadcast()
        {
            InitializeComponent();
            initialComp();
        }

        private void _frmManualBroadcast_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 4:
                    dgSend(e.RowIndex, e.ColumnIndex);
                    refreshTable();
                    //MessageBox.Show(e.RowIndex.ToString() + ";;;" + e.ColumnIndex.ToString());
                    break;
            }
        }

        private void dgSend(int _rowIndex, int _columnsIndex)
        {

            foreach(DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[1].Value!=null && (Boolean)row.Cells[0].Value==true)
                {
                    string MsgName = dataGridView1.Rows[_rowIndex].Cells["MsgName"].Value.ToString();
                    string Msg = dataGridView1.Rows[_rowIndex].Cells["Msg"].Value.ToString();
                    Msg = Msg.Replace(@"""", "");
                    CardNotice.CardNotice.SendNotificationFromFirebaseCloud(MsgName, Msg);
                }
            }

            /*  Send online*/
            //SendPushNotification("aa0e8521ac7f3aba7d81a0bbe28007db9ccbbcab8e86deb17434ab4cd2e223e6",
            //    Msg);

            //CardNotice.CardNotice.SendNotificationFromFirebaseCloud(MsgName, Msg);
            //CardNotice.SendNotificationFromFirebaseCloud(MsgName, Msg);


            /*           */
        }


        public void refreshTable()
        {
            DataTable _dataTable = new DataTable();
            //dtBK = (DataTable)dataGridView1.DataSource;
            //列出班別ID
            string CommandStr = "Select * from Table_Message";
            _dataTable = dbc.CommandFunctionDB("Table_Message", CommandStr);
            dataGridView1.DataSource = _dataTable;

            dgBtn();
        }

        private void initialComp()
        {
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select ClassID from Table_ClassSchedule";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            cbox_ClassID.Items.Add("*");
            int i = 0;
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_ClassID.Items.Add(drw.ItemArray[0].ToString());
                this.dataGridView2.Rows.Insert(i, false, drw.ItemArray[0].ToString());
                i++;
            }
            cbox_ClassID.Text = cbox_ClassID.Items[0].ToString();

            //dataGridView2.DataSource = _dataTable;
           

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
        protected void btnSendNotification_Click(object sender, int _rowIndex, DataGridViewCellEventArgs e)
        {
            {
                CardNotice.CardNotice.SendNotificationFromFirebaseCloud("", "123");
                //SendPushNotification("aa0e8521ac7f3aba7d81a0bbe28007db9ccbbcab8e86deb17434ab4cd2e223e6",
                //dataGridView1.Rows[_rowIndex].Cells["Msg"].Value.ToString());
            }
        }

        private void SendPushNotification(string deviceToken, string message)
        {
            try
            {
                //var certificateFilePath = "D:\\BackEnd\\pc_server\\push_notification\\PushNotification\\PushNotification\\Certificates.p12";
                var certificateFilePath = "Certificates_v3.p12";
                
                //Get Certificate
                var appleCert = System.IO.File.ReadAllBytes(certificateFilePath);
                //var appleCert = new X509Certificate2(@"C:\filepath.p12", "", X509KeyStorageFlags.MachineKeySet);
                //_certificate = string.IsNullOrEmpty("") ? new X509Certificate2(File.ReadAllBytes(certificateFilePath)) : new X509Certificate2(File.ReadAllBytes(certificateFilePath), "", X509KeyStorageFlags.MachineKeySet);
                //_certificates = new X509CertificateCollection { _certificate };
                // Configuration (NOTE: .pfx can also be used here)
                //var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, certificateFilePath, "b22303409");
                 var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, certificateFilePath, "b22303409");
                
                var connection = new ApnsServiceConnection(config);
                MessageBox.Show(config.Certificate.ToString());

                //config.SkipSsl = true;
                //MessageBox.Show(config.ValidateServerCertificate.ToString());
                // Create a new broker
                var apnsBroker = new ApnsServiceBroker(config);
                // Wire up events
                apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
                {

                    aggregateEx.Handle(ex =>
                    {

                        // See what kind of exception it was to further diagnose
                        if (ex is ApnsNotificationException)
                        {
                            //MessageBox.Show("kill me");

                            var notificationException = (ApnsNotificationException)ex;

                            // Deal with the failed notification
                            var apnsNotification = notificationException.Notification;
                            var statusCode = notificationException.ErrorStatusCode;
                            string desc = $"Apple Notification Failed: ID={apnsNotification.Identifier}, Code={statusCode}";
                            Console.WriteLine(desc);
                            MessageBox.Show(apnsNotification.ToString());

                            //lblStatus.Text = desc;
                        }
                        else
                        {
                            //MessageBox.Show("help");
                            string desc = $"Apple Notification Failed for some unknown reason : {ex.InnerException}";
                            // Inner exception might hold more useful information like an ApnsConnectionException			
                            Console.WriteLine(desc);
                            MessageBox.Show(desc);

                            //lblStatus.Text = desc;
                        }

                        // Mark it as handled
                        return true;
                    });
                };

                apnsBroker.OnNotificationSucceeded += (notification) =>
                {
                    MessageBox.Show("Apple Notification Sent successfully!");
                    //lblStatus.Text = "Apple Notification Sent successfully!";
                };

                var fbs = new FeedbackService(config);
                fbs.FeedbackReceived += (string devicToken, DateTime timestamp) =>
                {
                    // Remove the deviceToken from your database
                    // timestamp is the time the token was reported as expired
                };

                // Start Proccess 
                apnsBroker.Start();
                //nsNotification
                if (deviceToken != "")
                {
                    //MessageBox.Show(("{\"aps\":{\"badge\":1,\"sound\":\"default\",\"alert\":\"" + (message + "\"}}")));
                    apnsBroker.QueueNotification(new ApnsNotification
                    {
                        DeviceToken = deviceToken,

                        Payload = JObject.Parse(("{\"aps\":{\"badge\":1,\"sound\":\"default\",\"alert\":\"" + (message + "\"}}")))
                    });
                }

                apnsBroker.Stop();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

    }
}
