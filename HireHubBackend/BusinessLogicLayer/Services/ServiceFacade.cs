using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class ServiceFacade : IServiceFacade
    {
        private readonly IEmployerService _employerService;
        private readonly IJobService _jobService;

        public ServiceFacade(IEmployerService employerService, IJobService jobService)
        {
            _employerService = employerService;
            _jobService = jobService;
        }

        public bool EmployerSignup(Employer employer)
        {
            return _employerService.Signup(employer);
        }

        public bool EmployerLogin(string email, string password)
        {
            return _employerService.Login(email, password);
        }

        public bool PostJob(Job job)
        {
            return _jobService.PostJob(job);
        }

        public List<Job> GetJobsPostedByAnEmployer(string email)
        {
            return _jobService.GetJobsPostedByAnEmployer(email);
        }
    }
}
