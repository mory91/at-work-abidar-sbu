using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using log4net;


namespace at_work_abidar_sbu.UI.GraphicUtils
{
    public class Renderer
    {
        private Bitmap bitmap;
        private Graphics gr;
                const int ROBOT_SIZE = 44;

        private Dictionary<Type, IObjectRenderer> renderers = new Dictionary<Type, IObjectRenderer>();
        private List<object> renderObjects = new List<object>();
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public Renderer EmptyFrame(int width, int height,Color color)
        {

            gr= Graphics.FromImage(bitmap);
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


        public void RegisterObjectRenderer<T>(IObjectRenderer<T> renderer)
        {
            renderers.Add(typeof(T), renderer);
        }

        public void AddObject(object obj)
        {
            renderObjects.Add(obj);
        }

        public Bitmap Render(int width, int height, Color color,float scalex , float scaley)
        {
            bitmap = new Bitmap(width, height);
            foreach (var renderObject in renderObjects)
            {
                if (renderers.ContainsKey(renderObject.GetType()))
                {
                    var renderer = renderers[renderObject.GetType()];
                    renderer.Render(renderObject,bitmap,scalex,scaley);
                }
                else
                {
                    log.Warn("No Renderer Registered For "+renderObject.GetType().FullName);
                }
            }
            renderObjects.Clear();
            return bitmap;

        }
    }
}
