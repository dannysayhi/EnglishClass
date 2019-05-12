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
using System.ComponentModel;
using _4RobotSystem.RecipeTemp;

namespace EnglishCalssManager.Utility.Database
{
    public partial class frmDBconfig : Form
    {
        public frmDBconfig()
        {
            InitializeComponent();
        }

        public baseinfo _bif = new baseinfo();

        private void frmDBconfig_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject=_bif;
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

        private void btn_connectTest_Click(object sender, EventArgs e)
        {

        }

        private void btn_Recipefrm_Click(object sender, EventArgs e)
        {
            frmRecipe _frmRecipe = new frmRecipe();
            _frmRecipe.Show();
        }
    }

    public class baseinfo
    {
        [Browsable(true), Category("濾波設定"), Description("高斯濾波")]
        public bool IsGaussFilter { set; get; }
    }
}
