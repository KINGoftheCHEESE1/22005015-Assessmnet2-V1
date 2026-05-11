using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NUnit.Framework;
using bsc_sc_path_finder;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace bsc_sc_path_finderTests
{

   
 
    [TestFixture]
    public class PathFindingTests
    {
        
        public DumbPathFinder dumbtest = new DumbPathFinder();
        public BFSpathing BFStest = new BFSpathing();
        public JobManager jobtest;

        [Test]
        public void job_starts_empty_test()
        {
            jobtest = new JobManager();

            var result = jobtest.CheckJobs();

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void job_show_not_empty()
        {
            jobtest = new JobManager();
            Point testLocation = new Point(1, 1);

            Job test = new Job(1, testLocation, "test");

            jobtest.AddJob(test, 10);

            var result = jobtest.CheckJobs();

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void job_Enqueue_test()
        {
            jobtest = new JobManager();
            Point testLocation = new Point(1, 1);

            Job test = new Job(1, testLocation, "test");

            jobtest.AddJob(test, 10);

            var result = jobtest.GetJob().Description;

            Assert.That(result, Is.EqualTo("test"));
        }

        [Test]
        public void job_Dequeue_test()
        {
            jobtest = new JobManager();
            Point testLocation = new Point(1, 1);

            Job test = new Job(1, testLocation, "test");

            jobtest.AddJob(test, 10);
            jobtest.RemoveJob();

            var result = jobtest.CheckJobs();

            Assert.That(result, Is.EqualTo(true));
        }


        [Test]
        public void job_Enqueue_Top_Priority_test()
        {
            jobtest = new JobManager();
            Point testLocation = new Point(1, 1);

            Job lowtest = new Job(1, testLocation, "lowest test");
            Job midtest = new Job(1, testLocation, "middle test");
            Job toptest = new Job(1, testLocation, "highest test");

            jobtest.AddJob(lowtest,1);
            jobtest.AddJob(midtest, 2);
            jobtest.AddJob(toptest, 3);

            var result = jobtest.GetJob().Description;

            Assert.That(result, Is.EqualTo("highest test"));
        }


        [Test]
        public void job_Enqueue_Mid_Priority_test()
        {
            jobtest = new JobManager();
            Point testLocation = new Point(1, 1);

            Job lowtest = new Job(1, testLocation, "lowest test");
            Job midtest = new Job(1, testLocation, "middle test");
            Job toptest = new Job(1, testLocation, "highest test");

            jobtest.AddJob(lowtest, 1);
            jobtest.AddJob(midtest, 2);
            jobtest.AddJob(toptest, 3);

            jobtest.RemoveJob();

            var result = jobtest.GetJob().Description;

            Assert.That(result, Is.EqualTo("middle test"));
        }

        [Test]
        public void job_Enqueue_Low_Priority_test()
        {
            jobtest = new JobManager();
            Point testLocation = new Point(1, 1);

            Job lowtest = new Job(1, testLocation, "lowest test");
            Job midtest = new Job(1, testLocation, "middle test");
            Job toptest = new Job(1, testLocation, "highest test");

            jobtest.AddJob(lowtest, 1);
            jobtest.AddJob(midtest, 2);
            jobtest.AddJob(toptest, 3);

            jobtest.RemoveJob();
            jobtest.RemoveJob();

            var result = jobtest.GetJob().Description;

            Assert.That(result, Is.EqualTo("lowest test"));
        }

        [Test]
        public void job_Empties_test()
        {
            jobtest = new JobManager();
            Point testLocation = new Point(1, 1);

            Job lowtest = new Job(1, testLocation, "lowest test");
            Job midtest = new Job(1, testLocation, "middle test");
            Job toptest = new Job(1, testLocation, "highest test");

            jobtest.AddJob(lowtest, 1);
            jobtest.AddJob(midtest, 2);
            jobtest.AddJob(toptest, 3);

            jobtest.RemoveJob();
            jobtest.RemoveJob();
            jobtest.RemoveJob();

            var result = jobtest.CheckJobs();

            Assert.That(result, Is.EqualTo(true));
        }
    }
}
