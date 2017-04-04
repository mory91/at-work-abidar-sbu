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
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace at_work_abidar_sbu
{
    public partial class ColorFilter : Form
    {
        private Image<Gray, byte> orangeImage;
        private Image<Bgr, byte> Image;
        private void setValue()
        {
            orangeImage = ColorFilterer.filterByHsv(Image, new Hsv((double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value), new Hsv((double)numericUpDown4.Value, (double)numericUpDown5.Value, (double)numericUpDown6.Value));
        }
        public ColorFilter()
        {
            InitializeComponent();
        }

        private void begin_Click(object sender, EventArgs e)
        {
            Capture capture = new Capture(0); //create a camera captue
            ImageViewer imageViewer = new ImageViewer();
            Application.Idle += new EventHandler(delegate(object sender1, EventArgs e2)
            {    
                Image = capture.QueryFrame().ToImage<Bgr, byte>();
                Bitmap bitmap = ColorFilterer.filterByHsv(Image, new Hsv((double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value), new Hsv((double)numericUpDown4.Value, (double)numericUpDown5.Value, (double)numericUpDown6.Value)).ToBitmap();
               
                List<Rectangle> rectangles = ColorFilterer.getRectsByColorHsv(Image, new Hsv((double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value), new Hsv((double)numericUpDown4.Value, (double)numericUpDown5.Value, (double)numericUpDown6.Value));
//                 Create a blank bitmap with the same dimensions
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Image.Draw(rectangles[i], new Bgr(0, 53, 163), 10);
                    Console.WriteLine(rectangles[i]);
                }
                pictureBox1.Image = Image.ToBitmap();
            });
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            setValue();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            setValue();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            setValue();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            setValue();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            setValue();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            setValue();
        }
    }
}
