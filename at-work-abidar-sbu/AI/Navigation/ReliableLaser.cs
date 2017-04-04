using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atwork_pb_msgs;
using at_work_abidar_sbu.Robotics;

namespace at_work_abidar_sbu.AI.Navigation
{
    class ReliableLaser
    {
        private IRobot robot;

        public ReliableLaser(IRobot robot)
        {
            this.robot = robot;
        }
        
//        public double getLL()
//        {
//            robot.ReadLaserValues();
//        }
    }
}
