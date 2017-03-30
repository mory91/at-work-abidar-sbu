using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu.AI.Navigation
{
    public class PathFinder
    {
        const int MAP_WIDTH = 800; //x, cm
        const int MAP_HEIGHT = 600; //y, cm
        const int ROBOT_SIZE = 46; //cm
        int[,] dis;
        int[,] map;
        int[,] touchWall;
        Point[,] nxt;
        Point src, dst;
        List<Point> path;
        public PathFinder()
        {
            path = new List<Point>();
            dis = new int[MAP_WIDTH + 10, MAP_HEIGHT + 10];
            map = new int[MAP_WIDTH + 10, MAP_HEIGHT + 10];
            touchWall = new int[MAP_WIDTH + 10, MAP_HEIGHT + 10];
            nxt = new Point[MAP_WIDTH + 10, MAP_HEIGHT + 10];
            setSrc(0, 0);
            setDst(0, 0);
            for (int i = 0; i < MAP_WIDTH; i++)
                for (int j = 0; j < MAP_HEIGHT; j++)
                {
                    map[i, j] = 0;
                    dis[i, j] = -1;
                    touchWall[i, j] = 0;
                }
            for (int i = 0; i < MAP_WIDTH; i++)
                for (int j = 0; j < MAP_HEIGHT; j++)
                    nxt[i, j] = new Point(-1, -1);
        }
        public void setSrc(int x, int y)
        {
            if (isInMap(x, y))
                src = new Point(x, y);
        }
        public void setDst(int x, int y)
        {
            if (isInMap(x, y))
                dst = new Point(x, y);
        }
        public void findPath()
        {
            path.Clear();
            List<Point> q = new List<Point>();
            q.Add(src);
            dis[(int)src.x, (int)src.y] = 0;
            for (int i = 0; i < q.Count(); i++)
            {
                Point v = q[i];
                for (int k = 1; k >= 1; k--)
                    for (int dx = -1; dx <= 1; dx++)
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (Math.Abs(dx) + Math.Abs(dy) == k)
                            {
                                int x2 = (int)v.x + dx;
                                int y2 = (int)v.y + dy;
                                if (isInMap(x2, y2) && touchWall[x2, y2] == 0 && dis[x2, y2] == -1)
                                {
                                    nxt[x2, y2] = v;
                                    dis[x2, y2] = dis[(int)v.x, (int)v.y] + 1;
                                    q.Add(new Point(x2, y2));
                                }
                            }
                        }
            }
            path.Clear();
            Point cell = dst;
            while (cell.x >= 0 && cell.y >= 0 && isInMap((int)cell.x, (int)cell.y))
            {
                path.Add(cell);
                cell = nxt[(int)cell.x, (int)cell.y];
            }
            path.Reverse();
        }
        public void addObstacle(int x, int y, int w, int h)
        {
            for (int i = x; i < x + w; i++)
                for (int j = y; j < y + h; j++)
                {
                    if (!isInMap(i, j))
                        continue;
                    map[i, j] = 1; //1 for FULL, 0 for EMPTY
                    for (int i2 = i - ROBOT_SIZE / 2; i2 <= i + ROBOT_SIZE / 2; i2++)
                        for (int j2 = j - ROBOT_SIZE / 2; j2 <= j + ROBOT_SIZE / 2; j2++)
                            if (isInMap(i2, j2))
                                touchWall[i2, j2] = 1;
                }
        }
        public Point getSrc()
        {
            return src;
        }
        public Point getDst()
        {
            return dst;
        }
        public bool isInMap(int x, int y)
        {
            if (x < 0 || x > MAP_WIDTH)
                return false;
            if (y < 0 || y > MAP_HEIGHT)
                return false;
            return true;
        }
        public bool isValid(int x, int y)
        {
            if (!isInMap(x, y))
                return false;
            for (int i = x - ROBOT_SIZE / 2; i <= x + ROBOT_SIZE / 2; i++)
                for (int j = y - ROBOT_SIZE / 2; j <= y + ROBOT_SIZE / 2; j++)
                    if (!isInMap(i, j) || map[i, j] != 0) //out of bounds or obstacle
                        return false;
            return true;
        }
        public List<Point> getPath()
        {
            return path;
        }
    }
}
