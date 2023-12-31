﻿using System;
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

        public List<Job> GetAllAvailableJobs(string email)
        {
            var jobs= _databaseDataService.GetAllJobs();
            var availableJobs = new List<Job>();
            var student = _databaseDataService.GetStudent(email);
            foreach (var job in jobs)
            {
                if (!job.StudentsApplied.Contains(student.Id))
                {
                    availableJobs.Add(job);
                }
            }
            return availableJobs;
        }

        public bool ApplyJob(string studentEmail, int JobId)
        {
            var student = _databaseDataService.GetStudent(studentEmail);
            var job = _databaseDataService.GetJob(JobId);
            if(student==null || job == null)
            {
                return false;
            }
            job.StudentsApplied.Add(student.Id);
            student.JobsApplied.Add(new JobStatus
            {
                JobId=job.Id,
                Status=Constant.APPLIED_STATUS
            });
            return true;
        }

        public List<Student> GetAllStudents()
        {
            return _databaseDataService.GetAllStudents();
        }

        public bool EditStudent(Student updatedStudent)
        {
            var student = _databaseDataService.GetStudentByID(updatedStudent.Id);
            if (student == null)
            {
                return false;
            }
            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Password = updatedStudent.Password;
            student.Qualification = updatedStudent.Qualification;
            student.School = updatedStudent.School;
            student.Experience = updatedStudent.Experience;
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var jobs = _databaseDataService.GetAllJobs();
            foreach (var job in jobs.ToList())
            {
                foreach (var studentApplied in job.StudentsApplied)
                {
                    if (studentApplied == id)
                    {
                        job.StudentsApplied.RemoveAll(x => x == id);
                    }
                }
            }
            return _databaseDataService.DeleteStudent(id);
        }

        public Student GetStudent(string email)
        {
            return _databaseDataService.GetStudent(email);
        }
    }
}
