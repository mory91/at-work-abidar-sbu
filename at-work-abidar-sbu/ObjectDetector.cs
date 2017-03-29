using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.Structure;

namespace at_work_abidar_sbu
{
    class ObjectDetector
    {
        SVM svm = new SVM();
        public ObjectDetector(string filePath)
        {
            LoadSVMFromFile(filePath);
        }
        private void LoadSVMFromFile(string path)
        {
            FileStorage fs = new FileStorage(path, FileStorage.Mode.Read);
            svm.Read(fs.GetRoot());
            fs.ReleaseAndGetString();
        }

        public float predict(Image<Bgr, Byte> img)
        {
            float[] hog = GetVector(img);
            Matrix<float> sample = new Matrix<float>(hog);
            sample = sample.Transpose();
            return svm.Predict(sample);
        }
        private Image<Bgr, Byte> Resize(Image<Bgr, Byte> im)
        {
            return im.Resize(64, 128, Emgu.CV.CvEnum.Inter.Linear);
        }
        private float[] GetVector(Image<Bgr, Byte> im)
        {
            HOGDescriptor hog = new HOGDescriptor();    // with defaults values
            Image<Bgr, Byte> imageOfInterest = Resize(im);
            Point[] p = new Point[imageOfInterest.Width * imageOfInterest.Height];
            int k = 0;
            for (int i = 0; i < imageOfInterest.Width; i++)
            {
                for (int j = 0; j < imageOfInterest.Height; j++)
                {
                    Point p1 = new Point(i, j);
                    p[k++] = p1;
                }
            }

            return hog.Compute(imageOfInterest, new Size(8, 8), new Size(0, 0), null);
        }
    }
}
