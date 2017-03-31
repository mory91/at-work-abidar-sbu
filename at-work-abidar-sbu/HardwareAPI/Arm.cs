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

        public Arm()
        {
            dynamixel = DX.i;
            lastPosition = Position.Rest;
        }

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
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle3, 1100);
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle2, 1460);
                Thread.Sleep(1000);
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle1, 1500);
                Thread.Sleep(500);
                dynamixel.SetPositioinWithoutTof(Actuator.ArmPlate, 1976);
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle1, 2284);
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle2, 3542);
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle3, 1125);
                dynamixel.SetPositioinWithoutTof(Actuator.GripperRotate, 2150);
            }
            else if(lastPosition == Position.Grip)
            {
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle1, 2284);
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle2, 3542);
                dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle3, 1125);
            }
            lastPosition = Position.Camera;
        }

        public void GoToGripPosition()
        {
            dynamixel.SetPositionWithTof(Actuator.ArmMiddle1, 1921);
            dynamixel.SetPositionWithTof(Actuator.ArmMiddle2, 3409);
            dynamixel.SetPositionWithTof(Actuator.ArmMiddle3, 1272);
            lastPosition = Position.Grip;
        }

        public void GoToRestPosition()
        {
            dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle2, 1060);
            Thread.Sleep(1000);
            dynamixel.SetPositioinWithoutTof(Actuator.ArmPlate, 984);
            Thread.Sleep(1000);
            dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle3, 750);
            Thread.Sleep(1000);
            dynamixel.SetPositioinWithoutTof(Actuator.ArmMiddle1, 1094);
            Thread.Sleep(1000);
            dynamixel.SetPositioinWithoutTof(Actuator.GripperRotate, 2156);
            CloseGripper();
            lastPosition = Position.Rest;
        }

        public void GoToHoldPosition()
        {

        }

        public void GoToDropPosition()
        {

        }
    }
}
