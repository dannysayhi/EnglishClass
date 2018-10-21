using System;
using System.Windows.Forms;

namespace AOISystem.Utility.Logging
{
    public partial class frmMessageNotification : Form
    {
        private static frmMessageNotification instance = null;

        public frmMessageNotification()
        {
            InitializeComponent();
        }

        public static frmMessageNotification GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new frmMessageNotification();
            }
            return instance;
        }

        public void Post(string message)
        {
            this.hLogger.SetCommandLine(message);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
