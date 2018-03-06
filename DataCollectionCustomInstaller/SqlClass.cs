using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollectionCustomInstaller
{
    public class SqlClass
    // database=; 
    {
        string connectionString = "Server={0}; Integrated security=true; ";

        public string make = "C:\\Data\\CreateDataCollection.sql";
        public string createMainTable = "C:\\Data\\MakeTable.sql";
        public string createS_List = "C:\\Data\\makeS_List.sql";

        public SqlClass()
        {
        }

        public string GetString(string path)
        {

            string content;
            using (StreamReader reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }



        public void DoIt(string nonQuery, string instance)
        {
            connectionString = string.Format(connectionString, instance);
            MessageBox.Show(connectionString);
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(nonQuery, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


    }
}
