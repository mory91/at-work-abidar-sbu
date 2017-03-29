using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace at_work_abidar_sbu
{
	public partial class PathFinderForm : Form
	{
		public PathFinderForm()
		{
			InitializeComponent();
		}
	}
	
	public class Noqte
	{
		public double x, y;
		public Noqte(double _x = 0, double _y = 0)
		{
			x = _x;
			y = _y;
		}
		public static Noqte operator +(Noqte p, Noqte q)
		{
			return new Noqte(p.x + q.x, p.y + q.y);
		}
		public static Noqte operator -(Noqte p, Noqte q)
		{
			return new Noqte(p.x - q.x, p.y - q.y);
		}
		public static Noqte operator *(double k, Noqte p)
		{
			return new Noqte(k * p.x, k * p.y);
		}
	}

	public class PathFinder
	{
		const int MAP_WIDTH = 800; //x, cm
		const int MAP_HEIGHT = 600; //y, cm
		const int ROBOT_SIZE = 46; //cm
		int[,] dis;
		int[,] map;
		int[,] touchWall;
		Noqte[,] nxt;
		Noqte src, dst;
		List<Noqte> path;
		public PathFinder()
		{
			path = new List<Noqte>();
			dis = new int[MAP_WIDTH + 10, MAP_HEIGHT + 10];
			map = new int[MAP_WIDTH + 10, MAP_HEIGHT + 10];
			touchWall = new int[MAP_WIDTH + 10, MAP_HEIGHT + 10];
			nxt = new Noqte[MAP_WIDTH + 10, MAP_HEIGHT + 10];
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
					nxt[i, j] = new Noqte(-1, -1);
		}
		public void setSrc(int x, int y)
		{
			if (isInMap(x, y))
				src = new Noqte(x, y);
		}
		public void setDst(int x, int y)
		{
			if (isInMap(x, y))
				dst = new Noqte(x, y);
		}
		public void findPath()
		{
			path.Clear();
			List<Noqte> q = new List<Noqte>();
			q.Add(src);
			dis[(int)src.x, (int)src.y] = 0;
			for (int i = 0; i < q.Count(); i++)
			{
				Noqte v = q[i];
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
									q.Add(new Noqte(x2, y2));
								}
							}
						}
			}
			path.Clear();
			Noqte cell = dst;
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
		public Noqte getSrc()
		{
			return src;
		}
		public Noqte getDst()
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
		public List<Noqte> getPath()
		{
			return path;
		}
	}
}