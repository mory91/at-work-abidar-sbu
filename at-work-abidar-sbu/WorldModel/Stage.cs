using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu
{
    class Stage //: Obstacle
    {
        public string name { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public System.Drawing.Point start { get; set; }
        public double scalex { get; set; }
        public double scaley { get; set; }

        
        public void draw(Bitmap scene)
        {
            using (Graphics gr = Graphics.FromImage(scene))
            {
                
            }
        }
    }
}
