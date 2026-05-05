using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder.Pathing
{
    internal class BFSpathing
    {

        SortedArrayPriorityQueue<Point> discoveryQueue;

        public List<Point> FindPath(Point start, Point goal)
        {
            int priority = 100;
            bool[][] visited = new bool[100][100];
            var path = new List<Point>();
            var current = new List<Point>();

            discoveryQueue = new SortedArrayPriorityQueue<Point>;

            visited[start.X][start.Y] = true;
            discoveryQueue.Enqueue(start);

            while (discoveryQueue.IsEmpty() == false) 
            {

            }
        }
    }
}
