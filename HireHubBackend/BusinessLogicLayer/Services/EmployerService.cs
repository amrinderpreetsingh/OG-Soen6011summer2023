﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class EmployerService:IEmployerService
    {
        private readonly IDatabaseDataService _databaseDataService;
        private readonly IJobService _jobService;

        public EmployerService(IDatabaseDataService databaseDataService,IJobService jobService)
        {
            _databaseDataService = databaseDataService;
            _jobService = jobService;
        }

        public bool Login(string email, string password)
        {
            var employers = _databaseDataService.GetAllEmployers();
            if(employers.Exists(x=>x.CompanyEmail.ToLower().Equals(email.ToLower())&& x.CompanyPassword.Equals(password)))
            {
                return true;
            }
            return false;
        }

        public bool Signup(Employer employer)
        {
            var employers = _databaseDataService.GetAllEmployers();
            if (employers.Exists(x => x.CompanyEmail.ToLower().Equals(employer.CompanyEmail.ToLower())))
            {
                return false;
            }
            employer.Id = employers.Max(x => x.Id) + 1;
            employers.Add(employer);
            return true;
        }

        public List<Student> GetStudents()
        {
            return _databaseDataService.GetAllStudents();
        }

        public List<Employer> GetAllEmployers()
        {
            return _databaseDataService.GetAllEmployers();
        }

        public bool UpdateEmployer(Employer updatedEmployer)
        {
            var employer = _databaseDataService.GetEmployer(updatedEmployer.Id);
            if (employer == null)
            {
                return false;
            }
            employer.CompanyName = updatedEmployer.CompanyName;
            employer.CompanyEmail = updatedEmployer.CompanyEmail;
            employer.CompanyPassword = updatedEmployer.CompanyPassword;
            employer.Address = updatedEmployer.Address;
            employer.About = updatedEmployer.About;
            return true;
        }

        public bool DeleteEmployer(int id)
        {
            var employee = _databaseDataService.GetEmployer(id);
            var jobs = _databaseDataService.GetAllJobs();
            foreach (var job in jobs.ToList())
            {
                if (job.PostedBy.ToLower().Equals(employee.CompanyEmail.ToLower()))
                {
                    _jobService.DeleteJob(job.Id);
                }
            }
            return _databaseDataService.DeleteEmployer(id);
        }

        public bool AcceptStudent(int studentId,int jobId)
        {
            var student = _databaseDataService.GetStudentByID(studentId);
            var job = _databaseDataService.GetJob(jobId);
            if(student==null || job == null)
            {
                return false;
            }
            foreach (var studentJob in student.JobsApplied)
            {
                if (studentJob.JobId == jobId)
                {
                    studentJob.Status = Constant.ACCEPTED_STATUS;
                    return true;
                }
            }
            return false;
        }

        public bool DeclineStudent(int studentId, int jobId)
        {
            var student = _databaseDataService.GetStudentByID(studentId);
            var job = _databaseDataService.GetJob(jobId);
            if (student == null || job == null)
            {
                return false;
            }
            foreach (var studentJob in student.JobsApplied)
            {
                if (studentJob.JobId == jobId)
                {
                    studentJob.Status = Constant.DECLINED_STATUS;
                    return true;
                }
            }
            return false;
        }

        public bool SelectStudentForInterview(int studentId,int jobId)
        {
            var student = _databaseDataService.GetStudentByID(studentId);
            var job = _databaseDataService.GetJob(jobId);
            if (student == null || job == null)
            {
                return false;
            }
            foreach (var studentJob in student.JobsApplied)
            {
                if (studentJob.JobId == jobId)
                {
                    studentJob.Status = Constant.SELECTED_FOR_INTERVIEW;
                    return true;
                }
            }
            return false;
        }
    }
}
