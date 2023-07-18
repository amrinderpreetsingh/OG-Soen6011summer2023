﻿using System;
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
    }
}