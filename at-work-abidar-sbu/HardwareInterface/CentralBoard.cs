using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTD2XX_NET;

namespace at_work_abidar_sbu.HardwareInterface
{
    enum LED
    {
        Left,
        Right
    }

    enum Laser
    {
        Right,
        Left
    }

    enum IR
    {
        Front,
        Rear,
        Left,
        Right,
        Bottom
    }

    class CentralBoard
    {
        FTD2XX_NET.FTDI centralBoardCom;
        private byte[] toSend = new byte[4];

        public CentralBoard()
        {
            centralBoardCom = new FTD2XX_NET.FTDI();
            string SerialNumber = "AL00F509";
            centralBoardCom.OpenBySerialNumber(SerialNumber);

            if (!centralBoardCom.IsOpen)
                throw new Exception("Could Not Connect to CentralBoard");

            centralBoardCom.SetBaudRate(38400);
        }

        private void send()
        {
            uint written = 0;
            toSend[0] = 0xFF;
            toSend[3] = (byte)checksum();
            centralBoardCom.Write(toSend, 4, ref written);
        }

        private int checksum()
        {
            return (toSend[1] + toSend[2]) & 0xff;
        }

        public void LEDControl(LED select, uint color)
        {
            switch(select)
            {
                case LED.Left:
                    toSend[1] = (byte)(toSend[1] & 227);
                    toSend[1] = (byte)(toSend[1] | (color << 2));
                    break;

                case LED.Right:
                    toSend[1] = (byte)(toSend[1] & 31);
                    toSend[1] = (byte)(toSend[1] | (color << 5));
                    break;
            }
            send();
            send();
            send();
            send();
            send();
            send();
        }

        public void SetIRSensor(IR direction)
        {
            toSend[2] = 0;
            toSend[1] = 0;
            switch (direction)
            {
                case IR.Front:
                    toSend[2] = 8;
                    break;

                case IR.Rear:
                    toSend[2] = 26;
                    break;

                case IR.Left:
                    toSend[2] = 44;
                    break;

                case IR.Right:
                    toSend[2] = 62;
                    break;
            }
            send();
            send();
            send();
            send();
            send();
            send();
        }

        public void SelectLaser(bool PowerOn, Laser select)
        {
            if(PowerOn)
            {
                toSend[1] = (byte)(toSend[1] | (int)Math.Pow(2, (select == Laser.Left ? 1 : 0)));
            }
            else
            {
                toSend[1] = (byte)(toSend[1] & (~(int)Math.Pow(2, (select == Laser.Left ? 1 : 0))));
            }
            send();
            send();
            send();
            send();
            send();
            send();
        }

    }
}
