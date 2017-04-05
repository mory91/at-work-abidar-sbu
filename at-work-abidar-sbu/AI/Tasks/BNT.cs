using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.Planning;
using at_work_abidar_sbu.AI.WorldModel;
using at_work_abidar_sbu.HardwareAPI;
using at_work_abidar_sbu.Robotics;
using Point = at_work_abidar_sbu.AI.Navigation.Point;

namespace at_work_abidar_sbu.AI.Tasks
{
    public enum BNTState
    {
        ROTATING, MOVING,WAITING,CORRECTING
    }

    public class BNT
    {
        private  readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Map map;
        private IRobot robot;
        private RotationChecker rotationChecker;
        private int ROBOT_SIZE = 44;
        private RoutePlanner route;
//        private Orientation orientation;

        private List<String> names = new List<string>();
        List<Orientation> orientations = new List<Orientation>();
        public BNT(Map map, IRobot robot)
        {
            this.map = map;
            this.robot = robot;
            rotationChecker = new RotationChecker();
            rotationChecker.SetUp(map);
        }

        public Point FindEntryVector()
        {

            Point e = null;
            foreach (var o in map.obstacles)
            {
                if (o.Type == WorldObjectType.Entry)
                {

                    if (o.Left)
                    {
                        e= new Point(1,0);
                    }
                    else if (o.Right)
                    {
                        e = new Point(-1, 0);
                    }
                    else if(o.Down)
                    {
                        e = new Point(0, -1);
                    }
                    else if(o.Up)
                    {
                        e = new Point(0, 1);
                    }
                }
                if (e != null)
                {
                    log.Info("Found Entry : " + e.ToString());
                }
                else
                {
                    log.Error("No Entry Found");
                }
            }
            return e;
        }

        public RectangleF FindStageRegion(string name)
        {
            MapObject stage = null;
            foreach (MapObject o in map.obstacles)
            {
                if ((o.Type == WorldObjectType.QR) && o.Name == name)
                {
                    stage = o;
                    log.Info("QR CODE FOUND");
                    break;
                }
            }
            if (stage == null)
            {
                foreach (MapObject o in map.obstacles)
                {
                    if ((o.Type == WorldObjectType.Stage) && o.Name == name)
                    {
                        stage = o;
                        break;
                    }
                }
            }
            
            if (stage != null)
            {
                if (stage.Type == WorldObjectType.QR)
                {
                    return stage.Bound;
                }
                if (stage.Type == WorldObjectType.Stage)
                {
                    int RBP = ROBOT_SIZE + 10;
                    RectangleF rec = stage.Bound;
                    if (stage.Left)
                    {

                        rec.X -= RBP;
                    }
                    else if (stage.Right)
                    {
                        rec.X += RBP + rec.Width;
                    }
                    else if (stage.Down)
                    {
                        rec.Y += RBP + rec.Height;
                    }
                    else if (stage.Up)
                    {
                        rec.Y -= RBP;
                    }
                    log.Info("Region Found For " + name + " Bounds : " + rec);
                    return rec;
                }
            }
            else
            {
                log.Error("Stage Not Found" + name);
            }
            return RectangleF.Empty;
        }

        public Point FindDestinationPoint(Rectangle rectangle)
        {
            for (int x = rectangle.X; x < rectangle.X + rectangle.Width; x++)
            {
                for (int y = rectangle.Y; y < rectangle.Y + rectangle.Height; y++)
                {
                    if (rotationChecker.CanStand(x, y))
                    {
                        return new Point(x, y);
                    }
                }
            }
            return null;
        }

        public Point TranslateLocalVector(Point p)
        {
            Point t = new Point();
            if (robot.Orientation == Orientation.B)
                return null;
            if (robot.Orientation == Orientation.N)
            {
                t.x = p.x;
                t.y = -p.y;
            }else if (robot.Orientation == Orientation.E)
            {
                t.x = p.y;
                t.y = p.x;

            }
            else if (robot.Orientation == Orientation.S)
            {
                t.y = p.y;
                t.x = -p.x;

            }else if (robot.Orientation == Orientation.W)
            {
                t.x = -p.y;
                t.y = -p.x;
            }
            return t;
        }

        public void Start(Point src, string name , Orientation orientation)
        {
            route = new RoutePlanner(robot,map);
            StartRoutingTo(src,name);
            this.orientations.Add(orientation);
            this.names.Add(name);
        }

        public void Start(Point src, List<String> names, List<Orientation> orientations)
        {
            route = new RoutePlanner(robot, map);
            StartRoutingTo(src, names[0]);
            this.orientations.AddRange(orientations);
            this.names.AddRange(names);
            
//            var rec = FindStageRegion(name);
//            Point p = FindDestinationPoint(Rectangle.Round(rec));
//            route.Start(src, p);
//            this.orientation = orientation;
        }

        public void StartRoutingTo(Point src, string name)
        {
            var rec = FindStageRegion(name);
            Point p = FindDestinationPoint(Rectangle.Round(rec));


            log.Info("Location For Working Found" + p.x +","+p.y);
            route.Start(src, p);
        }

        BNTState state = BNTState.MOVING;
        private long startTime = 0;
        public void Tick()
        {
            if (orientations.Count == 0)
            {
                log.Info("BNT FINISHED");
                return;
            }
            var d = robot.Center - route.GetDestination();
            var orientation = orientations.First();
            switch (state)
            {
                case BNTState.ROTATING:
                    if (robot.IsMoving)
                        return;
                    if (robot.Orientation != orientation)
                    {
                        robot.Rotate(88);
                        log.Info(robot.Orientation);
                    }
                    else
                    {
                        state = BNTState.WAITING;
                        startTime =  DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    }
                    break;
                case BNTState.MOVING:
                    if (d.Lenght() < 4)
                    {
                        state = BNTState.ROTATING;
                        break;
                    }
                    route.Tick();
                    break;
                case BNTState.CORRECTING:
                    if (robot.IsMoving)
                        return;
                    if (robot.Orientation != Orientation.N)
                    {
                        robot.Rotate(88);
                        log.Info(robot.Orientation);
                    }
                    else
                    {
                        state = BNTState.MOVING;
                        orientations.RemoveAt(0);
                        names.RemoveAt(0);
                        if (names.Count > 0)
                            StartRoutingTo(robot.Center, names[0]);
                    }

                    break;
                case BNTState.WAITING:
                    var now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    if (now - startTime > 5000)
                    {
                        state = BNTState.CORRECTING;
                    }
                    break;
            }
            

            if(state == BNTState.MOVING)
                route.Tick();
            else
            {
                
                    
            }
        }

        public PathShape GetPathShape()
        {
            return route.GetPathShape();
        }

    }
}
