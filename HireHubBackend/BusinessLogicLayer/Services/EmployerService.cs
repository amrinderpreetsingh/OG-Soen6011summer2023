using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class EmployerService:IEmployerService
    {
        private readonly IDatabaseDataService _databaseDataService;

        public EmployerService(IDatabaseDataService databaseDataService)
        {
            _databaseDataService = databaseDataService;
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
            return _databaseDataService.DeleteEmployer(id);
        }
    }
}
