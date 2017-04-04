using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.Robotics;

namespace at_work_abidar_sbu.Simulation
{
    class VirtualRobot : IRobot
    {
        private float ROBOT_SIZE = 44;
        private const int LASER_TO_SIDE = 7;
        private const int LASER_TO_FRONT = 2;
        public void Go(float dx, float dy)
        {

            Center.x += dx;
            Center.y += dy;
        }

        public void Rotate(float degree)
        {
            throw new NotImplementedException("Rotate Not Implemented in Simulation");
        }

        public Point Center { get; set; }

        public float Width
        {
            get { return ROBOT_SIZE; }
        }

        public float Hieght { get { return ROBOT_SIZE; } }
        public float LF { get; set; }
        public float LL { get; set; }
        public float RF { get; set; }
        public float RR { get; set; }
        public HardwareAPI.Orientation Orientation { get;  }
        public void ReadLaserValues()
        {
            
        }

        public void End()
        {
            
        }

        public byte Speed { get; set; }
        public bool IsMoving { get; set; }
    }
}
