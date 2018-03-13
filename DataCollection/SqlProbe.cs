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

        public SqlProbe()
        {
            string x = OSVersionInfo.Name;
            if (x == "Windows 7")
            {
                instanceCollection = Go();
            }
            if (x == "Windows 10")
            {
                instanceCollection =gather();
            }

            instanceName = Select(instanceCollection);
        }

        public string InstanceName
            {
            get { return instanceName; }
                
            }

        public string Select(List<string> str)
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

        public bool Sql(string server)
        {
            try
            {
                DataTable result = new DataTable();
                string connectionString = String.Format("Server={0}; Database=; Integrated Security=True;", server);
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

        public string Truncate(string s, int maxLength)
        {
            return s != null && s.Length > maxLength ? s.Substring(0, maxLength) : s;
        }


        public List<string> gather()
        {
            List<string> floyd = new List<string>();
            DataTable dt = SmoApplication.EnumAvailableSqlServers(true);

            foreach (DataRow a in dt.Rows)
            {
                floyd.Add(a[0].ToString());
            }
            return floyd;
        }

        public List<string> Go()
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
    }
}
