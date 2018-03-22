using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace DataCollection
{
    public partial class DataCollection : Form
    {
        private delegate void DataIsReceived(byte[] rxTemp);

        ArrayList rxData = new ArrayList();
        private int RXcount = 0;
        private byte[] getTemps = { 0x40, 0x10, 0xf5 };
        private byte[] getHumps = { 0x40, 0x20, 0xf5 };
        private byte[] getAuxs = { 0x40, 0x30, 0xf5 };
        private SerialPort comPort = new SerialPort();

        private double[] procdValues = new double[32];
        private double[] dews = new double[4];
        
        private byte relayStat = 0;
        private byte[] setRelays = new byte[4];
        Timer timer1 = new Timer();     // sets the interval between data collection 450,000 = 7.5 minutes
        Timer timer2 = new Timer();     // sets  short delay to separate the data send commands

        public static bool set = false;


        public DataCollection()
        {
            InitializeComponent();
            RefreshComPortList();
            comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            timer1.Interval = 450000;   // specify interval time as you want
            numCrunch crunch = new numCrunch();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
            FillLabels();

        }

        #region Events
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
            setForm.Updater = new UpdateLabels(FillLabels);
            setForm.Show();
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }
        #endregion

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

        private void communicate(byte[] txString)
        {
            if (comPort.IsOpen)
            {
                try
                {
                    comPort.Write(txString, 0, txString.Length);
                }
                catch (IOException)
                { MessageBox.Show("IOException"); }
                catch (ArgumentNullException)
                { MessageBox.Show("Argument Null"); }
                catch (InvalidOperationException)
                { MessageBox.Show("InvalidOperationException"); }
                catch (ArgumentOutOfRangeException)
                { MessageBox.Show("ArgumentOutOfRangeException"); }
                catch (ArgumentException)
                { MessageBox.Show("ArgumentException"); }
                catch (TimeoutException)
                { MessageBox.Show("TimeoutException"); }
                catch (Exception)
                { MessageBox.Show("Just an Exception"); }
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = comPort.BytesToRead;
            byte[] rxBuffer = new byte[bytes]; // Read the data from the port and store it in our buffer
            comPort.Read(rxBuffer, 0, bytes);
            DataIsReceived d = new DataIsReceived(process);
            Invoke(d, new object[] { rxBuffer });
        }

        // This method takes the receieved byte[] and determines which processing method to use based on the second element in the received byte[]
        private void process(byte[] rxBuffer)
        {
            TempHumidityProcessing arrange = new TempHumidityProcessing();

            foreach (byte a in rxBuffer)
            {
                rxData.Add(a);
            }


            byte[] tempArray = new byte[rxData.Count];

            try
            {
                tempArray = (byte[])rxData.ToArray(typeof(byte));
            }
            catch(IndexOutOfRangeException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
            }
            

            if (tempArray[1] == 0x10 && tempArray.Length == 36)
            {
                if (tempArray[35] == 0)
                {
                    double[] temperatureArray = arrange.ArrangeTemps(tempArray);
                    temperatureArray = arrange.ProcTemps(temperatureArray);
                    fillTemps(temperatureArray);
                }
                rxData.Clear();

            }
            
            if (tempArray[1] == 0x20 && tempArray.Length == 20)
            {
                if (tempArray[19] == 0)
                {
                    double[] humidArray = arrange.ArrangeHumids(tempArray);
                    TempHumDew hum1 = new TempHumDew(humidArray[1], humidArray[0]);
                    TempHumDew hum2 = new TempHumDew(humidArray[3], humidArray[2]);
                    TempHumDew hum3 = new TempHumDew(humidArray[5], humidArray[4]);
                    TempHumDew hum4 = new TempHumDew(humidArray[7], humidArray[6]);
                    List<TempHumDew> humDew = new List<TempHumDew>();
                    humDew.Add(hum1);
                    humDew.Add(hum2);
                    humDew.Add(hum3);
                    humDew.Add(hum4);
                    fillHumps(humDew);
                }
                rxData.Clear();

            }
            if (tempArray[1] == 0x30 && tempArray.Length == 20)
            {
                if(tempArray[19] == 0)
                {
                    double[] auxArray = arrange.ArrangeAuxs(tempArray);
                    auxArray = arrange.ProcAuxs(auxArray);
                    fillAuxs(auxArray);
                }
                rxData.Clear();
            }
            if (tempArray[1] == 0x50 && tempArray.Length == 7)
            {
                if (tempArray[6] == 0)
                {
                    relayStat = tempArray[2];
                    funKen();
                }
                rxData.Clear();
            }
        }

        #endregion

   

        #region fill methods

        private void FillLabels()
        {
            numCrunch crunch1 = new numCrunch();
            DataTable fillit = new DataTable();
            fillit = crunch1.configLoad();

            label1.Text = fillit.Rows[0][1].ToString();
            label2.Text = fillit.Rows[1][1].ToString();
            label3.Text = fillit.Rows[2][1].ToString();
            label4.Text = fillit.Rows[3][1].ToString();
            label5.Text = fillit.Rows[4][1].ToString();
            label6.Text = fillit.Rows[5][1].ToString();
            label7.Text = fillit.Rows[6][1].ToString();
            label8.Text = fillit.Rows[7][1].ToString();
            label9.Text = fillit.Rows[8][1].ToString();
            label10.Text = fillit.Rows[9][1].ToString();
            label11.Text = fillit.Rows[10][1].ToString();
            label12.Text = fillit.Rows[11][1].ToString();
            label13.Text = fillit.Rows[12][1].ToString();
            label14.Text = fillit.Rows[13][1].ToString();
            label15.Text = fillit.Rows[14][1].ToString();
            label16.Text = fillit.Rows[15][1].ToString();
            label25.Text = fillit.Rows[24][1].ToString();
            label26.Text = fillit.Rows[25][1].ToString();
            label27.Text = fillit.Rows[26][1].ToString();
            label28.Text = fillit.Rows[27][1].ToString();
            label29.Text = fillit.Rows[28][1].ToString();
            label30.Text = fillit.Rows[29][1].ToString();
            label31.Text = fillit.Rows[30][1].ToString();
            label32.Text = fillit.Rows[31][1].ToString();
            label17.Text = fillit.Rows[32][1].ToString();
            label18.Text = fillit.Rows[33][1].ToString();
            label19.Text = fillit.Rows[34][1].ToString();
            label20.Text = fillit.Rows[35][1].ToString();

        }


        private void fillTemps(double[] proccessValues)
        {
            try
            {
                textBox1.Text = proccessValues[0].ToString("0.0") + "\u00b0F";
                textBox2.Text = proccessValues[1].ToString("0.0") + "\u00b0F";
                textBox3.Text = proccessValues[2].ToString("0.0") + "\u00b0F";
                textBox4.Text = proccessValues[3].ToString("0.0") + "\u00b0F";
                textBox5.Text = proccessValues[4].ToString("0.0") + "\u00b0F";
                textBox6.Text = proccessValues[5].ToString("0.0") + "\u00b0F";
                textBox7.Text = proccessValues[6].ToString("0.0") + "\u00b0F";
                textBox8.Text = proccessValues[7].ToString("0.0") + "\u00b0F";
                textBox9.Text = proccessValues[8].ToString("0.0") + "\u00b0F";
                textBox10.Text = proccessValues[9].ToString("0.0") + "\u00b0F";
                textBox11.Text = proccessValues[10].ToString("0.0") + "\u00b0F";
                textBox12.Text = proccessValues[11].ToString("0.0") + "\u00b0F";
                textBox13.Text = proccessValues[12].ToString("0.0") + "\u00b0F";
                textBox14.Text = proccessValues[13].ToString("0.0") + "\u00b0F";
                textBox15.Text = proccessValues[14].ToString("0.0") + "\u00b0F";
                textBox16.Text = proccessValues[15].ToString("0.0") + "\u00b0F";

                for (int i = 0; i < 16; i++)
                {
                    procdValues[i] = proccessValues[i];
                }
                RXcount = 1;
            }
            catch (NullReferenceException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
                RXcount = 1;
            }

        }

        public void fillHumps(List<TempHumDew> humps)
        {
            try
            {
                textBox17.Text = humps[0].TempF.ToString("0.00") + "\u00b0F";
                procdValues[16] = humps[0].TempF;
                textBox18.Text = humps[0].RHT.ToString("0.00") + "%RH";
                procdValues[17] = humps[0].RHT;
                textBox19.Text = humps[1].TempF.ToString("0.00") + "\u00b0F";
                procdValues[18] = humps[1].TempF;
                textBox20.Text = humps[1].RHT.ToString("0.00") + "%RH";
                procdValues[19] = humps[1].RHT;
                textBox21.Text = humps[2].TempF.ToString("0.00") + "\u00b0F";
                procdValues[20] = humps[2].TempF;
                textBox22.Text = humps[2].RHT.ToString("0.00") + "%RH";
                procdValues[21] = humps[2].RHT;
                textBox23.Text = humps[3].TempF.ToString("0.00") + "\u00b0F";
                procdValues[22] = humps[3].TempF;
                textBox24.Text = humps[3].RHT.ToString("0.00") + "%RH";
                procdValues[23] = humps[3].RHT;


                textBox33.Text = humps[0].DewF.ToString("0.00") + "\u00b0F";
                textBox34.Text = humps[1].DewF.ToString("0.00") + "\u00b0F";
                textBox35.Text = humps[2].DewF.ToString("0.00") + "\u00b0F";
                textBox36.Text = humps[3].DewF.ToString("0.00") + "\u00b0F";
                RXcount = 4;
            }
            catch (NullReferenceException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
                RXcount = 1;
            }
        }

        private void fillAuxs(double[] auxArray)
        {
            try
            {
                textBox25.Text = auxArray[0].ToString("0.00");
                textBox26.Text = auxArray[1].ToString("0.00");
                textBox27.Text = auxArray[2].ToString("0.00");
                textBox28.Text = auxArray[3].ToString("0.00");
                textBox29.Text = auxArray[4].ToString("0.00");
                textBox30.Text = auxArray[5].ToString("0.00");
                textBox31.Text = auxArray[6].ToString("0.00");
                textBox32.Text = auxArray[7].ToString("0.00");

                for (int i = 0; i < 8; i++)
                {
                    procdValues[i + 24] = auxArray[i];
                }
                RXcount = 2;
            }
            catch (NullReferenceException e)
            {
                bool bReturnLog = false;

                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, e);

                if (false == bReturnLog)
                    MessageBox.Show("Unable to write a log");
                RXcount = 1;
            }
        }
        #endregion fill methods

 
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
            //rxData.Clear();
            setRelays[0] = 0x40;
            setRelays[1] = 0x50;
            setRelays[2] = 0x01;
            setRelays[3] = 0xf5;
            communicate(setRelays);
        }

        private void setRelay2()
        {
            //rxData.Clear();
            setRelays[0] = 0x40;
            setRelays[1] = 0x50;
            setRelays[2] = 0x02;
            setRelays[3] = 0xf5;
            communicate(setRelays);
        }

        private void setRelay3()
        {
            //rxData.Clear();
            setRelays[0] = 0x40;
            setRelays[1] = 0x50;
            setRelays[2] = 0x03;
            setRelays[3] = 0xf5;
            communicate(setRelays);
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comPort.IsOpen)
            {
                firstShot();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (RXcount == 1)
            {
                timer2.Enabled = false;
                //rxData.Clear();
                communicate(getAuxs);
                timer2.Enabled = true;
            }

            if (RXcount == 2)
            {
                timer2.Enabled = false;
                //rxData.Clear();
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
               // rxData.Clear();
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
            label22.Text = "Last Update-  " + DateTime.Now.ToString();
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
                if (!check.determine())
                {
                    if (button5.BackColor == Color.Green)
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
                if (!check.determine())
                {
                    if (button6.BackColor == Color.Green)
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
                if (!check.determine())
                {
                    if (button7.BackColor == Color.Green)
                    {
                        setRelay3();
                    }
                }
            }
        }

    }
}
