using System;
using System.Collections.Generic;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Moq;
using Xunit;

namespace Test.ServiceTests
{
    public class StudentServiceTests
    {
        [Theory]
        [InlineData("ammy@hirehub.com", "1313")]
        [InlineData("gagan@hirehub.com", "122")]
        public void StudentLoginReturnsTrue(string email, string password)
        {
            var mockService = new Mock<IDatabaseDataService>();

            var serviceReturn = new List<Student>()
            {
                new Student
                {
                    Email="gagan@hirehub.com",
                    Password="122"
                },
                new Student
                {
                    Email="ammy@hirehub.com",
                    Password="1313"
                }
            };
            var c = new StudentService(mockService.Object);
            mockService.Setup(x => x.GetAllStudents()).Returns(serviceReturn);
            var result = c.Login(email, password);
            Assert.True(result);
        }

        [Theory]
        [InlineData("ammy1@hirehub.com", "1313")]
        [InlineData("gagan1@hirehub.com", "122")]
        public void StudentLoginReturnsFalse(string email, string password)
        {
            var mockService = new Mock<IDatabaseDataService>();
            var serviceReturn = new List<Student>()
            {
                new Student
                {
                    Email="gagan@hirehub.com",
                    Password="122"
                },
                new Student
                {
                    Email="ammy@hirehub.com",
                    Password="1313"
                }
            };
            var c = new StudentService(mockService.Object);
            mockService.Setup(x => x.GetAllStudents()).Returns(serviceReturn);
            var result = c.Login(email, password);
            Assert.False(result);
        }

        [Theory]
        [InlineData("gagan@hirehub.com",1)]
        public void ApplyJobIsOk(string email,int id)
        {
            var mockService = new Mock<IDatabaseDataService>();
            var student = new Student
            {
                Email = email,
                Experience = "1",
                Id = 1,
                JobsApplied = new List<int>(),
                Name = "Gagan",
                Password = "1234",
                Qualification = "Masters",
                School = "Concordia"

            };
            var job = new Job
            {
                Title = "Engineer",
                Id = id,
                Description = "hardworker",
                Experience = "2",
                Role = "Full-Time",
                Skills = "Java",
                PostedBy = "jobs@nagarro.com",
                Type = "Intern"
            };
            mockService.Setup(x => x.GetStudent(It.IsAny<string>())).Returns(student);
            mockService.Setup(x => x.GetJob(It.IsAny<int>())).Returns(job);

            var sut = new StudentService(mockService.Object);
            var result = sut.ApplyJob(email, id);

            mockService.Verify(x => x.GetStudent(It.IsAny<string>()), Times.Once);
            Assert.True(result);
            Assert.Single(job.StudentsApplied);
            Assert.Single(student.JobsApplied);
        }

        [Theory]
        [InlineData("gagan1@hirehub.com", 1)]
        [InlineData("gagan@hirehub.com", 2)]
        public void ApplyJobIsNotOk(string email, int id)
        {
            var mockService = new Mock<IDatabaseDataService>();
            var student = new Student
            {
                Email = email,
                Experience = "1",
                Id = 1,
                JobsApplied = new List<int>(),
                Name = "Gagan",
                Password = "1234",
                Qualification = "Masters",
                School = "Concordia"

            };
            var job = new Job
            {
                Title = "Engineer",
                Id = id,
                Description = "hardworker",
                Experience = "2",
                Role = "Full-Time",
                Skills = "Java",
                PostedBy = "jobs@nagarro.com",
                Type = "Intern"
            };
            mockService.Setup(x => x.GetStudent(It.IsAny<string>())).Returns((Student)null);
            mockService.Setup(x => x.GetJob(It.IsAny<int>())).Returns((Job)null);

            var sut = new StudentService(mockService.Object);
            var result = sut.ApplyJob(email, id);

            mockService.Verify(x => x.GetStudent(It.IsAny<string>()), Times.Once);
            Assert.False(result);
            Assert.Empty(job.StudentsApplied);
            Assert.Empty(student.JobsApplied);
        }
    }
}
