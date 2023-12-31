﻿using System;
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
        public List<Student> GetStudents();
        public List<Job> GetAvailableJobsForStudent(string email);
        public bool StudentJobApply(string studentEmail, int jobId);
        public bool UpdateJob(Job job);
        public bool DeleteJob(int id);
        public List<Job> GetAppliedJobsByStudent(string email);
        public List<Student> GetListOfAppliedStudentsInJob(int id);
        public List<Job> GetAllJobsAdmin();
        public List<Employer> GetAllEmployersAdmin();
        public List<Student> GetAllStudentsAdmin();
        public bool EditEmployerAdmin(Employer updatedEmployer);
        public bool DeleteEmployerAdmin(int id);
        public bool EditStudentAdmin(Student student);
        public bool DeleteStudentAdmin(int id);
        public bool AcceptStudent(int studentId, int jobId);
        public bool DeclinetStudent(int studentId, int jobId);
        public Student GetStudent(string email);
        public bool SelectStudentForInterview(int studentId, int jobId);
    }
}
