using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public interface IStudentService
    {
        public bool Login(string email, string password);
        public bool Signup(Student employer);
        public List<Job> GetAllJobs();
    }
}
