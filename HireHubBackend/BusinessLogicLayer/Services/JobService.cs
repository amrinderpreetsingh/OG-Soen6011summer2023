using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class JobService : IJobService
    {
        private readonly IDatabaseDataService _databaseDataService;

        public JobService(IDatabaseDataService databaseDataService)
        {
            _databaseDataService = databaseDataService;
        }

        public bool PostJob(Job job)
        {

            return _databaseDataService.AddJob(job);
        }

        public List<Job> GetJobsPostedByAnEmployer(string email)
        {
            var allJobs = _databaseDataService.GetAllJobs();
            var jobsPostedByEmployer = allJobs.Where(x => x.PostedBy.ToLower().Equals(email.ToLower())).ToList();
            return jobsPostedByEmployer;
        }

        
        public bool UpdateJob(Job updatedJob)
        {
            var originalJob = _databaseDataService.GetJob(updatedJob.Id);
            if (originalJob == null)
            {
                return false;
            }
            originalJob.PostedBy = updatedJob.PostedBy;
            originalJob.Role = updatedJob.Role;
            originalJob.Skills = updatedJob.Skills;
            originalJob.Title = updatedJob.Title;
            originalJob.Description = updatedJob.Description;
            originalJob.Experience = updatedJob.Experience;
            return true;
        }

        public bool DeleteJob(int id)
        {
            return _databaseDataService.DeleteJob(id);
        }
    }
}
