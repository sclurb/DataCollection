using JCS;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollection
{
    public class  SqlProbe
    {
        List<string> instanceCollection = new List<string>();
        private string standard = "Microsoft SQL Server 2012";
        string instanceName;
        string versionName;

        public SqlProbe()
        {
            versionName = OSVersionInfo.Name;
            GetVersion();
        }

        public string InstanceName
            {
            get { return instanceName; }
                
            }
        public string VersionName
        {
            get
            {
                return versionName;
            }
        }

        private string GetVersion()
        {
            if (VersionName == "Windows 10")
            {
                instanceCollection = gather();
            }
            if (VersionName == "Windows 7")
            {
                instanceCollection = Go();
            }

            string result = Select(instanceCollection);
            instanceName = result;
            return result;
        }

        private string Select(List<string> str)
        {
            string p = null;
            foreach(string a in str)
            {
                if (Sql(a))
                {
                    p = a;
                }
            }
            if (p != null)
            {
                return p;
            }
            else
            {
                return "No Match!";
            }
        }

        private bool Sql(string server)
        {
            try
            {
                DataTable result = new DataTable();
                string connectionString = String.Format("Server={0}; Database=; Integrated Security=True;", server);
                string s = " ";
                string query = "Select @@version";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        result.Load(rdr);
                    }
                    s = result.Rows[0]["Column1"].ToString();
                }
                s = Truncate(s, 25);
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
                MessageBox.Show("Bad SQL Query in SqlProbe- " + e.ToString());
                return false;
            }
        }

        // This method removes characters after the name of the instance
        private string Truncate(string s, int maxLength)
        {
            return s != null && s.Length > maxLength ? s.Substring(0, maxLength) : s;
        }

        // This method returns a List<string> with all the instances of SQL Server on the host computer.
        // This method is called if the computer's OS is Windows 10.
        private List<string> gather()
        {
            List<string> floyd = new List<string>();
            DataTable dt = SmoApplication.EnumAvailableSqlServers(true);

            foreach (DataRow a in dt.Rows)
            {
                floyd.Add(a[0].ToString());
            }
            return floyd;
        }

        // This method returns a List<string> with all the instances of SQL Server on the host computer.
        // This method is called if the computer's OS is Windows 7.
        private List<string> Go()
        {
            List<string> goober = new List<string>();
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instName in instanceKey.GetValueNames())
                    {
                        goober.Add(Environment.MachineName + "\\" + instName);
                    }
                }
            }
            return goober;
        }
    }
}
