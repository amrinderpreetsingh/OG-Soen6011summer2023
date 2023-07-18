using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public interface IEmployerService
    {
        public bool Login(string email, string password);
        public bool Signup(Employer employer);
        public List<Student> GetStudents();
    }
}
