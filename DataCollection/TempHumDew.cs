using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollection
{
    public class TempHumDew
    {
        // This class processes the data for the Sensiron SHT1
        private const double ch1 = -2.0468;     // SHT1 RH linear humidity coefficient 12bit
        private const double ch2 = 0.0367;      // SHT1 RH linear humidity coeeficient 12bit
        private const double ch3 = -1.5955E-6;  // SHT1 RH linear humidity coefficient 12bit
        private const double t1 = .01;          // SHT1 RHT temperature compensation of humidity coefficient 12bit
        private const double t2 = .00008;       // SHT1 RHT temperature compensation of humidity coefficient 12bit
        private const double d2 = .01;          // SHT1 temperature coefficient for Celcius 14bit
        private const double d1 = -40.1;        // SHT1 temperature coefficient for 5Vdc Supply and Celcius

        private double rawTemp;                 // raw temperature data from sensor 
        private double rawHumid;                // raw humidit data from sensor
 
        public TempHumDew(double temp, double humid)
        {
            rawTemp = temp;
            rawHumid = humid;
        }

        public double RawTemp
        {
            get { return rawTemp; }

            set { rawTemp = value; }
        }

        public double RawHumid
        {
            get { return rawHumid; }

            set { rawHumid = value; }
        }

        public double RH()
        {
            double result = ch1 + (ch2 * rawHumid) + (ch3 * Math.Pow(rawHumid, 2));
            return result;
        }

        public double RHT(double tempC1, double RH1)
        {
            double y = (tempC1 - 25) * (t1 + (t2 * rawHumid)) + RH1;
            return y;
        }

        public double TempC(double rawTemp1)
        {
            double y = ((rawTemp1 * d2) + d1);
            return y;
        }

        private double calcDew(double RHT, double rawTemp1)
        {
            double a = Math.Pow((RHT / 100), .125) * (112 + (.9 * rawTemp1)) + (.1 * rawTemp1) - 112;
            return (a * 1.8) + 32;
        }
    }
}
