using at_work_abidar_sbu.AI.ObjectDetection;
using at_work_abidar_sbu.Robotics;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.WorldModel;
using at_work_abidar_sbu.HardwareAPI;

namespace at_work_abidar_sbu.AI.Task
{
    class BMT
    {
        enum BMTState
        {
            GetRotation,
            Rotate
        }

        private BMTState state;

        private Orientation rotateTo;

        private readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Map map;
        private IRobot robot;
        private int ROBOT_SIZE = 44;
        private bool rotateRequired;

        private MapObject source;
        private MapObject destination;
        private List<string> objectCollection;

        private Point currentPoint;

        public BMT(Map map, IRobot robot, string sourceName, string destinationName, List<string> collection, Point init)
        {

            this.map = map;
            this.robot = robot;
            this.objectCollection = collection;
            currentPoint = init;

            foreach (MapObject obj in map.obstacles)
            {
                if (obj.Name == sourceName)
                    source = obj;
                if (obj.Name == destinationName)
                    destination = obj;
            }
        }

        public Orientation getRotate(MapObject mapObject)
        {
            if (mapObject.Down)
            {
                if (robot.Orientation != Orientation.N)
                    rotateTo = Orientation.N;
            }
            if (mapObject.Up)
            {
                if (robot.Orientation != Orientation.S)
                    rotateTo = Orientation.S;
            }
            if (mapObject.Right)
            {
                if (robot.Orientation != Orientation.W)
                    rotateTo = Orientation.W;
            }
            if (mapObject.Left)
            {
                if (robot.Orientation != Orientation.E)
                    rotateTo = Orientation.E;
            }
            return rotateTo;
        }

        public void rotate(Orientation o)
        {
            robot.Speed = 5;
            RotationChecker rotationChecker = new RotationChecker();
            rotationChecker.SetUp(map);
            if (rotationChecker.CanRotate((int) robot.Center.x, (int) robot.Center.y))
            {
                if (robot.Orientation != rotateTo)
                    robot.Rotate(1);
            }
            else
            {
                robot.Go(0, -1);
            }

        }

        public Rectangle search()
        {
            Capture capture = new Capture(0);
            ObjectRecognizer objectRecog = new ObjectRecognizer();
            List<DetectedObject> detecteds;
            DetectedObject firstDetected = new DetectedObject();
            bool search = true;
            if (search)
            {
                robot.Speed = 10;
                if (source.Left || source.Right)
                {
                    bool isGoingRight = true;
                    if (isGoingRight)
                    {
                        robot.Go(1, 0);
                        currentPoint.Y++;
                    }
                    else
                    {
                        robot.Go(-1, 0);
                        currentPoint.Y--;
                    }
                    if (currentPoint.Y > source.Y + robot.Width || currentPoint.Y < source.Y - robot.Width)
                    {
                        isGoingRight = !isGoingRight;
                    }
                }
                else
                {
                    bool isGoingRight = true;
                    if (isGoingRight)
                    {
                        robot.Go(1, 0);
                        currentPoint.X++;
                    }
                    else
                    {
                        robot.Go(-1, 0);
                        currentPoint.X--;
                    }
                    if (currentPoint.X > source.X + robot.Width || currentPoint.X < source.X - robot.Width)
                    {
                        isGoingRight = !isGoingRight;
                    }
                }
                objectRecog.CannyLow = 124;
                objectRecog.CannyHight = 28;
                detecteds = objectRecog.DetectObjects(capture.QueryFrame().ToImage<Emgu.CV.Structure.Rgb, byte>());
                foreach (var d in detecteds)
                {
                    if (objectCollection.Where(s => (s == d.Lable)).ToArray().Length > 0)
                    {
                        search = false;
                        firstDetected = d;
                        break;
                    }
                }
            }
            return firstDetected.Bound;
        }

        public void goForward()
        {

        }


    }
}
