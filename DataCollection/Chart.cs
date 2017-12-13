using System;
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
        private string connectionString = "data source = (localdb)\\MSSQLLocalDB;" +
                            "initial catalog = DataCollection;" +
                            "integrated security = True;" +
                            "MultipleActiveResultSets=True;App=EntityFramework";
        private string strSelectQuery1 = "SELECT ReadDate, SensorVal FROM S_Data where SensorID = ";
        private string strSelectQuery2 = "SELECT ReadDate, SensorVal FROM S_Data where SensorID = ";
        private bool[] tempLogic = new bool[16];
        public Chart()
        {
            InitializeComponent();
             chart1.Visible = true;


        }

        private void Chart_Load(object sender, EventArgs e)
        {

        }

        private void sDATABindingSource_CurrentChanged(object sender, EventArgs e)
        {
            

        }

        public DataTable get(string query)
        {
            numCrunch access = new numCrunch();
            DataTable result = new DataTable();
            result = access.dataRead(query);
            return result;
        }


        public DataTable dataMerge(DataTable orig, DataTable add, int index)
        {
            try
            {
               orig.Columns.Add(new DataColumn("Temperature-" + (index + 1).ToString() , typeof(float)));
                for (int col = 0; col < orig.Columns.Count; col++)
                {
                    for (int i = 0; i < orig.Rows.Count; i++)
                    {
                        orig.Rows[i][col +2] = add.Rows[i][col + 1];
                    }
                }

                return orig;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Well, You're gonna have to give this another Select Statement Try  \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
                return null;
            }
        }

        private bool[] chkChecked()
        {
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

            return tempLogic;
        }
        private DataTable getValues(bool[] chkItems )
        {
            DataTable chartTable = new DataTable();
            string column = "Temperature-";
            for (int i = 0; i < chkItems.Length; i++)
            {
                if (chkItems[i] == true)
                {
                    if (chartTable.Columns.Count < 1)
                    {
                        
                        string y = column + (i + 1).ToString();
                        chart1.Series.Add(y);
                        chart1.Series[y].XValueType = ChartValueType.DateTime;
                        chart1.Series[y].ChartType = SeriesChartType.Line;
                        chart1.Series[y].XValueMember = "ReadDate";
                        chart1.Series[y].YValueMembers = y;
                        chartTable = get(strSelectQuery1 + (i + 1).ToString());
                        chartTable.Columns["SensorVal"].ColumnName = column + (i + 1).ToString();

                    }
                    
                    else
                    {
                        string x = column + (i + 1).ToString();
                        chart1.Series.Add(x);
                        chart1.Series[x].XValueType = ChartValueType.DateTime;
                        chart1.Series[x].ChartType = SeriesChartType.Line;
                        chart1.Series[x].XValueMember = "ReadDate";
                        chart1.Series[x].YValueMembers = x;
                        chartTable = dataMerge(chartTable, (get(strSelectQuery1 + (i + 1).ToString())), i);
                    }
                    //MessageBox.Show(strSelectQuery1 + (i + 1).ToString() + ";");
                    
                }
            }

            return chartTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            chart1.Series.Add("Temperature1");
            chart1.Series["Temperature1"].XValueMember = "ReadDate";
            chart1.Series["Temperature1"].YValueMembers = "SensorVal";
            chart1.Series["Temperature1"].XValueType = ChartValueType.DateTime;
            chart1.Series["Temperature1"].ChartType = SeriesChartType.Line;
            
            chart1.Series.Add("Humidity1");
            chart1.Series["Humidity1"].XValueMember = "ReadDate";
            chart1.Series["Humidity1"].YValueMembers = "SensorVal2";
            chart1.Series["Humidity1"].XValueType = ChartValueType.DateTime;
            chart1.Series["Humidity1"].ChartType = SeriesChartType.Line;
           // */
            DataTable forChart = new DataTable();
            forChart = getValues(chkChecked());
            chart1.DataSource = forChart;
            chart1.DataBind();
        }

        private void Chart_Load_1(object sender, EventArgs e)
        {

        }
    }
}
/*
protected void Button1_Click(object sender, EventArgs e)
{
    //private DateTime dog = Convert.ToDateTime("2017/01/06 15:00:40.6849066");
    //private DateTime cat = Convert.ToDateTime("2017/01/12 23:59:40.0000000");

    string start = Start_YearDrop.SelectedItem.ToString() + "/" + Start_MonthDrop.SelectedItem.ToString() + "/" + Start_DayDrop.SelectedItem.ToString() + " " + Start_HourDrop.SelectedItem.ToString() + ":00:00.000000 ";
    string end = End_YearDrop.SelectedItem.ToString() + "/" + End_MonthDrop.SelectedItem.ToString() + "/" + End_DayDrop.SelectedItem.ToString() + " " + End_HourDrop.SelectedItem.ToString() + ":00:00.000000 ";
    // Label1.Text = start;

    DateTime dog = Convert.ToDateTime(start);
    DateTime cat = Convert.ToDateTime(end);

    Label1.Text = start + " and " + end;
    string _strQuery = "Select * From Stuff where Date > '" + dog + "' and Date < '" + cat + "'";

    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TemperatureLogsConnectionString"].ConnectionString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(_strQuery, conn))
        {
            SqlDataReader rdr = cmd.ExecuteReader();
            Chart01.DataSource = rdr;
            Chart01.DataBind();
        }
    }
}


        <asp:Chart ID="Chart01" runat="server" CssClass="table   table-condensed table-responsive" Height="500px" TextAntiAliasingQuality="High" Width="1200px" BackColor="#99ffcc" >
    <series>
        <asp:Series Name="Series1" ChartType="Line" XValueMember="Date" YValueMembers="Temp1" Color="#3333cc" LegendText="Inside Temp"></asp:Series>
         <asp:Series Name="Series2" ChartType="Line" XValueMember="Date" YValueMembers="Temp2" Color="#cc3399" LegendText="Ouside Temp" ></asp:Series>
        <asp:Series Name="Series3" ChartType="Line" XValueMember="Date" YValueMembers="Hum1" Color="#00cc00" LegendText="Outside Humidity"></asp:Series>
         <asp:Series Name="Series4" ChartType="Line" XValueMember="Date" YValueMembers="Hum4" Color="#ff9900" LegendText="Inside Humidity" XValueType="DateTime" ></asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1">
            <AxisX IntervalAutoMode="VariableCount" IntervalOffsetType="Seconds" IntervalType="Seconds">
            </AxisX>
        </asp:ChartArea>
    </chartareas>
     <Legends>
         <asp:Legend Alignment="Center" IsDockedInsideChartArea="False" LegendStyle="Column" Name="Legend1">
      </asp:Legend>
            </Legends>
</asp:Chart>


*/
