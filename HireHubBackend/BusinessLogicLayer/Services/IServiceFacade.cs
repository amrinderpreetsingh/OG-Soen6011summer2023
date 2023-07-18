using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public interface IServiceFacade
    {
        public bool EmployerSignup(Employer employer);
        public bool EmployerLogin(string email, string password);
        public bool PostJob(Job job);
        public List<Job> GetJobsPostedByAnEmployer(string email);
        public bool StudentSignup(Student student);
        public bool StudentLogin(string email, string password);
    }
}
