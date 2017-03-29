using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu
{
    class PathShape : Obstacle
    {
        public string name { get; set; }
        public List<Noqte> path { get; set; }
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
            return "PathShape : " + name + " Start : " + start.ToString();
        }

        public void draw(Bitmap scene)
        {
            using (Graphics gr = Graphics.FromImage(scene))
            {
				for (int i = 0; i < path.Count() - 1; i++)
					gr.DrawLine(Pens.Purple, (int)(path[i].x * scalex), (int)(path[i].y * scaley), (int)(path[i + 1].x * scalex), (int)(path[i + 1].y * scaley));
            }
        }
    }
}
