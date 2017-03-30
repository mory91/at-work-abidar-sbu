using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.ML;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenTK.Graphics.ES20;

namespace at_work_abidar_sbu
{
    public partial class ObjectRecognitionTestForm : Form
    {
        private HOGDescriptor hog = new HOGDescriptor();
        private ObjectDetector objectDetector;
        public ObjectRecognitionTestForm()
        {
            InitializeComponent();
            objectDetector = new ObjectDetector("salam2.save");
        }

        private int frameCount = 0;
        private int second = 1;
        private Image<Rgb, byte> finalImage;

        private string[] names =
        {
            "ball11", "ball3", "box-head", "big-screw", "black-nut", "big-black-screw",
            "small-black-screw"
        };
        private void button1_Click(object sender, EventArgs e)
        {

            Capture capture = new Capture(0); //create a camera captue
            ImageViewer imageViewer = new ImageViewer();
            Application.Idle += new EventHandler(delegate (object sender1, EventArgs e2)
            {
                //run this until application closed (close button click on image viewer)
               // pictureBox1.Image = capture.QuerySmallFrame().Bitmap; //draw the image obtained from camera
                Image<Rgb, byte> imageOrig = capture.QueryFrame().ToImage<Rgb, byte>();
                
                Image<Gray, byte> image = imageOrig.Convert<Gray, byte>();
                image._EqualizeHist();
                Image<Gray, byte> imageblur = image.SmoothBlur(3, 3).Convert<Gray, byte>();
              //  imageViewer.Image = image;
//                Image<Gray, byte> imageThresh = imageblur.ThresholdBinary(new Gray(threshHS.Value), new Gray(255));

//                pictureBox1.Image =  imageThresh.ToBitmap();
                Image<Gray, byte> edges = imageblur.Canny(cannyLowHS.Value, cannyHighHS.Value);

                pictureBox1.Image = edges.ToBitmap();
                Image<Gray, byte> delated = edges.Dilate(2);

                pictureBox2.Image = delated.ToBitmap();
                Image<Gray,byte> temp = new Image<Gray, byte>(delated.Width + 2, delated.Height + 2);
                Rectangle rectangle = new Rectangle(0, 0, delated.Rows - 2, delated.Cols - 2);
                CvInvoke.FloodFill(delated, temp, new Point(0, 0),new MCvScalar(),out rectangle ,  
                    new MCvScalar(), new MCvScalar(),Connectivity.FourConnected,4 + (255 << 8) + FloodFillType.MaskOnly);
                
                pictureBox3.Image =temp.ToBitmap();
                Image<Gray, byte> eroded = temp.Erode(2);
                pictureBox4.Image = eroded.ToBitmap();
                VectorOfVectorOfPoint contoursDetected = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(eroded, contoursDetected, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                VectorOfVectorOfPoint contoursArray = new VectorOfVectorOfPoint();
                int count = contoursDetected.Size;
                Bitmap bitmap = imageOrig.ToBitmap();
                Graphics g = Graphics.FromImage(bitmap);
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint currContour = contoursDetected[i])
                    {

                        if (currContour.Size > 50 )
                        {
                            Rectangle rect = CvInvoke.BoundingRectangle(currContour);
                            if(rect.Height == imageOrig.Height && rect.Width == imageOrig.Width)
                                continue;
                            contoursArray.Push(currContour);
                            
                            imageOrig.Draw(rect,new Rgb(100,100,100));
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
                            imageOrig.ROI = new Rectangle(0,0, image.Width, image.Height);
                            finalImage = rectImage;
                            pictureBox5.Image = rectImage.ToBitmap();
                            g.DrawRectangle(Pens.White,rect);
                            float f = (int)objectDetector.predict(rectImage.Convert<Bgr, byte>());
                            g.DrawString(names[(int) (f-1)],this.Font,Brushes.Red,rect.X,rect.Y);
                        }
                        
                    }
                }
                Console.WriteLine(contoursArray.Size);
                //CvInvoke.DrawContours(imageOrig,contoursArray,-1,new MCvScalar(255,255,255));
                imageViewer.Image = new Image<Bgr,byte>(bitmap);
                //                Canny(cannyLowHS.Value, cannyHighHS.Value).ToBitmap();
            });
            imageViewer.Show();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void ObjectRecognitionTestForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string dir = "images/"+textBox1.Text;
            if (dir != "" && finalImage != null)
            {
                Directory.CreateDirectory(dir);
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                finalImage.Save(dir+"/"+ unixTimestamp+".png");
            }
            

        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(objectDetector.predict(new Image<Bgr, byte>((Bitmap) Image.FromFile(openFileDialog1.FileName))).ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
