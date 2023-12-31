﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class JobService : IJobService
    {
        private readonly IDatabaseDataService _databaseDataService;

        public JobService(IDatabaseDataService databaseDataService)
        {
            _databaseDataService = databaseDataService;
        }

        public bool PostJob(Job job)
        {

            return _databaseDataService.AddJob(job);
        }

        public List<Job> GetJobsPostedByAnEmployer(string email)
        {
            var allJobs = _databaseDataService.GetAllJobs();
            var jobsPostedByEmployer = allJobs.Where(x => x.PostedBy.ToLower().Equals(email.ToLower())).ToList();
            return jobsPostedByEmployer;
        }

        
        public bool UpdateJob(Job updatedJob)
        {
            var originalJob = _databaseDataService.GetJob(updatedJob.Id);
            if (originalJob == null)
            {
                return false;
            }
            originalJob.PostedBy = updatedJob.PostedBy;
            originalJob.Role = updatedJob.Role;
            originalJob.Skills = updatedJob.Skills;
            originalJob.Title = updatedJob.Title;
            originalJob.Description = updatedJob.Description;
            originalJob.Experience = updatedJob.Experience;
            return true;
        }

        public bool DeleteJob(int id)
        {
            var job = _databaseDataService.GetJob(id);
            foreach (var studentId in job.StudentsApplied)
            {
                var student = _databaseDataService.GetStudentByID(studentId);
                student.JobsApplied.RemoveAll(x=>x.JobId==job.Id);
            }
            return _databaseDataService.DeleteJob(id);
        }

        public List<Job> GetAllJobs()
        {
            return _databaseDataService.GetAllJobs();
        }

        public List<Job> GetAppliedJobsByStudent(string email)
        {
            var allJobs = _databaseDataService.GetAllJobs();
            var student = _databaseDataService.GetStudent(email);
            var appliedJobs = new List<Job>();
            foreach (var job in allJobs)
            {
                if (job.StudentsApplied.Contains(student.Id))
                {
                    appliedJobs.Add(job);
                }
            }
            return appliedJobs;
        }

        public List<Student> GetListOfAppliedStudentsInJob(int id)
        {
            var job = _databaseDataService.GetJob(id);
            var students = new List<Student>();
            foreach (var studentId in job.StudentsApplied)
            {
                students.Add(_databaseDataService.GetStudentByID(studentId));
            }
            return students;
        }
    }
}
