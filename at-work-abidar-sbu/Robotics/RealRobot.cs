using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.HardwareAPI;

namespace at_work_abidar_sbu.Robotics
{
    class RealRobot : IRobot
    {
        private float ROBOT_SIZE = 44;
        private const int LASER_TO_SIDE = 7;
        private const int LASER_TO_FRONT = 2;

        public void Go(float dx, float dy)
        {
            Navigation.i.Go((float)(dx), (float)(dy));
        }

        public void Rotate(float degree)
        {
            Navigation.i.Rotate(degree);
        }

        private Point _Center = new Point();
        public Point Center {
            get
            {

                //                ReadLaserValues();
                _Center.x = LL;
                _Center.y = (RF);
                return _Center;
            }
            set { _Center = value; } 
        }
        public void ReadLaserValues()
        {
            var t = Navigation.i.GetDistanceSync(HardwareAPI.Orientation.Front);
            LF = t.Item1 + ROBOT_SIZE / 2 - LASER_TO_FRONT;
            RF = t.Item2 + ROBOT_SIZE / 2 - LASER_TO_FRONT;

            t = Navigation.i.GetDistanceSync(HardwareAPI.Orientation.Left);
            LL = t.Item1 + ROBOT_SIZE / 2 - LASER_TO_SIDE;
            RR = t.Item2 + ROBOT_SIZE / 2 - LASER_TO_SIDE;

        }

        public float Width {
            get { return ROBOT_SIZE; } 
        }
        public float Hieght {
            get { return ROBOT_SIZE; } 
        }
        public float LF { get; set; }
        public float LL { get; set; }
        public float RF { get; set; }
        public float RR { get; set; }
        public float Orientation { get; set; }
        public void End()
        {
            Navigation.i.End();
        }

        private byte _Speed;
        public byte Speed {
            get { return _Speed; }
            set
            {
                Navigation.i.SetSpeed(value);
                _Speed = value;
            } 
        }
        public bool IsMoving {
            get { return Navigation.i.IsMoving(); } 
        }
    }
}
