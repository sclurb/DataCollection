using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTD2XX_NET;
using System.Windows.Forms;

namespace DataCollectionCustomInstaller
{
    class FT232
    {
        public SerialPort comm = new SerialPort();
        FTDI myFtdiDevice = new FTDI();         // instance of the FTDI DLL class
        uint ftdiDeviceCount = 0;               // just to hold a property valsue
        string[] deviceList = new string[7];    // string aray that will hold pertinant information of the FTDI device
        FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK; // Static object used by some FTDI_2XX.dll
        public FT232()
        {

        }/// <summary>
        /// This method finds the FTDI device opens the device, writes all the pertinanlt information
        /// in a string[], closes the connection so that it may be opened in a MS SerialPort instance 
        /// and returns that string array to the caller.
        /// </summary>
        /// <returns></returns>
        public string[] InitFTDI()
        {
            //FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;     // static
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);  //instance, method changes uint by reference 
            if (ftdiDeviceCount > 0)
            {
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
                // Populate our device list
                ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);
                deviceList[0] = ftdiDeviceList[0].Type.ToString();
                deviceList[1] = ftdiDeviceList[0].ID.ToString();
                deviceList[2] = ftdiDeviceList[0].LocId.ToString();
                deviceList[3] = ftdiDeviceList[0].SerialNumber.ToString();
                deviceList[4] = ftdiDeviceList[0].Description.ToString();
                ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[0].SerialNumber);
                string COMnumber;
                ftStatus = myFtdiDevice.GetCOMPort(out (COMnumber));    // passes result by reference
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    deviceList[5] = "No Com Port";
                }
                else
                {
                    deviceList[5] = COMnumber;
                }
                ftStatus = myFtdiDevice.SetBaudRate(9600);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    deviceList[6] = "BaudRate not Set";
                }
                else
                {
                    deviceList[6] = "9600";
                }
            }
            ftStatus = myFtdiDevice.SetResetPipeRetryCount(150);


            ftStatus = myFtdiDevice.Close();
            if (deviceList[5] != null)
            {
                PortSetUp();
            }
            if (deviceList[5] == null)
            {
                MessageBox.Show("FTDI Chip not Found.   Have you connected the USB from the computer to the Temperature Board?");
            }
            return deviceList;
        }
        /// <summary>
        /// Gets called by InitFTDI to set port parametrs.
        /// </summary>
        public void PortSetUp()
        {
            comm.PortName = deviceList[5];
            comm.BaudRate = 9600;
            comm.DataBits = 8;
            comm.Parity = Parity.None;
            comm.StopBits = StopBits.One;
            comm.Open();
        }

        public bool ResetFtdi()
        {

            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);  //instance, method changes uint by reference
            if (ftdiDeviceCount > 0)
            {
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
                string SerNum = ftdiDeviceList[0].SerialNumber.ToString();
                ftStatus = myFtdiDevice.OpenBySerialNumber(SerNum);

                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    myFtdiDevice.CyclePort();

                    if (ftStatus == FTDI.FT_STATUS.FT_OK)
                    {
                        ftStatus = myFtdiDevice.Close();
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
