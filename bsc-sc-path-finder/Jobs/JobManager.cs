using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder.Jobs
{ 

    public class JobManager
    {

        private SortedArrayPriorityQueue<Job> jobQueue;

        public JobManager()
        {
            jobQueue = new SortedArrayPriorityQueue<Job>(100);
        }

        public bool CheckJobs()
        {
            return jobQueue.IsEmpty();
        }

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

        public Job GetJob()
        {
            return jobQueue.Peek();
        }

        public void AddJob(Job job, int Priority)
        {
            jobQueue.Enqueue(job,  Priority);
        }
    }
}