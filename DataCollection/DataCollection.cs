using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollection
{
    public partial class DataCollection : Form
    {
        delegate void SetTextCallback(byte[] rxTemp);
        delegate void justGiveMeNumBytes(string foo, string bar);
        
        private int RXcount = 0;
        private byte[] getTemps = { 0x40, 0x10, 0xf5 };
        private byte[] getHumps = { 0x40, 0x20, 0xf5 };
        private byte[] getAuxs = { 0x40, 0x30, 0xf5 };
        private SerialPort comPort = new SerialPort();
        private double c1 = -4;
        private double c2 = 0.0405;
        private double c3 = -2.8E-6;
        private const double ch1 = -2.0468;
        private const double ch2 = 0.0367;
        private const double ch3 = -1.5955E-6;
        private const double t1 = .01;
        private const double t2 = .00008;
        private const double Tn = 243.12;
        private const double m = 17.62;
        private double[] procdValues = new double[32];
        private double[] dews = new double[4];
        ArrayList rxData = new ArrayList();
        private byte relayStat = 0;
        private byte[] setRelays = new byte[4];
        Timer timer1 = new Timer();     // sets the interval between data collection 450,000 = 7.5 minutes
        Timer timer2 = new Timer();     // sets  short delay to separate the data send commands


        public DataCollection()
        {
            InitializeComponent();
            RefreshComPortList();
            comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            timer1.Interval = 450000;   // specify interval time as you want
            numCrunch crunch = new numCrunch();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);

        }
        private void DataCollection_Load(object sender, EventArgs e)
        {

        }

        private void tripPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TripPoint tripoint = new TripPoint();
            tripoint.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config setForm = new Config();
            setForm.Show();
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }
        #region Communicate Methods
        private void RefreshComPortList()
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(portNameBox.Items.Cast<string>(), portNameBox.SelectedItem as string, comPort.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                portNameBox.Items.Clear();
                portNameBox.Items.AddRange(OrderedPortNames());
                portNameBox.SelectedItem = selected;
            }
        }

        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;
            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = SerialPort.GetPortNames();
            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;
            if (updated)    // If there was a change, then select an appropriate default port
            {
                ports = OrderedPortNames(); // Use the correctly ordered set of port names
                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();
                if (PortOpen)   // If the port was already open... (see logic notes and reasoning in Notes.txt)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }
            return selected;    // If there was a change to the port list, return the recommended default selection
        }

        private void communicate(byte[] felderCarp)
        {
            try
            {
                comPort.Write(felderCarp, 0, felderCarp.Length);
            }
            catch (ArgumentNullException)
            {MessageBox.Show("Argument Null");}
            catch (InvalidOperationException)
            { MessageBox.Show("InvalidOperationException"); }
            catch (ArgumentOutOfRangeException)
            { MessageBox.Show("ArgumentOutOfRangeException"); }
            catch (ArgumentException)
            { MessageBox.Show("ArgumentException");}
            catch (TimeoutException)
            { MessageBox.Show("TimeoutException");}
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = comPort.BytesToRead;
            byte[] rxBuffer = new byte[bytes]; // Read the data from the port and store it in our buffer
            comPort.Read(rxBuffer, 0, bytes);
            SetTextCallback d = new SetTextCallback(process);
            this.Invoke(d, new object[] { rxBuffer });
        }
        // This method takes the receieved byte[] and determines which processing method to use based on the second element in the received byte[]
        private void process(byte[] gertrude)
        {
            foreach (byte a in gertrude)
            {
                rxData.Add(a);
            }

            byte[] fred = new byte[1];
            fred = (byte[])rxData.ToArray(typeof(byte));

            if (fred[1] == 0x10 && fred.Length == 36)
            {
                procTemps(fred);
            }
            if (fred[1] == 0x20 && fred.Length == 20)
            {
                procHumps(fred);
            }
            if (fred[1] == 0x30)
            {
                procAuxs(fred);
            }
            if (fred[1] == 0x50)
            {
                relayStat = fred[2];
                funKen();
            }
        }

        #endregion

        #region  proc methods
        // This method processes the byte[] by combining two separate btytes in the array then applying slope and offset.
        // Finally the new value is placed in a global array that contains the values for all sensors
        private void procTemps(byte[] rawTemps)
        {
            if (rawTemps.Length != 36)  // if there is a formatting error or maybe the comport only returns a partial byte[], clear rxdata and return
            {
                rxData.Clear();
                return;
            }
            double a;               // holds the combined bytes from sent data byte array
            double d = 0xfff;       // checks raw data to see if temperature sensor is giving data, maybe it is disconnected

            a = (rawTemps[2] * 256) + rawTemps[3];
            if (a == d) { a = 0; } else { procdValues[0] = fahrenheit(a); }
            a = (rawTemps[4] * 256) + rawTemps[5];
            if (a == d) { a = 0; } else { procdValues[1] = fahrenheit(a); }
            a = (rawTemps[6] * 256) + rawTemps[7];
            if (a == d) { a = 0; } else { procdValues[2] = fahrenheit(a); }
            a = (rawTemps[8] * 256) + rawTemps[9];
            if (a == d) { a = 0; } else { procdValues[3] = fahrenheit(a); }
            a = (rawTemps[10] * 256) + rawTemps[11];
            if (a == d) { a = 0; } else { procdValues[4] = fahrenheit(a); }
            a = (rawTemps[12] * 256) + rawTemps[13];
            if (a == d) { a = 0; } else { procdValues[5] = fahrenheit(a); }
            a = (rawTemps[14] * 256) + rawTemps[15];
            if (a == d) { a = 0; } else { procdValues[6] = fahrenheit(a); }
            a = (rawTemps[16] * 256) + rawTemps[17];
            if (a == d) { a = 0; } else { procdValues[7] = fahrenheit(a); }
            a = (rawTemps[18] * 256) + rawTemps[19];
            if (a == d) { a = 0; } else { procdValues[8] = fahrenheit(a); }
            a = (rawTemps[20] * 256) + rawTemps[21];
            if (a == d) { a = 0; } else { procdValues[9] = fahrenheit(a); }
            a = (rawTemps[22] * 256) + rawTemps[23];
            if (a == d) { a = 0; } else { procdValues[10] = fahrenheit(a); }
            a = (rawTemps[24] * 256) + rawTemps[25];
            if (a == d) { a = 0; } else { procdValues[11] = fahrenheit(a); }
            a = (rawTemps[26] * 256) + rawTemps[27];
            if (a == d) { a = 0; } else { procdValues[12] = fahrenheit(a); }
            a = (rawTemps[28] * 256) + rawTemps[29];
            if (a == d) { a = 0; } else { procdValues[13] = fahrenheit(a); }
            a = (rawTemps[30] * 256) + rawTemps[31];
            if (a == d) { a = 0; } else { procdValues[14] = fahrenheit(a); }
            a = (rawTemps[32] * 256) + rawTemps[33];
            if (a == d) { a = 0; } else { procdValues[15] = fahrenheit(a); }
            fillTemps(procdValues);
        }

        private void procHumps(byte[] rawHumps)
        {
            if (rawHumps.Length != 20)
            {
                rxData.Clear();
                return;
            }


            double Hum1 = (rawHumps[2] * 256) + rawHumps[3];
            double Temp1 = (rawHumps[4] * 256) + rawHumps[5];
            double Hum2 = (rawHumps[6] * 256) + rawHumps[7];
            double Temp2 = (rawHumps[8] * 256) + rawHumps[9];
            double Hum3 = (rawHumps[10] * 256) + rawHumps[11];
            double Temp3 = (rawHumps[12] * 256) + rawHumps[13];
            double Hum4 = (rawHumps[14] * 256) + rawHumps[15];
            double Temp4 = (rawHumps[16] * 256) + rawHumps[17];

            double TempC1 = procTempsC(Temp1);
            double TempC2 = procTempsC(Temp2);
            double TempC3 = procTempsC(Temp3);
            double TempC4 = procTempsC(Temp4);
            double RH1 = procHumsh(Hum1);
            double RH2 = procHumsh(Hum2);
            double RH3 = procHumsh(Hum3);
            double RH4 = procHumsh(Hum4);
            double RHt1 = (TempC1 - 25) * (t1 + (t2 * Hum1)) + RH1;
            double RHt2 = (TempC2 - 25) * (t1 + (t2 * Hum2)) + RH2;
            double RHt3 = (TempC3 - 25) * (t1 + (t2 * Hum3)) + RH3;
            double RHt4 = (TempC4 - 25) * (t1 + (t2 * Hum4)) + RH4;

            // These lines first check to see if a sensor is giving readings, if it is not, zero is the value placed in the procdVales array
            if (Temp1 == 0xf4f4) { procdValues[16] = 0; } else { procdValues[16] = Math.Round(procTempsF(TempC1), 2); }
            if (Hum1 == 0xf4f4) { procdValues[17] = 0; } else { procdValues[17] = Math.Round(RHt1, 2); }
            if (Temp2 == 0xf4f4) { procdValues[18] = 0; } else { procdValues[18] = Math.Round(procTempsF(TempC2), 2); }
            if (Hum2 == 0xf4f4) { procdValues[19] = 0; } else { procdValues[19] = Math.Round(RHt2, 2); }
            if (Temp3 == 0xf4f4) { procdValues[20] = 0; } else { procdValues[20] = Math.Round(procTempsF(TempC3), 2); }
            if (Hum3 == 0xf4f4) { procdValues[21] = 0; } else { procdValues[21] = Math.Round(RHt3, 2); }
            if (Temp4 == 0xf4f4) { procdValues[22] = 0; } else { procdValues[22] = Math.Round(procTempsF(TempC4), 2); }
            if (Hum4 == 0xf4f4) { procdValues[23] = 0; } else { procdValues[23] = Math.Round(RHt4, 2); }

            // These lines first check to see if a sensor is attached if it is, the values of humidity and temerature are sent
            // to procDews and that result is put in a separate arrays for dew point only
            if (Hum1 == 0xf4f4) { dews[0] = 0; } else { dews[0] = procDews(RHt1, TempC1); }
            if (Hum2 == 0xf4f4) { dews[1] = 0; } else { dews[1] = procDews(RHt2, TempC2); }
            if (Hum3 == 0xf4f4) { dews[2] = 0; } else { dews[2] = procDews(RHt3, TempC3); }
            if (Hum4 == 0xf4f4) { dews[3] = 0; } else { dews[3] = procDews(RHt4, TempC4); }

            fillHumps();

        }

        private void procAuxs(byte[] rawAuxs)
        {
            if (rawAuxs.Length != 20)
            {
                rxData.Clear();
                return;
            }
            double a;
            a = (rawAuxs[2] * 256) + rawAuxs[3];
            a = value(a);
            a = calculate(a);
            procdValues[24] = Math.Round(a, 2);
            a = (rawAuxs[4] * 256) + rawAuxs[5];
            a = value(a);
            a = calculate(a);
            procdValues[25] = Math.Round(a, 2);
            a = (rawAuxs[6] * 256) + rawAuxs[7];
            a = value(a);
            a = calculate(a);
            procdValues[26] = Math.Round(a, 2);
            a = (rawAuxs[8] * 256) + rawAuxs[9];
            a = value(a);
            a = calculate(a);
            procdValues[27] = Math.Round(a, 2);
            a = (rawAuxs[10] * 256) + rawAuxs[11];
            a = value(a);
            a = calculate(a);
            procdValues[28] = Math.Round(a, 2);
            a = (rawAuxs[12] * 256) + rawAuxs[13];
            a = value(a);
            a = calculate(a);
            procdValues[29] = Math.Round(a, 2);
            a = (rawAuxs[14] * 256) + rawAuxs[15];
            a = value(a);
            a = calculate(a);
            procdValues[30] = Math.Round(a, 2);
            a = (rawAuxs[16] * 256) + rawAuxs[17];
            a = value(a);
            a = calculate(a);
            procdValues[31] = Math.Round(a, 2);
            fillAuxs();
        }
        #endregion



        #region fill methods
        private void fillTemps(double[] stuff)
        {

            textBox1.Text = procdValues[0].ToString("0.0") + "\u00b0F";
            textBox2.Text = procdValues[1].ToString("0.0") + "\u00b0F";
            textBox3.Text = procdValues[2].ToString("0.0") + "\u00b0F";
            textBox4.Text = procdValues[3].ToString("0.0") + "\u00b0F";
            textBox5.Text = procdValues[4].ToString("0.0") + "\u00b0F";
            textBox6.Text = procdValues[5].ToString("0.0") + "\u00b0F";
            textBox7.Text = procdValues[6].ToString("0.0") + "\u00b0F";
            textBox8.Text = procdValues[7].ToString("0.0") + "\u00b0F";
            textBox9.Text = procdValues[8].ToString("0.0") + "\u00b0F";
            textBox10.Text = procdValues[9].ToString("0.0") + "\u00b0F";
            textBox11.Text = procdValues[10].ToString("0.0") + "\u00b0F";
            textBox12.Text = procdValues[11].ToString("0.0") + "\u00b0F";
            textBox13.Text = procdValues[12].ToString("0.0") + "\u00b0F";
            textBox14.Text = procdValues[13].ToString("0.0") + "\u00b0F";
            textBox15.Text = procdValues[14].ToString("0.0") + "\u00b0F";
            textBox16.Text = procdValues[15].ToString("0.0") + "\u00b0F";
            RXcount = 1;
        }


        // This method calculates dew point from a standard formula
        private double procDews(double RH, double TempC)
        {
            double a = Math.Pow((RH / 100), .125) * (112 + (.9 * TempC)) + (.1 * TempC) - 112;
            return (a * 1.8) + 32;
        }

        public void fillHumps()
        {

            textBox17.Text = procdValues[16].ToString("0.00") + "\u00b0F";
            textBox18.Text = procdValues[17].ToString("0.00") + "%RH";
            textBox19.Text = procdValues[18].ToString("0.00") + "\u00b0F";
            textBox20.Text = procdValues[19].ToString("0.00") + "%RH";
            textBox21.Text = procdValues[20].ToString("0.00") + "\u00b0F";
            textBox22.Text = procdValues[21].ToString("0.00") + "%RH";
            textBox23.Text = procdValues[22].ToString("0.00") + "\u00b0F";
            textBox24.Text = procdValues[23].ToString("0.00") + "%RH";
            
            textBox33.Text = dews[0].ToString("0.00") + "\u00b0F";
            textBox34.Text = dews[1].ToString("0.00") + "\u00b0F";
            textBox35.Text = dews[2].ToString("0.00") + "\u00b0F";
            textBox36.Text = dews[3].ToString("0.00") + "\u00b0F";
            RXcount = 4;
        }

        private void fillAuxs()
        {
            textBox25.Text = procdValues[24].ToString("0.00");
            textBox26.Text = procdValues[25].ToString("0.00");
            textBox27.Text = procdValues[26].ToString("0.00");
            textBox28.Text = procdValues[27].ToString("0.00");
            textBox29.Text = procdValues[28].ToString("0.00");
            textBox30.Text = procdValues[29].ToString("0.00");
            textBox31.Text = procdValues[30].ToString("0.00");
            textBox32.Text = procdValues[31].ToString("0.00");
            RXcount = 2;
        }
        #endregion fill methods

        #region Helper Methds (used by other methods)

        //Gets called by procTemps()   This has two purposes:
        // first, the passed value has slope and offset to set up for graph
        // second, the value then get converted from Celcius to Fahenheit
        private double fahrenheit(double x)
        {
            double slope = -.0135;
            double offset = 48.43;
            return Math.Round((((x * slope) + offset) * 1.8) + 32, 2);
        }


        // this method processes raw data from Humidity uses 8 bit processing
        private double procHums(double x)
        {
            double y;
            y = ((c2 + (c3 * x)) * x + c1);
            return y;
        }

        // this method uses constants from 12bit processing receives raw data and returns a double 
        // with the linear RH
        private double procHumsh(double x)
        {
            double y;
            y = ch1 + (ch2 * x) + (ch3 * Math.Pow(x, 2));
            return y;
        }
        //  recieves processed Celcius temps and returns a double with the temp in Fahrenheit
        private double procTempsF(double x)
        {
            double y;
            y = ((x * 1.8) + 32);
            return y;
        }
        //  recieves raw data and returns a double with the temp in Celcius
        private double procTempsC(double x)
        {
            double y;
            y = ((x * .01) + -40.1);
            return y;
        }
        // used to get Aux values from raw data
        private double calculate(double x)
        {
            x = (x * .0009655);
            return x;
        }

        private double value(double z)
        {
            double d = 0xfff;
            if (z == d)
            {
                z = 0;
            }
            return z;
        }

        #endregion

        private void firstShot()
        {
            rxData.Clear();
            communicate(getTemps);
            timer2.Enabled = true;
        }
        private void funKen()
        {
            switch (relayStat)
            {
                case 0:
                    button5.BackColor = Color.Red;
                    button6.BackColor = Color.Red;
                    button7.BackColor = Color.Red;
                    break;
                case 1:
                    button5.BackColor = Color.Green;
                    button6.BackColor = Color.Red;
                    button7.BackColor = Color.Red;
                    break;
                case 2:
                    button5.BackColor = Color.Red;
                    button6.BackColor = Color.Green;
                    button7.BackColor = Color.Red;
                    break;
                case 3:
                    button5.BackColor = Color.Green;
                    button6.BackColor = Color.Green;
                    button7.BackColor = Color.Red;
                    break;
                case 4:
                    button5.BackColor = Color.Red;
                    button6.BackColor = Color.Red;
                    button7.BackColor = Color.Green;
                    break;
                case 5:
                    button5.BackColor = Color.Green;
                    button6.BackColor = Color.Red;
                    button7.BackColor = Color.Green;
                    break;
                case 6:
                    button5.BackColor = Color.Red;
                    button6.BackColor = Color.Green;
                    button7.BackColor = Color.Green;
                    break;
                case 7:
                    button5.BackColor = Color.Green;
                    button6.BackColor = Color.Green;
                    button7.BackColor = Color.Green;
                    break;
            }
            RXcount = 3;
        }
        #region  button click events
        private void button1_Click(object sender, EventArgs e)
        {
            bool error = false;

            // If the port is open, close it.
            if (comPort.IsOpen) comPort.Close();
            else
            {
                // Set the port's settings
                comPort.BaudRate = 9600;
                comPort.DataBits = 8;
                comPort.StopBits = StopBits.One;
                comPort.Parity = Parity.None;
                comPort.PortName = portNameBox.Text;

                try
                {
                    // Open the port
                    comPort.Open();
                }
                catch (UnauthorizedAccessException) { error = true; }
                catch (IOException) { error = true; }
                catch (ArgumentException) { error = true; }

                if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (comPort.IsOpen)
            {
                button1.Text = "&Close Port"; timer1.Enabled = true;
                firstShot();
            }
            else { button1.Text = "&Open Port"; timer1.Enabled = false; }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            setRelay1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setRelay2();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setRelay3();
        }

        #endregion
        #region relay set methods

        private void setRelay1()
        {
            rxData.Clear();
            setRelays[0] = 0x40;
            setRelays[1] = 0x50;
            setRelays[2] = 0x01;
            setRelays[3] = 0xf5;
            communicate(setRelays);
        }

        private void setRelay2()
        {
            rxData.Clear();
            setRelays[0] = 0x40;
            setRelays[1] = 0x50;
            setRelays[2] = 0x02;
            setRelays[3] = 0xf5;
            communicate(setRelays);
        }

        private void setRelay3()
        {
            rxData.Clear();
            setRelays[0] = 0x40;
            setRelays[1] = 0x50;
            setRelays[2] = 0x03;
            setRelays[3] = 0xf5;
            communicate(setRelays);
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            firstShot();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (RXcount == 1)
            {
                timer2.Enabled = false;
                rxData.Clear();
                communicate(getAuxs);
                timer2.Enabled = true;
            }

            if (RXcount == 2)
            {
                timer2.Enabled = false;
                rxData.Clear();
                setRelays[0] = 0x40;
                setRelays[1] = 0x50;
                setRelays[2] = 0xff;
                setRelays[3] = 0xf5;
                communicate(setRelays);
                timer2.Enabled = true;
            }
            if (RXcount == 3)
            {
                timer2.Enabled = false;
                rxData.Clear();
                communicate(getHumps);
                timer2.Enabled = true;
            }
            if (RXcount == 4)
            {
                timer2.Enabled = false;
                writeDB();
            }
            tripoiintCheck();
        }
        // This method inserts the valuse in procValues into the database
        private void writeDB()
        {
            label22.Text = DateTime.Now.ToString();
            numCrunch log = new numCrunch();
            bool[] switches = log.dataEnable();
            log.insert(procdValues);
            /*   old routine with older database  obsolete!
            for (int i = 0; i < switches.Length; i++)
            {
                if (switches[i])
                {
                    log.insert(procdValues);
                }
            }
            */
        }
        private void tripoiintCheck()
        {
            if (Properties.Settings.Default.Enable1)
            {
                tripRelay check = new tripRelay();

                check.MonitoredValue = procdValues[Properties.Settings.Default.Index1];
                check.OverUnder = Properties.Settings.Default.OverUnder1;
                check.TripPoint = Properties.Settings.Default.TripPoint1;
                if (check.determine())
                {
                    if (button5.BackColor == Color.Red )
                    {
                        setRelay1();
                    }
                }
            }

            if (Properties.Settings.Default.Enable2)
            {
                tripRelay check = new tripRelay();

                check.MonitoredValue = procdValues[Properties.Settings.Default.Index2];
                check.OverUnder = Properties.Settings.Default.OverUnder2;
                check.TripPoint = Properties.Settings.Default.TripPoint2;
                if (check.determine())
                {
                    if (button6.BackColor == Color.Red)
                    {
                        setRelay2();
                    }
                }
            }

            if (Properties.Settings.Default.Enable3)
            {
                tripRelay check = new tripRelay();

                check.MonitoredValue = procdValues[Properties.Settings.Default.Index3];
                check.OverUnder = Properties.Settings.Default.OverUnder3;
                check.TripPoint = Properties.Settings.Default.TripPoint3;
                if (check.determine())
                {
                    if (button7.BackColor == Color.Red)
                    {
                        setRelay3();
                    }
                }
            }
        }

    }
}
