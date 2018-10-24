﻿using EnglishCalssManager.Rollcall.EmployeeRollcall;
using EnglishClassManager.Utility.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishClassManager.Rollcall.EmployeeRollcall
{

    public partial class frmEmployeeRollcall : Form
    {
        public DatabaseCore dbc = DatabaseManager._databaseCore;
        public DatabaseTable dbt = DatabaseManager._databaseTable;
        public DatabaseCoreRollcall dbcR = DatabaseManager._databaseCoreRollcall;
        public string date = DateTime.Now.ToString("dd");
        public string datelong = DateTime.Now.ToString("yyyyMMdd");
        public string dateshort = DateTime.Now.ToString("yyyy_MM");
        private string _classSelect = "*";

        public frmEmployeeRollcall()
        {
            InitializeComponent();
        }

        private void frmEmployeeRollcall_Load(object sender, EventArgs e)
        {
            CreateTable();
            DataTable _dataTable = new DataTable();
            string CommandStr = "Select ClassID from Table_ClassSchedule";
            _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            cbox_ClassID.Items.Add("*");
            foreach (DataRow drw in _dataTable.Rows)
            {
                cbox_ClassID.Items.Add(drw.ItemArray[0].ToString());
            }
            cbox_ClassID.Text = cbox_ClassID.Items[0].ToString();
            refreshTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(e.ColumnIndex.ToString(),e.RowIndex.ToString());
            string CommandStr = "";
            int _dataCurRowIndex = dataGridView1.CurrentCell.RowIndex;
            string _employeeID = dataGridView1.Rows[_dataCurRowIndex].Cells["EmployeeID"].Value.ToString();
            DateTime _dtrollcallDate = DateTime.Now;
            string _strrollcallDate = _dtrollcallDate.ToString("yyyy-MM-dd HH:mm:ss");
            string _latetime = "";
            string _eralytime = "";
            if (e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                // MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                if (e.ColumnIndex==14)
                {
                    if (ckb_WorkStart.Checked)
                    {
                        string _workS = dataGridView1.Rows[_dataCurRowIndex].Cells["ClassStart"].Value.ToString(); //_dataTable.Rows[0][3];
                        funcRollStart(_employeeID, _workS); 
                    }
                    else if (ckb_WorkEnd.Checked && dataGridView1.Rows[e.RowIndex].Cells["RollcallStart"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["RollCallState"].Value != "請假")
                    {
                        string _workE = dataGridView1.Rows[_dataCurRowIndex].Cells["ClassEnd"].Value.ToString(); //_dataTable.Rows[0][3];
                        funcRollEnd(_employeeID, _workE);
                    }
                    refreshTable();
                }
                else if (e.ColumnIndex==15)
                {
                    if(dataGridView1.Rows[e.RowIndex].Cells["RollcallStart"].Value == "")
                    {
                        funcRollLeave(_employeeID);
                        refreshTable();
                    }
                    
                }
            }
        }
    
        public void refreshTable()
        {
            if (dataGridView1.Rows.Count > 1)
            {
                while (dataGridView1.Rows.Count != 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                }
            }

            string CommandStr = string.Format(" select distinct * from EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
                + " left outer join EnglishClassDBtest.dbo.Table_ClassSchedule"
                + " on  EnglishClassDBtest.dbo.Table_ClassSchedule.ClassID = EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.ClassID"
                + " left outer join EnglishClassDBtest.dbo.Table_EmployeeBasic"
                + " on  EnglishClassDBtest.dbo.Table_EmployeeBasic.EmployeeID = EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID"
                + " left outer join EnglishClassDBtest.dbo.Table_EmployeeBook"
                + " on  EnglishClassDBtest.dbo.Table_EmployeeBook.EmployeeID = EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID"
                + " left outer join EnglishClassShift.dbo.Table_ClassShift_{1}"
                + " on  EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID = EnglishClassShift.dbo.Table_ClassShift_{1}.EmployeeID"
                + " where EnglishClassShift.dbo.Table_ClassShift_{1}.D{2} != ''"
                + "{3}",
                datelong,dateshort, date,_classSelect);
            DataTable _dataTable = dbc.CommandFunctionDB("Table_ClassSchedule", CommandStr);
            // dataGridView1.DataSource = _dataTable;
        
            int i = 0;
            foreach(DataRow drw in _dataTable.Rows)
            {
                //string mon = DateTime.Parse(drw.ItemArray[2].ToString()).ToString("yyyy-MM-dd");
                try
                {
                    dataGridView1.Rows[i].Cells["EmployeeID"].Value = drw.ItemArray[0].ToString();// _dataTable.Rows[0][0];
                    string _workStart = drw.ItemArray[11].ToString()+":"+ drw.ItemArray[12].ToString();
                string _workEnd = drw.ItemArray[13].ToString() + ":" + drw.ItemArray[14].ToString();
                    string _rollcallStart = drw.ItemArray[3].ToString();//DateTime.Parse(drw.ItemArray[3].ToString()).ToString("HH:mm:ss");
                    string _rollcallEnd = drw.ItemArray[4].ToString();//DateTime.Parse(drw.ItemArray[4].ToString()).ToString("HH:mm:ss");
                    string _rollcallDatetime = drw.ItemArray[2].ToString();
                    //string _rollcallEarly = "";
                    //string _rollcallLate = "";
                  // diffTimeFunction(_workStart,_workEnd,_rollcallStart,_rollcallEnd,ref _rollcallEarly,ref _rollcallLate, drw.ItemArray[0].ToString(),ref _rollcallDatetime);
                     dataGridView1.Rows.Add(drw.ItemArray[0].ToString());
                dataGridView1.Rows[i].Cells["ClassID"].Value = drw.ItemArray[1].ToString();// _dataTable.Rows[0][0];
                dataGridView1.Rows[i].Cells["TwName"].Value = drw.ItemArray[25].ToString(); ;// _dataTable.Rows[0][11];
                dataGridView1.Rows[i].Cells["Dept"].Value = drw.ItemArray[32].ToString();// _dataTable.Rows[0][18];
                dataGridView1.Rows[i].Cells["Position"].Value = drw.ItemArray[31].ToString(); //_dataTable.Rows[0][17];
                dataGridView1.Rows[i].Cells["ClassStart"].Value = _workStart; //_dataTable.Rows[0][17];
                dataGridView1.Rows[i].Cells["ClassEnd"].Value = _workEnd; //_dataTable.Rows[0][17];
                dataGridView1.Rows[i].Cells["RollcallDate"].Value = _rollcallDatetime; // _dataTable.Rows[0][2];
                dataGridView1.Rows[i].Cells["RollCallState"].Value = drw.ItemArray[8].ToString();//_dataTable.Rows[0][8];
                dataGridView1.Rows[i].Cells["RollcallStart"].Value = _rollcallStart; //_dataTable.Rows[0][3];
                dataGridView1.Rows[i].Cells["RollcallEnd"].Value = _rollcallEnd; // _dataTable.Rows[0][4];
                dataGridView1.Rows[i].Cells["RollCallLate"].Value = drw.ItemArray[5].ToString().Substring(0,8); //_dataTable.Rows[0][5];
                dataGridView1.Rows[i].Cells["RollCallEarly"].Value = drw.ItemArray[6].ToString().Substring(0, 8); ; //_dataTable.Rows[0][6];
                dataGridView1.Rows[i].Cells["RollcallHR"].Value = drw.ItemArray[7].ToString();// _dataTable.Rows[0][7];
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.ToString());
                }

                i++;
            }
        }

        public void CreateTable()
        {
            ///創建Talbe
            baseEmployeeRollcall.CreateTable();
        }

        private void diffTimeFunction(string _workS,string _workE,string _rollcallS, string _rollcallE, ref string _eralytime,ref string _latetime,string _employeeID,ref string _rollcallDatetime)
        {
            bool _bRCS = false;
            bool _bRCE = false;
            bool _bRCDT = false;
            string CommandStr = "";
            
            if(_rollcallDatetime!="")
            {
                _rollcallDatetime = DateTime.Parse(_rollcallDatetime).ToString("yyyy-MM-dd");
                _bRCDT = true;
            }

            if (_rollcallS != "")
            {
                _rollcallS = DateTime.Parse(_rollcallS).ToString("HH:mm:ss");
                _bRCS = true;
            }
            if (_rollcallE != "")
            {
                _rollcallE = DateTime.Parse(_rollcallE).ToString("HH:mm:ss");
                _bRCE = true;
            }

            if(_bRCE && _bRCS && _bRCDT)
            {

            DateTime dt_workS = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day, Convert.ToUInt16(_workS.Substring(0,2)), Convert.ToUInt16(_workS.Substring(3, 2)),0);
            DateTime dt_workE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(_workE.Substring(0, 2)), Convert.ToInt32(_workE.Substring(3, 2)), 0);
            DateTime dt_rollcallS = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(_rollcallS.Substring(0, 2)), Convert.ToInt32(_rollcallS.Substring(3, 2)), Convert.ToInt32(_rollcallS.Substring(6, 2)) );
            DateTime dt_rollcallE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(_rollcallE.Substring(0, 2)), Convert.ToInt32(_rollcallE.Substring(3, 2)), Convert.ToInt32(_rollcallE.Substring(6, 2)));
            TimeSpan tWS =  dt_rollcallS-dt_workS;
            TimeSpan tWD = dt_workE - dt_rollcallE;

            //dt_workS = new DateTime(2018,6,8,11,11,11);
            //dt_workE = new DateTime(2018, 6, 8, 11, 11, 11);
            //dt_rollcallS = new DateTime(2018, 6, 8, 11, 11, 11);
            //dt_rollcallE = new DateTime(2018, 6, 8, 11, 11, 11);
           

            if (dt_workS < dt_rollcallS)
            { 
                _latetime = tWS.ToString();
                CommandStr = string.Format(
                   "Update EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
                   + " Set RollCallLate='{1}'"
                   + " Where EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID='{2}'"
                   , datelong, _latetime, _employeeID);
                dbcR.ExecuteNonQuery(CommandStr);
            }
            if (dt_workE > dt_rollcallE)
            {
                _eralytime = tWD.ToString();
                CommandStr = string.Format(
                 "Update EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
                 + " Set RollCallEarly='{1}'"
                 + " Where EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID='{2}'"
                 , datelong, _eralytime, _employeeID);
                dbcR.ExecuteNonQuery(CommandStr);
            }
            }
        }

        private void cbox_ClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbox_ClassID.Text.ToString());
            if (cbox_ClassID.Text.ToString() == "*")
                _classSelect = "";
            else
                _classSelect = string.Format(" and EnglishClassShift.dbo.Table_ClassShift_{1}.D{2} = '{0}'",cbox_ClassID.Text.ToString(), dateshort, date);

            refreshTable();
        }

        private void ckb_WorkStart_Click(object sender, EventArgs e)
        {
            ckb_WorkEnd.Checked = false;
        }

        private void ckb_WorkEnd_Click(object sender, EventArgs e)
        {
            ckb_WorkStart.Checked = false;
        }

        public void funcRollStart(string _employeeID, string _workS)
        {
            string CommandStr = "";
            DateTime _dtrollcallDate = DateTime.Now;
            string _strrollcallDate = _dtrollcallDate.ToString("yyyy-MM-dd HH:mm:ss");
            string _latetime = "";
            DateTime dt_workS = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToUInt16(_workS.Substring(0, 2)), Convert.ToUInt16(_workS.Substring(3, 2)), 0);
            TimeSpan tWS = _dtrollcallDate - dt_workS;
            if (dt_workS < _dtrollcallDate)
            {
                _latetime = tWS.ToString();
            }
            CommandStr = string.Format(
       "Update EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
       + " Set RollcallDate='{1}',RollCallStart='{2}',RollCallState='{3}',RollCallLate='{4}'"
       + " Where EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID='{5}'"
       , datelong, _strrollcallDate, _strrollcallDate, "已上班", _latetime, _employeeID);
            dbcR.ExecuteNonQuery(CommandStr);
        }

        public void funcRollEnd(string _employeeID, string _workE)
        {
            string CommandStr = "";
            DateTime _dtrollcallDate = DateTime.Now;
            string _strrollcallDate = _dtrollcallDate.ToString("yyyy-MM-dd HH:mm:ss");
            string _eralytime = "";

            DateTime dt_workE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToUInt16(_workE.Substring(0, 2)), Convert.ToUInt16(_workE.Substring(3, 2)), 0);
            TimeSpan tWS = _dtrollcallDate - dt_workE;
            if (dt_workE < _dtrollcallDate)
            {
                _eralytime = tWS.ToString();
            }

            CommandStr = string.Format(
            "Update EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
           + " Set RollcallDate='{1}',RollCallEnd='{2}',RollCallState='{3}',RollCallEarly='{4}'"
           + " Where EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID='{5}'"
           , datelong, _strrollcallDate, _strrollcallDate, "已上班", _eralytime, _employeeID);
            dbcR.ExecuteNonQuery(CommandStr);
        }

        public void funcRollLeave(string _employeeID)
        {
            string CommandStr = string.Format(
                       "Update EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}"
                       + " Set RollcallDate='{1}',RollCallStart='{2}',RollCallState='{4}'"
                       + " Where EnglishClassDBtestRollcall.dbo.Table_EmployeeRollcall_{0}.EmployeeID='{3}'"
                       , datelong, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _employeeID, "請假");
            dbcR.ExecuteNonQuery(CommandStr);
        }

        private void btn_OFF_Click(object sender, EventArgs e)
        {

        }

        private void btn_Select_Click(object sender, EventArgs e)
        {

        }

        private void btn_ON_Click(object sender, EventArgs e)
        {

        }

        private void btn_Leave_Click(object sender, EventArgs e)
        {

        }
    }
}