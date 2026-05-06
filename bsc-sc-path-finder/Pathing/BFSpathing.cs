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

            var discovered = new List<Point>();

            var movedFrom = new Dictionary<Point, Point>();
            
            int tempX;
            int tempY;

            bool[,] visited = new bool[grid.Width, grid.Height];

            Point current;

            discoveryQueue = new SortedArrayPriorityQueue<Point>(4000);

            discoveryQueue.Enqueue(start, priority);

            discovered.Add(start);

            while (discoveryQueue.IsEmpty() == false)
            {
                priority--;
                current = discoveryQueue.Peek();
                discoveryQueue.Dequeue();

                if (current == goal) {

                    var temp = goal;

                    while (temp != start)
                    {
                        path.Add(temp);
                        temp = movedFrom[temp];
                    }

                    path.Reverse();

                    return path;
                }

                if (current != goal)
                {

                    tempX = getLeft(current.X);
                    tempY = current.Y;

                    

                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        if (visited[tempX, tempY] == false && grid.GetTile(tempX, tempY) != null)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            if (tempTile.IsWalkable == true && grid.GetTile(tempX, tempY) != null)
                            {
                                Point tempPoint = new Point(tempX, tempY);
                                visited[tempX, tempY] = true;
                                
                                discoveryQueue.Enqueue(tempPoint, priority);

                                discovered.Add(tempPoint);

                                movedFrom[tempPoint] = current;
                            }
                        }
                    }


                    tempX = getRight(current.X);


                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        if (visited[tempX, tempY] == false && grid.GetTile(tempX, tempY) != null)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            if (tempTile.IsWalkable == true && grid.GetTile(tempX, tempY) != null)
                            {
                                Point tempPoint = new Point(tempX, tempY);
                                visited[tempX, tempY] = true;

                                discoveryQueue.Enqueue(tempPoint, priority);

                                discovered.Add(tempPoint);

                                movedFrom[tempPoint] = current;
                            }
                        }
                    }


                    tempX = current.X;
                    tempY = getAbove(current.Y);

                    if (tempX < grid.Width && tempY <= grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        if (visited[tempX, tempY] == false && grid.GetTile(tempX, tempY) != null)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            if (tempTile.IsWalkable == true && grid.GetTile(tempX, tempY) != null)
                            {
                                Point tempPoint = new Point(tempX, tempY);
                                visited[tempX, tempY] = true;

                                discoveryQueue.Enqueue(tempPoint, priority);

                                discovered.Add(tempPoint);

                                movedFrom[tempPoint] = current;
                            }
                        }
                    }


                    tempY = getBelow(current.Y);

                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        if (visited[tempX, tempY] == false && grid.GetTile(tempX, tempY) != null)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            if (tempTile.IsWalkable == true && grid.GetTile(tempX, tempY) != null)
                            {
                                Point tempPoint = new Point(tempX, tempY);
                                visited[tempX, tempY] = true;

                                discoveryQueue.Enqueue(tempPoint, priority);

                                discovered.Add(tempPoint);

                                movedFrom[tempPoint] = current;
                            }
                        }
                    }
                }
            }
            return path;
        }


        int getLeft(int x) {  return x - 1; }
        int getRight(int x) { return x + 1; }

        int getAbove(int y) { return y - 1; }
        int getBelow(int y) { return y + 1; }

        
    }
}
