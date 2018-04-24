﻿using System.Collections.Generic;
using System.IO.Ports;
using System.Management;

namespace DataCollection
{
    class Crystal_LCD
    {

        SerialPort com = new SerialPort();      // comport object used when this class is instantiated.
        string portName = null;                 // backing field for PortName 
        bool isPresent = false;                 // ensures consumers of this class that a port used by a Crystalfonz LCD is discovered.
        public Crystal_LCD()
        {
           portName = findDeviceComPort();      // determine if a crystalfontz device is present at the time of instamtioation.
        }
        /// <summary>
        /// If true, indicates the presence of a crystalfontz lcd device.
        /// </summary>
        public bool IsPresent {
            get
            {
                return isPresent;
            }
        }
        /// <summary>
        /// Contails the name of the port used by the crystalfontz lcd display
        /// </summary>
        public string PortName
        {
            get
            {
                return portName;
            }
        }
        /// <summary>
        /// This Method should be called only after confirming the "IsPresent" proprty is true.
        /// 
        /// </summary>
        /// <returns>Returns true if port was opened successfully.</returns>
        public bool Open()
        {
            if (PortName != null)
            {
                com.PortName = PortName;
                com.BaudRate = 19200;
                com.DataBits = 8;
                com.Parity = Parity.None;
                com.StopBits = StopBits.Two;
                if (com.IsOpen != true)
                {
                    com.Open();
                }
            }

            if (com.IsOpen)
            {
                SendData(0x0c);         // Form-Feed (Clear Display)
                SendData(0x04);         // Hide Cursor
                SendData(0x18);         // Word wrap Off.  (otherwise there is a Carraige return as soon as you reach 20 charcters)
                SendText("Display Ready");
                return true;
            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// This Method is used for sending text to the Crystalfontz lcd display.   
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// <summary>
        /// This method is used for sending commands to the Crystalfontz LCD Display (ex.  "Word Wrap-OFF"= 0x0c)
        /// </summary>
        /// <param name="data">Takes a byte of data, but thr SerialPort class only takes a method that takes
        /// byte[]'s.   So there is a conversion of sorts inside this method.</param>
        /// <returns></returns>
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
        /// <summary>
        /// This method takes a list<Temp<HumDew>.   It then extracts the data as a string[] 
        /// and calls the sendText method.  
        /// </summary>
        /// <param name="readings"></param>
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
            DisplayText(tempHums);
        }
        /// <summary>
        /// This method takes a string[4] as a parameter and puts each sepate string into the proper line 
        /// on the 4 line display.
        /// </summary>
        /// <param name="tempHums">Contains a string array with all the temperature and humidity data from all four sensors.</param>
        private void DisplayText(string[] tempHums)
        {
            SendData(0x0c);         // Turn word Wrapp off
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


        /// <summary>
        /// Thimethod returns a string with the com port that the Crystalfontz device is assigned on the local machine.
        /// </summary>
        /// <returns>Returns a single string with the Com Port Used by the Crystalfontz LCD Display.</returns>
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
                    isPresent = true;
                }
            }
            return result;
        }
        /// <summary>
        /// This method returns a List<string> of all com port devices on the local machine.   
        /// </summary>
        /// <returns=List>Returns a List of type string with all com ports.</returns>
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
