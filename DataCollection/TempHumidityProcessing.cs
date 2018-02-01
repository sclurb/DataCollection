using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollection
{
    public class TempHumidityProcessing
    {
        public TempHumidityProcessing()
        {

        }

        // This method processes the byte[] by combining two separate btytes in the array then applying slope and offset.
        // Finally the new value is placed in a global array that contains the values for all sensors
        public double[] procTemps(byte[] rawTemps)
        {
            if (rawTemps.Length != 36)  // if there is a formatting error or maybe the comport only returns a partial byte[], clear rxdata and return
            {
                rxData.Clear();
                return;
            }
            double a;               // holds the combined bytes from sent data byte array
            double d = 0xfff;       // checks raw data to see if temperature sensor is giving data, maybe it is disconnected

            a = (rawTemps[2] * 256) + rawTemps[3];
            if (a == d) { a = 0; } else { procdValues[0] = fahrenheit(a); }
            a = (rawTemps[4] * 256) + rawTemps[5];
            if (a == d) { a = 0; } else { procdValues[1] = fahrenheit(a); }
            a = (rawTemps[6] * 256) + rawTemps[7];
            if (a == d) { a = 0; } else { procdValues[2] = fahrenheit(a); }
            a = (rawTemps[8] * 256) + rawTemps[9];
            if (a == d) { a = 0; } else { procdValues[3] = fahrenheit(a); }
            a = (rawTemps[10] * 256) + rawTemps[11];
            if (a == d) { a = 0; } else { procdValues[4] = fahrenheit(a); }
            a = (rawTemps[12] * 256) + rawTemps[13];
            if (a == d) { a = 0; } else { procdValues[5] = fahrenheit(a); }
            a = (rawTemps[14] * 256) + rawTemps[15];
            if (a == d) { a = 0; } else { procdValues[6] = fahrenheit(a); }
            a = (rawTemps[16] * 256) + rawTemps[17];
            if (a == d) { a = 0; } else { procdValues[7] = fahrenheit(a); }
            a = (rawTemps[18] * 256) + rawTemps[19];
            if (a == d) { a = 0; } else { procdValues[8] = fahrenheit(a); }
            a = (rawTemps[20] * 256) + rawTemps[21];
            if (a == d) { a = 0; } else { procdValues[9] = fahrenheit(a); }
            a = (rawTemps[22] * 256) + rawTemps[23];
            if (a == d) { a = 0; } else { procdValues[10] = fahrenheit(a); }
            a = (rawTemps[24] * 256) + rawTemps[25];
            if (a == d) { a = 0; } else { procdValues[11] = fahrenheit(a); }
            a = (rawTemps[26] * 256) + rawTemps[27];
            if (a == d) { a = 0; } else { procdValues[12] = fahrenheit(a); }
            a = (rawTemps[28] * 256) + rawTemps[29];
            if (a == d) { a = 0; } else { procdValues[13] = fahrenheit(a); }
            a = (rawTemps[30] * 256) + rawTemps[31];
            if (a == d) { a = 0; } else { procdValues[14] = fahrenheit(a); }
            a = (rawTemps[32] * 256) + rawTemps[33];
            if (a == d) { a = 0; } else { procdValues[15] = fahrenheit(a); }

            //fillTemps(procdValues);
        }

        public double[] procHumps(byte[] rawHumps)
        {
            if (rawHumps.Length != 20)
            {
                rxData.Clear();
                return;
            }


            double Hum1 = (rawHumps[2] * 256) + rawHumps[3];
            double Temp1 = (rawHumps[4] * 256) + rawHumps[5];
            double Hum2 = (rawHumps[6] * 256) + rawHumps[7];
            double Temp2 = (rawHumps[8] * 256) + rawHumps[9];
            double Hum3 = (rawHumps[10] * 256) + rawHumps[11];
            double Temp3 = (rawHumps[12] * 256) + rawHumps[13];
            double Hum4 = (rawHumps[14] * 256) + rawHumps[15];
            double Temp4 = (rawHumps[16] * 256) + rawHumps[17];

            double TempC1 = procTempsC(Temp1);
            double TempC2 = procTempsC(Temp2);
            double TempC3 = procTempsC(Temp3);
            double TempC4 = procTempsC(Temp4);
            double RH1 = procHumsh(Hum1);
            double RH2 = procHumsh(Hum2);
            double RH3 = procHumsh(Hum3);
            double RH4 = procHumsh(Hum4);
            double RHt1 = (TempC1 - 25) * (t1 + (t2 * Hum1)) + RH1;
            double RHt2 = (TempC2 - 25) * (t1 + (t2 * Hum2)) + RH2;
            double RHt3 = (TempC3 - 25) * (t1 + (t2 * Hum3)) + RH3;
            double RHt4 = (TempC4 - 25) * (t1 + (t2 * Hum4)) + RH4;

            // These lines first check to see if a sensor is giving readings, if it is not, zero is the value placed in the procdVales array
            if (Temp1 == 0xf4f4) { procdValues[16] = 0; } else { procdValues[16] = Math.Round(procTempsF(TempC1), 2); }
            if (Hum1 == 0xf4f4) { procdValues[17] = 0; } else { procdValues[17] = Math.Round(RHt1, 2); }
            if (Temp2 == 0xf4f4) { procdValues[18] = 0; } else { procdValues[18] = Math.Round(procTempsF(TempC2), 2); }
            if (Hum2 == 0xf4f4) { procdValues[19] = 0; } else { procdValues[19] = Math.Round(RHt2, 2); }
            if (Temp3 == 0xf4f4) { procdValues[20] = 0; } else { procdValues[20] = Math.Round(procTempsF(TempC3), 2); }
            if (Hum3 == 0xf4f4) { procdValues[21] = 0; } else { procdValues[21] = Math.Round(RHt3, 2); }
            if (Temp4 == 0xf4f4) { procdValues[22] = 0; } else { procdValues[22] = Math.Round(procTempsF(TempC4), 2); }
            if (Hum4 == 0xf4f4) { procdValues[23] = 0; } else { procdValues[23] = Math.Round(RHt4, 2); }

            // These lines first check to see if a sensor is attached if it is, the values of humidity and temerature are sent
            // to procDews and that result is put in a separate arrays for dew point only
            if (Hum1 == 0xf4f4) { dews[0] = 0; } else { dews[0] = procDews(RHt1, TempC1); }
            if (Hum2 == 0xf4f4) { dews[1] = 0; } else { dews[1] = procDews(RHt2, TempC2); }
            if (Hum3 == 0xf4f4) { dews[2] = 0; } else { dews[2] = procDews(RHt3, TempC3); }
            if (Hum4 == 0xf4f4) { dews[3] = 0; } else { dews[3] = procDews(RHt4, TempC4); }

            //fillHumps();

        }

        public double[] procAuxs(byte[] rawAuxs)
        {
            if (rawAuxs.Length != 20)
            {
                rxData.Clear();
                return;
            }
            double[] proccessedAuxs = new double[20]
            double a;
            a = (rawAuxs[2] * 256) + rawAuxs[3];
            a = value(a);
            a = calculate(a);
            procdValues[24] = Math.Round(a, 2);
            a = (rawAuxs[4] * 256) + rawAuxs[5];
            a = value(a);
            a = calculate(a);
            procdValues[25] = Math.Round(a, 2);
            a = (rawAuxs[6] * 256) + rawAuxs[7];
            a = value(a);
            a = calculate(a);
            procdValues[26] = Math.Round(a, 2);
            a = (rawAuxs[8] * 256) + rawAuxs[9];
            a = value(a);
            a = calculate(a);
            procdValues[27] = Math.Round(a, 2);
            a = (rawAuxs[10] * 256) + rawAuxs[11];
            a = value(a);
            a = calculate(a);
            procdValues[28] = Math.Round(a, 2);
            a = (rawAuxs[12] * 256) + rawAuxs[13];
            a = value(a);
            a = calculate(a);
            procdValues[29] = Math.Round(a, 2);
            a = (rawAuxs[14] * 256) + rawAuxs[15];
            a = value(a);
            a = calculate(a);
            procdValues[30] = Math.Round(a, 2);
            a = (rawAuxs[16] * 256) + rawAuxs[17];
            a = value(a);
            a = calculate(a);
            procdValues[31] = Math.Round(a, 2);


            //fillAuxs();
        }
    }
}
