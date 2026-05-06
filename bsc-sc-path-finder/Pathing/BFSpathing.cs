using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder.Pathing
{
    internal class BFSpathing
    {

        SortedArrayPriorityQueue<Point> discoveryQueue;

        public List<Point> FindPath(Grid grid, Point start, Point goal)
        {
            int priority = 4000;

            var path = new List<Point>();

            bool found = false;
            
            int tempX;
            int tempY;

            bool[,] visited = new bool[grid.Width, grid.Height];

            Point current;

            discoveryQueue = new SortedArrayPriorityQueue<Point>(4000);

            discoveryQueue.Enqueue(start, priority);

            while (discoveryQueue.IsEmpty() == false && found == false)
            {
                priority--;
                current = discoveryQueue.Peek();

                tempX = getLeft(current.X);
                tempY = current.Y;

                if (!found)
                {
                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        if (visited[tempX, tempY] == false && grid.GetTile(tempX, tempY) != null)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            if (tempTile.IsWalkable == true && grid.GetTile(tempX, tempY) != null)
                            {
                                visited[tempX, tempY] = true;
                                Point tempPoint = new Point(tempX, tempY);
                                discoveryQueue.Enqueue(tempPoint, priority);

                                path.Add(tempPoint);

                                if (tempX == goal.X && tempY == goal.Y)
                                {
                                    found = true;
                                }
                            }
                        }
                    }
                }

                tempX = getRight(current.X);

                if (!found)
                {
                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        if (visited[tempX, tempY] == false && grid.GetTile(tempX, tempY) != null)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            if (tempTile.IsWalkable == true && grid.GetTile(tempX, tempY) != null)
                            {
                                visited[tempX, tempY] = true;
                                Point tempPoint = new Point(tempX, tempY);
                                discoveryQueue.Enqueue(tempPoint, priority);

                                path.Add(tempPoint);

                                if (tempX == goal.X && tempY == goal.Y)
                                {
                                    found = true;
                                }
                            }
                        }
                    }
                }

                tempX = current.X;
                tempY = getAbove(current.Y);

                if (!found)
                {
                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        if (visited[tempX, tempY] == false && grid.GetTile(tempX, tempY) != null)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            if (tempTile.IsWalkable == true && grid.GetTile(tempX, tempY) != null)
                            {
                                visited[tempX, tempY] = true;
                                Point tempPoint = new Point(tempX, tempY);
                                discoveryQueue.Enqueue(tempPoint, priority);

                                path.Add(tempPoint);

                                if (tempX == goal.X && tempY == goal.Y)
                                {
                                    found = true;
                                }
                            }
                        }
                    }
                }

                tempY = getBelow(current.Y);

                if (!found)
                {
                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        if (visited[tempX, tempY] == false && grid.GetTile(tempX, tempY) != null)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            if (tempTile.IsWalkable == true && grid.GetTile(tempX, tempY) != null)
                            {
                                visited[tempX, tempY] = true;
                                Point tempPoint = new Point(tempX, tempY);
                                discoveryQueue.Enqueue(tempPoint, priority);

                                path.Add(tempPoint);

                                if (tempX == goal.X && tempY == goal.Y)
                                {
                                    found = true;
                                }
                            }
                        }
                    }
                }

                discoveryQueue.Dequeue();
            }
            return path;
        }


        int getLeft(int x) {  return x - 1; }
        int getRight(int x) { return x + 1; }

        int getAbove(int y) { return y - 1; }
        int getBelow(int y) { return y + 1; }

        
    }
}
