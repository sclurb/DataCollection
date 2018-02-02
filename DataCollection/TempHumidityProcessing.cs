using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollection
{
    public class TempHumidityProcessing
    {
        private TempHumidCalculations calcs = new TempHumidCalculations();
        private const double t1 = .01;
        private const double t2 = .00008;
        public TempHumidityProcessing()
        {
            
        }

        // This method converts the input parameter byte[] by combining two separate bytes of the array into an array of doubles.
        public double[] ArrangeTemps(byte[] rawTemps)
        {
            if (rawTemps.Length != 36)  // if there is a formatting error or maybe the comport only returns a partial byte[], clear rxdata and return
            {
                return null;
            }
            double[] arrangedValues = new double[16];
            for (int x = 0; x < 16; x++)
            {
                arrangedValues[x] = (rawTemps[(x * 2) + 2] * 256) + rawTemps[(x * 2) + 3];
            }
            return arrangedValues;
        }

        public double[] ProcTemps(double[] temperatureArray)
        {
            for (int x = 0; x < 16; x++)
            {
                if (temperatureArray[x] == 0xfff)
                {
                    temperatureArray[x] = 0;
                }
                else
                {
                    temperatureArray[x] = calcs.fahrenheit(temperatureArray[x]);
                }
            }
            return temperatureArray;
        }

        public double[] ArrangeHumids(byte[] rawHumps)
        {
            double[] arrangedValues = new double[8];
            for (int x = 0; x < 8; x++)
            {
                arrangedValues[x] = (rawHumps[(x * 2) + 2] * 256) + rawHumps[(x * 2) + 3];
            }
            return arrangedValues;
        }




    }
}
