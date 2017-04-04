using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.Robotics;

namespace at_work_abidar_sbu.UI.GraphicUtils
{
    class RobotRenderer : IObjectRenderer<IRobot>
    {
        int ROBOT_SIZE = 44;

        public void Render(IRobot robot, Bitmap bitmap, float scalex, float scaley)
        {
            Graphics gr = Graphics.FromImage(bitmap);

            if (robot.Center != null)
            {
                Rectangle robotRectangle = new Rectangle((int) ((robot.Center.x - ROBOT_SIZE / 2) * scalex),
                    (int) ((robot.Center.y - ROBOT_SIZE / 2) * scaley),
                    (int) (ROBOT_SIZE * scalex), (int) (ROBOT_SIZE * scaley));
                gr.FillRectangle(Brushes.Gold, robotRectangle);
            }

            DrawLaseres(robot, bitmap, scalex, scaley);
        }

        public void Render(object obj, Bitmap bmp, float scalex, float scaley)
        {
            Render((IRobot) obj, bmp, scalex, scaley);
        }

        private const int LASER_TO_SIDE = 7;
        private const int LASER_TO_FRONT = 2;

        public void DrawLaseres(IRobot robot, Bitmap bitmap, float scalex, float scaley)
        {
//            //Todo Very Bad Code , No Robot Orientation
//            var scalex = bitmap.Width / map.width;
//            var scaley = bitmap.Height / map.height;
            Graphics gr = Graphics.FromImage(bitmap);
//            if (center != null)
//            {
            int Bottom = (int) (robot.Center.y + ROBOT_SIZE / 2);
            int Left = (int) (robot.Center.x - ROBOT_SIZE / 2);
            int Top = (int) (robot.Center.y - ROBOT_SIZE / 2);
            int Right = (int) (robot.Center.x + ROBOT_SIZE / 2);

            var LF = robot.LF - ROBOT_SIZE / 2 + LASER_TO_FRONT;
            var RF = robot.RF - ROBOT_SIZE / 2 + LASER_TO_FRONT;

            var LL = robot.LL - ROBOT_SIZE / 2 + LASER_TO_SIDE;
            var RR = robot.RR - ROBOT_SIZE / 2 + LASER_TO_SIDE;
            //                //                gr.DrawLine(Pens.Brown,(int) (Left*scalex), (int)(Bottom *scaley), (int)(Left * scalex), (int)((Bottom+RF) * scaley));
            //                //                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Bottom * scaley), (int)((Left-RR) * scalex), (int)((Bottom) * scaley));
            //                //                Left += ROBOT_SIZE;
            //                //                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Bottom * scaley), (int)(Left * scalex), (int)((Bottom + LF) * scaley));
            //                //                gr.DrawLine(Pens.Brown, (int)(Left * scalex), (int)(Bottom * scaley), (int)((Left + LL) * scalex), (int)((Bottom) * scaley));
            gr.DrawLine(Pens.Brown, (int) (Left * scalex), (int) (Top * scaley), (int) (Left * scalex),
                (int) ((Top - LF) * scaley));
            gr.DrawLine(Pens.Brown, (int) (Left * scalex), (int) (Top * scaley), (int) ((Left - LL) * scalex),
                (int) ((Top) * scaley));
            gr.DrawLine(Pens.Brown, (int) (Right * scalex), (int) (Top * scaley), (int) (Right * scalex),
                (int) ((Top - RF) * scaley));
            gr.DrawLine(Pens.Brown, (int) (Right * scalex), (int) (Top * scaley), (int) ((Right + RR) * scalex),
                (int) ((Top) * scaley));

//            }
//            return this;
        }
    }
}
