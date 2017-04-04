using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.WorldModel;
using at_work_abidar_sbu.HardwareAPI;
using at_work_abidar_sbu.Robotics;
using Point = at_work_abidar_sbu.AI.Navigation.Point;

namespace at_work_abidar_sbu.AI.Tasks
{
    class BNT
    {
        private  readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Map map;
        private IRobot robot;
        private RotationChecker rotationChecker;
        private int ROBOT_SIZE = 44;

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
                if (o.Type == WordObjectType.Entry)
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
                if (o.Type == WordObjectType.Stage && o.Name == name)
                {
                    stage = o;
                    break;
                }
            }
            if (stage != null)
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

    }
}
