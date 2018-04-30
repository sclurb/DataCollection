using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Security.AccessControl;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
//using DataCollection;
//using JCS;

namespace DataCollectionCustomInstaller
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {

        //string create;
        string connectionString = "data source = {0}; initial catalog=DataCollection; Integrated Security=true; AttachDBfilename=C:\\Data\\DataCollection.mdf; MultipleActiveResultSets=True; ";
        //List<string> instanceCollection = new List<string>();
        SqlProbe probe = new SqlProbe();


        public Installer1()
        {
            InitializeComponent();

            if (SetAcl() == true)
            {
                connectionString = string.Format(connectionString, probe.Select(probe.InstanceCollection));
                if (File.Exists("C:\\Data\\connString.txt"))
                {
                    File.Delete("C:\\Data\\connString.txt");
                }
                using (var writer = new StreamWriter("C:\\Data\\connString.txt"))
                {
                    writer.WriteLine(connectionString);
                }

            }
        }

        static bool SetAcl()
        {
            try
            {
                System.IO.Directory.CreateDirectory("C:\\Data");
                
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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }
        
        private void MakeDB()
        {
            /*
            SqlClass makeDB = new SqlClass();
            create = makeDB.GetString(makeDB.make);
            makeDB.DoIt(create, instanceName);
            create = makeDB.GetString(makeDB.createMainTable);
            makeDB.DoIt(create, instanceName);
            create = makeDB.GetString(makeDB.createS_List);
            makeDB.DoIt(create, instanceName);
            */
        }


 

    }
}
