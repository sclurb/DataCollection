using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataCollectionCustomInstaller
{
    /// <summary>
    /// This class performs calculations off data processed through TempHumidity Processing
    /// </summary>
    public class TempHumidCalculations
    {

        private double c1 = -4;
        private double c2 = 0.0405;
        private double c3 = -2.8E-6;
        private const double ch1 = -2.0468;
        private const double ch2 = 0.0367;
        private const double ch3 = -1.5955E-6;

        /// <summary>
        /// default constructor
        /// </summary>
        public TempHumidCalculations()
        {
                
        }
        /// <summary>
        /// Gets called by procTemps()
        /// first, the passed value has slope and offset to set up for graph
        /// second, the value then get converted from Celcius to Fahenheit
        /// </summary>
        /// <param name="x">Processed single temperature</param>
        /// <returns>a double which is a calculated fahrenheit value</returns>
        public double fahrenheit(double x)
        {
            double slope = -.0135;
            double offset = 48.43;
            return Math.Round((((x * slope) + offset) * 1.8) + 32, 2);
        }


        /// <summary>
        /// this method processes raw data from Humidity uses 8 bit processing
        /// </summary>
        /// <param name="x">processed data from TempHumidityProcessing</param>
        /// <returns></returns>
        public double procHums(double x)
        {
            double y;
            y = ((c2 + (c3 * x)) * x + c1);
            return y;
        }

        /// <summary>
        /// this method uses constants from 12bit processing receives raw data
        /// </summary>
        /// <param name="x">processed data from TempHumidityProcessing</param>
        /// <returns>returns a double with the linear RH</returns>
        public double procHumsh(double x)
        {
            double y;
            y = ch1 + (ch2 * x) + (ch3 * Math.Pow(x, 2));
            return y;
        }
        //  
        /// <summary>
        /// recieves processed Celcius temps and returns a double with the temp in Fahrenheit
        /// </summary>
        /// <param name="x">processed data from TempHumidityProcessing</param>
        /// <returns>returns a double with the temerature in Fahrenheit</returns>
        public double procTempsF(double x)
        {
            double y;
            y = ((x * 1.8) + 32);
            return y;
        }
        //  
        /// <summary>
        /// recieves raw data and returns a double with the temp in Celcius
        /// </summary>
        /// <param name="x">processed data from TempHumidityProcessing</param>
        /// <returns>returns a double with the temerature in Celcius</returns>
        public double procTempsC(double x)
        {
            double y;
            y = ((x * .01) + -40.1);
            return y;
        }
        // 
        /// <summary>
        /// used to get Aux values from raw data
        /// </summary>
        /// <param name="x">processed data from TempHumidityProcessing</param>
        /// <returns>returns a double which is the Voltage level</returns>
        public double calculate(double x)
        {
            x = (x * .0009655);
            return x;
        }
        /// <summary>
        /// Reall not sure what this was written for...;)   Maybe I should delete it?
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public double value(double z)
        {
            double d = 0xfff;
            if (z == d)
            {
                z = 0;
            }
            return z;
        }





    }
}
