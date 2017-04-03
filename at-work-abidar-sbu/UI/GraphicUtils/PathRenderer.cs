using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu.UI.GraphicUtils
{
    class PathRenderer : IObjectRenderer<PathShape>
    {
        public void Render(PathShape path, Bitmap bmp, float scalex, float scaley)
        {
            Graphics gr = Graphics.FromImage(bmp);
            if (path != null)
            {

                var points = path.path.ConvertAll(p => new Point((int)(scalex * p.x), (int)(scaley * p.y))).ToArray();
                gr.DrawLines(Pens.Red, points);
            }
        }

        public void Render(object obj, Bitmap bmp, float scalex, float scaley)
        {
            Render((PathShape)obj,bmp,scalex,scaley);
        }
    }
}
