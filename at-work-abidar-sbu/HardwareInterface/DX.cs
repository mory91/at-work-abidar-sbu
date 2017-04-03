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
        private int portHandle;
        private static DX instance;
        private int group_num;      //For Sync Writing to Motors
        private int PositionTofFactor;

        private DX()
        {
            FTDI ftdi = new FTDI();

            PropertyManager.i.Load("Hardware");
            PropertyManager.i.Load("Dynamixel");
            ftdi.OpenBySerialNumber(PropertyManager.i.GetStringValue("Hardware","DynamixelSerialNumber"));
        
            if (!ftdi.IsOpen)
                throw new Exception("Could not connect to Dynamixel");

            ftdi.GetCOMPort(out COMPort);

            ftdi.Close();

            portHandle = dynamixel.portHandler(COMPort);

            dynamixel.openPort(portHandle);
            dynamixel.setBaudRate(portHandle, 1000000);

            dynamixel.packetHandler();

            SetSpeed(Actuator.ArmPlate,      (ushort)PropertyManager.i.GetIntValue("Dynamixel", "ArmPlateSpeed"));
            SetSpeed(Actuator.ArmMiddle1,    (ushort)PropertyManager.i.GetIntValue("Dynamixel", "ArmMiddle1Speed"));
            SetSpeed(Actuator.ArmMiddle2,    (ushort)PropertyManager.i.GetIntValue("Dynamixel", "ArmMiddle2Speed"));
            SetSpeed(Actuator.ArmMiddle3,    (ushort)PropertyManager.i.GetIntValue("Dynamixel", "ArmMiddle3Speed"));
            SetSpeed(Actuator.GripperRotate, (ushort)PropertyManager.i.GetIntValue("Dynamixel", "GripperRotateSpeed"));
            SetSpeed(Actuator.Gripper1,      (ushort)PropertyManager.i.GetIntValue("Dynamixel", "Gripper1Speed"));
            SetSpeed(Actuator.Gripper2,      (ushort)PropertyManager.i.GetIntValue("Dynamixel", "Gripper2Speed"));
            SetSpeed(Actuator.LeftLaser,     (ushort)PropertyManager.i.GetIntValue("Dynamixel", "LeftLaserSpeed"));
            SetSpeed(Actuator.RightLaser,    (ushort)PropertyManager.i.GetIntValue("Dynamixel", "RightLaserSpeed"));

            SetTorqueLimit(Actuator.Gripper1,(ushort)PropertyManager.i.GetIntValue("Dynamixel", "Gripper1TorqueLimit"));
            SetTorqueLimit(Actuator.Gripper2,(ushort)PropertyManager.i.GetIntValue("Dynamixel", "Gripper2TorqueLimit"));

            PositionTofFactor = PropertyManager.i.GetIntValue("Dynamixel", "PositionTofFactor");

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

        public void SetPositioinWithoutTof(Actuator act, ushort position)
        {
            dynamixel.write2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.GoalPosition, position);
        }

        public ushort GetCurrentPosition(Actuator act)
        {
            return dynamixel.read2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.PresentPosition);
        }

        public void SetPositionWithTof(Actuator act, ushort position)
        {
            ushort CurrentPosition = 0;
            CurrentPosition = dynamixel.read2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.PresentPosition);
            dynamixel.write2ByteTxRx(portHandle, 1, (byte)act, (ushort)Instructions.GoalPosition, position);
            while (Math.Abs(CurrentPosition - position) > PositionTofFactor)
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

        public void LasersPointForward()
        {
            group_num = dynamixel.groupSyncWrite(portHandle, 1, (byte)Instructions.GoalPosition, 2);
            dynamixel.groupSyncWriteAddParam(group_num, (byte)Actuator.LeftLaser, (ushort)208, 2);
            dynamixel.groupSyncWriteAddParam(group_num, (byte)Actuator.RightLaser, (ushort)820, 2);
            dynamixel.groupSyncWriteTxPacket(group_num);
            dynamixel.groupSyncWriteClearParam(group_num);
        }

        public void LasersPointSides()
        {
            group_num = dynamixel.groupSyncWrite(portHandle, 1, (byte)Instructions.GoalPosition, 2);
            dynamixel.groupSyncWriteAddParam(group_num, (byte)Actuator.LeftLaser, (ushort)511, 2);
            dynamixel.groupSyncWriteAddParam(group_num, (byte)Actuator.RightLaser, (ushort)511, 2);
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
