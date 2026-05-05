using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder.Jobs
{ 

    public class JobManager
    {

        private SortedArrayPriorityQueue<Job> jobQueue;

        //constructor to call the sorted array priority queue
        public JobManager()
        {
            jobQueue = new SortedArrayPriorityQueue<Job>(100);
        }

        //checks if job queue is empty
        public bool CheckJobs()
        {
            return jobQueue.IsEmpty();
        }

        //removes the highest priority queue item
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

        //returns the highest priority job
        public Job GetJob()
        {
            return jobQueue.Peek();
        }

        //adds a new job to the queue
        public void AddJob(Job job, int Priority)
        {
            jobQueue.Enqueue(job, Priority);
        }

        //creates a string list of all the jobs currently in queue
        public string createList()
        {
            string taskList = jobQueue.ToString();

            return taskList;
        }
    }
}