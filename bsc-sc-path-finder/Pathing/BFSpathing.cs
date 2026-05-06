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
            //variables used for BFS search
            int priority = 4000;
            var path = new List<Point>();
            var movedFrom = new Dictionary<Point, Point>();
            
            int tempX;
            int tempY;

            bool[,] visited = new bool[grid.Width, grid.Height];

            Point current;

            //add start to priority queue
            discoveryQueue = new SortedArrayPriorityQueue<Point>(4000);
            discoveryQueue.Enqueue(start, priority);

            while (discoveryQueue.IsEmpty() == false)
            {
                priority--;
                current = discoveryQueue.Peek();
                discoveryQueue.Dequeue();

                //creates path is goal has been found by the algorithm
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

                //if the goal has not been found check the grid coordinates around the current coordinate
                if (current != goal)
                {

                    tempX = getLeft(current.X);
                    tempY = current.Y;

                    //checks coord is in grid
                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        //checks coord has not been visited
                        if (visited[tempX, tempY] == false)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            //checks coord is walkable and 
                            if (tempTile.IsWalkable == true)
                            {

                                //add coord to priority queue and setup pathing callback
                                Point tempPoint = new Point(tempX, tempY);
                                visited[tempX, tempY] = true;
                                
                                discoveryQueue.Enqueue(tempPoint, priority);

                                movedFrom[tempPoint] = current;
                            }
                        }
                    }


                    tempX = getRight(current.X);


                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        //checks coord has not been visited
                        if (visited[tempX, tempY] == false)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            //checks coord is walkable and 
                            if (tempTile.IsWalkable == true)
                            {

                                //add coord to priority queue and setup pathing callback
                                Point tempPoint = new Point(tempX, tempY);
                                visited[tempX, tempY] = true;

                                discoveryQueue.Enqueue(tempPoint, priority);

                                movedFrom[tempPoint] = current;
                            }
                        }
                    }


                    tempX = current.X;
                    tempY = getAbove(current.Y);

                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        //checks coord has not been visited
                        if (visited[tempX, tempY] == false)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            //checks coord is walkable and 
                            if (tempTile.IsWalkable == true)
                            {

                                //add coord to priority queue and setup pathing callback
                                Point tempPoint = new Point(tempX, tempY);
                                visited[tempX, tempY] = true;

                                discoveryQueue.Enqueue(tempPoint, priority);

                                movedFrom[tempPoint] = current;
                            }
                        }
                    }


                    tempY = getBelow(current.Y);

                    if (tempX < grid.Width && tempY < grid.Height && tempX >= 0 && tempY >= 0)
                    {
                        //checks coord has not been visited
                        if (visited[tempX, tempY] == false)
                        {
                            ITileType tempTile = grid.GetTile(tempX, tempY).Type;

                            //checks coord is walkable and 
                            if (tempTile.IsWalkable == true)
                            {

                                //add coord to priority queue and setup pathing callback
                                Point tempPoint = new Point(tempX, tempY);
                                visited[tempX, tempY] = true;

                                discoveryQueue.Enqueue(tempPoint, priority);

                                movedFrom[tempPoint] = current;
                            }
                        }
                    }
                }
            }
            return path;
        }

        //gets left coord
        int getLeft(int x) {  return x - 1; }
        //get right coord
        int getRight(int x) { return x + 1; }
        //get above coord
        int getAbove(int y) { return y - 1; }
        //get below coord
        int getBelow(int y) { return y + 1; }

        
    }
}
