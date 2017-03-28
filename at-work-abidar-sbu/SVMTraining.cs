using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.ML.MlEnum;
using Emgu.CV.Structure;
using OpenTK.Graphics.ES20;

namespace at_work_abidar_sbu
{
    class SVMTraining
    {
        List<Image> imagesList =new List<Image>();
        List<float[]> hogs = new List<float[]>();
        List<int> labels = new List<int>();
        private void loadImageAndLabel()
        {
            try
            {
                string dirPath = @"images";

                List<string> dirs = new List<string>(Directory.EnumerateDirectories(dirPath));
                int labelNum = 1;
                foreach (var dir in dirs)
                {
                    string[] images = Directory.GetFiles(dir);
                    foreach (var image in images)
                    {
                        imagesList.Add(Image.FromFile(image));
                        labels.Add(labelNum);
                    }
                    labelNum++;
                }
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
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

        private void buildHOGs()
        {
            List<int> labels2 = new List<int>();
            int labelNums = 0;
            foreach (Image img in imagesList)
            {
                Image<Bgr, byte> loadedImg = new Image<Bgr, byte>((Bitmap)img);
             
                for (int i = 0; i < 360; i+=30)
                {
                    float[] histog = GetVector(loadedImg.Rotate(i, new Bgr(255, 255, 255)));
                    hogs.Add(histog);
                    labels2.Add(labels[labelNums]);
                }
                labelNums++;
            }
            labels = labels2;
        }

        public void train()
        {
            loadImageAndLabel();
            buildHOGs();
            using (SVM model = new SVM())
            {
                Matrix<float> matSamples = new Matrix<float>(To2D<float>(hogs.ToArray()));
                Matrix<int> matRes = new Matrix<int>(labels.ToArray());
                TrainData trainData = new TrainData(matSamples, DataLayoutType.RowSample, matRes);

                //bool trained = model.Train(trainData, trainClasses, null, null, p);
                bool trained = model.TrainAuto(trainData);
                SaveSVMToFile(model, "salam2.save");
            }
        }
        private T[,] To2D<T>(T[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }
        public void SaveSVMToFile(SVM model, String path)
        {
            if (File.Exists(path)) File.Delete(path);
            FileStorage fs = new FileStorage(path, FileStorage.Mode.Write);
            model.Write(fs);
            fs.ReleaseAndGetString();
        }
    }
}
