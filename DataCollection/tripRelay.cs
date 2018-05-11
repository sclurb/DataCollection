using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionCustomInstaller
{
    class tripRelay
    {
        private double monitoredValue;
        private bool over;
        private int index;
        private double tripPoint;

        public tripRelay()
        {

        }

        public tripRelay(double monValue, bool over1, int ind, double trippiont)
        {
            monitoredValue = monValue;
            over = over1;
            index = ind;
            tripPoint = trippiont;
        }

        public double MonitoredValue { get { return monitoredValue; } set { monitoredValue = value; } }
        public bool OverUnder { get { return over; } set { over = value; } }
        public int Index { get { return index; } set { index = value; } }
        public double TripPoint { get { return tripPoint; } set { tripPoint = value; } }

        public bool determine()
        {
            bool t;
            if (over)
            {
                if (monitoredValue > tripPoint)
                {
                    t = true;
                }
                else
                {
                    t = false;
                }
            }
            else
            {
                if (tripPoint > monitoredValue)
                {
                    t = true;
                }
                else
                {
                    t = false;
                }
            }
            return t;
        }

    }
}
