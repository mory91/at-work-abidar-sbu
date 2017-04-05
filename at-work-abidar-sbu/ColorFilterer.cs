using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace at_work_abidar_sbu
{
    class ColorFilterer
    {
        public static Image<Gray, byte> filterByHsv(Image<Bgr, byte> original, Hsv lower, Hsv higher)
        {
            var hsvImage = original.Convert<Hsv, byte>();
             Image< Gray, byte> huefilter =
                 hsvImage.InRange(lower, higher);
            return huefilter;
        }

        public static List<Rectangle> getRectsByColorHsv(Image<Bgr, byte> original, Hsv lower, Hsv higher)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            var filtered = ColorFilterer.filterByHsv(original, lower, higher);
             


            VectorOfVectorOfPoint contoursDetected = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(filtered, contoursDetected, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            VectorOfVectorOfPoint contoursArray = new VectorOfVectorOfPoint();
            int count = contoursDetected.Size;

            for (int i = 0; i < count; i++)
            {
                using (VectorOfPoint currContour = contoursDetected[i])
                {

                    if (currContour.Size > 50)
                    {
                        Rectangle rect = CvInvoke.BoundingRectangle(currContour);
                        contoursArray.Push(currContour);
                        rectangles.Add(rect);

                    }

                }
            }
            return rectangles;
        }
    }
}
