using System;
using System.Collections.Generic;
using System.Data;

namespace DataCollection
    {/// <summary>
    /// This Class will handle the trim feature.
    /// this class gets a list of sensor trim values
    /// and will add them to all the ellments of an double[]
    /// if each sensor has been "Enabled"
    /// </summary>
    class Trim
    {
 
        public Trim()
        {

        }
        /// <summary>
        /// backing field for Enabled
        /// </summary>
        private bool enabled;
        /// <summary>
        /// public bool holds value for Enabled
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        /// <summary>
        /// backing field for Trim
        /// </summary>
        private double trimValue;
        /// <summary>
        /// public double holds value of trim
        /// </summary>
        public double TrimValue
        {
            get { return trimValue; }
            set { trimValue = value; }
        }

        /// <summary>
        /// Gets a List of type Trim with all the sensor trim and enabled values as 
        /// properties in each object type Trim.
        /// </summary>
        /// <returns>List of type Trim with each list item having two properties
        /// "Enabled" = bool and "Trim" = double </returns>
        public List<Trim> GetValues()
        {
            numCrunch pluto = new numCrunch();
            DataTable result = pluto.configLoad();
            List<Trim> procTrim = new List<Trim>();
            try
            {
                int count = result.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    Trim temp = new Trim();
                    temp.Enabled = Convert.ToBoolean(result.Rows[i][4]);
                    temp.TrimValue = Convert.ToDouble(result.Rows[i][3].ToString());
                    procTrim.Add(temp);
                }
                return procTrim;
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("Failed to get Trim Values and Enables \r \n"
                    + "Here's Why.... \r \n" + e.ToString());
                return null;
            }
        }
        /// <summary>
        /// this method looks to see if each reading in the list is "Enaables"
        /// if it is enabled, then it adds that trim value stored in the database S_List to the 
        /// value displayed in the textboxes and int eh database MainData table
        /// </summary>
        /// <param name="list">List of type <Trim> with two properties, "Enabled" = bool and Trim= double</param>
        /// <param name="proccessedValues">An array of double holding all the sensor readings (32 in all)</param>
        /// <returns>Returns an array of doubles with the Trim values added in.</returns>
        public double[] ProcessTrim(List<Trim> list, double[] proccessedValues)
        {
            double[] values = new double[32];

            for (int i = 0; i < 32; i++)
            {
                if(list[i].Enabled == true)
                {
                    values[i] = list[i].TrimValue + proccessedValues[i];
                }
                else
                {
                    values[i] = proccessedValues[i];
                }
                
            }
            return values;
        }

    }
}
