using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace bsc_sc_path_finder.Jobs
{ 

    internal class JobManager
    {

        private PriorityQueue<Jobs> jobQueue;

        public JobManager()
        {
            jobQueue = new SortedArrayPriorityQueue<Jobs>(100);
        }

        public bool CheckJobs()
        {
            return jobQueue.IsEmpty();
        }

        public void RemoveJob()
        {
            try
            {
                jobQueue.Dequeque();
            }
            catch(QueueUnderflowException ex)
            {
                throw new InvalidOperationException("Job Queue is empty.", ex);
            }
        }

        public Jobs GetJob()
        {
            return jobQueue.Peek();
        }

        public void AddJob(Jobs job, int Priority)
        {
            jobQueue.Enqueue(job,  Priority);
        }
    }
}