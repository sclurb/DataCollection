using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTD2XX_NET;
using System.Windows.Forms;

namespace DataCollectionCustomInstaller
{
    class FT232
    {
        public SerialPort comm = new SerialPort();

        private string comPortNum;
        public FT232()
        {

        }
        public string ComPortNum
        {
            get
            {
                return comPortNum;
            }
            set
            {
                comPortNum = value;
            }
        }


        /// <summary>
        /// Gets called by InitFTDI to set port parametrs.
        /// </summary>
        public void PortSetUp()
        {
            comm.PortName = comPortNum;
            comm.BaudRate = 9600;
            comm.DataBits = 8;
            comm.Parity = Parity.None;
            comm.StopBits = StopBits.One;
            comm.Open();
        }
    }
}
