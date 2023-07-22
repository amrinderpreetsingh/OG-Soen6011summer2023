using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public interface IJobService
    {
        public bool PostJob(Job job);
        public List<Job> GetJobsPostedByAnEmployer(string email);
        public bool UpdateJob(Job updatedJob);
        public bool DeleteJob(int id);
    }
}
