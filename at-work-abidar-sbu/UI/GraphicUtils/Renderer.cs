using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu.GraphicUtils
{
    public class Renderer
    {
        private Bitmap bitmap;
        private Graphics gr;
        const int ROBOT_SIZE = 44;
        public Renderer EmptyFrame(int width, int height,Color color)
        {
            bitmap = new Bitmap(width,height);
            gr= Graphics.FromImage(bitmap);
            return this;
        }

        public Renderer DrawMap(Map map)
        {
            var scalex = bitmap.Width / map.width ;
            var scaley = bitmap.Height / map.height ;
            gr = Graphics.FromImage(bitmap);
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

            return this;
        }

        public Renderer DrawPath(PathShape path,Map map)
        {
            var scalex = bitmap.Width / map.width;
            var scaley = bitmap.Height / map.height;
            gr = Graphics.FromImage(bitmap);
            if (path != null)
            {
              
                var points = path.path.ConvertAll(p => new Point( (int)(scalex*p.x),  (int)(scaley*p.y))).ToArray();
                gr.DrawLines(Pens.Red,points);
            }
            return this;
        }

        public Renderer DrawRobot(AI.Navigation.Point center, Map map)
        {
            var scalex = bitmap.Width / map.width;
            var scaley = bitmap.Height / map.height;
            gr = Graphics.FromImage(bitmap);
            if (center != null)
            {
            Rectangle robot = new Rectangle((int) ((center.x - ROBOT_SIZE/2)*scalex),(int) ((center.y - ROBOT_SIZE/2)*scaley),
                (int) (ROBOT_SIZE*scalex), (int) (ROBOT_SIZE * scaley));
            gr.FillRectangle(Brushes.Gold,robot);
            }
            return this;
        }
        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public Renderer DrawLaseres(AI.Navigation.Point center, Map map, int LL,int LF,int RR,int RF)
        {
            //Todo Very Bad Code , No Robot Orientation
            var scalex = bitmap.Width / map.width;
            var scaley = bitmap.Height / map.height;
            gr = Graphics.FromImage(bitmap);
            if (center != null)
            {
                int Bottom = (int) (center.y + ROBOT_SIZE / 2);
                int Left = (int) (center.x - ROBOT_SIZE / 2);
                int Top = (int)(center.y - ROBOT_SIZE / 2);
                int Right = (int)(center.x + ROBOT_SIZE / 2);
                //                gr.DrawLine(Pens.Brown,(int) (Left*scalex), (int)(Bottom *scaley), (int)(Left * scalex), (int)((Bottom+RF) * scaley));
                //                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Bottom * scaley), (int)((Left-RR) * scalex), (int)((Bottom) * scaley));
                //                Left += ROBOT_SIZE;
                //                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Bottom * scaley), (int)(Left * scalex), (int)((Bottom + LF) * scaley));
                //                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Bottom * scaley), (int)((Left + LL) * scalex), (int)((Bottom) * scaley));
                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Top * scaley), (int)(Left * scalex), (int)((Top - RF) * scaley));
                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Top * scaley), (int)((Left - RR) * scalex), (int)((Top) * scaley));
                Left += ROBOT_SIZE;
                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Top * scaley), (int)(Left * scalex), (int)((Top - LF) * scaley));
                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Top * scaley), (int)((Left + LL) * scalex), (int)((Top) * scaley));

            }
            return this;
        }
    }
}
