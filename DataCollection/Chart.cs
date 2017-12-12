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
        private string strSelectQuery1 = "SELECT ReadDate, SensorVal FROM S_Data where SensorID = 1;";
        private string strSelectQuery2 = "SELECT ReadDate, SensorVal FROM S_Data where SensorID = 18;";
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


        public DataTable dataRead()
        {
            try
            {
                DataTable result1 = new DataTable();
                DataTable result2 = new DataTable();
                using (SqlConnection conn2 = new SqlConnection(connectionString))
                {
                    conn2.Open();
                    using (SqlCommand cmd = new SqlCommand(strSelectQuery1, conn2))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        result1.Load(rdr);
                    }
                }

                using (SqlConnection conn2 = new SqlConnection(connectionString))
                {
                    conn2.Open();
                    using (SqlCommand cmd = new SqlCommand(strSelectQuery2, conn2))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        result2.Load(rdr);
                    }
                }

                result1.Columns.Add(new DataColumn("SensorVal2", typeof(float)));
                //result2.Columns["SensorVal"].ColumnName = "SensorVal2";

                for (int i = 0; i < result1.Rows.Count; i++)
                {
                    result1.Rows[i][2] = result2.Rows[i][1];
                }

                return result1;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Well, You're gonna have to give this another Select Statement Try  \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            DataTable forChart = new DataTable();
            forChart = dataRead();
            chart1.DataSource = forChart;
            chart1.DataBind();
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
