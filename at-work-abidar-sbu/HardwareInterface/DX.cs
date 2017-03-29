using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dynamixel_sdk;
using FTD2XX_NET;

namespace at_work_abidar_sbu.HardwareInterface
{
    class DX
    {
        private string COMPort;
        int portHandle;

        public DX()
        {
            FTDI ftdi = new FTDI();

            ftdi.OpenBySerialNumber("A4012ADD");
        
            if (!ftdi.IsOpen)
                throw new Exception("Could not connect to Dynamixel");

            ftdi.GetCOMPort(out COMPort);

            ftdi.Close();

            portHandle = dynamixel.portHandler(COMPort);
        }

    }
}
