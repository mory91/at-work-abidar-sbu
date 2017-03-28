using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace at_work_abidar_sbu
{
    public interface Obstacle
    {
        double scalex { get; set; }
        double scaley { get; set; }
        Point start { get; set; }
        string Name { get;  }
        void draw(Bitmap scene);
    }
}
