using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionCustomInstaller
{
    /// <summary>
    /// This class formats the data into a byte array that the LCD can take
    /// This class has both data and commands embedded intot eh byte[] that 
    /// gets returned via the FormatData() method
    /// </summary>
    public class FormatLCD
    {

        public FormatLCD()
        {

        }

        /// <summary>
        /// Used to change the cursor position for every update
        /// </summary>
        private byte cursor = 0x00;


        /// <summary>
        /// This method takes a list of TempHumDew type and extracts the readings
        /// into an array of strings to be passed to FormatData()
        /// </summary>
        /// <param name="readings">List of 4 Temperature and Humidity readings</param>
        /// <returns>returns an array of strings to be sent to Formatdata</returns>
        public string[] ExtractStrings(List<TempHumDew> readings)
        {
            string[] tempHums = new string[12];
            tempHums[0] = readings[0].TempF.ToString("0.") + "F";
            tempHums[1] = readings[0].RHT.ToString("0.") + "%RH";
            tempHums[2] = readings[0].Mnemonic;
            tempHums[3] = readings[1].TempF.ToString("0.") + "F";
            tempHums[4] = readings[1].RHT.ToString("0.") + "%RH";
            tempHums[5] = readings[1].Mnemonic;
            tempHums[6] = readings[2].TempF.ToString("0.") + "F";
            tempHums[7] = readings[2].RHT.ToString("0.") + "%RH";
            tempHums[8] = readings[2].Mnemonic;
            tempHums[9] = readings[3].TempF.ToString("0.") + "F";
            tempHums[10] = readings[3].RHT.ToString("0.") + "%RH";
            tempHums[11] = readings[3].Mnemonic;
            return tempHums;

        }
        /// <summary>
        /// This method takes the array of strings and converts each string to a byte[]
        /// </summary>
        /// <param name="tempHums">array of strings each with 4 Temperature/Humidity and Dew point values</param>
        /// <param name="cursor">This input is rfom a local method that will increment from 0 to 3
        /// so that the cursor will appear on a new line every time an updat occurs</param>
        /// <returns>The byte[] has commands and data embedded together which will fir the 
        /// 4 line display perfectly</returns>
        public byte[] FormatData(string[] tempHums, byte cursor)
        {

            byte[] cmd = new byte[2] { 0x0a, 0x0d };
            string line1 = tempHums[0] + " " + tempHums[1] + " " + tempHums[2];
            string line2 = tempHums[3] + " " + tempHums[4] + " " + tempHums[5];
            string line3 = tempHums[6] + " " + tempHums[7] + " " + tempHums[8];
            string line4 = tempHums[9] + " " + tempHums[10] + " " + tempHums[11];

            byte[] buffer1 = System.Text.Encoding.UTF8.GetBytes(line1);
            byte[] buffer2 = System.Text.Encoding.UTF8.GetBytes(line2);
            byte[] buffer3 = System.Text.Encoding.UTF8.GetBytes(line3);
            byte[] buffer4 = System.Text.Encoding.UTF8.GetBytes(line4);

            List<byte> masterByte = new List<byte>();
            masterByte.Add(0x0c);
            masterByte.Add(0x05);
            foreach (byte a in buffer1)
            {
                masterByte.Add(a);
            }
            masterByte.Add(0x0a);
            masterByte.Add(0x0d);
            foreach (byte a in buffer2)
            {
                masterByte.Add(a);
            }
            masterByte.Add(0x0a);
            masterByte.Add(0x0d);
            foreach (byte a in buffer3)
            {
                masterByte.Add(a);
            }
            masterByte.Add(0x0a);
            masterByte.Add(0x0d);
            foreach (byte a in buffer4)
            {
                masterByte.Add(a);
            }
            masterByte.Add(0x11);
            masterByte.Add(0x13);
            masterByte.Add(cursor);
            
            byte[] masterBuffer = new byte[masterByte.Count];

            masterBuffer = masterByte.ToArray();
            return masterBuffer;
        }
        /// <summary>
        /// This method is used to increment the cursor variable
        /// </summary>
        /// <returns>Returns a byte which will be 0x00 to 0x03</returns>
        public byte Cursor()
        {
            cursor++;
            if (cursor == 0x04)
            {
                cursor = 0x00;
            }
            return cursor;
        }

    }

}
