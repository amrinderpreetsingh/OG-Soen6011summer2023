using System;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public interface IServiceFacade
    {
        public bool EmployerSignup(Employer employer);
        public bool EmployerLogin(string email, string password);
    }
}
