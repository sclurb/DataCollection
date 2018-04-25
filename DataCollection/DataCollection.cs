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
        private int zelda = 0;
        private delegate void DataIsReceived(byte[] rxTemp);
        private string[] InfoFTDI = new string[7];
        ArrayList rxData = new ArrayList();
        private int RXcount = 0;
        private byte[] getTemps = { 0x40, 0x10, 0xf5 };
        private byte[] getHumps = { 0x40, 0x20, 0xf5 };
        private byte[] getAuxs = { 0x40, 0x30, 0xf5 };
        //private SerialPort comPort = new SerialPort();
        FT232 comPort = new FT232();
        Crystal_LCD lcd = new Crystal_LCD();
        private double[] procdValues = new double[32];
        private double[] dews = new double[4];
        
        private byte[] setRelays = new byte[4];
        Timer timer1 = new Timer();     // sets the interval between data collection 450,000 = 7.5 minutes
        Timer timer2 = new Timer();     // sets  short delay to separate the data send commands

        public static bool set = false;


        public DataCollection()
        {
            InitializeComponent();
            InfoFTDI = comPort.InitFTDI();
            comPort.comm.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            timer1.Interval = 450000;   // specify interval time as you want
            timer2.Interval = 100;
            numCrunch crunch = new numCrunch();
            if(lcd.IsPresent == true)
            {
                lcd.Open();
            }
            
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
            FillLabels();
            timer1.Enabled = true;
            timer1.Start();
            InitCommunications();
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
        private void communicate(byte[] txString)
        {
            if (comPort.comm.IsOpen)
            {
                try
                {
                    comPort.comm.Write(txString, 0, txString.Length);
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
            
            if (comPort.comm.BytesToRead == 0)
            {
                return;
            }
            try
            {
                byte[] rxBuffer = new byte[comPort.comm.BytesToRead]; // Read the data from the port and store it in our buffer
                comPort.comm.Read(rxBuffer, 0, comPort.comm.BytesToRead);
                DataIsReceived d = new DataIsReceived(process);
                Invoke(d, new object[] { rxBuffer });
            }
            catch (Exception ex)
            {
                bool bReturnLog = false;
                ErrorLog.LogFilePath = "C:\\Data\\ErrorLogFile.txt";
                //false for writing log entry to customized text file
                bReturnLog = ErrorLog.ErrorRoutine(false, ex);
            }
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
            
            // Checking to see if rxdata is for temp sensors
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
            // checking to see if rxdata is for Humidity/temperature sensors
            if (tempArray[1] == 0x20 && tempArray.Length == 20)
            {
                zelda++;
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
                    lcd.ExtractStrings(humDew);
                    Trim trim = new Trim();
                    procdValues = trim.ProcessTrim(trim.GetValues(), procdValues);
                    FillAll(procdValues);
                    label33.Text = zelda.ToString();
                }
                rxData.Clear();
            }

            // checking to see if rxdata is for aux inputs
            if (tempArray[1] == 0x30 && tempArray.Length == 20)
            {
                
                if (tempArray[19] == 0)
                {
                    double[] auxArray = arrange.ArrangeAuxs(tempArray);
                    auxArray = arrange.ProcAuxs(auxArray);
                    fillAuxs(auxArray);
                }
                rxData.Clear();
                
            }

            // checking to see if information is for relays
            if (tempArray[1] == 0x50 && tempArray.Length == 7)
            {
                
                if (tempArray[6] == 0)
                {
                    DisplayRelayStatus(tempArray[2]);
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
                procdValues[16] = humps[0].TempF;
                procdValues[17] = humps[0].RHT;
                procdValues[18] = humps[1].TempF;
                procdValues[19] = humps[1].RHT;
                procdValues[20] = humps[2].TempF;
                procdValues[21] = humps[2].RHT;
                procdValues[22] = humps[3].TempF;
                procdValues[23] = humps[3].RHT;
                // The following displyed readings are derived and are not stored in the database.
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
        
        private void FillAll(double[] ProcessedValues)
        {
            textBox1.Text = ProcessedValues[0].ToString("0.0") + "\u00b0F";
            textBox2.Text = ProcessedValues[1].ToString("0.0") + "\u00b0F";
            textBox3.Text = ProcessedValues[2].ToString("0.0") + "\u00b0F";
            textBox4.Text = ProcessedValues[3].ToString("0.0") + "\u00b0F";
            textBox5.Text = ProcessedValues[4].ToString("0.0") + "\u00b0F";
            textBox6.Text = ProcessedValues[5].ToString("0.0") + "\u00b0F";
            textBox7.Text = ProcessedValues[6].ToString("0.0") + "\u00b0F";
            textBox8.Text = ProcessedValues[7].ToString("0.0") + "\u00b0F";
            textBox9.Text = ProcessedValues[8].ToString("0.0") + "\u00b0F";
            textBox10.Text = ProcessedValues[9].ToString("0.0") + "\u00b0F";
            textBox11.Text = ProcessedValues[10].ToString("0.0") + "\u00b0F";
            textBox12.Text = ProcessedValues[11].ToString("0.0") + "\u00b0F";
            textBox13.Text = ProcessedValues[12].ToString("0.0") + "\u00b0F";
            textBox14.Text = ProcessedValues[13].ToString("0.0") + "\u00b0F";
            textBox15.Text = ProcessedValues[14].ToString("0.0") + "\u00b0F";
            textBox16.Text = ProcessedValues[15].ToString("0.0") + "\u00b0F";
            textBox17.Text = ProcessedValues[16].ToString("0.00") + "\u00b0F";
            textBox18.Text = ProcessedValues[17].ToString("0.00") + "%RH";
            textBox19.Text = ProcessedValues[18].ToString("0.00") + "\u00b0F";
            textBox20.Text = ProcessedValues[19].ToString("0.00") + "%RH";
            textBox21.Text = ProcessedValues[20].ToString("0.00") + "\u00b0F";
            textBox22.Text = ProcessedValues[21].ToString("0.00") + "%RH";
            textBox23.Text = ProcessedValues[22].ToString("0.00") + "\u00b0F";
            textBox24.Text = ProcessedValues[23].ToString("0.00") + "%RH";
            textBox25.Text = ProcessedValues[24].ToString("0.00");
            textBox26.Text = ProcessedValues[25].ToString("0.00");
            textBox27.Text = ProcessedValues[26].ToString("0.00");
            textBox28.Text = ProcessedValues[27].ToString("0.00");
            textBox29.Text = ProcessedValues[28].ToString("0.00");
            textBox30.Text = ProcessedValues[29].ToString("0.00");
            textBox31.Text = ProcessedValues[30].ToString("0.00");
            textBox32.Text = ProcessedValues[31].ToString("0.00");
        }

        #endregion fill methods

 
        private void InitCommunications()
        {
            timer2.Enabled = false;
            rxData.Clear();
            communicate(getTemps);
            timer2.Enabled = true;
            timer2.Start();
        }
        private void DisplayRelayStatus(int relayStat)
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
            if (comPort.comm.IsOpen)
            {
                rxData.Clear();
                timer2.Interval = 100;
                communicate(getTemps);
                timer2.Enabled = true;
                timer2.Start();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (RXcount == 1)
            {
                timer2.Enabled = false;
                communicate(getAuxs);
                timer2.Enabled = true;
                timer2.Start();
            }

            if (RXcount == 2)
            {
                timer2.Enabled = false;
                setRelays[0] = 0x40;
                setRelays[1] = 0x50;
                setRelays[2] = 0xff;
                setRelays[3] = 0xf5;
                communicate(setRelays);
                timer2.Enabled = true;
                timer2.Start();
            }
            if (RXcount == 3)
            {
                timer2.Interval = 1500;
                timer2.Enabled = false;
                communicate(getHumps);
                timer2.Enabled = true;
                timer2.Start();
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
