using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FTD2XX_NET;

namespace at_work_abidar_sbu.HardwareInterface
{
    class MotorControl
    {
        private enum Commands       //MD49 Commands
        {
            GET_SPEED1 = 0x21,
            GET_SPEED2,
            GET_ENCODER1,
            GET_ENCODER2,
            GET_ENCODERS,
            GET_VOLTS,
            GET_CURRENT1,
            GET_CURRENT2,
            GET_VERSION,
            GET_ACCELERATION,
            GET_MODE,
            GET_VI,
            GET_ERROR,
            SET_SPEED1 = 0x31,
            SET_SPEED2,
            SET_ACCELERATION,
            SET_MODE,
            RESET_ENCODERS,
            DISABLE_REGULATOR,
            ENABLE_REGULATOR,
            DISABLE_TIMEOUT,
            ENABLE_TIMEOUT
        }
        public enum Motors
        {
            FrontLeft,
            FrontRight,
            RearLeft,
            RearRight
        }

        private const uint FrontLocationID = 531;
        private const uint RearLocationID = 18;
        private const byte SYNC_BYTE = 0x00;

        private byte[] toSend = new byte[3]; //Maximum Length of packets is 3
        private byte[] MotorSpeed = { 128, 128, 128, 128 };    //4 motors and 4 encoders, Stop Value is 128
        private int[] EncodersValue = new int[4];

        FTDI frontFTDI;
        FTDI rearFTDI;
        Thread PacketSender;

        public MotorControl()
        {
            frontFTDI = new FTDI();
            rearFTDI = new FTDI();

            frontFTDI.OpenByLocation(FrontLocationID);
            rearFTDI.OpenByLocation(RearLocationID);

            if (!frontFTDI.IsOpen)
                throw new Exception("Could Not Connect to Front Motor Controller");

            if(!rearFTDI.IsOpen)
               throw new Exception("Could Not Connect to Rear Motor Controller");

            frontFTDI.SetBaudRate(38400);
            rearFTDI.SetBaudRate(38400);

            PacketSender = new Thread(new ThreadStart(SendSpeedReceiveEncoder));
            PacketSender.Start();
        }

        private void SetSpeed(Motors mot, byte value)
        {
            toSend[0] = SYNC_BYTE;
            toSend[2] = value;

            uint written = 0;

            switch (mot)
            {
                case Motors.FrontLeft:
                    toSend[1] = (byte)Commands.SET_SPEED1;
                    frontFTDI.Write(toSend, 3, ref written);
                    break;

                case Motors.FrontRight:
                    toSend[1] = (byte)Commands.SET_SPEED2;
                    frontFTDI.Write(toSend, 3, ref written);
                    break;

                case Motors.RearLeft:
                    toSend[1] = (byte)Commands.SET_SPEED2;
                    rearFTDI.Write(toSend, 3, ref written);
                    break;

                case Motors.RearRight:
                    toSend[1] = (byte)Commands.SET_SPEED1;
                    rearFTDI.Write(toSend, 3, ref written);
                    break;
            }
        }

        private void UpdateEncoderValue()
        {
            toSend[0] = SYNC_BYTE;
            toSend[1] = (byte)Commands.GET_ENCODERS;

            uint read = 0;
            uint written = 0;

            byte[] mot1 = new byte[4];
            byte[] mot2 = new byte[4];

            frontFTDI.Write(toSend, 2, ref written);

            frontFTDI.Read(mot2, 4, ref read);
            frontFTDI.Read(mot1, 4, ref read);

            EncodersValue[(int)Motors.FrontRight] = (mot1[0] << 24);
            EncodersValue[(int)Motors.FrontRight] |= (mot1[1] << 16);
            EncodersValue[(int)Motors.FrontRight] |= (mot1[2] << 8);
            EncodersValue[(int)Motors.FrontRight] |= (mot1[3]);

            EncodersValue[(int)Motors.FrontLeft] = (mot2[0] << 24);
            EncodersValue[(int)Motors.FrontLeft] |= (mot2[1] << 16);
            EncodersValue[(int)Motors.FrontLeft] |= (mot2[2] << 8);
            EncodersValue[(int)Motors.FrontLeft] |= (mot2[3]);

            rearFTDI.Write(toSend, 2, ref written);

            rearFTDI.Read(mot1, 4, ref read);
            rearFTDI.Read(mot2, 4, ref read);

            EncodersValue[(int)Motors.RearRight] = (mot1[0] << 24);
            EncodersValue[(int)Motors.RearRight] |= (mot1[1] << 16);
            EncodersValue[(int)Motors.RearRight] |= (mot1[2] << 8);
            EncodersValue[(int)Motors.RearRight] |= (mot1[3]);

            EncodersValue[(int)Motors.RearLeft] = (mot2[0] << 24);
            EncodersValue[(int)Motors.RearLeft] |= (mot2[1] << 16);
            EncodersValue[(int)Motors.RearLeft] |= (mot2[2] << 8);
            EncodersValue[(int)Motors.RearLeft] |= (mot2[3]);
        }

        private void SendSpeedReceiveEncoder()
        {
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    SetSpeed((Motors)i, MotorSpeed[i]);
                }
                UpdateEncoderValue();
                Thread.Sleep(100);
            }
        }

        public void ResetEncoder()
        {
            toSend[0] = SYNC_BYTE;
            toSend[1] = (byte)Commands.RESET_ENCODERS;

            uint written = 0;

            frontFTDI.Write(toSend, 2, ref written);
            rearFTDI.Write(toSend, 2, ref written);

            for (int i = 0; i < 4; i++)
                EncodersValue[i] = 0;
        }

        public void SetVal(Motors mot, byte Value)
        {
            if (mot == Motors.FrontRight || mot == Motors.FrontLeft)
            {
                MotorSpeed[(int)mot] = (byte)(128 - Value);
                return;
            }
            MotorSpeed[(int)mot] = (byte)(128 + Value);

        }

        public void SetDestination(int x, int y)
        {
            SetVal(Motors.FrontLeft, (byte)(-(y - x)));
            SetVal(Motors.FrontRight, (byte)(-(y + x)));
            SetVal(Motors.RearRight, (byte)(x - y));
            SetVal(Motors.RearLeft, (byte)(-(y + x)));
        }
    }
}
