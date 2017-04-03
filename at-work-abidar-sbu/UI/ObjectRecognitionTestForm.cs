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
using at_work_abidar_sbu.AI.ObjectDetection;
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
            objectDetector = new ObjectDetector("svm3.save");
            recognizer = new ObjectRecognizer(); 
        }

        private ObjectRecognizer recognizer;
        private int frameCount = 0;
        private int second = 1;
        private Image<Rgb, byte> finalImage;
        private string[] names =
        {
            "big-nut",
            "big-screw",
             "box-head",
            "knife",
            "light",
            "small-screw"
        };

        private void button1_Click(object sender, EventArgs e)
        {

            Capture capture = new Capture(0); //create a camera captue
            ImageViewer imageViewer = new ImageViewer();
            ImageViewer imageViewer2 = new ImageViewer();
            Application.Idle += new EventHandler(delegate (object sender1, EventArgs e2)
            {
                //run this until application closed (close button click on image viewer)
               // pictureBox1.Image = capture.QuerySmallFrame().Bitmap; //draw the image obtained from camera
                Image<Rgb, byte> imageOrig = capture.QueryFrame().ToImage<Rgb, byte>();
                recognizer.CannyHight = cannyHighHS.Value;
                recognizer.CannyLow = cannyLowHS.Value;
                recognizer.DetectObjects(imageOrig);
                pictureBox1.Image = recognizer.EdgesImage.ToBitmap();

                pictureBox2.Image = recognizer.DelatedImage.ToBitmap();

                pictureBox3.Image = recognizer.FloodFilledImage.ToBitmap();
                pictureBox4.Image = recognizer.ErodedImage.ToBitmap();
                pictureBox5.Image = recognizer.FinalImage.ToBitmap();
                origPictureBox.Image = imageOrig.ToBitmap();
                //CvInvoke.DrawContours(imageOrig,contoursArray,-1,new MCvScalar(255,255,255));
                imageViewer.Image = new Image<Bgr,byte>(recognizer.LabledImage);
                //                Canny(cannyLowHS.Value, cannyHighHS.Value).ToBitmap();
            });
            imageViewer.Show();
            imageViewer2.Show();
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
            if (dir != "" && recognizer.FinalImage != null)
            {
                Directory.CreateDirectory(dir);
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                recognizer.FinalImage.Save(dir+"/"+ unixTimestamp+".png");
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
