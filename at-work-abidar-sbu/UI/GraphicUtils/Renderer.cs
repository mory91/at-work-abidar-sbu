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
                bool flag = false;
                if (renderObject == null)
                {
                    log.Warn("Cannot Render NULL Object");
                    continue;
                }
                List<Type> types = new List<Type>(renderObject.GetType().GetInterfaces());
                types.Add(renderObject.GetType());

                foreach (var type in types)
                {
                    if (renderers.ContainsKey(type))
                    {
                        var renderer = renderers[type];
                        renderer.Render(renderObject, bitmap, scalex, scaley);
                        flag = true;
                    }
                }
                if (!flag)
                {
                       log.Warn("No Renderer Registered For " + renderObject.GetType().FullName);
                }

            }
            renderObjects.Clear();
            return bitmap;

        }
    }
}
