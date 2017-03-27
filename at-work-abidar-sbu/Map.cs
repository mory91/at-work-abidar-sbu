using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace at_work_abidar_sbu
{
    public class Map
    {
        public List<Obstacle> obstacles = new List<Obstacle>();
        public double width { get; set; }
        public double height { get; set; }
        public double scalex { get; set; }
        public double scaley { get; set; }
        public Bitmap build(Bitmap scene)
        {
            Bitmap res = new Bitmap((int)(width * scalex), (int)(height * scaley));
            using (Graphics grp = Graphics.FromImage(res)) 
            {
                grp.FillRectangle(
                    Brushes.White, 0, 0, res.Width, res.Height);
            }
            foreach (Obstacle o in obstacles)
            {
                o.draw(res);
            }
            return res;
        }
    }
}
