﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IServiceFacade _serviceFacade;

        public StudentController(IServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
        }

        [HttpPost]
        [Route("Signup")]
        public ActionResult SignUp(Student student)
        {
            return Ok(_serviceFacade.StudentSignup(student));
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            return Ok(_serviceFacade.StudentLogin(email, password));
        }
    }
}
