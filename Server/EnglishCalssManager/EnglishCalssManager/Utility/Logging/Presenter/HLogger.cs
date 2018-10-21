using System;
using System.Windows.Forms;
using AOISystem.Utility.Logging.Presenter;

namespace AOISystem.Utility.Logging
{
    public partial class HLogger : UserControl, ILoggerTarget
    {
        public HLogger()
        {
            InitializeComponent();
        }

        public void  ClearCommand()
        {
            lbCommand.Items.Clear();
        }

        // ILogTarget 
        public void SetCommandLine(string obj)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    if (lbCommand.Items.Count > 500)
                    {
                        lbCommand.Items.RemoveAt(lbCommand.Items.Count-1);
                    }
                    lbCommand.Items.Insert(0,obj);
                    lbCommand.SelectedIndex = 0;
                });
            }
            catch (InvalidOperationException e)
            {
            }
            catch(StackOverflowException e)
            {
            }
        }

        private void lbCommand_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(this.lbCommand.SelectedItem.ToString());
        }
    }
}
