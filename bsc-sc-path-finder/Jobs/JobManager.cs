using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder
{ 

    public class JobManager
    {

        private SortedArrayPriorityQueue<Job> jobQueue;

        /// <summary>
        /// constructor for Job Manager
        /// </summary>
        public JobManager()
        {
            jobQueue = new SortedArrayPriorityQueue<Job>(100);
        }

        /// <summary>
        /// checks if queue is empty
        /// </summary>
        /// <returns>returns true or false</returns>
        public bool CheckJobs()
        {
            return jobQueue.IsEmpty();
        }


        /// <summary>
        /// removes the highest priority item from job queue
        /// </summary>
        /// <exception cref="InvalidOperationException">throws an exception if job queue is empty</exception>
        public void RemoveJob()
        {
            try
            {
                jobQueue.Dequeue();
            }
            catch(QueueUnderflowException ex)
            {
                throw new InvalidOperationException("Job Queue is empty.", ex);
            }
        }

        /// <summary>
        /// gets the queue item for the highest priority item
        /// </summary>
        /// <returns>the highest priority job object</returns>
        public Job GetJob()
        {
            return jobQueue.Peek();
        }

        /// <summary>
        /// adds a job object to the priority queue with a given priority
        /// </summary>
        /// <param name="job">job object to be stored</param>
        /// <param name="Priority">priority of the job</param>
        public void AddJob(Job job, int Priority)
        {
            jobQueue.Enqueue(job, Priority);
        }

        /// <summary>
        /// writes entire priority queue to string
        /// </summary>
        /// <returns>the concatinated string variable</returns>
        public string createList()
        {
            string taskList = jobQueue.ToString();

            return taskList;
        }
    }
}