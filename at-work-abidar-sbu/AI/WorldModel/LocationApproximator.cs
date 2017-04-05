using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.Navigation;

namespace at_work_abidar_sbu.AI.WorldModel
{
	class LocationApproximator
	{

		private int[] _dy = { +1, 0, -1, 0 }; //Front, Left, Rear, Right
		private int[] _dx = { 0, +1, 0, -1 };
		int[,] map;
		int[,] touchWall;
		int[,,] obstacleDistance;

		private int _MapWidth = 800;
		private int _MapHeight = 600;

		const int RobotSize = 45; //cm
		const int RobotPadding = 6;

		private int MapWidth => _MapWidth;
		int MapHeight => _MapHeight;
		public void SetUp(Map imap)
		{
			_MapWidth = (int)imap.width;
			_MapHeight = (int)imap.height;
			map = new int[MapWidth + 10, MapHeight + 10];
			touchWall = new int[MapWidth + 10, MapHeight + 10];
			obstacleDistance = new int[MapWidth + 10, MapHeight + 10, 4];
			for (int i = 0; i <= MapWidth; i++)
				for (int j = 0; j <= MapHeight; j++)
				{
					map[i, j] = 0;
					touchWall[i, j] = 0;
					for (int k = 0; k < 4; k++)
						obstacleDistance[i, j, k] = -1;
				}
			foreach (MapObject o in imap.obstacles)
			{
                if (o.Type != WorldObjectType.QR)
                    AddObstacle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height, o.Type == WorldObjectType.Wall);
			}
			CalcObstacleDistances();
		}

		public Point GetLocation(int rectX, int rectY, int rectW, int rectH, int orientation, double laserLL, double laserLF, double laserRR, double laserRF)
		{
			double[] lasers = { -1, laserLL, -1, laserRR };
			int srcX = rectX + rectW / 2;
			int srcY = rectY + rectH / 2;
			double minSum = 1000 * 1000 * 1000 + 10;
			for (int i = rectX; i <= rectX + rectW; i++)
			{
				for (int j = rectY; j <= rectY + rectH; j++)
				{
					int laserLX = i + _dx[(orientation + 1) % 4] * 11;
					int laserLY = j + _dy[(orientation + 1) % 4] * 11;
					int laserRX = i + _dx[(orientation + 3) % 4] * 11;
					int laserRY = j + _dy[(orientation + 3) % 4] * 11;
					if (!IsInMap(i, j) || touchWall[i, j] != 0 || !IsInMap(laserLX, laserLY) || !IsInMap(laserRX, laserRY))
						continue;
					double sum = 0;
					for (int k = 0; k < 4; k++)
					{
						int k2 = (k + orientation) % 4;
						if (obstacleDistance[i, j, k2] > Math.Max(MapWidth, MapHeight) && lasers[k] > 200)
							continue;
						if (obstacleDistance[i, j, k2] != -1 && lasers[k] > 0)
							sum += Math.Abs(lasers[k] - obstacleDistance[i, j, k2]);
					}
					sum += Math.Abs(laserLF - obstacleDistance[laserLX, laserLY, orientation]);
					sum += Math.Abs(laserRF - obstacleDistance[laserRX, laserRY, orientation]);
					if (sum < minSum)
					{
						minSum = sum;
						srcX = i;
						srcY = j;
					}
				}
			}
			return new Point(srcX, srcY);
		}
		private void CalcObstacleDistances()
		{
			for (int k = 0; k < 4; k++)
				for (int i = 0; i < MapWidth; i++)
					for (int j = 0; j < MapHeight; j++)
						CalcDis(i, j, k);
		}
		private int CalcDis(int x, int y, int orientation)
		{
			if (!IsInMap(x, y)) //outside
			{
				return Math.Max(MapWidth, MapHeight) * 2; //INF
			}
			if (obstacleDistance[x, y, orientation] != -1)
				return obstacleDistance[x, y, orientation];
			if (map[x, y] == 2) //wall
			{
				if (IsInMap(x, y))
					obstacleDistance[x, y, orientation] = 0;
				return 0;
			}
			int x2 = x + _dx[orientation];
			int y2 = y + _dy[orientation];
			obstacleDistance[x, y, orientation] = CalcDis(x2, y2, orientation) + 1;
			return obstacleDistance[x, y, orientation];
		}
		private bool IsInMap(int x, int y)
		{
			if (x < 0 || x > MapWidth)
				return false;
			if (y < 0 || y > MapHeight)
				return false;
			return true;
		}
		public void AddObstacle(int x, int y, int w, int h, bool isWall)
		{
			int tmp = 1; //robot touches but laser doesn't
			if (isWall)
				tmp = 2; //robot and laser touch
			for (int i = x; i < x + w; i++)
				for (int j = y; j < y + h; j++)
				{
					if (!IsInMap(i, j))
						continue;
					map[i, j] = tmp;
					for (int i2 = i - RobotSize / 2 - RobotPadding; i2 <= i + RobotSize / 2 + RobotPadding; i2++)
						for (int j2 = j - RobotSize / 2 - RobotPadding; j2 <= j + RobotSize / 2 + RobotPadding; j2++)
							if (IsInMap(i2, j2))
								touchWall[i2, j2] = 1;
				}
		}
	}
}