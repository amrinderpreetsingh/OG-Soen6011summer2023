using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Data
{
    public class DatabaseDataService:IDatabaseDataService
    {
        private List<Employer> _employers = new List<Employer>()
        {
            new Employer
            {
                CompanyName="Nagarro",
                CompanyEmail="jobs@nagarro.com",
                CompanyPassword="1234"

            }
        };

        

        public List<Employer> GetAllEmployers()
        {
            return _employers;
        }
    }
}
