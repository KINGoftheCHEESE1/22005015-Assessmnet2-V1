using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder
{
    public class Job
    {
        public int Priority {  get; set; }
        public string Description { get; set; }
        public Point Location { get; set; }

        /// <summary>
        /// constructor for jobs
        /// </summary>
        /// <param name="priority">riority used for priority queue</param>
        /// <param name="location">coordinate point used for placing on grid</param>
        /// <param name="description">job description</param>
        public Job( int priority, Point location, string description)
        {
            Location = location;
            Priority = priority;
            Description = description;
        }
    }
}
