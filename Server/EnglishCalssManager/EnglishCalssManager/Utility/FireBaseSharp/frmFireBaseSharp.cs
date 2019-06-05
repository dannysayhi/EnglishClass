using EnglishCalssManager.Utility.FileControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EnglishCalssManager.Utility.FireBaseSharp
{
    public  partial class frmFireBaseSharp : Form
    {
        funFireBaseSharp _funFireBaseSharp = new funFireBaseSharp();
        public frmFireBaseSharp()
        {
            InitializeComponent();
        }

        private void frmFireBaseSharp_Load(object sender, EventArgs e)
        {
            if (_funFireBaseSharp.IsConnect())
            { lb_connect.Text = lb_connect.Text + "  ： OK"; }
            else
            {
                lb_connect.Text = lb_connect.Text + "  ： NULL";
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if(_funFireBaseSharp.IsConnect())
            { lb_connect.Text =" Connect is ： OK"; }
            else
            {
                lb_connect.Text = " Connect is ： NULL "; ;
                _funFireBaseSharp.connection();
                if (_funFireBaseSharp.IsConnect())
                {
                    lb_connect.Text = " Connect is ： OK"; ;
                }
            }
        }
        private void btn_disconncet_Click(object sender, EventArgs e)
        {
            _funFireBaseSharp.disconnection();
        }

        private async void btn_Retrieving_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private async void btn_insert_Click(object sender, EventArgs e)
        {
            btn_insert.Enabled = false;
            if (_funFireBaseSharp.IsConnect())
            {
                var data = new Data
                {
                    ID = txt_ID.Text,
                    phone = txt_phone.Text,
                    Groups = txt_Groups.Text,
                };
                if (txt_ID.Text == "" || txt_phone.Text == "" || !Regex.IsMatch(txt_ID.Text, RegularExp.NumericOrLetter) || !Regex.IsMatch(txt_ID.Text, RegularExp.NumbericOrLetterOrChinese))
                {
                    MessageBox.Show("ID不可空白");
                }
                else
                {
                    _funFireBaseSharp.insert(data);
                }
                RefreshTable();
            }
            else
            {
                MessageBox.Show("請確認連線！");
            }
            btn_insert.Enabled = true;
        }

        private async void btn_TotalDel_Click(object sender, EventArgs e)
        {
            await _funFireBaseSharp.deleteTotal();
            RefreshTable();

        }

        private void btn_delet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value != null)
                {
                    object wrStr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                    if (wrStr.ToString() == "" || !Regex.IsMatch(wrStr.ToString(), RegularExp.NumericOrLetter) || !Regex.IsMatch(wrStr.ToString(), RegularExp.NumbericOrLetterOrChinese))
                    {
                        MessageBox.Show("請確認輸入文字");
                    }
                    else
                    {
                        _funFireBaseSharp.fun_delete(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            RefreshTable();
        }

        /// <summary>
        /// 更新Table
        /// </summary>
        private async void RefreshTable()
        {
            DataTable dt = new DataTable();
            List<Data> _vehicles = new List<Data>();
            List<Data> _vehicles_new = new List<Data>();
            _vehicles = await _funFireBaseSharp.Retrieving();
            if (_vehicles != null)
            {
                foreach (Data i in _vehicles)
                {
                   if(i!=null)
                    {
                        _vehicles_new.Add(i);
                    }
                }
                dt = ConvertToDataTable(_vehicles_new);
            }

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// List to Table 轉換
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

      
    }
}
