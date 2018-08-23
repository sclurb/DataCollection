using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollectionCustomInstaller
{
    /// <summary>
    /// This class processes the raw data taken from the sensor board
    /// It arranges the data in arrays which are ordered to facilitate
    /// calculating values in the TempHumidCalculations class
    /// </summary>
    public class TempHumidityProcessing
    {
        private TempHumidCalculations calcs = new TempHumidCalculations();
        private const double t1 = .01;
        private const double t2 = .00008;
        public TempHumidityProcessing()
        {
            
        }

        //  
        /// <summary>
        /// This method converts the input parameter byte[] by combining
        /// two separate bytes of the array into an array of doubles.
        /// </summary>
        /// <param name="rawTemps">An array of bytes taken from the sensor board  which are raw
        /// tempeaure readings before calculating
        /// Each byte gets combined with a second byte in the array</param>
        /// <returns>returns an array of doubles which contains all the temperature readings</returns>
        public double[] ArrangeTemps(byte[] rawTemps)
        {
            try
            {
                double[] arrangedValues = new double[16];
                for (int x = 0; x < 16; x++)
                {
                    arrangedValues[x] = (rawTemps[(x * 2) + 2] * 256) + rawTemps[(x * 2) + 3];
                }
                return arrangedValues;
            }
            catch(IndexOutOfRangeException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
                return null;
            }

        }
        /// <summary>
        /// This method converts the input parameter byte[] by combining
        /// two separate bytes of the array into an array of doubles.
        /// </summary>
        /// <param name="rawHumps">An array of bytes taken from the sensor board  which are raw
        /// humidity readings before calculating
        /// Each byte gets combined with a second byte in the array</param>
        /// <returns>returns an array of doubles which contains all the humidity readings</returns>
        public double[] ArrangeHumids(byte[] rawHumps)
        {
            try
            {
                double[] arrangedValues = new double[8];
                for (int x = 0; x < 8; x++)
                {
                    arrangedValues[x] = (rawHumps[(x * 2) + 2] * 256) + rawHumps[(x * 2) + 3];
                }
                return arrangedValues;
            }
            catch (IndexOutOfRangeException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
                return null;
            }

        }
        /// <summary>
        /// This method converts the input parameter byte[] by combining
        /// two separate bytes of the array into an array of doubles.
        /// </summary>
        /// <param name="rawAuxs">Takes an array of bytes</param>
        /// <returns>Returns an array of doubles</returns>
        public double[] ArrangeAuxs(byte[] rawAuxs)
        {
            try
            {
                double[] arrangedValues = new double[8];
                for (int x = 0; x < 8; x++)
                {
                    arrangedValues[x] = (rawAuxs[(x * 2) + 2] * 256) + rawAuxs[(x * 2) + 3];
                }
                return arrangedValues;
            }

            catch (IndexOutOfRangeException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
                return null;
            }
        }
        /// <summary>
        /// This method takes the "arranged temperature readings and determines if any of the sensors are connected
        /// to the sensor board.   If they are not connected, the method changes the values
        /// to zero so that the view of the data knows that there is no sensor
        /// </summary>
        /// <param name="temperatureArray">temperature array from ArrangeTemps()</param>
        /// <returns>Returns an array of doubles with the appropriate values"zeroed"</returns>
        public double[] ProcTemps(double[] temperatureArray)
        {
            try
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
            catch (NullReferenceException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
                return null;
            }

        }
        /// <summary>
        /// This method takes the "arranged aux or voltage readings and determines if any of the sensors are connected
        /// to the sensor board.   If they are not connected, the method changes the values
        /// to zero so that the view of the data knows that there is no sensor 
        /// </summary>
        /// <param name="auxArray">called from ArrangeAuxs()</param>
        /// <returns>returns an array of doubles witht the appropriate values "zeroed"</returns>
        public double[] ProcAuxs(double[] auxArray)
        {
            try
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
            catch (NullReferenceException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
                return null;
            }
        }

        /// <summary>
        /// fahrenheit takes raw doubles from ProcTemps and aplies Slope and Offset
        /// </summary>
        /// <param name="x">Takes in one double which is the raw value</param>
        /// <returns> returns a double which is the temperature in Fahrenheit</returns>
        private double fahrenheit(double x)
        {
            double slope = -.0135;
            double offset = 48.43;
            return Math.Round((((x * slope) + offset) * 1.8) + 32, 2);
        }
        // .
        /// <summary>
        /// CalculateAuxs takes raw double from ProAuxs and applies Slope.  There is no offset
        /// </summary>
        /// <param name="x">Takes a double</param>
        /// <returns>returns a double which ios the voltage reading from the sensor</returns>
        private double calculateAuxs(double x)
        {
            x = (x * .008648) -2.3;
            if (x < 0)
            {
                x = 0;
            }
            return x;
        }


    }
}
