using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using ZXing;

namespace at_work_abidar_sbu
{
	public partial class QrCodeTestForm : Form
    {
		public string qrDecoder(string fileName)
		{
			IBarcodeReader reader = new BarcodeReader();
			var barcodeBitmap = (Bitmap)Bitmap.FromFile(fileName);
			var result = reader.Decode(barcodeBitmap);
			if (result == null)
				return null;
			else
				return result.Text;
		}
		public QrCodeTestForm()
        {
            InitializeComponent();
        }
		private void button1_Click(object sender, EventArgs e)
		{
			// create a barcode reader instance
			IBarcodeReader reader = new BarcodeReader();
			// load a bitmap
			var barcodeBitmap = (Bitmap)Bitmap.FromFile(textBox1.Text);
			// detect and decode the barcode inside the bitmap
			var result = reader.Decode(barcodeBitmap);
			// do something with the result
			if (result != null)
			{
				textBox3.Text = result.BarcodeFormat.ToString();
				textBox2.Text = result.Text;
			    Image<Bgr, Byte> rectangleImage = new Image<Bgr, byte>((Bitmap) pictureBox1.Image);
			    List<RotatedRect> boxList = getRects(rectangleImage);
			    foreach (RotatedRect box in boxList)
                    rectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
                pictureBox1.Image = rectangleImage.ToBitmap();
            }
			else
			{
				textBox3.Text = ":|";
				textBox2.Text = ":|";
			}
		}

        private List<RotatedRect> getRects(Image<Bgr, Byte> img)
        {
            //img = img.Resize(400, 400, Inter.Linear, true);

            //Convert the image to grayscale and filter out the noise
            UMat uimage = new UMat();
            CvInvoke.CvtColor(img, uimage, ColorConversion.Bgr2Gray);

            //use image pyr to remove noise
            UMat pyrDown = new UMat();
            CvInvoke.PyrDown(uimage, pyrDown);
            CvInvoke.PyrUp(pyrDown, uimage);

            double cannyThreshold = 180.0;
            double cannyThresholdLinking = 120.0;
            UMat cannyEdges = new UMat();
            CvInvoke.Canny(uimage, cannyEdges, cannyThreshold, cannyThresholdLinking);

            LineSegment2D[] lines = CvInvoke.HoughLinesP(
               cannyEdges,
               1, //Distance resolution in pixel-related units
               Math.PI / 45.0, //Angle resolution measured in radians.
               20, //threshold
               30, //min Line width
               10); //gap between lines


            List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle

            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                int count = contours.Size;
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                        if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                        {
                            if (approxContour.Size == 4) //The contour has 4 vertices.
                            {
                                bool isRectangle = true;
                                Point[] pts = approxContour.ToArray();
                                LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

//                                for (int j = 0; j < edges.Length; j++)
//                                {
//                                    double angle = Math.Abs(
//                                       edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
//                                    if (angle < 80 || angle > 100)
//                                    {
//                                        isRectangle = false;
//                                        break;
//                                    }
//                                }

                                if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                            }
                        }
                    }
                }
            }
            return boxList;

        }

        private void button2_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				textBox1.Text = openFileDialog1.FileName;
				pictureBox1.Load(textBox1.Text);
			}
		}

		private void QrCodeTestForm_Load(object sender, EventArgs e)
		{

		}
	}
}
