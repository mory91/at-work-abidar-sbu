using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FTD2XX_NET;

namespace at_work_abidar_sbu.HardwareInterface
{
    public class CentralBoard
    {
        public enum LED
        {
            Left,
            Right
        }

        public enum Laser
        {
            Right,
            Left
        }

        public enum IR
        {
            Front,
            Rear,
            Left,
            Right,
            None
        }

        public enum BottomSensor
        {
            Left,
            Right
        }

        FTD2XX_NET.FTDI centralBoardCom;
        Thread DataReceiver;
        PropertyManager propertyManager;

        private byte[] toSend = new byte[4];
        private ushort[] IRSensorValue = new ushort[8];
        private bool[] BottomSensorValue = new bool[2];
        private ushort[] LaserValue = new ushort[2];
        private bool[] LaserError = new bool[2];
        private bool LeftLaserOn;
        private bool RightLaserOn;
        private bool running;
        private IR currentIr = IR.None;

        public CentralBoard()
        {
            centralBoardCom = new FTD2XX_NET.FTDI();
            propertyManager = PropertyManager.i;
            propertyManager.Load("Hardware");

            string SerialNumber = propertyManager.GetStringValue("Hardware", "CentralBoardSerialNumber");
            centralBoardCom.OpenBySerialNumber(SerialNumber);

            if (!centralBoardCom.IsOpen)
                throw new Exception("Could Not Connect to CentralBoard");

            centralBoardCom.SetBaudRate(38400);
            centralBoardCom.SetTimeouts(100, 1000);
        }

        ~CentralBoard()
        {
            if(centralBoardCom.IsOpen)
                centralBoardCom.Close();

            running = false;
        }

        private void FetchData()
        {
            while(running)
            {
                Read();
            }
        }

        private void Read()
        {
            byte[] packetStart = new byte[2];
            byte[] packetBody = new byte[10];
            uint read = 0;

            centralBoardCom.Read(packetStart, 2, ref read);

            if(packetStart[0] == 0xff && packetStart[1] == 0xff)    //Start of packet detected
            {
                centralBoardCom.Read(packetBody, 10, ref read);
//                Monitor.Enter(readLock);

                int sum = 0;

                for (int i = 0; i < 9; i++)
                    sum += packetBody[i];

                if ((byte)(sum & 0xff) != packetBody[9])
                    return;

                byte IRInfo = packetBody[8];

                Monitor.Enter(BottomSensorValue);
                BottomSensorValue[0] = ((IRInfo & 1) == 1 ? true : false);
                BottomSensorValue[1] = (((IRInfo >> 1) & 1) == 1 ? true : false);
                Monitor.Exit(BottomSensorValue);

                int IRChannel0Num = (IRInfo >> 2) & 7;
                int IRChannel1Num = (IRInfo >> 5) & 7;

                Monitor.Enter(IRSensorValue);
                IRSensorValue[IRChannel0Num] = (ushort)((packetBody[1] << 8) | packetBody[0]);
                IRSensorValue[IRChannel1Num] = (ushort)((packetBody[3] << 8) | packetBody[2]);
                Monitor.Exit(IRSensorValue);

                if (packetBody[4] == 0xFE && packetBody[5] == 0xFE)
                {
                    Monitor.Enter(LaserError);
                    LaserError[0] = true;
                    Monitor.Exit(LaserError);

                    Monitor.Enter(LaserValue);
                    LaserValue[0] = 0;
                    Monitor.Exit(LaserValue);
                }
                else
                {
                    Monitor.Enter(LaserError);
                    LaserError[0] = false;
                    Monitor.Exit(LaserError);

                    Monitor.Enter(LaserValue);
                    LaserValue[0] = (ushort)((packetBody[5] << 8) | packetBody[4]);
                    Monitor.Exit(LaserValue);
                }

                if (packetBody[6] == 0xFE && packetBody[7] == 0xFE)
                {
                    Monitor.Enter(LaserError);
                    LaserError[1] = true;
                    Monitor.Exit(LaserError);

                    Monitor.Enter(LaserValue);
                    LaserValue[1] = 0;
                    Monitor.Exit(LaserValue);
                }
                else
                {
                    Monitor.Enter(LaserError);
                    LaserError[1] = false;
                    Monitor.Exit(LaserError);

                    Monitor.Enter(LaserValue);
                    LaserValue[1] = (ushort)((packetBody[7] << 8) | packetBody[6]);
                    Monitor.Exit(LaserValue);
                }
                
            }
            else
            {
                centralBoardCom.Purge(FTDI.FT_PURGE.FT_PURGE_RX);
            }
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
            currentIr = direction;
            switch (direction)
            {
                case IR.Front:
                    toSend[2] = 62;
                    break;

                case IR.Rear:
                    toSend[2] = 26;
                    break;

                case IR.Left:
                    toSend[2] = 44;
                    break;

                case IR.Right:
                    toSend[2] = 8;
                    break;

                case IR.None:
                    toSend[2] = 0;
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
                LeftLaserOn = (select == Laser.Left ? true : false);
                RightLaserOn = (select == Laser.Right ? true : false);
            }
            else
            {
                toSend[1] = (byte)(toSend[1] & (~(int)Math.Pow(2, (select == Laser.Left ? 1 : 0))));
                LeftLaserOn = (select == Laser.Left ? false : true);
                RightLaserOn = (select == Laser.Right ? false : true);
            }
            send();
            send();
            send();
            send();
            send();
            send();
        }

        public void Start()
        {
            if(!running)
            {
                running = true;
                DataReceiver = new Thread(new ThreadStart(FetchData));
                DataReceiver.Name = "CentralBoardDataReceiver";
                DataReceiver.Start();
            }
        }

        public void Stop()
        {
            if (running)
            {
                running = false;
                toSend[1] = 0;
                toSend[2] = 0;
                send();
                send();
                send();
                send();
                send();
                send();
            }
        }

        public bool IsRunning()
        {
            return running;
        }

        public ushort GetLaserValue(Laser laser)
        {
            Monitor.Enter(LaserValue);
            var res = LaserValue[(int)laser];
            Monitor.Exit(LaserValue);
            return res;
        }

        public bool DoesLaserHaveError(Laser laser)
        {
            Monitor.Enter(LaserError);
            var res = LaserError[(int)laser];
            Monitor.Exit(LaserError);
            return res;
        }

        public Tuple<ushort, ushort> GetIRValue()
        {
            if (currentIr == IR.None)
                return null;

            Tuple<ushort, ushort> result;

            Monitor.Enter(IRSensorValue);
            switch(currentIr)
            {
                case IR.Right:
                    result = new Tuple<ushort, ushort>(IRSensorValue[0], IRSensorValue[1]);
                    break;
                case IR.Rear:
                    result = new Tuple<ushort, ushort>(IRSensorValue[2], IRSensorValue[3]);
                    break;
                case IR.Left:
                    result = new Tuple<ushort, ushort>(IRSensorValue[4], IRSensorValue[5]);
                    break;
                case IR.Front:
                    result = new Tuple<ushort, ushort>(IRSensorValue[6], IRSensorValue[7]);
                    break;
                default:
                    result = null;
                    break;
            }
            Monitor.Exit(IRSensorValue);
            
            return result;
        }

        public bool GetBottomValue(BottomSensor bottom)
        {
            Monitor.Enter(BottomSensorValue);
            var res = BottomSensorValue[(int)bottom];
            Monitor.Exit(BottomSensorValue);
            return res;
        }

    }
}
