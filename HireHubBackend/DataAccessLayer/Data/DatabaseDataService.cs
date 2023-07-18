using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Data
{
    public class DatabaseDataService : IDatabaseDataService
    {
        private List<Employer> _employers = new List<Employer>()
        {
            new Employer
            {
                CompanyName="Nagarro",
                CompanyEmail="jobs@nagarro.com",
                CompanyPassword="1234"

            }
        };

        private List<Job> _jobs = new List<Job>()
        {
            new Job
            {
                Title="",
                Id=1,
                Description="",
                Experience="",
                Role="",
                Skills="",
                PostedBy="",
                Type=""

            }
        };

        public List<Employer> GetAllEmployers()
        {
            return _employers;
        }

        public List<Job> GetAllJobs()
        {
            return _jobs;
        }

        public bool AddJob(Job job)
        {
            job.Id = _jobs.Max(x => x.Id)+1;
            _jobs.Add(job);
            return true;
        }

    }
}
