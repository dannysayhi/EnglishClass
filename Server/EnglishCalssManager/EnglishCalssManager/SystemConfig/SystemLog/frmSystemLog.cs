using AOISystem.Utility.Logging.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCalssManager.SystemConfig.SystemLog
{
    public partial class frmSystemLog : Form
    {
        private LoggerPresenter _loggerPresenter;   // Log 連結元件實體

        public frmSystemLog()
        {
            InitializeComponent();
        }

        private void frmSystemLog_Load(object sender, EventArgs e)
        {
            // 設定Logger
            _loggerPresenter = new LoggerPresenter(this.hLogger1);
        }
    }
}
