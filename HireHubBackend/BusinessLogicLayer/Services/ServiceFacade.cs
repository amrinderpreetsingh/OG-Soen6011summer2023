using System;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class ServiceFacade:IServiceFacade
    {
        private readonly IEmployerService _employerService;
        private readonly IStudentService _studentService;

        public ServiceFacade(IEmployerService employerService,IStudentService studentService)
        {
            _employerService = employerService;
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

        public bool StudentSignup(Student student)
        {
            return _studentService.Signup(student);
        }

        public bool StudentLogin(string email, string password)
        {
            return _studentService.Login(email, password);
        }
    }
}
