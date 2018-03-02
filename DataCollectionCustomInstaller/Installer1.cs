using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Security.AccessControl;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DataCollectionCustomInstaller
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {

        //string create;
        //string connectionString = "Server=.\\SQLExpress; Integrated security=true; database=master";
        //string make = "C:\\Data\\DataCollection-2.sql";
        //string createMainTable = "C:\\Data\\MakeTable.sql";
        //string createS_List = "C:\\Data\\makeS_List.sql";
        public Installer1()
        {
            InitializeComponent();

            if (SetAcl() == true)
            {
                Console.WriteLine("Yay");
            }
            else
            {
                Console.WriteLine("Awww shucks");
            }

            //MakeDB();
        }

        static bool SetAcl()
        {
            FileSystemRights Rights = (FileSystemRights)0;
            Rights = FileSystemRights.FullControl;

            // *** Add Access Rule to the actual directory itself
            FileSystemAccessRule AccessRule = new FileSystemAccessRule("Users", Rights,
                                        InheritanceFlags.None,
                                        PropagationFlags.NoPropagateInherit,
                                        AccessControlType.Allow);

            DirectoryInfo Info = new DirectoryInfo(@"C:\Data");
            DirectorySecurity Security = Info.GetAccessControl(AccessControlSections.Access);

            bool Result = false;
            Security.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);

            if (!Result)
                return false;

            // *** Always allow objects to inherit on a directory
            InheritanceFlags iFlags = InheritanceFlags.ObjectInherit;
            iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

            // *** Add Access rule for the inheritance
            AccessRule = new FileSystemAccessRule("Users", Rights,
                                        iFlags,
                                        PropagationFlags.InheritOnly,
                                        AccessControlType.Allow);
            Result = false;
            Security.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);

            if (!Result)
                return false;

            Info.SetAccessControl(Security);

            return true;
        }
        /*
        private void MakeDB()
        {
            //SqlClass makeDB = new SqlClass();
            create = GetString(make);
            MessageBox.Show(create);
            DoIt(create);
            //create = makeDB.GetString(createMainTable);
            //makeDB.DoIt(create);
           // create = makeDB.GetString(createS_List);
            //makeDB.DoIt(create);

        }


        private string GetString(string path)
        {
            string content;
            using (StreamReader reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }



        private void DoIt(string nonQuery)
        {
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
        */

    }
}
