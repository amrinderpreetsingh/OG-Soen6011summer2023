using System;
using System.Collections.Generic;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Moq;
using Xunit;

namespace Test.ServiceTests
{
    public class EmployerServiceTests
    {

        [Theory]
        [InlineData("jobs@kpmg.com", "1234")]
        [InlineData("jobs@meta.com", "12345")]
        [InlineData("JOBS@meta.com", "12345")]
        public void EmployerLoginReturnsTrue(string email, string password)
        {
            var mockService = new Mock<IDatabaseDataService>();
            var serviceReturn = new List<Employer>()
            {
                new Employer
                {
                    CompanyEmail="jobs@kpmg.com",
                    CompanyPassword="1234"
                },
                new Employer
                {
                    CompanyEmail="jobs@meta.com",
                    CompanyPassword="12345"
                }
            };
            var c = new EmployerService(mockService.Object);
            mockService.Setup(x => x.GetAllEmployers()).Returns(serviceReturn);
            var result = c.Login(email, password);
            Assert.True(result);
        }

        [Theory]
        [InlineData("jobs@nagarro.com", "1234")]
        [InlineData("jobs@tcs.com", "12345")]
        public void EmployerLoginReturnsFalse(string email, string password)
        {
            var mockService = new Mock<IDatabaseDataService>();
            var serviceReturn = new List<Employer>()
            {
                new Employer
                {
                    CompanyEmail="jobs@kpmg.com",
                    CompanyPassword="1234"
                },
                new Employer
                {
                    CompanyEmail="jobs@kpmg.com",
                    CompanyPassword="1234"
                }
            };
            var c = new EmployerService(mockService.Object);
            mockService.Setup(x => x.GetAllEmployers()).Returns(serviceReturn);
            var result = c.Login(email, password);
            Assert.False(result);
        }
    }
}
