using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.UI.GraphicUtils;

namespace at_work_abidar_sbu.UI.GraphicUtils
{
    class MapRenderer : IObjectRenderer<Map>
    {
        public void Render(Map map, Bitmap bitmap, float scalex, float scaley)
        {
            Graphics gr = Graphics.FromImage(bitmap);
            using (gr)
            {
                gr.FillRectangle(
                    Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                foreach (MapObject o in map.obstacles)
                {
                    Rectangle rect = new Rectangle((int)(o.X * scalex), (int)(o.Y * scaley), (int)(o.Width * scalex), (int)(o.Height * scaley));
                    if (rect.Width <= 0)
                        rect.Width = 2;
                    if (rect.Height <= 0)
                        rect.Height = 2;
                    switch (o.Type)
                    {

                        case WordObjectType.Stage:
                            var name = o.Name;
                            if (name[0] == 'S')
                                gr.FillRectangle(Brushes.Red, rect);
                            if (name[0] == 'T')
                                gr.FillRectangle(Brushes.Blue, rect);
                            if (name[0] == 'U')
                                gr.FillRectangle(Brushes.Yellow, rect);
                            if (name[0] == 'D')
                                gr.FillRectangle(Brushes.Orange, rect);
                            break;
                        case WordObjectType.Wall:
                            gr.FillRectangle(Brushes.Black, rect);
                            break;
                        case WordObjectType.QR:
                            gr.FillRectangle(Brushes.Gray, rect);
                            break;
                        default:
                            gr.FillRectangle(Brushes.Crimson, rect);
                            break;
                    }
                }
            }
        }

        public void Render(object obj, Bitmap bmp, float scalex, float scaley)
        {
            Render((Map) obj, bmp, scalex, scaley);
        }
    }
}
