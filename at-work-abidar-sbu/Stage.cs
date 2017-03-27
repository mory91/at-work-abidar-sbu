using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu
{
    class Stage : Obstacle
    {
        public string name { get; set; }
        public double width { get; set; }
        public double height { get; set; }
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
            return "Stage : " + name + " Start : " + start.ToString();
        }

        public void draw(Bitmap scene)
        {
            using (Graphics gr = Graphics.FromImage(scene))
            {
                Rectangle rect = new Rectangle((int)(start.X * scalex), (int)(start.Y * scaley), (int)(width * scalex), (int)(height * scaley));
                if (name[0] == 'S')
                    gr.FillRectangle(Brushes.Red, rect);
                if (name[0] == 'T')
                    gr.FillRectangle(Brushes.Blue, rect);
                if (name[0] == 'U')
                    gr.FillRectangle(Brushes.Yellow, rect);
                if (name[0] == 'D')
                    gr.FillRectangle(Brushes.Orange, rect);
            }
        }
    }
}
