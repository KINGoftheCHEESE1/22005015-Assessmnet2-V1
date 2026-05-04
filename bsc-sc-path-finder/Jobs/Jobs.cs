using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder.Jobs
{
    internal class Jobs
    {
        public int Priority {  get; set; }
        public string Description { get; set; }
        public Point Location { get; set; }

        public Jobs( int priority, Point location, string description)
        {
            Location = location;
            Priority = priority;
            Description = description;
        }


    }
}
