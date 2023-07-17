using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Data
{
    public class DatabaseDataService : IDatabaseDataService
    {
        private List<Employer> _employers = new()
        {
            new Employer
            {
                CompanyName="Nagarro",
                CompanyEmail="jobs@nagarro.com",
                CompanyPassword="1234",
                Id=1
            }
        };

        private List<Student> _students = new()
        {
            new Student
            {
                Name="Gagan",
                Email="gagan@hirehub.com",
                Password="1234",
                Qualification="Masters",
                Id=1
            }
        };

        public List<Employer> GetAllEmployers()
        {
            return _employers;
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }
    }
}
