using System;
namespace DataAccessLayer.Entities
{
    public class Employer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPassword { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
    }
}
