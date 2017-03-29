using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dynamixel_sdk;
using FTD2XX_NET;

namespace at_work_abidar_sbu.HardwareInterface
{
    enum Instructions
    {
        GoalPosition = 0x1E,
        MovingSpeed = 0x20,
        GoalAcceleration = 0x49
    }
    class DX
    {
        private string COMPort;
        int portHandle;
        private static DX instance;

        private DX()
        {
            FTDI ftdi = new FTDI();

            ftdi.OpenBySerialNumber("A4012ADD");
        
            if (!ftdi.IsOpen)
                throw new Exception("Could not connect to Dynamixel");

            ftdi.GetCOMPort(out COMPort);

            ftdi.Close();

            portHandle = dynamixel.portHandler(COMPort);

            dynamixel.openPort(portHandle);
            dynamixel.setBaudRate(portHandle, 1000000);


            dynamixel.packetHandler();

            
        }

        ~DX()
        {
            dynamixel.closePort(portHandle);
        }

        public static DX i
        {
            get
            {
                if (instance == null)
                    instance = new DX();
                return instance;
            }
        }


        public void SetAcceleration(byte Motor, byte accel)
        {
            dynamixel.write1ByteTxRx(portHandle, 1, Motor, (ushort)Instructions.GoalAcceleration, accel);
        }

        public void SetSpeed(byte Motor, ushort speed)
        {
            dynamixel.write2ByteTxRx(portHandle, 1, Motor, (ushort)Instructions.MovingSpeed, speed);
        }

        public void SetPosition(byte Motor, ushort position)
        {
            dynamixel.write2ByteTxRx(portHandle, 1, Motor, (ushort)Instructions.GoalPosition, position);
        }
    }
}
