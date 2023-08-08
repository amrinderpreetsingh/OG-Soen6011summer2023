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
        public List<Employer> GetAllEmployers();
        public bool UpdateEmployer(Employer updatedEmployer);
        public bool DeleteEmployer(int id);
        public bool AcceptStudent(int studentId, int jobId);
        public bool DeclineStudent(int studentId, int jobId);
        public bool SelectStudentForInterview(int studentId, int jobId);
    }
}
