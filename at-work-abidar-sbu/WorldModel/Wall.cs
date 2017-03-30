using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu
{
    class Wall //: Obstacle
    {
        public System.Drawing.Point start { get; set; }
        public System.Drawing.Point end { get; set; }
        public double scalex { get; set; }
        public double scaley { get; set; }

        public string Name
        {
            get
            {
                return ToString();
            }
        }
        
        public void draw(Bitmap scene)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            // Draw line to screen.
            using (var graphics = Graphics.FromImage(scene))
            {
                graphics.DrawLine(blackPen, (int)(start.X * scalex), (int)(start.Y * scaley),(int)(end.X * scalex), (int)(end.Y * scaley));
            }
        }
    }
}
