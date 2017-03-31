using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.HardwareAPI;
using at_work_abidar_sbu.HardwareInterface;

namespace at_work_abidar_sbu.AI.Planning
{
    public class RoutePlanner
    {
        private PathShape path;
        private List<Point> rallyPoints = new List<Point>();
        private HardwareAPI.Navigation nav;
        private Map map;
        public RoutePlanner(PathShape path,Map map)
        {
            this.path = path;
            nav = HardwareAPI.Navigation.i;
            this.map = map;
        }

        public List<Point> NormalizePath()
        {
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
        public void ReadLaserValues()
        {
            LF = nav.GetDistance(Orientation.Front, CentralBoard.Laser.Left);
            LL = nav.GetDistance(Orientation.Left, CentralBoard.Laser.Left);
            RF = nav.GetDistance(Orientation.Front, CentralBoard.Laser.Right);
            RR = nav.GetDistance(Orientation.Right, CentralBoard.Laser.Right);
        }

        public Point RobotPositionFromLasers()
        {
            Point c = new Point();
            ReadLaserValues();
            c.x = RR + 22-10;
            c.y = map.height-(RF + 22-4);
            return c;
        }
    }
}
