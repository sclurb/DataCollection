using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataCollection
{
    public class numCrunch
    {
        public numCrunch()
        {

            if (DataCollection.set)
            {
                connectionString = Properties.Settings.Default.ConnectionString;
                MessageBox.Show("Already Saved " + Properties.Settings.Default.Attached.ToString());
            }
            else
            {
                connectionString = GetInstance();
                Properties.Settings.Default.ConnectionString = connectionString;
                Properties.Settings.Default.Attached = true;
                Properties.Settings.Default.Save();
                DataCollection.set = true;
               // MessageBox.Show("This Time " + Properties.Settings.Default.Attached.ToString() + "   " + Properties.Settings.Default.ConnectionString);
                MessageBox.Show("This Time " + DataCollection.set.ToString());
            }
        }

        SqlProbe chk = new SqlProbe();
        private string configQuery =  "select * from S_List";




        
        private string connectionString;


        // Insert S_Data into DataCollection Database
        private string strSelectQuery = "SELECT Enable FROM S_List";

        private string Insert2 = "INSERT INTO MainData (Temp1, Temp2, Temp3, Temp4, Temp5, Temp6, Temp7, Temp8, Temp9, " +
            " Temp10, Temp11, Temp12, Temp13, Temp14, Temp15, Temp16, Temph1, Hum1, Temph2, Hum2, Temph3, Hum3, Temph4, Hum4, " +
            "Volts1, Volts2, Volts3, Volts4, Volts5, Volts6, Volts7, Volts8, ReadDate) VALUES (";
        
        public string GetInstance()
        {
            string inst = chk.InstanceName;
            string conn = "data source={0}; " +
                                       "initial catalog = DataCollection;" +
                                    "integrated security = True;" +
                                    "AttachDBFilename=C:\\Data\\DataCollection.mdf;" +
                                    "MultipleActiveResultSets=True;";
            string result = string.Format(conn, inst);
            return result;
        }
        

        // This method inserts datarows into the MainData table in the database
        public string insert(double[] values)
        {
            string y;
            DateTime x = DateTime.Now;
            string z = "'" + x.ToString() + "')";
            try
            {
                 y = Insert2 + values[0] + "," + values[1] + "," + values[2] + "," + values[3] + "," + values[4] + "," 
                     + values[5] + "," + values[6] + "," + values[7] + "," + values[8] + "," +
                     values[9] + "," + values[10] + "," + values[11] + "," + values[12] + "," + values[13] + "," + values[14] + "," + values[15] + "," + values[16] + "," +
                     values[17] + "," + values[18] + "," + values[19] + "," + values[20] + "," + values[21] + "," + values[22] + "," + values[23] + "," + values[24] + "," +
                     values[25] + "," + values[26] + "," + values[27] + "," + values[28] + "," + values[29] + "," + values[30] + "," + values[31] + "," + z ;

                using (SqlConnection conn1 = new SqlConnection(connectionString))
                {
                    conn1.Open();
                    using (SqlCommand cmd = new SqlCommand(y, conn1))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                    }
                }
                return y;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Had some trouble inserting data into MainData table \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
                return "failure";
            }
        }
        // This method returns an array of bools which are the Enable column of the S_List table in the Database
        public bool[] dataEnable()
        {
            bool [] switches = new bool[32];
            try
            {
                DataTable result = new DataTable();
                using (SqlConnection conn2 = new SqlConnection(connectionString))
                {
                    conn2.Open();
                    using (SqlCommand cmd = new SqlCommand(strSelectQuery, conn2))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        result.Load(rdr);
                        int count = result.Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            switches[i] = (bool)result.Rows[i][0];
                        }  
                    }
                }
                return switches;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Well, You're gonna have to give this another Select Statement Try  \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
                return null;
            }
        }
        // This method reads the database for the chart form
        public DataTable dataRead(string query)
        {
            try
            {
                DataTable result = new DataTable();
                using (SqlConnection conn2 = new SqlConnection(connectionString))
                {
                    conn2.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn2))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        result.Load(rdr);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failure reading the database to load all the parameters for the config form \r \r"
                               + "Here's Why.... \r \r" + e.ToString());
                return null;
            }

        }

        //  This method is called to load parameter values for the config form
        public DataTable configLoad()
        {
            try
            {
                DataTable result = new DataTable();
                using (SqlConnection conn1 = new SqlConnection(connectionString))
                {
                    conn1.Open();
                    using (SqlCommand cmd = new SqlCommand(configQuery, conn1))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        result.Load(rdr);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failure reading the database to load all the parameters for the config form \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
                return null;
            }
        }

        // This method updates the S_List Table in the database
        public void updateS_List(string query)
        {
            using (SqlConnection conn1 = new SqlConnection(connectionString))
            {
                conn1.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn1))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                }
            }
        }


    }

}
