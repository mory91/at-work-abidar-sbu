using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using at_work_abidar_sbu.HardwareInterface;

namespace at_work_abidar_sbu.HardwareAPI
{
    enum Orientation
    {
        Front,
        Rear,
        Left,
        Right
    }

    class Navigation
    {
        CentralBoard board;
        MotorControl motor;
        DX dynamixel;
        Thread NavigationThread;

        private bool running;
        private bool Moving;
        private bool move;

        private float xStartPoint;
        private float yStartPoint;

        private float xSetPoint;
        private float ySetPoint;

        private float xToMove;
        private float yToMove;

        private CentralBoard.Laser xLaser;
        private CentralBoard.Laser yLaser;

        private byte Speed;
        
        public Navigation()
        {
            board = new CentralBoard();
            motor = new MotorControl();
           // dynamixel = new DX();
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
            ushort CurrentLaserX = 0;
            ushort CurrentLaserY = 0;
            int xToSend = 0;
            int yToSend = 0;
            while(running)
            {
                if (xToMove == 0 && yToMove == 0)
                {
                    xToSend = 0;
                    yToSend = 0;
                }
                else if (xToMove != 0 && move)
                {
                    Thread.Sleep(300);
                    CurrentLaserX = board.GetLaserValue(xLaser);
                    if (Math.Abs(CurrentLaserX - xSetPoint) < 10 || CurrentLaserX < xSetPoint)
                    {
                        xStartPoint = 0;
                        xSetPoint = 0;
                        xToMove = 0;
                        CurrentLaserX = 0;
                        xToSend = 0;
                        move = false;
                        Moving = false;
                    }
                    else
                    {
                        xToSend = (xToMove > 0 ? Speed : -Speed);
                    }
                }
                else if (yToMove != 0 && move)
                {
                    Thread.Sleep(300);
                    CurrentLaserY = board.GetLaserValue(yLaser);
                    if (Math.Abs(CurrentLaserY - ySetPoint) < 10 || CurrentLaserY < ySetPoint)
                    {
                        yStartPoint = 0;
                        ySetPoint = 0;
                        yToMove = 0;
                        CurrentLaserY = 0;
                        yToSend = 0;
                        move = false;
                        Moving = false;
                    }
                    else
                    {
                        yToSend = (yToMove > 0 ? Speed : -Speed);
                    }
                }
                motor.SetDestination(xToSend, yToSend, 0);
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

                xStartPoint = 0;
                yStartPoint = 0;
                xSetPoint = 0;
                ySetPoint = 0;
                xToMove = 0;
                yToMove = 0;

                NavigationThread = new Thread(new ThreadStart(ThreadWorker));
                NavigationThread.Start();

                motor.SetDestination(0, 5, 0);
                Thread.Sleep(800);
                motor.SetDestination(0, 0, 0);
            }
        }

        public void End()
        {
            if (running)
            {
                motor.Stop();
                board.Stop();
                running = false;
                Moving = false;

                xStartPoint = 0;
                yStartPoint = 0;
                xSetPoint = 0;
                ySetPoint = 0;
                xToMove = 0;
                yToMove = 0;
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

            Moving = true;

            ///TODO: Rotate Lasers

            if(xCm >= 0)
            {
                xLaser = CentralBoard.Laser.Right;
                yLaser = CentralBoard.Laser.Left;
            }
            else
            {
                xLaser = CentralBoard.Laser.Left;
                yLaser = CentralBoard.Laser.Right;
            }

            xToMove = xCm;
            yToMove = yCm;

            Thread.Sleep(400);

            xStartPoint = board.GetLaserValue(xLaser);
            yStartPoint = board.GetLaserValue(yLaser);

            xSetPoint = xStartPoint + (xToMove > 0 ? -(xToMove * 10) : (xToMove * 10));
            ySetPoint = yStartPoint + (yToMove > 0 ? -(yToMove * 10) : (yToMove * 10));

            move = true;

        }

        public void Rotate(float degree)
        {
            if (Moving)
                return;

            Moving = true;
        }

    }
}
