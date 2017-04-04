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

        private int degree = 0;
        public void Rotate(float degree)
        {
            this.degree += (int)degree;
            this.degree %= 360;
            Navigation.i.Rotate(degree);
        }

        private Point _Center = new Point();
        public Point Center {
            get
            {

                //                ReadLaserValues();
                
                return _Center;
            }
            set { _Center = value; } 
        }
        public void ReadLaserValues()
        {
            var t = Navigation.i.GetDistanceSync(HardwareAPI.Orientation.N);
            LF = t.Item1 + ROBOT_SIZE / 2 - LASER_TO_FRONT;
            RF = t.Item2 + ROBOT_SIZE / 2 - LASER_TO_FRONT;

            t = Navigation.i.GetDistanceSync(HardwareAPI.Orientation.W);
            LL = t.Item1 + ROBOT_SIZE / 2 - LASER_TO_SIDE;
            RR = t.Item2 + ROBOT_SIZE / 2 - LASER_TO_SIDE;
            _Center.x = LL;
            _Center.y = (RF);

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
        public float Degree {
            get { return degree; } 
        }

        public void End()
        {
            Navigation.i.End();
        }

        public HardwareAPI.Orientation Orientation {
            get
            {
                if(degree >80 && degree < 100)
                    return  Orientation.E;
                if (degree > 170 && degree < 190)
                    return Orientation.S;
                if (degree > 260 && degree < 280)
                    return Orientation.W;
                if((degree < 10 && degree >= 0) || (degree > 350 && degree <= 360))
                    return Orientation.N;
                return Orientation.B;
                
            }
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
