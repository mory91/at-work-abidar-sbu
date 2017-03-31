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
using at_work_abidar_sbu.GraphicUtils;
using at_work_abidar_sbu.HardwareAPI;
using Point = at_work_abidar_sbu.AI.Navigation.Point;

namespace at_work_abidar_sbu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Map map;
        private Point robot;
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
            Renderer renderer = new Renderer();


            var r = renderer.EmptyFrame(pictureBox1.Width, pictureBox1.Height, Color.White)
                .DrawMap(map)
                .DrawRobot(robot, map)
                .DrawPath(path, map);
            if (route != null)
                r = r.DrawLaseres(robot, map, (int) route.LL, (int) route.LF, (int) route.RR, (int) route.RF);

            pictureBox1.Image = r.GetBitmap();

        }

        private RoutePlanner route;
        private PathShape path;
        private Navigation nav;
        private void navigateBtn_Click(object sender, EventArgs e)
        {
            CreatePathForm createPathForm = new CreatePathForm();
            createPathForm.pathFinder =new PathFinder();
            createPathForm.map = map;
            createPathForm.FormClosing += (o, form) =>
            {
                map = createPathForm.map;
                path = new PathShape();
                path.path = createPathForm.pathFinder.getPath();
                route = new RoutePlanner(path,map);
                rallyPoint = route.NormalizePath();
                robot = rallyPoint[0] ?? new Point(0, 0);
                //rallyPoint.RemoveAt(0);

              
                nav.Initialize();
                nav.SetSpeed(10);
                moved = true;
                Timer1.Enabled = true;
            };
            createPathForm.Show();
        }

        private bool moved = false;
        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (nav.IsMoving())
                moved = true;
            else
            {
                if (moved)
                {
                    moved = false;
                    if (rallyPoint.Count > 0)
                    {
                        robot = rallyPoint[0];
                        rallyPoint.RemoveAt(0);
                        if (rallyPoint.Count > 0)
                        {
                            double dx = rallyPoint[0].x - robot.x;
                            double dy = rallyPoint[0].y - robot.y;
                            Console.WriteLine((float) (dx));
                            Console.WriteLine((float)(dy));

                            if (Math.Abs(dx) <= Math.Abs(dy))
                                dx = 0;
                            else
                            {
                                dy = 0;
                            }
                           
                            Navigation.i.Go((float)(-dx),(float) (dy));
                        }
                            
                    }
                }
            }
            Render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            route = new RoutePlanner(null,map);
            robot = route.RobotPositionFromLasers();
            Render();
        }
    }
}
