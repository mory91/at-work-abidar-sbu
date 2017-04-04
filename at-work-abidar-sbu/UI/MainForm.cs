using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using at_work_abidar_sbu.HardwareInterface;
using System.Threading;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.AI.Planning;
using at_work_abidar_sbu.AI.Tasks;
using at_work_abidar_sbu.AI.WorldModel;
using at_work_abidar_sbu.UI.GraphicUtils;
using at_work_abidar_sbu.HardwareAPI;
using at_work_abidar_sbu.Robotics;
using at_work_abidar_sbu.Simulation;
using at_work_abidar_sbu.UI.GraphicUtils;
using Point = at_work_abidar_sbu.AI.Navigation.Point;
using at_work_abidar_sbu.UI;
using Orientation = at_work_abidar_sbu.HardwareAPI.Orientation;

namespace at_work_abidar_sbu
{
    public partial class MainForm : Form
    {
        Arm arm;
        Renderer renderer = new Renderer();
        private IRobot robot;
        public MainForm()
        {
            
            renderer.RegisterObjectRenderer<Map>(new MapRenderer());
            renderer.RegisterObjectRenderer<IRobot>(new RobotRenderer());
            renderer.RegisterObjectRenderer<PathShape>(new PathRenderer());
            InitializeComponent();
            robot = new RealRobot();
        }

        private Map map;
//        private Point robot;
        private List<Point> rallyPoint;
        private void cameraTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraTestForm cameraTestForm = new CameraTestForm();
            cameraTestForm.ShowDialog();
        }

        private void configsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesForm propertiesForm = new PropertiesForm();
            propertiesForm.ShowDialog();
        }

        private void mapBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitMapBuilderForm mapBuilderForm = new InitMapBuilderForm();
            mapBuilderForm.ShowDialog();
        }

        private void qRTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QrCodeTestForm qrCodeTestForm = new QrCodeTestForm();
            qrCodeTestForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void motorTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MotorControlForm mf = new MotorControlForm();
            mf.ShowDialog();
        }

        private void loadMapMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                map = Map.Load(openFileDialog1.FileName);
                Render();
            }
        }

        private void Render()
        {

            float scalex = (float) (pictureBox1.Width / map.width);
            float scaley = (float) (pictureBox1.Height / map.height);
            renderer.AddObject(map);
            renderer.AddObject(robot);
            if(route != null)
                renderer.AddObject(route.GetPathShape());
            if ( bnt != null)
                renderer.AddObject(bnt.GetPathShape());


            pictureBox1.Image = renderer.Render(pictureBox1.Width,pictureBox1.Height,Color.White, scaley, scaley);

            //            var r = renderer.EmptyFrame(pictureBox1.Width, pictureBox1.Height, Color.White)
            //                .DrawMap(map)
            //                .DrawRobot(robot, map)
            //                .DrawPath(path, map);
            //            if (route != null)
            //                r = r.DrawLaseres(robot, map, (int) route.LL, (int) route.LF, (int) route.RR, (int) route.RF);
            //
            //            pictureBox1.Image = r.GetBitmap();

        }

        private RoutePlanner route;
        private void navigateBtn_Click(object sender, EventArgs e)
        {
            CreatePathForm createPathForm = new CreatePathForm();
            createPathForm.map = map;
            
            createPathForm.FormClosing += (o, form) =>
            {
                route = new RoutePlanner(robot,map);
                var src = new Point(Int32.Parse(createPathForm.srcXTextBox.Text), Int32.Parse(createPathForm.srcYTextBox.Text));
                var dest = new Point(Int32.Parse(createPathForm.dstXtextBox.Text), Int32.Parse(createPathForm.dstYTextBox.Text));

                route.Start(src,dest);
                Timer1.Enabled = true;
            };
            createPathForm.Show();
        }

        private bool moved = false;
        private int R = 44;
        private void Timer1_Tick(object sender, EventArgs e)
        {

//            route.Tick();
            bnt.Tick();
            Render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            robot.ReadLaserValues();

            Console.WriteLine("Robot: {0} {1}", robot.Center.x, robot.Center.y);
            Console.WriteLine("Robot: {0} {1} {2} {3}", robot.LL, robot.LF, robot.RF, robot.RR);

            CreatePathForm createPathForm = new CreatePathForm();

            createPathForm.FormClosing += (o, form) =>
            {
                var src = new Point(Int32.Parse(createPathForm.srcXTextBox.Text), Int32.Parse(createPathForm.srcYTextBox.Text));


                LocationApproximator locationApproximator = new LocationApproximator();
                locationApproximator.SetUp(map);
                Point loc = locationApproximator.GetLocation((int)(src.x - R / 2), (int)(src.y - R / 2), R, R, 2, robot.LL, robot.LF, robot.RR, robot.RF);
                robot.Center = loc;
                Console.WriteLine("Robot: {0} {1}", robot.Center.x, robot.Center.y);
                Console.WriteLine("Robot: {0} {1} {2} {3}", robot.LL, robot.LF, robot.RF, robot.RR);
                Render();
            };
            createPathForm.Show();

            Render();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            robot.End();
            
            Console.WriteLine("Ending Navigation");
        }
        private void objectRecognitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectRecognitionTestForm test = new ObjectRecognitionTestForm();
            test.Show();
        }

        private void armTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArmControl armControl = new ArmControl();
            armControl.Show();
        }

        private void iMUTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMUTest test = new IMUTest();
            test.ShowDialog();
        }

        private BNT bnt;
        private void bntBtn_Click(object sender, EventArgs e)
        {
         ///   robot.ReadLaserValues();

            //Console.WriteLine("Robot: {0} {1}", robot.Center.x, robot.Center.y);
            //Console.WriteLine("Robot: {0} {1} {2} {3}", robot.LL, robot.LF, robot.RF, robot.RR);


            robot.Rotate(-270);
            return;
            CreatePathForm createPathForm = new CreatePathForm();

            createPathForm.FormClosing += (o, form) =>
            {
                var src = new Point(Int32.Parse(createPathForm.srcXTextBox.Text), Int32.Parse(createPathForm.srcYTextBox.Text));
               // LocationApproximator locationApproximator = new LocationApproximator();
             //   locationApproximator.SetUp(map);
            //    Point loc = locationApproximator.GetLocation((int)(src.x - R / 2), (int)(src.y - R / 2), R, R, 2, robot.LL, robot.LF, robot.RR, robot.RF);
          //      robot.Center = loc;
                Console.WriteLine("Robot: {0} {1}", robot.Center.x, robot.Center.y);
                Console.WriteLine("Robot: {0} {1} {2} {3}", robot.LL, robot.LF, robot.RF, robot.RR);
                bnt= new BNT(map,robot);
                Orientation orientation;
                Enum.TryParse<Orientation>(createPathForm.dstYTextBox.Text, out orientation);
                bnt.Start(src,createPathForm.dstXtextBox.Text,orientation);
                Timer1.Enabled = true;
                Render();
            };
            createPathForm.Show();
            Render();
        }
    }
}
