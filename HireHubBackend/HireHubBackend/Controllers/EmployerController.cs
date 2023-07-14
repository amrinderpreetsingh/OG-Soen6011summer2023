using System;
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
    public class EmployerController : Controller
    {

        private readonly IServiceFacade _serviceFacade;

        public EmployerController(IServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Signup")]
        public ActionResult SignUp(Employer employer)
        {
            return Ok(_serviceFacade.EmployerSignUp(employer));
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            return Ok(_serviceFacade.EmployerLogin(email, password));
        }
    }
}
