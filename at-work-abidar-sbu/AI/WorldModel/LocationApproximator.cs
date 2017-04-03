﻿using System;
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

        const int RobotSize = 55; //cm

        private int MapWidth => _MapWidth;
        int MapHeight => _MapHeight;
        private void SetUp(Map imap)
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
                AddObstacle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height, o.Type == WordObjectType.Wall);
            }
            CalcObstacleDistances();
        
        }

        public Point GetLocation(int rectX, int rectY, int rectW, int rectH, int orientation, double laserLL, double laserLF, double laserRR, double laserRF)
        {
            double[] lasers = { (laserLF + laserRF) / 2.0, laserLL, -1, laserRR };
            int srcX = 0;
            int srcY = 0;
            double minSum = 1000 * 1000 * 1000 + 10;
            for (int i = rectX; i <= rectX + rectW; i++)
                for (int j = rectY; j <= rectY + rectH; j++)
                {
                    if (!IsInMap(i, j) || touchWall[i, j] != 0)
                        continue;
                    double sum = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        int k2 = (k + orientation) % 4;
                        if (obstacleDistance[i, j, k2] != -1 && lasers[k] > 0)
                            sum += Math.Abs(lasers[k] - obstacleDistance[i, j, k2]);
                    }
                    if (sum < minSum)
                    {
                        minSum = sum;
                        srcX = i;
                        srcY = j;
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
        private int  CalcDis(int x, int y, int orientation)
        {
            if (!IsInMap(x, y) || map[x, y] == 2) //out or wall
            {
                if (IsInMap(x, y))
                    obstacleDistance[x, y, orientation] = 0;
                return 0;
            }
            if (obstacleDistance[x, y, orientation] != -1)
                return obstacleDistance[x, y, orientation];
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
            int tmp = 1;
            if (isWall)
                tmp = 2;
            for (int i = x; i < x + w; i++)
                for (int j = y; j < y + h; j++)
                {
                    if (!IsInMap(i, j))
                        continue;
                    map[i, j] = tmp; //1 for FULL, 0 for EMPTY
                    for (int i2 = i - RobotSize / 2; i2 <= i + RobotSize / 2; i2++)
                        for (int j2 = j - RobotSize / 2; j2 <= j + RobotSize / 2; j2++)
                            if (IsInMap(i2, j2))
                                touchWall[i2, j2] = 1;
                }
        }
    }
}
