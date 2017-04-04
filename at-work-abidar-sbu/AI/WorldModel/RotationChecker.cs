using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using at_work_abidar_sbu.AI.Navigation;

namespace at_work_abidar_sbu.AI.WorldModel
{
    class RotationChecker
    {

        private int[] _dy = { +1, 0, -1, 0 }; //Front, Left, Rear, Right
        private int[] _dx = { 0, +1, 0, -1 };
        int[,] map;
        int[,] touchWall;
		int[,] touchWallRotate;

        private int _MapWidth = 800;
        private int _MapHeight = 600;

        const int RobotSize = 45; //cm
		const int RobotPadding = 6;
		const int RobotRadius = (int)((RobotSize / 2.0) * 1.4142135623);

        private int MapWidth => _MapWidth;
        int MapHeight => _MapHeight;
        public void SetUp(Map imap)
        {
            _MapWidth = (int)imap.width;
            _MapHeight = (int)imap.height;
            map = new int[MapWidth + 10, MapHeight + 10];
            touchWall = new int[MapWidth + 10, MapHeight + 10];
			touchWallRotate = new int[MapWidth + 10, MapHeight + 10];
            for (int i = 0; i <= MapWidth; i++)
                for (int j = 0; j <= MapHeight; j++)
                {
                    map[i, j] = 0;
                    touchWall[i, j] = 0;
					touchWallRotate[i, j] = 0;
                }
            foreach (MapObject o in imap.obstacles)
            {
                AddObstacle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height, o.Type == WordObjectType.Wall);
            }
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
					for (int i2 = i - RobotRadius - RobotPadding; i2 <= i + RobotRadius + RobotPadding; i2++)
						for (int j2 = j - RobotRadius - RobotPadding; j2 <= j + RobotRadius + RobotPadding; j2++)
							if (IsInMap(i2, j2))
								touchWallRotate[i2, j2] = 1;
				}
        }
		public bool CanStand(int x, int y)
		{
			return IsInMap(x, y) && touchWall[x, y] == 0;
		}
		public bool CanRotate(int x, int y)
		{
			return IsInMap(x, y) && touchWallRotate[x, y] == 0;
		}
    }
}
