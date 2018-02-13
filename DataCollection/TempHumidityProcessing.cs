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
            double[] arrangedValues = new double[16];
            for (int x = 0; x < 16; x++)
            {
                arrangedValues[x] = (rawTemps[(x * 2) + 2] * 256) + rawTemps[(x * 2) + 3];
            }
            return arrangedValues;
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

        public double[] ArrangeAuxs(byte[] rawAuxs)
        {
            double[] arrangedValues = new double[8];
            for (int x = 0; x < 8; x++)
            {
                arrangedValues[x] = (rawAuxs[(x * 2) + 2] * 256) + rawAuxs[(x * 2) + 3];
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
                    temperatureArray[x] = fahrenheit(temperatureArray[x]);
                }
            }
            return temperatureArray;
        }

        public double[] ProcAuxs(double[] auxArray)
        {
            for (int x = 0; x < 8; x++)
            {
                if (auxArray[x] == 0xfff)
                {
                    auxArray[x] = 0;
                }
                else
                {
                    auxArray[x] = calculateAuxs(auxArray[x]);
                }
            }
            return auxArray;
        }

        // fahrenheit takes raw doubles from ProcTemps and aplies Slope and Offset
        private double fahrenheit(double x)
        {
            double slope = -.0135;
            double offset = 48.43;
            return Math.Round((((x * slope) + offset) * 1.8) + 32, 2);
        }
        // CalculateAuxs takes raw double from ProAuxs and applies Slope.  There is no offset.
        private double calculateAuxs(double x)
        {
            x = (x * .0009655);
            return x;
        }


    }
}
