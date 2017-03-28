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
using Emgu.CV.UI;
using Emgu.CV.Structure;
namespace at_work_abidar_sbu
{
    public partial class CameraTestForm : Form
    {
        public CameraTestForm()
        {
            InitializeComponent();
        }

        private int frameCount = 0;
        private int second = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Capture capture = new Capture(1); //create a camera captue
            Application.Idle += new EventHandler(delegate (object sender1, EventArgs e2)
            {  //run this until application closed (close button click on image viewer)
                pictureBox1.Image = capture.QuerySmallFrame().Bitmap; //draw the image obtained from camera
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.DrawString("fps:"+ frameCount/second, Font,Brushes.Red,10,10);
                frameCount++;
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
        }
    }
}
