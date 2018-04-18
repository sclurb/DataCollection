using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTD2XX_NET;

namespace DataCollection
{
    class FT232
    {
        public SerialPort comm = new SerialPort();
        FTDI myFtdiDevice = new FTDI();
        uint ftdiDeviceCount = 0;
        string[] deviceList = new string[7];
        FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
        public FT232()
        {

        }
        public string[] InitFTDI()
        {
            //FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;     // static
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);  //instance
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
                ftStatus = myFtdiDevice.GetCOMPort(out (COMnumber));
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    deviceList[5] = "Com Port huh?";
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
            ftStatus = myFtdiDevice.Close();
            PortSetUp();
            return deviceList;
        }
        public void PortSetUp()
        {
            comm.PortName = deviceList[5];
            comm.BaudRate = 9600;
            comm.DataBits = 8;
            comm.Parity = Parity.None;
            comm.StopBits = StopBits.One;
            comm.Open();
        }
    }
}
