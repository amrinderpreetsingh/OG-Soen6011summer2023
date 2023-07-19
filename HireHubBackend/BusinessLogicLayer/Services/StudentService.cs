using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IDatabaseDataService _databaseDataService;

        public StudentService(IDatabaseDataService databaseDataService)
        {
            _databaseDataService = databaseDataService;
        }

        public bool Login(string email, string password)
        {
            var students = _databaseDataService.GetAllStudents();
            if (students.Exists(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password.Equals(password)))
            {
                return true;
            }
            return false;
        }

        public bool Signup(Student employer)
        {
            var students = _databaseDataService.GetAllStudents();
            if (students.Exists(x => x.Email.ToLower().Equals(employer.Email.ToLower())))
            {
                return false;
            }
            employer.Id = students.Max(x => x.Id) + 1;
            students.Add(employer);
            return true;
        }

        public List<Job> GetAllJobs()
        {
            return _databaseDataService.GetAllJobs();
        }
    }
}
