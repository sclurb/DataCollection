using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollection
{
    class numCrunch
    {
        private string connectionString = "data source = (localdb)\\MSSQLLocalDB;" +
                                    "initial catalog = DataCollection;" +
                                    "integrated security = True;" +
                                    "MultipleActiveResultSets=True;App=EntityFramework";
        private string strInsertQuery = "INSERT INTO S_Data (ReadDate, SensorID, SensorVal) VALUES ('{0}', {1}, {2} )";
        private string strSelectQuery = "SELECT Enable FROM S_List";

        private void build()
        {
            try
            {
                DataTable result = new DataTable();
                using (SqlConnection conn1 = new SqlConnection(connectionString))
                {
                    conn1.Open();
                    using (SqlCommand cmd = new SqlCommand(strInsertQuery, conn1))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        result.Load(rdr);
                        int count = result.Rows.Count;

                        for (int i = 0; i < count; i++)
                        {

                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public string insert(int sensorID, double sensorVal)
        {
            string y;
            DateTime x = DateTime.Now ;
            try
            {
                y = String.Format(strInsertQuery, x.ToString(), sensorID, sensorVal);
                
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
                System.Windows.Forms.MessageBox.Show("Well, You're gonna have to give this another Insert Try from numCrunch \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
                return "failure";
            }
        }

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
                           // System.Windows.Forms.MessageBox.Show(strSelectQuery + "   " + (bool)result.Rows[i][0]);
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




    }
}
