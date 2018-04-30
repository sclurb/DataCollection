using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataCollectionCustomInstaller
{
    public class SqlProbe
    {
        private string temp;
        //private string p = @"Bobzilla_16\SqlExpress";
        private string standard = "Microsoft SQL Server 2012";
        private string osVersion;
        public List<string> InstanceCollection = new List<string>();

        public string OSVersion
        {
            get { return osVersion; }
            set { osVersion = GetVersion(); }
        }

        public string Temp
        {
            get { return temp; }
        }


        public SqlProbe()
        {
            osVersion = GetVersion();

            InstanceCollection = GetInstanceVer10();

        }
        /// <summary>
        /// Select will look though the list of sql Instances and select 
        /// the one for SQL Server 2012.   It will then return the name of the instance
        /// </summary>
        /// <param name="str">Takes a list type string with all the instances listed</param>
        /// <returns></returns>
        public string Select(List<string> str)
        {
            string p = "2012";

            for (int i = 0; i < str.Count; i++)
            {
                if (Sql(str[i]))
                {
                    if (str[i].Contains(p))
                    {
                        return str[i];
                    }
                }
            }
            return "No Match!";
        }
        /// <summary>
        /// This method Takes a string and returns true if that string contains
        /// the name of a SQL Server Express 2012
        /// </summary>
        /// <param name="server">name of the server to be queried for sql server 2012</param>
        /// <returns></returns>
        public bool Sql(string server)
        {
            try
            {
                DataTable result = new DataTable();
                string connectionString = String.Format("Server={0}; Database=; Integrated Security=True;", server);
                //int x = 0;
                string s = " ";
                string nonQuery = "Select @@version";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(nonQuery, conn))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        result.Load(rdr);
                    }
                    s = result.Rows[0]["Column1"].ToString();
                }
                s = Truncate(s, 25);
                temp = s;
                if (s.Equals(standard))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        /// <summary>
        /// truncates a string cotaining the version of SQL Server
        /// </summary>
        /// <param name="s">String to be truncated</param>
        /// <param name="maxLength">Sets the length at which you would like the string to be.</param>
        /// <returns></returns>
        public string Truncate(string s, int maxLength)
        {
            return s != null && s.Length > maxLength ? s.Substring(0, maxLength) : s;
        }
        /*
        /// <summary>
        /// This Method works fasres on windows 7 OS.   It will return a list with the instance names 
        /// of sql server
        /// </summary>
        /// <returns>List of type string with all the instances of sql server on local machine</returns>
        public List<string> GetInstanceVer7()
        {
            List<string> floyd = new List<string>();
            DataTable dt = SmoApplication.EnumAvailableSqlServers(true);

            foreach (DataRow a in dt.Rows)
            {
                floyd.Add(a[0].ToString());
            }
            return floyd;
        }
        */
        /// <summary>
        /// This method works best for windows 10 OS.   It will return a list with the instance names 
        /// of sql server
        /// </summary>
        /// <returns>List of type string with all the instances of sql server on local machine</returns>
        public List<string> GetInstanceVer10()
        {
            List<string> goober = new List<string>();
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        goober.Add(Environment.MachineName + "\\" + instanceName);
                    }
                }
            }
            return goober;
        }
        /// <summary>
        /// Returns a string with the type of OS system installe don local machine
        /// </summary>
        /// <returns>String with the tpe of OS on local machine.</returns>
        private string GetVersion()
        {
            string result = null;
            result = JCS.OSVersionInfo.Name;
            return result;
        }
    }
}
