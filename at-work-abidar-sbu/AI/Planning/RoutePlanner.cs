using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.AI.WorldModel;
using at_work_abidar_sbu.HardwareAPI;
using at_work_abidar_sbu.HardwareInterface;
using at_work_abidar_sbu.Robotics;
using OpenTK.Graphics.OpenGL;

namespace at_work_abidar_sbu.AI.Planning
{
    public class RoutePlanner
    {
        private List<Point> rallyPoints = new List<Point>();
        private Map map;
        private IRobot robot;
        private int R = 44;
        public PathFinder pathFinder;
        LocationApproximator locationApproximator = new LocationApproximator();
        
        public RoutePlanner(IRobot robot,Map map)
        {
            this.robot = robot;
            this.map = map;
            this.pathFinder = new PathFinder();
            this.pathFinder.LoadInMap(map);
            locationApproximator.SetUp(map);
        }

        public List<Point> NormalizePath(List<Point> path)
        {
            rallyPoints.Clear();
            if (path.Count > 3)
            {
                rallyPoints.Add(path[0]);
                var dv =path[1] - path[0];
                for (int i = 2; i < path.Count; i++)
                {
                    var tdv = path[i] - path[i - 1];
                    if (tdv.x != dv.x || tdv.y != dv.y)
                    {
                        rallyPoints.Add(path[i]);
                        dv = tdv;
                    }
                }
            }
            rallyPoints.Add(path.Last());
            return rallyPoints;
        }
        bool moved = false;

        public Point GetDestination()
        {
            return pathFinder.getDst();
        }

        public void Start(Point src,Point dst)
        {

            pathFinder.setSrc((int) src.x, (int) src.y);
            pathFinder.setDst((int)dst.x, (int)dst.y);
            pathFinder.findPath();
                
//            path.path = createPathForm.pathFinder.getPath();
//            route = new RoutePlanner(path, map, createPathForm.pathFinder);
            rallyPoints = NormalizePath(pathFinder.getPath());
            robot.Center = rallyPoints[0] ?? new Point(0, 0);

            //rallyPoint.RemoveAt(0);
            //  nav.Initialize();
            robot.Speed = 10;
            moved = true;
        }

        public void Tick()
        {
            if (robot.IsMoving)
                moved = true;
            else
            {
                if (moved)
                {
                    moved = false;
                    if (rallyPoints.Count > 0)
                    {


                        var robotl = rallyPoints[0];


                        robot.ReadLaserValues();
                        Console.WriteLine("Robot: {0} {1}", robot.Center.x, robot.Center.x);
                        Console.WriteLine("Robot: {0} {1} {2} {3}", robot.LL, robot.LF, robot.RF, robot.RR);
                        // Render();

                        
                        Point loc = locationApproximator.GetLocation((int)(robotl.x - R / 2), (int)(robotl.y - R / 2), R, R, 2, robot.LL, robot.LF, robot.RR, robot.RF);

                        if (loc != null)
                        {
                            pathFinder.setSrc((int)loc.x, (int)loc.y);
                            pathFinder.findPath();
                            robot.Center = loc;
                            Console.WriteLine("rec");
                        }
                       
//                        path = new PathShape();
//                        Console.WriteLine("Path Hash" + path.GetHashCode());
//                        path.path = pathFinder.getPath();
//                        route.path = path;
                        rallyPoints =NormalizePath(pathFinder.getPath());
                        rallyPoints.RemoveAt(0);
                        while (rallyPoints.Count > 1)
                        {
                            double dx = rallyPoints[0].x - robot.Center.x;
                            double dy = rallyPoints[0].y - robot.Center.y;
                            if (dx * dx + dy * dy < 4)
                                rallyPoints.RemoveAt(0);
                            else
                                break;
                        }

                        if (rallyPoints.Count > 0)
                        {
                            double dx = rallyPoints[0].x - robot.Center.x;
                            double dy = rallyPoints[0].y - robot.Center.y;
                            Console.WriteLine((float)(dx));
                            Console.WriteLine((float)(dy));

                            if (Math.Abs(dx) <= Math.Abs(dy))
                                dx = 0;
                            else
                            {
                                dy = 0;
                            }
                            if (Math.Sqrt(dx * dx + dy * dy) < 15)
                                robot.Speed = 5;
                            else
                            {
                                robot.Speed = 10;
                            }
                            double fx = pathFinder.getDst().x - robot.Center.x;
                            double fy = pathFinder.getDst().y - robot.Center.y;

                            robot.Go((float)(dx), (float)(-dy));
                        }

                    }
                }
            }
        }

        public PathShape GetPathShape()
        {
            PathShape path = new PathShape();
            path.path = pathFinder.getPath();
            return path;
        }
    }
}
