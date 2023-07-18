using System;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public interface IEmployerService
    {
        public bool Login(string email, string password);
        public bool Signup(Employer employer);
    }
}
