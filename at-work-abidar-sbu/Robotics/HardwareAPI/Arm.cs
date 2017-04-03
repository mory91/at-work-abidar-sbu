using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using at_work_abidar_sbu.HardwareInterface;

namespace at_work_abidar_sbu.HardwareAPI
{
    class Arm
    {
        DX dynamixel;
        enum Position
        {
            Rest,
            Camera,
            Grip,
            Hold,
            Drop
        }

        Position lastPosition;

        private Arm()
        {
            dynamixel = DX.i;
            lastPosition = Position.Rest;
            GoToRestPosition();
        }

        private static Arm instance;
        public static Arm i => instance ?? (instance = new Arm());


        public void OpenGripper()
        {
            dynamixel.OpenGripper();
        }

        public void CloseGripper()
        {
            dynamixel.CloseGripper();
        }

        public void GoToCameraPosition()
        {
            if (lastPosition == Position.Rest)
            {
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle3, 1100);
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle2, 1460);
                Thread.Sleep(1000);
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle1, 1500);
                Thread.Sleep(500);
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle1, 2284);
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle2, 3542);
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle3, 1125);
                Thread.Sleep(500);
                TurnArmPlate(180);
                TurnGripper(180);
            }
            else if(lastPosition == Position.Grip)
            {
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle1, 2284);
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle2, 3542);
                dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle3, 1125);
            }
            lastPosition = Position.Camera;
        }

        public void GoToGripPosition()
        {
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle2, 3330);
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle3, 1237);
            Thread.Sleep(100);
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle1, 1921);
            lastPosition = Position.Grip;
        }

        public void GoToRestPosition()
        {
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle2, 1060);
            Thread.Sleep(1000);
            TurnArmPlate(90);
            Thread.Sleep(1000);
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle3, 750);
            Thread.Sleep(1000);
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle1, 1094);
            Thread.Sleep(1000);
            TurnGripper(180);
            CloseGripper();
            lastPosition = Position.Rest;
        }

        public bool GripperGrabbedObject()
        {
            int Gripper1Pos = dynamixel.GetCurrentPosition(Actuator.Gripper1);
            int Gripper2Pos = dynamixel.GetCurrentPosition(Actuator.Gripper2);

            if (Gripper1Pos < 2050 && Gripper2Pos > 1800)
                return true;
            else
                return false;
        }

        public void TurnArmPlate(float degree)
        {
            degree -= 3F;
            dynamixel.SetPositionWithoutTof(Actuator.ArmPlate, DX.RearAngleConverter(degree));
        }

        public void TurnGripper(float degree)
        {
            degree += 15F;
            dynamixel.SetPositionWithoutTof(Actuator.GripperRotate, DX.RearAngleConverter(degree));
        }

        public void GoToHoldPosition()
        {

        }

        public void GoToDropPosition()
        {
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle2, 3200);
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle3, 1100);
            Thread.Sleep(100);
            dynamixel.SetPositionWithoutTof(Actuator.ArmMiddle1, 1921);
            lastPosition = Position.Grip;
        }
    }
}
