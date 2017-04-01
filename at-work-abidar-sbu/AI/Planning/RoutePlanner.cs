using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.HardwareAPI;
using at_work_abidar_sbu.HardwareInterface;
using OpenTK.Graphics.OpenGL;

namespace at_work_abidar_sbu.AI.Planning
{
    public class RoutePlanner
    {
        public PathShape path { get; set; }
        private List<Point> rallyPoints = new List<Point>();
        private HardwareAPI.Navigation nav;
        private Map map;
        public PathFinder pathFinder { get; set; }

        public RoutePlanner(PathShape path, Map map,PathFinder pathFinder)
        {
            this.path = path;
            nav = HardwareAPI.Navigation.i;
            this.map = map;
            this.pathFinder = pathFinder;

        }

        public List<Point> NormalizePath()
        {
            rallyPoints.Clear();
            if (path.path.Count > 3)
            {
                rallyPoints.Add(path.path[0]);
                var dv = path.path[1] - path.path[0];
                for (int i = 2; i < path.path.Count; i++)
                {
                    var tdv = path.path[i] - path.path[i - 1];
                    if (tdv.x != dv.x || tdv.y != dv.y)
                    {
                        rallyPoints.Add(path.path[i]);
                        dv = tdv;
                    }
                }
            }
            rallyPoints.Add(path.path.Last());
            return rallyPoints;
        }

        public float LF;
        public float LL;
        public float RF;
        public float RR;
        private const int ROBOT_SIZE = 55;
        private const int LASER_TO_SIDE = 10;
        private const int LASER_TO_FRONT = 4;
        public void ReadLaserValues()
        {
            var t =nav.GetDistanceSync(Orientation.Front);
            LF = t.Item1 + ROBOT_SIZE / 2 - LASER_TO_FRONT+10;
            RF = t.Item2 + ROBOT_SIZE / 2 - LASER_TO_FRONT+10;

            t = nav.GetDistanceSync(Orientation.Left);
            LL = t.Item1+ROBOT_SIZE/2 -LASER_TO_SIDE ;
            RR = t.Item2+ROBOT_SIZE / 2 - LASER_TO_SIDE;
            
        }

        public Point RobotPositionFromLasers()
        {
            Point c = new Point();
            ReadLaserValues();
            c.x = RR ;
            c.y = map.height-(RF );
            return c;
        }
    }
}
