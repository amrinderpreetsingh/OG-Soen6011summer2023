﻿using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class ServiceFacade : IServiceFacade
    {
        private readonly IEmployerService _employerService;
        private readonly IJobService _jobService;
        private readonly IStudentService _studentService;

        public ServiceFacade(IEmployerService employerService, IJobService jobService,IStudentService studentService)
        {
            _employerService = employerService;
            _jobService = jobService;
            _studentService = studentService;
        }

        public bool EmployerSignup(Employer employer)
        {
            return _employerService.Signup(employer);
        }

        public bool EmployerLogin(string email, string password)
        {
            return _employerService.Login(email, password);
        }

        public bool PostJob(Job job)
        {
            return _jobService.PostJob(job);
        }

        public List<Job> GetJobsPostedByAnEmployer(string email)
        {
            return _jobService.GetJobsPostedByAnEmployer(email);
        }
        public bool StudentSignup(Student student)
        {
            return _studentService.Signup(student);
        }

        public bool StudentLogin(string email, string password)
        {
            return _studentService.Login(email, password);
        }

        public List<Student> GetStudents()
        {
            return _employerService.GetStudents();
        }

        public List<Job> GetAvailableJobsForStudent(string email)
        {
            return _studentService.GetAllAvailableJobs(email);
        }

        public bool StudentJobApply(string studentEmail, int jobId)
        {
            return _studentService.ApplyJob(studentEmail, jobId);
        }

        public bool UpdateJob(Job job)
        {
            return _jobService.UpdateJob(job);
        }

        public bool DeleteJob(int id)
        {
            return _jobService.DeleteJob(id);
        }

        public List<Job>GetAppliedJobsByStudent(string email)
        {
            return _jobService.GetAppliedJobsByStudent(email);
        }

        public List<Student> GetListOfAppliedStudentsInJob(int id)
        {
            return _jobService.GetListOfAppliedStudentsInJob(id);
        }

        public List<Job> GetAllJobsAdmin()
        {
            return _jobService.GetAllJobs();
        }

        public List<Employer> GetAllEmployersAdmin()
        {
            return _employerService.GetAllEmployers();
        }

        public List<Student> GetAllStudentsAdmin()
        {
            return _studentService.GetAllStudents();
        }
    }
}
