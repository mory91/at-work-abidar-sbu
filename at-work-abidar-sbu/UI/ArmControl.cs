using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using at_work_abidar_sbu.AI.ObjectDetection;
using at_work_abidar_sbu.HardwareAPI;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace at_work_abidar_sbu
{
    public partial class ArmControl : Form
    {
        public ArmControl()
        {
            InitializeComponent();
        }

        private void restBtn_Click(object sender, EventArgs e)
        {
            Arm.i.GoToRestPosition();
        }

        private void cameraBtn_Click(object sender, EventArgs e)
        {
            Arm.i.GoToCameraPosition();
        }

        private void gripBtn_Click(object sender, EventArgs e)
        {
            Arm.i.OpenGripper();

            Arm.i.GoToGripPosition();
            Arm.i.CloseGripper();
        }

        private bool isMoved = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isMoved && !Navigation.i.IsMoving())
            {
                isMoved = false;
                DetectedObject dd = null;
                foreach (var d in detected)
                {
                    if (d.Lable == "small-screw")
                    {
                        dd = d;
                        break;
                    }
                }
                if (dd == null)
                {
                    Navigation.i.Go(-2, 0);
                    isMoved = true;
                }
                else
                {
                    var cx = dd.Bound.X + dd.Bound.Width / 2;
                    var cy = dd.Bound.Y + dd.Bound.Height / 2;
                    var dx = cx - icx;
                    var dy = cy - icy;

                    var d = dx * dx + dy * dy;
                    Console.WriteLine("Distance:"+d);
                    if (Math.Sqrt(d) < 50)
                    {
                        Console.WriteLine("Moving Griper");
                        Arm.i.OpenGripper();
                        Arm.i.GoToGripPosition();
                        Arm.i.CloseGripper();
                    }
                    else
                    {
                        Navigation.i.Go(-2, 0);
                        isMoved = true;
                    }

                }
            }
        }

        private List<DetectedObject> detected;
        private int icx, icy;
        private void button1_Click(object sender, EventArgs e)
        {
            Capture capture = new Capture(0);
            ObjectRecognizer recognizer = new ObjectRecognizer();
            ImageViewer imageViewer = new ImageViewer();
            Application.Idle += new EventHandler((o, args) =>
            {
                var image = capture.QueryFrame().ToImage<Rgb, byte>();
                icx = image.Width / 2;
                icy = image.Height / 2;
                recognizer.CannyHight = cannyHighHS.Value;
                recognizer.CannyLow = cannyLowHS.Value;
                detected = recognizer.DetectObjects(image);
                imageViewer.Image = new Image<Bgr,byte>(recognizer.LabledImage);


            });
            imageViewer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation.i.SetSpeed(5);
            isMoved = true;
            timer1.Enabled = true;

        }

    }
}
