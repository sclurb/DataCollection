using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Windows.Forms;

namespace DataCollection
{
    class Crystal_LCD
    {

        SerialPort com = new SerialPort();
        public Crystal_LCD()
        {
           
        }
        public string PortName { get { return findDeviceComPort(); } }

        public bool Open()
        {
            com.PortName = PortName;
            com.BaudRate = 19200;
            com.DataBits = 8;
            com.Parity = Parity.None;
            com.StopBits = StopBits.Two;
            com.Open();
            if (com.IsOpen)
            {
                SendData(0x0c);
                SendData(0x04);
                SendData(0x18);
                SendText("Display Ready");
                return true;
            }
            return false;
        }

        public bool SendText(string text)
        {
            if (com.IsOpen)
            {
                com.Write(text);
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool SendData(byte data)
        {
            if (com.IsOpen)
            {
                byte[] cmd = new byte[1];
                cmd[0] = data;
                com.Write(cmd, 0, 1);
                return true;
            }
            else
            {
                return false;
            }

        }

        public void ExtractStrings(List<TempHumDew> readings)
        {
            string[] tempHums = new string[8];
            tempHums[0] = readings[0].TempF.ToString("0.0") + "F";
            tempHums[1] = readings[0].RHT.ToString("0.0") + "%RH";
            tempHums[2] = readings[1].TempF.ToString("0.0") + "F";
            tempHums[3] = readings[1].RHT.ToString("0.0") + "%RH";
            tempHums[4] = readings[2].TempF.ToString("0.0") + "F";
            tempHums[5] = readings[2].RHT.ToString("0.0") + "%RH";
            tempHums[6] = readings[3].TempF.ToString("0.0") + "F";
            tempHums[7] = readings[3].RHT.ToString("0.0") + "%RH";
            //return tempHums;
            formatDisplayText(tempHums);
        }

        private void formatDisplayText(string[] tempHums)
        {
            SendData(0x0c);
            string line1 = "1 T " + tempHums[0] + " H " + tempHums[1];
            string line2 = "2 T " + tempHums[2] + " H " + tempHums[3];
            string line3 = "3 T " + tempHums[4] + " H " + tempHums[5];
            string line4 = "4 T " + tempHums[6] + " H " + tempHums[7];

            
            SendText(line1);

            SendData(0x0a);
            SendData(0x0d);
            SendText(line2);
            SendData(0x0a);
            SendData(0x0d);
            SendText(line3);
            SendData(0x0a);
            SendData(0x0d);
            SendText(line4);


        }



        private string findDeviceComPort()
        {
            List<string> deviceInfo = getPortNames();
            int z = 0; 
            string searchString1 = "Crystalfontz CFA634-USB";
            string searchString2 = "com";
            string result = null;
            foreach (string comListItem in deviceInfo)
            {
                if (comListItem.Contains(searchString1))
                {
                    string blah = comListItem.ToLower();
                    z = blah.IndexOf(searchString2);
                    result = blah.Substring(z, 5);
                }
                if (result != null)
                {
                    if (result.Contains(")"))
                    {
                        z = result.IndexOf(")");
                        result = result.Substring(0, (z - 1));
                    }
                }

 

            }
            return result;
        }

        private List<string> getPortNames()
        {
            List<string> portDeviceInfo = new List<string>();
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("root\\CIMV2",
                     "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
            ManagementObjectCollection PortInfo = objOSDetails.Get();
            foreach (ManagementObject mo in PortInfo)
            {
                portDeviceInfo.Add((string)mo.GetPropertyValue("Name"));
            }
            return portDeviceInfo;
        }
    }
}
