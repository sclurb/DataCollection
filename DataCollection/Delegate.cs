using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionCustomInstaller
{
    public delegate void UpdateLabels();
    public delegate void AdjustLCD(AdjustEventArgs e);


    public class AdjustEventArgs : EventArgs
    {
        private byte cmd;
        private byte data;

        public byte Cmd
        {
            get
            {
                return cmd;
            }
            set
            {
                cmd = value;
            }
        }
        public byte Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }

        }

    }
}
