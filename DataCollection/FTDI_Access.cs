using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTD2XX_NET;
using System.IO.Ports;
using static FTD2XX_NET.FTDI;
using FT_HANDLE = System.UInt32;
using System.Windows.Forms;

namespace DataCollectionCustomInstaller
{
    public class FTDI_Access
    {
        private string port1Description;
        private string port1SerNum;
        private string port1LocId;
        private string port1ComPort;
        private bool tempHumPresent = false;

        private string port2Description;
        private string port2SerNum;
        private string port2LocId;
        private string port2ComPort;
        private bool lcdPresent = false;
        FTDI initial = new FTDI();

        public FTDI board = new FTDI();
        public FTDI display = new FTDI();

        uint deviceCount = 0;
        FT_STATUS ftStatus = FT_STATUS.FT_OK;
        public FT_DEVICE_INFO_NODE[] AllDevices;

        public FTDI_Access()
        {
            FindFTDI();
            ProcessFTDIInfo(deviceCount);
        }
        #region properties
        public string Port1Description
        {
            get
            {
                return port1Description;
            }
        }

        public string Port1SerNum
        {
            get
            {
                return port1SerNum;
            }
        }

        public string Port1LocId
        {
            get
            {
                return port1LocId;
            }
        }
        public string Port1ComPort
        {
            get
            {
                return port1ComPort;
            }
        }

        public string Port2Description
        {
            get
            {
                return port2Description;
            }
        }

        public string Port2SerNum
        {
            get
            {
                return port2SerNum;
            }
        }

        public string Port2LocId
        {
            get
            {
                return port2LocId;
            }
        }
        public string Port2ComPort
        {
            get
            {
                return port1ComPort;
            }
        }

        public bool LcdPresent
        {
            get
            {
                return lcdPresent;
            }
        }

        public bool TempHumPresent
        {
            get
            {
                return tempHumPresent;
            }
        }
        #endregion

        public void FindFTDI()
        {
            ftStatus = initial.GetNumberOfDevices(ref deviceCount);
        }
        /// <summary>
        /// This method is called via the constructor for this class.   
        /// This method 
        /// </summary>
        /// <param name="_deviceCount"></param>
        public void ProcessFTDIInfo(uint _deviceCount)
        {
            if(_deviceCount == 0)
            {
                MessageBox.Show("No USB Devices Found");               
                return;
            }
            AllDevices = new FT_DEVICE_INFO_NODE[_deviceCount];
            ftStatus = initial.GetDeviceList(AllDevices);

            for(int i = 0; i < _deviceCount; i++)
            {
                if (AllDevices[i].Description == "Crystalfontz CFA634-USB LCD")
                {
                    port2Description = AllDevices[i].Description;
                    port2SerNum = AllDevices[i].SerialNumber;
                    port2LocId = AllDevices[i].LocId.ToString();
                    lcdPresent = true;
                }
                if (AllDevices[i].Description == "FT245R USB FIFO")
                {
                    port1Description = AllDevices[i].Description;
                    port1SerNum = AllDevices[i].SerialNumber;
                    port1LocId = AllDevices[i].LocId.ToString();
                    tempHumPresent = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool OpenByDescription(string description)
        {
            if (port1Description == description)
            {
                ftStatus = board.OpenByDescription(description);
                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    ftStatus = board.SetResetPipeRetryCount(150);
                    if(ftStatus == FT_STATUS.FT_OK)
                    {
                        ftStatus = board.GetCOMPort(out port1ComPort);
                        if (ftStatus == FT_STATUS.FT_OK)
                        {
                            return true;
                        }
                    }
                }
            }

            if (port2Description == description)
            {
                ftStatus = display.OpenByDescription(description);
                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    ftStatus = display.SetBaudRate(19200);
                    {
                        if (ftStatus == FT_STATUS.FT_OK)
                        {
                            ftStatus = display.GetCOMPort(out port2ComPort);
                            if (ftStatus == FT_STATUS.FT_OK)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool CyclePort(string check)
        {
            if (check == "display")
            {
                if (!display.IsOpen)
                {
                    ftStatus = display.OpenByDescription(port2Description);
                }
                if (display.IsOpen)
                {
                    ftStatus = display.CyclePort();
                    if (ftStatus == FT_STATUS.FT_OK)
                    {
                        return true;
                    }
                }
            }
            if (check == "board")
            {
                if (!board.IsOpen)
                {
                    ftStatus = board.OpenByDescription(port1Description);
                }
                if (board.IsOpen)
                {
                    ftStatus = board.CyclePort();
                    if (ftStatus == FT_STATUS.FT_OK)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
