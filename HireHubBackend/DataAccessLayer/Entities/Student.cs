using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Qualification { get; set; }
        public string School { get; set; }
        public string Experience { get; set; }
        public List<JobStatus> JobsApplied { get; set; }

        public Student()
        {
            JobsApplied = new List<JobStatus>();
        }
    }
}
