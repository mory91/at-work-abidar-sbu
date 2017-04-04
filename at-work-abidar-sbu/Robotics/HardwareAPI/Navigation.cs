using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using at_work_abidar_sbu.HardwareInterface;

namespace at_work_abidar_sbu.HardwareAPI
{
    public enum Orientation
    {
        N,
        E,
        S,
        W,
        B
    }

    public class Navigation
    {
        CentralBoard board;
        MotorControl motor;
        DX dynamixel;
        Thread NavigationThread;

        private bool running;
        private bool Moving;

        int desiredEncoderValue;
        MotorControl.Motors encoderToWatch;
        
        private byte Speed;
        private static Navigation instance;

        public static Navigation i
        {
            get
            {
                if (instance == null)
                {
                    instance = new Navigation();
                    instance.Initialize();
                }
                    
                return instance;
            }
        }

        private Navigation()
        {
            board = new CentralBoard();
            motor = new MotorControl();
            dynamixel = DX.i;
            running = false;
            Moving = false;
            Speed = 0;
        }

        ~Navigation()
        {
            End();
        }

        private void ThreadWorker()
        {
            while(running)
            {
                if(Moving)
                {
                    int CurrentEncoderValue = motor.GetEncoderValue(encoderToWatch);
                    if ((desiredEncoderValue > 0 && CurrentEncoderValue > desiredEncoderValue) || (desiredEncoderValue < 0 && CurrentEncoderValue < desiredEncoderValue))
                    {
                        Moving = false;
                        desiredEncoderValue = 0;
                        motor.SetDestination(0, 0, 0);
                    }
                }
            }
        }

        public void Initialize()
        {
            if (!running)
            {
                board.SelectLaser(true, CentralBoard.Laser.Left);
                board.SelectLaser(true, CentralBoard.Laser.Right);

                motor.Start();
                board.Start();
                running = true;
                Moving = false;

                NavigationThread = new Thread(new ThreadStart(ThreadWorker));
                NavigationThread.Name = "NavigationThread";
                NavigationThread.Start();
            }
        }

        public void End()
        {
            if (running)
            {
                board.SelectLaser(false, CentralBoard.Laser.Left);
                board.SelectLaser(false, CentralBoard.Laser.Right);
                motor.Stop();
                board.Stop();
                running = false;
                Moving = false;
            }
        }

        public bool IsRunning()
        {
            return running;
        }

        public bool IsMoving()
        {
            return Moving;
        }

        public void SetSpeed(byte speed)
        {
            this.Speed = speed;
        }

        public void Go(float xCm, float yCm)
        {
            if (Moving)
                return;

            motor.ResetEncoder();

            if (xCm == 0 && yCm == 0)
                return;

            desiredEncoderValue = (int)(xCm != 0 ? xCm : yCm) * (998 / 32);

            encoderToWatch = MotorControl.Motors.FrontLeft;

            if ((xCm < 0 && yCm > 0) || (xCm > 0 && yCm < 0))
            {
                desiredEncoderValue = (int)(desiredEncoderValue * 1.414213562373);
                encoderToWatch = MotorControl.Motors.FrontRight;
                desiredEncoderValue *= -1;
            }
            else if((xCm < 0 && yCm < 0) || (xCm > 0 && yCm > 0))
            {
                desiredEncoderValue = (int)(desiredEncoderValue * 1.414213562373);
            }

            int xSpeed = (xCm > 0 ? Speed : -Speed);
            int ySpeed = (yCm > 0 ? Speed : -Speed);

            if (xCm == 0)
                xSpeed = 0;

            if (yCm == 0)
                ySpeed = 0;

            motor.SetDestination(xSpeed, ySpeed, 0);

            Moving = true;
        }

        public void Rotate(float degree)
        {
            if (Moving)
                return;

            motor.ResetEncoder();

            if (degree == 0)
                return;

            desiredEncoderValue = (int)(degree * (630 / 35));

            encoderToWatch = MotorControl.Motors.FrontLeft;

            int wSpeed = (degree > 0 ? 2 : -2);

            motor.SetDestination(0, 0, wSpeed);

            Moving = true;
        }

        public float GetDistance(Orientation or, CentralBoard.Laser laser)
        {
            float result = 0.0f;

            switch(or)
            {
                case Orientation.N:
                    switch(laser)
                    {
                        case CentralBoard.Laser.Left:
                            dynamixel.SetPositionWithoutTof(Actuator.LeftLaser, 208);
                            break;

                        case CentralBoard.Laser.Right:
                            dynamixel.SetPositionWithoutTof(Actuator.RightLaser, 820);
                            break;
                    }
                    break;
                case Orientation.W:
                    switch (laser)
                    {
                        case CentralBoard.Laser.Left:
                            dynamixel.SetPositionWithoutTof(Actuator.LeftLaser, 511);
                            break;

                        case CentralBoard.Laser.Right:
                            dynamixel.SetPositionWithoutTof(Actuator.RightLaser, 511);
                            break;
                    }
                    break;
                case Orientation.E:
                    switch (laser)
                    {
                        case CentralBoard.Laser.Left:
                            dynamixel.SetPositionWithoutTof(Actuator.LeftLaser, 511);
                            break;

                        case CentralBoard.Laser.Right:
                            dynamixel.SetPositionWithoutTof(Actuator.RightLaser, 511);
                            break;
                    }
                    break;
            }

            Thread.Sleep(2000);

            result = board.GetLaserValue(laser) / 10;


            return result;
        }

        public Tuple<float, float> GetDistanceSync(Orientation or)
        {
            if (or == Orientation.N)
            {
                dynamixel.LasersPointForward();
            }
            else
            {
                dynamixel.LasersPointSides();
            }

            Thread.Sleep(2000);

            Tuple<float, float> res = new Tuple<float, float>(board.GetLaserValue(CentralBoard.Laser.Left) / 10, board.GetLaserValue(CentralBoard.Laser.Right) / 10);

            return res;
        }

    }
}
