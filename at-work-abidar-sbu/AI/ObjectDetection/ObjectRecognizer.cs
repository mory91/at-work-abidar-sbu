using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace at_work_abidar_sbu.AI.ObjectDetection
{
    class ObjectRecognizer
    {
        public int CannyLow { get; set; }
        public int CannyHight { get; set; }

        public Image<Gray, byte> FilteredImage;
        public Image<Gray, byte> EdgesImage;
        public Image<Gray, byte> DelatedImage;
        public Image<Gray, byte> ErodedImage;
        public Image<Gray, byte> FloodFilledImage;

        private string[] names =
        {
//            "big-nut",
//            "big-screw",
//            "box-head",
//            "knife",
//            "light",
//            "small-screw"
            "big-screw",
            "knife",
            "light",
            "small-screw"
        };

        public Image<Rgb, byte> FinalImage;
        public Bitmap LabledImage;
        private ObjectDetector objectDetector;
        Rectangle lightbox = Rectangle.Empty;

        public ObjectRecognizer(string path)
        {
            objectDetector = new ObjectDetector(path);
        }

        public List<DetectedObject> DetectObjects(Image<Rgb, byte> imageInput)
        {
            Image<Rgb, byte> imageOrig = imageInput.Copy();
            var obox = new Rectangle(0, 0, imageOrig.Width, imageOrig.Height);
            imageOrig.ROI = new Rectangle(0, 0, imageOrig.Width, imageOrig.Height - 100);
            Image<Rgb, byte> image = imageOrig.Copy();
            imageOrig.ROI = obox;
            if (!lightbox.IsEmpty)
            {
                var l2 = lightbox;
                l2.X -= 10;
                l2.Y -= 10;
                l2.Width += 20;
                l2.Height += 20;
                image.ROI = l2;
                var light = image.InRange(new Rgb(200, 200, 200), new Rgb(255, 255, 255));
                light = light.Dilate(5);
                image.SetValue(new Rgb(156, 163, 167), light);
                image.ROI = new Rectangle(0, 0, imageOrig.Width, imageOrig.Height);
            }

            image = image.SmoothBlur(3, 3);

            //  image.ThresholdTrunc(new Rgb(254, 251, 254), new Rgb(156, 163, 167));
            //image._EqualizeHist();
            //   image._GammaCorrect((threshHS.Value / 128.0));
            FilteredImage = image /*.SmoothBlur(3, 3)*/.Convert<Gray, byte>().PyrDown().PyrUp();
            //                imagefiltered = imagefiltered.SmoothGaussian()
            //  imageViewer.Image = image;
            //                Image<Gray, byte> imageThresh = imageblur.ThresholdBinary(new Gray(threshHS.Value), new Gray(255));

            //                pictureBox1.Image =  imageThresh.ToBitmap();
            EdgesImage = FilteredImage.Canny(CannyLow, CannyHight);


            DelatedImage = EdgesImage.Dilate(2);

            FloodFilledImage = new Image<Gray, byte>(DelatedImage.Width + 2, DelatedImage.Height + 2);
            Rectangle rectangle = new Rectangle(0, 0, DelatedImage.Rows - 2, DelatedImage.Cols - 2);
            CvInvoke.FloodFill(DelatedImage, FloodFilledImage, new System.Drawing.Point(100, 100), new MCvScalar(),
                out rectangle,
                new MCvScalar(), new MCvScalar(), Connectivity.FourConnected, 4 + (255 << 8) + FloodFillType.MaskOnly);

            ErodedImage = FloodFilledImage.Erode(2);

            VectorOfVectorOfPoint contoursDetected = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(ErodedImage, contoursDetected, null, Emgu.CV.CvEnum.RetrType.List,
                Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            VectorOfVectorOfPoint contoursArray = new VectorOfVectorOfPoint();
            int count = contoursDetected.Size;
            LabledImage = imageOrig.ToBitmap();
            Graphics g = Graphics.FromImage(LabledImage);
            //     lightbox = Rectangle.Empty;
            List<DetectedObject> objects = new List<DetectedObject>();
            for (int i = 0; i < count; i++)
            {
                using (VectorOfPoint currContour = contoursDetected[i])
                {
                    if (currContour.Size > 50)
                    {
                        Rectangle rect = CvInvoke.BoundingRectangle(currContour);
                        if (imageOrig.Height - rect.Height < 10 || imageOrig.Width - rect.Width < 10)
                            continue;


                        contoursArray.Push(currContour);

                        imageOrig.Draw(rect, new Rgb(100, 100, 100));
                        imageOrig.ROI = rect;
                        var rectImage = imageOrig.Copy();

                        //
                        //                            MCvMoments moments = CvInvoke.Moments(rectImage.Convert<Gray,Single>());
                        //                            double u20 = moments.Mu20 / moments.M00;
                        //                            double u02 = moments.Mu02 / moments.M00;
                        //                            double u11 = moments.Mu11 / moments.M00;
                        //
                        //                            var phi = Math.Atan2(2 * u11, u20 - u02)*0.5;
                        //                            rectImage = rectImage.Rotate(-(phi*360/(2*Math.PI)),new Rgb(0,0,0));
                        //rectImage.ROI = rect;
                        Console.WriteLine(rect);
                        //   Console.WriteLine(phi);
                        imageOrig.ROI = new Rectangle(0, 0, image.Width, image.Height);
                        FinalImage = rectImage;
                        g.DrawRectangle(Pens.White, rect);
                        float f = (int) objectDetector.predict(rectImage.Convert<Bgr, byte>());
                        g.DrawString(names[(int) (f - 1)], SystemFonts.DefaultFont, Brushes.Red, rect.X, rect.Y);
                        if (names[(int) (f - 1)] == "light")
                        {
                            lightbox = rect;
                        }
                        objects.Add(new DetectedObject(rect, names[(int) (f - 1)]));
                    }
                }
            }
            return objects;
        }
    }
}