using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.HardwareInterface;

namespace at_work_abidar_sbu.HardwareAPI
{
    class Arm
    {
        DX dynamixel;

        public Arm()
        {
            dynamixel = DX.i;
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
            
        }

        public void GoToGripPosition()
        {

        }
    }
}
