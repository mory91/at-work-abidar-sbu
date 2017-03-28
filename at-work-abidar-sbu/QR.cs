using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu
{
    class QR : Obstacle
    {
        public Point start { get; set; }
        public double scalex { get; set; }
        public double scaley { get; set; }
        public string Name
        {
            get
            {
                return ToString();
            }
        }
        public override string ToString()
        {
            return "QR => " + "Start : " + start.ToString();
        }

        public void draw(Bitmap scene)
        {
            using (Graphics gr = Graphics.FromImage(scene))
            {
                Rectangle rect = new Rectangle((int)(start.X*scalex), (int)(start.Y*scaley), (int)(8 * scalex),(int)(8 * scaley));
                gr.FillRectangle(Brushes.Gray, rect);
            }
        }
    }
}
