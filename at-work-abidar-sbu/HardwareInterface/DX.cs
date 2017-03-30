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
        GoalAcceleration = 0x49,
        TorqueLimit = 0x22,
        PresentPosition = 0x24
    }

    enum Actuator
    {
        ArmPlate = 1,
        ArmMiddle1,
        ArmMiddle2,
        ArmMiddle3,
        GripperRotate,
        Gripper1,
        Gripper2,
        FrontCameraLR = 12,
        FrontCameraUD,
        RightLaser,
        LeftLaser
    }

    class DX
    {
        private string COMPort;
        int portHandle;
        private static DX instance;
        private const ushort Speed = 100;

        int group_num;

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

            foreach(Actuator act in Enum.GetValues(typeof(Actuator)))
            {
                SetSpeed(act, Speed);
            }

            SetSpeed(Actuator.ArmPlate, 50);
            SetSpeed(Actuator.Gripper1, 300);
            SetSpeed(Actuator.Gripper2, 300);
            SetSpeed(Actuator.LeftLaser, 300);
            SetSpeed(Actuator.RightLaser, 300);

            SetTorqueLimit(Actuator.Gripper1, 250);
            SetTorqueLimit(Actuator.Gripper2, 250);

            
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

        public void SetAcceleration(Actuator act, byte accel)
        {
            dynamixel.write1ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.GoalAcceleration, accel);
        }

        public void SetSpeed(Actuator act, ushort speed)
        {
            dynamixel.write2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.MovingSpeed, speed);
        }

        public void SetPosition(Actuator act, ushort position)
        {
            ushort CurrentPosition = 0;
            CurrentPosition = dynamixel.read2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.PresentPosition);
            dynamixel.write2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.GoalPosition, position);
            while (Math.Abs(CurrentPosition - position) > 100)
            {
                CurrentPosition = dynamixel.read2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.PresentPosition);
            }
            dynamixel.write2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.GoalPosition, CurrentPosition);
        }

        public void SetTorqueLimit(Actuator act, ushort torque)
        {
            dynamixel.write2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.TorqueLimit, torque);
        }

        public void OpenGripper()
        {
            group_num = dynamixel.groupSyncWrite(portHandle, 1, (byte)Instructions.GoalPosition, 2); 
            dynamixel.groupSyncWriteAddParam(group_num, (byte)Actuator.Gripper1, (ushort)1361, 2);
            dynamixel.groupSyncWriteAddParam(group_num, (byte)Actuator.Gripper2, (ushort)2536, 2);
            dynamixel.groupSyncWriteTxPacket(group_num);
            dynamixel.groupSyncWriteClearParam(group_num);
        }

        public void CloseGripper()
        {
            group_num = dynamixel.groupSyncWrite(portHandle, 1, (byte)Instructions.GoalPosition, 2);
            dynamixel.groupSyncWriteAddParam(group_num, (byte)Actuator.Gripper1, (ushort)2104, 2);
            dynamixel.groupSyncWriteAddParam(group_num, (byte)Actuator.Gripper2, (ushort)1759, 2);
            dynamixel.groupSyncWriteTxPacket(group_num);
            dynamixel.groupSyncWriteClearParam(group_num);
        }

        public static ushort FrontAngleConverter(float degree)
        {
            return (ushort)(degree * (1023 / 300));
        }

        public static ushort RearAngleConverter(float degree)
        {
            return (ushort)(degree * (4096 / 360));
        }
    }
}
