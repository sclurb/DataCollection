using System;


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
        private double rawHumid;                // raw humidiy data from sensor
 
        /// <summary>
        /// returns a an object containig the processed values from sensor data.
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="humid"></param>
        public TempHumDew(double temp, double humid)
        {
            rawTemp = temp;
            rawHumid = humid;
        }
        /// <summary>
        /// Holds a Temperature pre-processsed value from the sensor.
        /// </summary>
        public double RawTemp
        {
            get { return rawTemp; }

            set { rawTemp = value; }
        }
        /// <summary>
        /// Holds a humidity pre-processed value from the sensor
        /// </summary>
        public double RawHumid
        {
            get { return rawHumid; }

            set { rawHumid = value; }
        }

        /// <summary>
        /// Returns a value derived from the raw temperature reading from sensor.
        /// </summary>
        public double TempC
        {
            get
            {
                if (rawTemp == 0xf4f4)
                {
                    return 0;
                }
                else
                {
                    return (rawTemp * d2) + d1;
                }
            }
                
        }

        /// <summary>
        /// Returns a value derived from the raw humidity reading from sensor
        /// Value is the Relative Humidity without temperature compensation factored in.
        /// </summary>
        public double RH
        {
            get
            {
                if (rawHumid == 0xf4f4)
                {
                    return 0;
                }
                else
                {
                    return ch1 + (ch2 * rawHumid) + (ch3 * Math.Pow(rawHumid, 2));
                }
                
            }

        }
        /// <summary>
        /// Returns a value derived from the rawHumid and rawTemp backing fields.
        /// Value is the Relative Humidity with a temperature compensation factored in.
        /// </summary>
        public double RHT
        {
             get
            {
                if ((rawHumid == 0xf4f4) || rawTemp == 0xf4f4)
                {
                    return 0;
                }
                else
                {
                    return ((TempC - 25) * (t1 + (t2 * rawHumid))) + RH;
                }
            }
        }

        // 
        /// <summary>
        /// This returns a value derived from raw temperature and raw humidity reading from sensor.
        /// https://www.ajdesigner.com/phphumidity/dewpoint_equation_dewpoint_temperature.php
        /// </summary>
        public double DewC
        {
            get
            {
                if ((rawHumid == 0xf4f4) || rawTemp == 0xf4f4)
                {
                    return 0;
                }
                else
                {
                    return Math.Pow((RHT / 100), .125) * (112 + (.9 * TempC)) + (.1 * TempC) - 112;
                }
                
            }
        }
        /// <summary>
        /// Returns a value derived from the rawHumid and rawTemp backing fields
        /// Value is the Dew point in fahrenheit.
        /// </summary>
        public double DewF
        {
            get
            {
                if ((rawHumid == 0xf4f4) || rawTemp == 0xf4f4)
                {
                    return 0;
                }
                else
                {
                    return ((Math.Pow((RHT / 100), .125) * (112 + (.9 * TempC)) + (.1 * TempC) - 112) * 1.8) + 32;
                }
                
            }
        }
        /// <summary>
        /// returns the temperature in fahrenheit of the value stored in rawTemps backing field
        /// </summary>
        public double TempF
        {
            get
            {
                if (rawTemp == 0xf4f4)
                {
                    return 0;
                }
                else
                {
                    return (((rawTemp * d2) + d1) * 1.8) + 32;
                }
            }
        }


    }
}
