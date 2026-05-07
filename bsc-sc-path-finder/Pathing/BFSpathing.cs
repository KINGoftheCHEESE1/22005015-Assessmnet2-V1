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

        
        /// <summary>
        /// this function is used to find a path between the robot and the goal through the use of BFS
        /// skips unwalkable tiles on grid
        /// </summary>
        /// <param name="grid">the current grid object of the map</param>
        /// <param name="start">the robot location, starting poitn for the path</param>
        /// <param name="goal">the coordinate being searched for by the BFS algorithm</param>
        /// <returns>path, coordinate list between the starting point and goal point</returns>
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

        /// <summary>
        /// gets the coordinate to the left of the current tile
        /// </summary>
        /// <param name="x">X coordinate of current tile</param>
        /// <returns></returns>
        int getLeft(int x) {  return x - 1; }


        /// <summary>
        /// gets the coordinate to the right of the current tile
        /// </summary>
        /// <param name="x">X coordinate of current tile</param>
        /// <returns></returns>
        int getRight(int x) { return x + 1; }


        /// <summary>
        /// gets the coordinate above the current tile
        /// </summary>
        /// <param name="y">Y coordinate of current tile</param>
        /// <returns></returns>
        int getAbove(int y) { return y - 1; }


        /// <summary>
        /// gets the coordinate below the current tile
        /// </summary>
        /// <param name="y">Y coordinate of current tile</param>
        /// <returns></returns>
        int getBelow(int y) { return y + 1; }

        
    }
}
