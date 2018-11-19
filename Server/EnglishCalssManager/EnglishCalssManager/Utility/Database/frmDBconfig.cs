using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EnglishCalssManager.Utility.Database
{
    public partial class frmDBconfig : Form
    {
        public frmDBconfig()
        {
            InitializeComponent();
        }

        private void frmDBconfig_Load(object sender, EventArgs e)
        {

        }

        /// Read xml file and bind it to comboBox
        /// 
        public void BindDropDown()
        {
            /*Here for testing put your xml file in debuger folder*/
            XmlTextReader xmdatareader = new XmlTextReader(Application.StartupPath + @"\Init\" + "Xml/Country.xml");
            DataSet _objdataset = new DataSet();
            _objdataset.ReadXml(xmdatareader);
            cbox_ConnectStr.DataSource = _objdataset.Tables[0];
        }

    }
}
