using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Data
{
    public interface IDatabaseDataService
    {
        public List<Employer> GetAllEmployers();
        public bool AddJob(Job job);
        public List<Job> GetAllJobs();
    }
}
