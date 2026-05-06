using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder.Jobs
{
    public class Job
    {

        //constructor and variables for jobs
        public int Priority {  get; set; }
        public string Description { get; set; }
        public Point Location { get; set; }

        public Job( int priority, Point location, string description)
        {
            Location = location;
            Priority = priority;
            Description = description;
        }
    }
}
