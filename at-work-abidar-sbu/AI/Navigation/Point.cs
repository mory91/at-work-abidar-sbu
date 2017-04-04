using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu.AI.Navigation
{
    public class Point
    {
        public double x
        {
            get; set;
        }
        public double y
        {
            get; set;
        }
        public Point(double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
        }
        public static Point operator +(Point p, Point q)
        {
            return new Point(p.x + q.x, p.y + q.y);
        }
        public static Point operator -(Point p, Point q)
        {
            return new Point(p.x - q.x, p.y - q.y);
        }
        public static Point operator *(double k, Point p)
        {
            return new Point(k * p.x, k * p.y);
        }

        public double Lenght()
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
}
