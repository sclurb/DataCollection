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

        string create;
        string connectionString = "Server=.\\SQLExpress; Integrated security=true; database=master";
        List<string> instanceCollection = new List<string>();
        //SqlProbe doom = new SqlProbe();
        string instanceName;

        public Installer1()
        {
            InitializeComponent();

            if (SetAcl() == true)
            { 
                /*
                string x = OSVersionInfo.Name;
                if (x == "Windows 7")
                {
                    instanceCollection = doom.Go();
                }
                if (x == "Windows 10")
                {
                    instanceCollection = doom.gather();
                }
                
                instanceName = doom.Select(instanceCollection);
                //MessageBox.Show(instanceName);
                //MakeDB();
                */
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
            SqlClass makeDB = new SqlClass();
            create = makeDB.GetString(makeDB.make);
            makeDB.DoIt(create, instanceName);
            create = makeDB.GetString(makeDB.createMainTable);
            makeDB.DoIt(create, instanceName);
            create = makeDB.GetString(makeDB.createS_List);
            makeDB.DoIt(create, instanceName);
        }


 

    }
}
