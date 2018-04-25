using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollection
{
    class Trim
    {
        public List<Trim> TrimList = new List<Trim>();
        public Trim()
        {
            //TrimList = GetValues();
        }
        private bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        private double trimValue;

        public double TrimValue
        {
            get { return trimValue; }
            set { trimValue = value; }
        }


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

                System.Windows.Forms.MessageBox.Show("Failed to load Controls \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
                return null;
            }
        }

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
