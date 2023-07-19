using System;
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

        public List<Job> GetAllJobsForStudent()
        {
            return _studentService.GetAllJobs();
        }
    }
}
