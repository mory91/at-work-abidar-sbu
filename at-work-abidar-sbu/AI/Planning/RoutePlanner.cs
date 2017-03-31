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
            var t =nav.GetDistanceSync(Orientation.Front);
            LF = t.Item1;
            RF = t.Item2;

            t = nav.GetDistanceSync(Orientation.Left);
            LL = t.Item1;
            RR = t.Item2;
            
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
