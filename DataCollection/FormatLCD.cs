using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionCustomInstaller
{
    public class FormatLCD
    {
        public FormatLCD()
        {

        }


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

        public byte[] FormatData(string[] tempHums)
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
            byte[] masterBuffer = new byte[masterByte.Count];

            masterBuffer = masterByte.ToArray();


            return masterBuffer;
        }
    }

}
