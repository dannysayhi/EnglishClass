using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AOISystem.Utility.Logging
{
    public partial class uctrlTactTimeTable : UserControl
    {
        private Stopwatch _stopwatch = new Stopwatch();
        public uctrlTactTimeTable()
        {
            InitializeComponent();
            dgvTactTime.Rows.Clear();
            txtProgramOpenTime.Text = string.Format("系統開啟時間 : {0}", DateTime.Now.ToString("MM/dd HH:mm:ss"));
            // 重構表格大小
            for (int i = 0; i < 10; i++)
            {
                dgvTactTime.Rows.Add(new object[] { string.Format("第 {0} 筆", i + 1), 0 });
            }
        }

        public void TactTimeStart()
        {
            _stopwatch.Restart();

        }
        // 下一筆 TactTime 計時開始
        public void TactTimeRestart()
        {
            if (timerCurrectTactTimeRefresh.Enabled == false) timerCurrectTactTimeRefresh.Enabled = true;
            for (int i = 0; i < dgvTactTime.RowCount - 2; i++)
            {
                dgvTactTime[1, dgvTactTime.RowCount - 2 - i].Value = dgvTactTime[1, dgvTactTime.RowCount - 3 - i].Value;
            }
            dgvTactTime[1, 0].Value = ((double)_stopwatch.ElapsedMilliseconds / 1000).ToString(("F2"));
            _stopwatch.Restart();
            double count = 0;
            double sum = 0;
            for (int i = 0; i < dgvTactTime.RowCount - 1; i++)
            {
                if (Convert.ToDouble(dgvTactTime[1, i].Value) != 0)
                {
                    count++;
                }
                sum = sum + Convert.ToDouble(dgvTactTime[1, i].Value);
            }
            if (count == 0) { count = 1; };
            txtTactTimeAverage.Text = (sum / count).ToString(("F2"));
        }
        // 停止計時
        public void TactTimeStop()
        {
            _stopwatch.Restart();
            _stopwatch.Stop();
            if (timerCurrectTactTimeRefresh.Enabled == true) timerCurrectTactTimeRefresh.Enabled = false;
        }

        // 系統 TactTime 刷新
        private void timerCurrectTactTimeRefresh_Tick(object sender, EventArgs e)
        {
            txtCurrectTactTime.Text = ((double)_stopwatch.ElapsedMilliseconds / 1000).ToString(("F2"));
        }
    }
}
