using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionCustomInstaller
{
    /// <summary>
    /// This delegate is used to fill in the labels for all the labels
    /// which will ave names based on the values in the database table S_LIST
    /// S_LIST holds all the names chosen by the user for each temperature/humidity reading
    /// </summary>
    public delegate void UpdateLabels();
    /// <summary>
    /// This delegate is used to send values of contrast and brightnes to the outboard LCD module
    /// </summary>
    /// <param name="e">This delegate can either take a command with its data.   
    /// The data will be for contrast or brightness levels</param>
    public delegate void AdjustLCD(AdjustEventArgs e);

    /// <summary>
    /// This class defines the data that can be passed via the AdjustLCD delegate
    /// </summary>
    public class AdjustEventArgs : EventArgs
    {
        private byte cmd;
        private byte data;

        public byte Cmd
        {
            get
            {
                return cmd;
            }
            set
            {
                cmd = value;
            }
        }
        public byte Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }

        }

    }
}
