using System;
using System.Windows.Forms;
using EnglishClassManager.DB;
using AOI_System.DB;

namespace _4RobotSystem.DataBase
{
    public partial class frmParamDB : Form
    {
        #region - Private Properties -
        // 物件
        private ParamDB paramDB;
        private MainDB mainDB = new MainDB("DB.xml");
        #endregion - Private Properties -

        public frmParamDB()
        {
        }
        #region - Public Constructor -
        public frmParamDB(ParamDB _paramDB)
        {
            InitializeComponent();
            paramDB = _paramDB;
            PropertySystem.SelectedObject = paramDB;
            DatatoUI();
        }
        #endregion - Public Constructor -

        #region - Private Methods - UI <> Data
        private bool DatatoUI()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool UItoData()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion UI <> Data

        #region - Private Methods -
        // 讀取參數
        private void mnReadParam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定讀取?", "再次確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    //ParamDB paramNew = XmlFile.DeserializeFromFile<ParamDB>(xmlFullPath);
                    //PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(paramNew);
                    //foreach (PropertyDescriptor property in properties)
                    //{
                    //    object value = property.GetValue(paramNew);
                    //    property.SetValue(paramDB, value);
                    //}
                    DatatoUI();
                    PropertySystem.Refresh();
                    MessageBox.Show("讀取完成");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取失敗，錯誤訊息：{0}", ex.Message);
                }
            }
        }
        // 寫入參數
        private void mnWriteParam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定寫入?", "再次確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    UItoData();
                    //       xmlFullPath = @"Recipe\000_StandardRecipe\algorithmChannelOne.xml";
                    //XmlFile.SerializeToFile(xmlFullPath, paramDB);
                    PropertySystem.SelectedObject = paramDB;
                    MessageBox.Show("寫入完成");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("寫入失敗，錯誤訊息：{0}", ex.Message);
                }
            }
        }
        // 離開
        private void mnExitParam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定離開?", "再次確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                //paramDB.XmlFullPath = xmlFullPath;
                this.Close();
            }
        }
        #endregion - Private Methods -

        private void buttonDBUpdate_Click(object sender, EventArgs e)
        {
            string[] result = new string[3];
            string[] ofield = new string[1];
            string[] ovalue = new string[1];
            string[] otype = new string[1];
            string[] wfield = new string[1];
            string[] wvalue = new string[1];
            string[] wtype = new string[1];

            wfield[0] = textField1.Text;
            ofield[0] = textField2.Text;
            wvalue[0] = textValue1.Text;
            ovalue[0] = textValue2.Text;
            wtype[0] = "_blank";
            otype[0] = "_blank";

            result = mainDB.UpdateToDB(textTable.Text, ofield,ovalue,otype,wfield,wvalue,wtype);
            textResult.Text = result[0] + Environment.NewLine + result[1] + Environment.NewLine + result[2];
        }

        private void buttonDBInsert_Click(object sender, EventArgs e)
        {
            string[] result = new string[3];
            string[] field = new string[2];
            string[] value = new string[2];
            string[] type = new string[2];

            field[0] = textField1.Text;
            field[1] = textField2.Text;
            value[0] = textValue1.Text;
            value[1] = textValue2.Text;
            type[0] = "_blank";
            type[1] = "_blank";

            result = mainDB.InsertToDB(textTable.Text, field, value, type);
            textResult.Text = result[0] + Environment.NewLine + result[1] + Environment.NewLine + result[2];
        }

        private void buttonDBDelete_Click(object sender, EventArgs e)
        {
            string[] result = new string[3];
            string[] dfield = new string[1];
            string[] dvalue = new string[1];
            string[] dtype = new string[1];

            dfield[0] = textField1.Text;
            dvalue[0] = textValue1.Text;
            dtype[0] = "_blank";

            result = mainDB.DeleteToDB(textTable.Text, dfield, dvalue, dtype);
            textResult.Text = result[0] + Environment.NewLine + result[1] + Environment.NewLine + result[2];
        }

        private void buttonDBSelect_Click(object sender, EventArgs e)
        {
            string[] result = new string[3];
            string[] dfield = new string[1];
            string[] dvalue = new string[1];
            string[] dtype = new string[1];

            dfield[0] = textField1.Text;
            dvalue[0] = textValue1.Text;
            dtype[0] = "_blank";

            result = mainDB.SelectFormDB(textTable.Text, dfield, dvalue, dtype);
            textResult.Text = result[0] + Environment.NewLine + result[1] +Environment.NewLine + result[2] ;
        }

        private void frmParamDB_Load(object sender, EventArgs e)
        {


        }

        public void countPlus()
        {
            string[] FieldNew = new string[25] { "dateDD",
                                "\"00\"", "\"01\"", "\"02\"", "\"03\"", "\"04\"", "\"05\"", "\"06\"", "\"07\"",
                                "\"08\"" , "\"09\"", "\"10\"", "\"11\"" , "\"12\"", "\"13\"" , "\"14\"", "\"15\"",
                                "\"16\"", "\"17\"", "\"18\"", "\"19\"", "\"20\"", "\"21\"", "\"22\"", "\"23\"" };
            string[] ValueNew = new string[25] { DateTime.Now.ToString("yyyyMMdd"),
                                "0", "0", "0", "0", "0", "0", "0", "0",
                                "0", "0", "0", "0", "0", "0", "0", "0",
                                "0", "0", "0", "0", "0", "0", "0", "0" };
            string[] TypeNew = new string[25] { "_blank" ,
                                "_blank" , "_blank" , "_blank" , "_blank" , "_blank" ,"_blank" ,"_blank" , "_blank" ,
                                "_blank" , "_blank" , "_blank" , "_blank" , "_blank" ,"_blank" ,"_blank" , "_blank" ,
                                "_blank" , "_blank" , "_blank" , "_blank" , "_blank" ,"_blank" ,"_blank" , "_blank"  };

            mainDB.InsertToDB(paramDB.Table_hhPP, FieldNew, ValueNew, TypeNew);

            string[] FieldDD = new string[1] { "dateDD" };
            string[] FieldHH = new string[1] { DateTime.Now.ToString("HH") };
            string[] ValueDD = new string[1] { DateTime.Now.ToString("yyyyMMdd") };
            string[] ValueTT = new string[1];
            string[] TypeATT = new string[1] { "_blank" };
            string[] result = new string[3];

            result = mainDB.SelectFormDB(paramDB.Table_hhPP, FieldDD, ValueDD, TypeATT);

            if (result[2] != null)
            {
                Char delimiter = ',';
                String[] subresult = result[2].Split(delimiter);
                ValueTT[0] = subresult[Convert.ToInt16(FieldHH[0]) + 1];
                ValueTT[0] = Convert.ToString(Convert.ToInt16(ValueTT[0]) + 1);
            }   

            textResult.Text = FieldHH[0] + "," + ValueTT[0];

            FieldHH[0] = "\"" + FieldHH[0] + "\"";
            result = mainDB.UpdateToDB(paramDB.Table_hhPP, FieldHH, ValueTT, TypeATT, FieldDD, ValueDD, TypeATT);
            textResult.Text = textResult.Text + Environment.NewLine + result[0] + Environment.NewLine + result[1] + Environment.NewLine + result[2];
        }

        public void ttcountPlus(int conveor_no)
        {
            string conveor = null;
            if (conveor_no == 1) conveor = "conveor01";
            else conveor = "conveor02";

            string[] result = new string[3];
            string[] FieldTT = new string[1] { conveor };
            string[] ValueTT = new string[1];
            string[] FieldID = new string[1] { "id" };
            string[] ValueID = new string[1] { "1" };
            string[] TypeATT = new string[1] { "_blank" };

            string ttProduct = null;

            result = mainDB.SelectFormDB(mainDB.paramDB.Table_ttPP, FieldID, ValueID, TypeATT);
            if (result[2] != null)
            {
                Char delimiter = ',';
                String[] subresult = result[2].Split(delimiter);
                ValueTT[0] = subresult[conveor_no];
                ValueTT[0] = Convert.ToString(Convert.ToInt64(ValueTT[0]) + 1);
                ttProduct = subresult[3];
            }

            mainDB.UpdateToDB(mainDB.paramDB.Table_ttPP, FieldTT, ValueTT, TypeATT, FieldID, ValueID, TypeATT);

            textResult.Text = "Total," + ttProduct;
            result = mainDB.UpdateToDB(mainDB.paramDB.Table_ttPP, FieldTT, ValueTT, TypeATT, FieldID, ValueID, TypeATT);
            textResult.Text = textResult.Text + Environment.NewLine + result[0] + Environment.NewLine + result[1] + Environment.NewLine + result[2];
        }

        private void buttonDBAdd_Click(object sender, EventArgs e)
        {
            countPlus();
        }

        private void buttonTBCreate_Click(object sender, EventArgs e)
        {
            string[] result = new string[3];
            string[] tbField = new string[6] { "no", "day", "hour", "min", "sec", "log" };
            string[] tbType = new string[6] { "bigint", "tinyint", "tinyint", "tinyint", "float", "nvarchar(max)" };
            string[] tbCondintion = new string[6] { "IDENTITY", "NOT NULL", "NOT NULL", "NOT NULL", "NOT NULL", "NOT NULL" };

            result = mainDB.CreateTable("log_" + DateTime.Now.ToString("yyyyMM"), tbField, tbType, tbCondintion);
            textResult.Text = result[0] + Environment.NewLine + result[1] + Environment.NewLine + result[2];
        }

        private void buttonDBAddTT_Click(object sender, EventArgs e)
        {
            ttcountPlus(1);
            ttcountPlus(2);
        }
    }
}
