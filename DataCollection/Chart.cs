﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataCollection
{
    public partial class Chart : Form
    {
        private string strSelectQuery1 = "SELECT * from MainData ";
        private bool[] tempLogic = new bool[32];

        //private static DateTime dog = Convert.ToDateTime("2017/01/06 15:00:40.6849066");
        //private static DateTime cat = Convert.ToDateTime("2017/12/31 23:59:40.0000000");

        string strQuery = "";
        private int monthLength = 32;
        public Chart()
        {
            InitializeComponent();
            chart1.Visible = true;
            populate();
        }

        private void Chart_Load(object sender, EventArgs e)
        { }

        private void sDATABindingSource_CurrentChanged(object sender, EventArgs e)
        {}

        private void populate()
        {
            cmbStartYear.Items.Clear();
            cmbStartMonth.Items.Clear();
            cmbStartDay.Items.Clear();
            cmbStartTime.Items.Clear();
            cmbEndYear.Items.Clear();
            cmbEndMonth.Items.Clear();
            cmbEndDay.Items.Clear();
            cmbEndTime.Items.Clear();

            for (int x = 2018; x < 2026; x++)
            {
                cmbStartYear.Items.Add(x.ToString("00"));
                cmbEndYear.Items.Add(x.ToString("00"));
            }

            for (int x = 0; x < 12; x++)
            {
                cmbStartMonth.Items.Add((x + 1).ToString("00"));
                cmbEndMonth.Items.Add((x + 1).ToString("00"));
            }

            for (int x = 1; x < monthLength; x++)
            {
                cmbStartDay.Items.Add(x.ToString("00"));
                cmbEndDay.Items.Add(x.ToString("00"));
            }
            for (int X = 0; X < 24; X++)
            {
                cmbStartTime.Items.Add(X.ToString("00"));
                cmbEndTime.Items.Add(X.ToString("00"));
            }
            cmbStartYear.SelectedIndex = 0;
            cmbEndYear.SelectedIndex = 0;
            cmbStartMonth.SelectedIndex = 0;
            cmbEndMonth.SelectedIndex = 0;
            cmbStartDay.SelectedIndex = 0;
            cmbEndDay.SelectedIndex = 0;
            cmbStartTime.SelectedIndex = 0;
            cmbEndTime.SelectedIndex = 0;
        }

        private void Establish_MonthDay(int a)
        {
            switch (a)
            {
                case 1:
                    monthLength = 31;
                    break;
                case 2:
                    monthLength = 28;
                    break;
                case 3:
                    monthLength = 31;
                    break;
                case 4:
                    monthLength = 30;
                    break;
                case 5:
                    monthLength = 31;
                    break;
                case 6:
                    monthLength = 30;
                    break;
                case 7:
                    monthLength = 31;
                    break;
                case 8:
                    monthLength = 31;
                    break;
                case 9:
                    monthLength = 30;
                    break;
                case 10:
                    monthLength = 31;
                    break;
                case 11:
                    monthLength = 30;
                    break;
                case 12:
                    monthLength = 31;
                    break;
                default:
                    monthLength = 0;
                    break;
            }
        }

        protected void Start_MonthDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cmbStartDay.Items.Clear();
            Establish_MonthDay(Int32.Parse(cmbStartMonth.SelectedItem.ToString()));
            for (int x = 1; x < monthLength + 1; x++)
            {
                cmbStartDay.Items.Add(x.ToString());
            }
            cmbStartDay.SelectedIndex = 0;
            

        }

        protected void End_MonthDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cmbEndDay.Items.Clear();
            Establish_MonthDay(Int32.Parse(cmbEndMonth.SelectedItem.ToString()));
            for (int x = 1; x < monthLength + 1; x++)
            {
                cmbEndDay.Items.Add(x.ToString());
            }
            cmbEndDay.SelectedIndex = 0;
        }

        public DataTable get(string query)
        {
            numCrunch access = new numCrunch();
            DataTable result = new DataTable();
            result = access.dataRead(query);
            return result;
        }

        private bool[] chkChecked()
        {
            // First the Temerature Sensor
            if (chkBoxSensor1.Checked) { tempLogic[0] = true; } else { tempLogic[0] = false; }
            if (chkBoxSensor2.Checked) { tempLogic[1] = true; } else { tempLogic[1] = false; }
            if (chkBoxSensor3.Checked) { tempLogic[2] = true; } else { tempLogic[2] = false; }
            if (chkBoxSensor4.Checked) { tempLogic[3] = true; } else { tempLogic[3] = false; }
            if (chkBoxSensor5.Checked) { tempLogic[4] = true; } else { tempLogic[4] = false; }
            if (chkBoxSensor6.Checked) { tempLogic[5] = true; } else { tempLogic[5] = false; }
            if (chkBoxSensor7.Checked) { tempLogic[6] = true; } else { tempLogic[6] = false; }
            if (chkBoxSensor8.Checked) { tempLogic[7] = true; } else { tempLogic[7] = false; }
            if (chkBoxSensor9.Checked) { tempLogic[8] = true; } else { tempLogic[8] = false; }
            if (chkBoxSensor10.Checked) { tempLogic[9] = true; } else { tempLogic[9] = false; }
            if (chkBoxSensor11.Checked) { tempLogic[10] = true; } else { tempLogic[10] = false; }
            if (chkBoxSensor12.Checked) { tempLogic[11] = true; } else { tempLogic[11] = false; }
            if (chkBoxSensor13.Checked) { tempLogic[12] = true; } else { tempLogic[12] = false; }
            if (chkBoxSensor14.Checked) { tempLogic[13] = true; } else { tempLogic[13] = false; }
            if (chkBoxSensor15.Checked) { tempLogic[14] = true; } else { tempLogic[14] = false; }
            if (chkBoxSensor16.Checked) { tempLogic[15] = true; } else { tempLogic[15] = false; }
            // Now the Temerature and Humidity Sensors...  The ordering in the groupboxes is different on [design] page

            if (chkBoxSensor17.Checked) { tempLogic[16] = true; } else { tempLogic[16] = false; }
            if (chkBoxSensor18.Checked) { tempLogic[17] = true; } else { tempLogic[17] = false; }
            if (chkBoxSensor19.Checked) { tempLogic[18] = true; } else { tempLogic[18] = false; }
            if (chkBoxSensor20.Checked) { tempLogic[19] = true; } else { tempLogic[19] = false; }
            if (chkBoxSensor21.Checked) { tempLogic[20] = true; } else { tempLogic[20] = false; }
            if (chkBoxSensor22.Checked) { tempLogic[21] = true; } else { tempLogic[21] = false; }
            if (chkBoxSensor23.Checked) { tempLogic[22] = true; } else { tempLogic[22] = false; }
            if (chkBoxSensor24.Checked) { tempLogic[23] = true; } else { tempLogic[23] = false; }
            // Finally the Voltage Sensors
            if (chkBoxSensor25.Checked) { tempLogic[24] = true; } else { tempLogic[24] = false; }
            if (chkBoxSensor26.Checked) { tempLogic[25] = true; } else { tempLogic[25] = false; }
            if (chkBoxSensor27.Checked) { tempLogic[26] = true; } else { tempLogic[26] = false; }
            if (chkBoxSensor28.Checked) { tempLogic[27] = true; } else { tempLogic[27] = false; }
            if (chkBoxSensor29.Checked) { tempLogic[28] = true; } else { tempLogic[28] = false; }
            if (chkBoxSensor30.Checked) { tempLogic[29] = true; } else { tempLogic[29] = false; }
            if (chkBoxSensor31.Checked) { tempLogic[30] = true; } else { tempLogic[30] = false; }
            if (chkBoxSensor32.Checked) { tempLogic[31] = true; } else { tempLogic[31] = false; }

            return tempLogic;
        }

        private DataTable getValues1(bool[] chkItems, string query)
        {
            string temperature = "Temperature-";
            string humidity = "Humidity-";
            string humTemp = "Temp-";
            string voltage = "Voltage-";
            int t = 0;
            int h = 0;
            DataTable chartTable = new DataTable();
            chartTable = get(query);
            for (int i = 0; i < chkItems.Length; i++)
            {
                if (chkItems[i] == true)
                {
                    if (i < 16)
                    {
                        chartTable.Columns[i + 1].ColumnName = temperature + (i + 1 );
                        addSeries(temperature, (i + 1 ));
                    }

                    if (i > 15 && i < 24)
                    {
                        if (i == 16) { t = 1; }
                        if (i == 17) { h = 1; }
                        if (i == 18) { t = 2; }
                        if (i == 19) { h = 2; }
                        if (i == 20) { t = 3; }
                        if (i == 21) { h = 3; }
                        if (i == 22) { t = 4; }
                        if (i == 23) { h = 4; }
                        if (i % 2 != 0)
                        {
                            chartTable.Columns[i + 1].ColumnName = humidity + h;
                            addSeries(humidity, (h));
                        }
                        else
                        {
                            chartTable.Columns[i + 1].ColumnName = humTemp + t;
                            addSeries(humTemp, (t));
                        }
                    }
                    if (i > 23 )
                    {
                        chartTable.Columns[i + 1].ColumnName = voltage + (i );
                        addSeries(voltage, (i ));
                    }
                }
            }
            return chartTable;
        }


        public void addSeries(string colName, int x)
        {
            string col = colName + x.ToString();
            chart1.Series.Add(col);
            chart1.Series[col].XValueType = ChartValueType.DateTime;
            chart1.Series[col].ChartType = SeriesChartType.Line;
            chart1.Series[col].XValueMember = "ReadDate";
            chart1.Series[col].YValueMembers = colName + x.ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string start = cmbStartYear.SelectedItem.ToString() + "/" + cmbStartMonth.SelectedItem.ToString() + "/" + cmbStartDay.SelectedItem.ToString() + " " + cmbStartTime.SelectedItem.ToString() + ":00:00.000000 ";
            string end = cmbEndYear.SelectedItem.ToString() + "/" + cmbEndMonth.SelectedItem.ToString() + "/" + cmbEndDay.SelectedItem.ToString() + " " + cmbEndTime.SelectedItem.ToString() + ":00:00.000000 ";
            DateTime dog = Convert.ToDateTime(start);
            DateTime cat = Convert.ToDateTime(end);

            strQuery = " WHERE ReadDate > '" + dog + "' AND ReadDate < '" + cat + "'";
            string whereClause = strSelectQuery1 + strQuery;

            while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
            DataTable forChart = new DataTable();
            forChart = getValues1(chkChecked(), whereClause);
            chart1.DataSource = forChart;
            chart1.DataBind();
        }

        private void Chart_Load_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpg";
            saveFileDialog.Title = "Save Chart As Image File";
            saveFileDialog.FileName = "Chart.png";

            DialogResult result = saveFileDialog.ShowDialog();
            saveFileDialog.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                try
                {
                    if (saveFileDialog.CheckPathExists)
                    {
                        if (saveFileDialog.FilterIndex == 2)
                        {
                            chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                        }
                        else if (saveFileDialog.FilterIndex == 1)
                        {
                            chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Given Path does not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }

        }
    }
}
