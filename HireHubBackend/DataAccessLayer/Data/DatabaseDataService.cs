﻿using System;
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
                Id = 1,
                About="Good Company",
                Address="India"
            },
            new Employer
            {
                CompanyName = "IO",
                CompanyEmail = "jobs@io.com",
                CompanyPassword = "1234",
                Id = 2,
                About="Good Company",
                Address="India"
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
                Role="Full Stack Developer",
                Skills="Java",
                PostedBy="jobs@nagarro.com",
                Type="Internship" },
             new Job
            {
                Title="SDE-3",
                Id=2,
                Description="Minimum Guy",
                Experience="2",
                Role="Backend Developer",
                Skills="Java",
                PostedBy="jobs@io.com",
                Type="Full Time" },
                         new Job
            {
                Title="Senior Engineer",
                Id=5,
                Description="The <mat-card> The amount of CSS generated for flexbox CSS is extremely huge(>250k), The amount of CSS generated for flexbox CSS is extremely huge(>250k)",
                Experience="2",
                Role="Developer",
                Skills="Java",
                PostedBy="jobs@nagarro.com",
                Type="Internship" },
             new Job
            {
                Title="SDE-2",
                Id=6,
                Description="Minimum Guy",
                Experience="2",
                Role="Tester",
                Skills="Java",
                PostedBy="jobs@io.com",
                Type="Full Time" }
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
            },
             new Student
            {
                Name="Amrinder",
                Email="ammy@hirehub.com",
                Password="1234",
                Qualification="Masters",
                Id=2,
                Experience="2",
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
            job.Id = _jobs.Max(x => x.Id) + 1;
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

        public Student GetStudentByID(int id)
        {
            var student = _students.FirstOrDefault(x => x.Id == id);
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

        public Employer GetEmployer(int id)
        {
            return _employers.FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteEmployer(int id)
        {
            _employers.RemoveAll(x => x.Id == id);
            return true;
        }

        public bool DeleteStudent(int id)
        {
            _students.RemoveAll(x => x.Id == id);
            return true;
        }
    }
}