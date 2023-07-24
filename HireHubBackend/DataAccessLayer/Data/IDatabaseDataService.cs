using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Data
{
    public interface IDatabaseDataService
    {
        public List<Employer> GetAllEmployers();
        public bool AddJob(Job job);
        public List<Job> GetAllJobs();
        public List<Student> GetAllStudents();
        public Student GetStudent(string studentEmail);
        public Job GetJob(int id);
        public bool DeleteJob(int id);
        public Student GetStudentByID(int id);
    }
}
