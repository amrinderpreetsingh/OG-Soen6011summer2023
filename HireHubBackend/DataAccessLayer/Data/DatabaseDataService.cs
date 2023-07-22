using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Data
{
    public class DatabaseDataService : IDatabaseDataService
    {
        private List<Employer> _employers = new List<Employer>()
        {
            new Employer
            {
                CompanyName = "Nagarro",
                CompanyEmail = "jobs@nagarro.com",
                CompanyPassword = "1234",
                Id = 1
            }
        };

        private List<Job> _jobs = new List<Job>()
        {
            new Job
            {
                Title="Engineer",
                Id=1,
                Description="hardworker",
                Experience="2",
                Role="Full-Time",
                Skills="Java",
                PostedBy="jobs@nagarro.com",
                Type="Intern" }
        };

        private List<Student> _students = new List<Student>()
        {
            new Student
            {
                Name="Gagan",
                Email="gagan@hirehub.com",
                Password="1234",
                Qualification="Masters",
                Id=1,
                Experience="1",
                School="GNDU"
            }
        };

        public List<Employer> GetAllEmployers()
        {
            return _employers;
        }

        public List<Job> GetAllJobs()
        {
            return _jobs;
        }

        public bool AddJob(Job job)
        {
            job.Id = _jobs.Max(x => x.Id)+1;
            _jobs.Add(job);
            return true;
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudent(string studentEmail)
        {
            var student = _students.FirstOrDefault(x => x.Email.Equals(studentEmail));
            return student;
        }

        public Job GetJob(int id)
        {
            return _jobs.FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteJob(int id)
        {
            _jobs.RemoveAll(x => x.Id == id);
            return true;
        }
    }
}