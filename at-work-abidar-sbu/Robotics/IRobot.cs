using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.HardwareAPI;

namespace at_work_abidar_sbu.Robotics
{
    interface IRobot
    {
        void Go(float dx, float dy);

        void Rotate(float degree);

        Point Center { get; set; }

        void ReadLaserValues();
        
        
        void End();
        float Width { get;  }
        float Hieght { get; }
        float LF { get; set; }
        float LL { get; set; }
        float RF { get; set; }
        float RR { get; set; }
        byte Speed { get; set; }
        bool IsMoving { get; }
        float Orientation { get; set;  }
    }
}
