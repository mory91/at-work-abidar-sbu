using System.Drawing;

namespace at_work_abidar_sbu.UI.GraphicUtils
{
    public interface IObjectRenderer<in T> : IObjectRenderer 
    {
        void Render(T obj,Bitmap bmp,float scalex,float scaley);
    }

    public interface IObjectRenderer
    {
        void Render(object obj, Bitmap bmp, float scalex, float scaley);
    }

}