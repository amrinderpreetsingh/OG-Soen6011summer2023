using System;
using System.Collections.Generic;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Moq;
using Xunit;

namespace Test.ServiceTests
{
    public class JobServiceTests
    {

        [Theory]
        [InlineData("jobs@nagarro.com",2)]
        [InlineData("jobs@kpmg.com",1)]
        public void GetJobsPostedByAnEmployerIsOk(string email,int expectedCount)
        {
            var mockService = new Mock<IDatabaseDataService>();

            var jobs = new List<Job>()
            {
                 new Job
                {
                    Title="Engineer",
                    Id=1,
                    Description="hardworker",
                    Experience="2",
                    Role="Full-Time",
                    Skills="Java",
                    PostedBy="jobs@nagarro.com",
                    Type="Intern"
                 },
                 new Job
                 {
                     Title="Associate Engineer",
                    Id=1,
                    Description="hardworker",
                    Experience="2",
                    Role="Full-Time",
                    Skills="Java",
                    PostedBy="jobs@nagarro.com",
                    Type="Intern"
                 },
                 new Job
                 {
                      Title="Associate Engineer",
                    Id=1,
                    Description="hardworker",
                    Experience="2",
                    Role="Full-Time",
                    Skills="Java",
                    PostedBy="jobs@kpmg.com",
                    Type="Intern"
                 }

            };

            mockService.Setup(x => x.GetAllJobs()).Returns(jobs);
            var sut = new JobService(mockService.Object);
            var result = sut.GetJobsPostedByAnEmployer(email);

            Assert.Equal(expectedCount, result.Count);

        }
    }
}
