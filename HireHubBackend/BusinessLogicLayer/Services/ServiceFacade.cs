using System;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class ServiceFacade:IServiceFacade
    {
        private readonly IEmployerService _employerService;

        public ServiceFacade(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        public bool EmployerSignup(Employer employer)
        {
            return _employerService.Signup(employer);
        }

        public bool EmployerLogin(string email, string password)
        {
            return _employerService.Login(email, password);
        }
    }
}
