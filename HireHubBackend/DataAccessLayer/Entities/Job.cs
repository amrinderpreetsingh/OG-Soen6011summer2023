using System;
namespace DataAccessLayer.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Role { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public string Type { get; set; }
        public string PostedBy { get; set; }
    }
}
