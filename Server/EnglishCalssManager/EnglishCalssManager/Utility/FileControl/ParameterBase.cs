using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace AOISystem.Utility.IO
{
    /// <summary> </summary>
    [Serializable]
    public class ParameterBase
    {
        /// <summary> XML檔案路徑 </summary>
        [XmlIgnore, Browsable(false)]
        public string XmlFullPath { set; get; }

        public ParameterBase()
        {
        }
        public ParameterBase(string xmlFullPath)
        {
            this.XmlFullPath = xmlFullPath;
        }


        #region 儲存 讀取
        /// <summary>
        /// 將參數寫入XML檔案
        /// </summary>
        public void WriteToXml()
        {
            //string xmlFullPath = XmlFullPath.Split;
            if (!Directory.GetParent(XmlFullPath).Exists)
            {
                MessageBox.Show("建立/儲存 參數檔的檔案夾不存在，請確認檔案路徑正確！");
            }
            else
            {
                using (FileStream fs = new FileStream(XmlFullPath, FileMode.Create))
                {
                    XmlSerializer xmls = new XmlSerializer(this.GetType());
                    xmls.Serialize(fs, this);
                    fs.Close();
                }
            }
        }
        /// <summary>
        /// 從XML檔案讀取參數
        /// </summary>
        /// <typeparam name="T">參數類別</typeparam>
        /// <param name="xmlPara"></param>
        public void ReadFromXml<T>(ref T xmlPara) where T : ParameterBase
        {
            string xmlFullPath = xmlPara.XmlFullPath;
            try
            {
                if (File.Exists(XmlFullPath) == true)
                {
                    using (FileStream fs = new FileStream(XmlFullPath, FileMode.Open))
                    {
                        XmlSerializer xmls = new XmlSerializer(this.GetType());
                        xmlPara = (T)xmls.Deserialize(fs);
                        xmlPara.XmlFullPath = xmlFullPath;
                    }
                }
                else
                {
                    //if (MessageBox.Show("參數檔案不存在，是否依照預設值建立參數檔案？", "Parameter", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (MessageBox.Show("參數檔案不存在", "Parameter", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        WriteToXml();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

    }

}
