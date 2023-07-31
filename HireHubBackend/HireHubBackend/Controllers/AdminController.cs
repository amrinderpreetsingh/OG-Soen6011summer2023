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
    public class AdminController : Controller
    {
        private readonly IServiceFacade _serviceFacade;

        public AdminController(IServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        [Route("UpdateJob")]
        public ActionResult UpdateJob(Job job)
        {
            return Ok(_serviceFacade.UpdateJob(job));
        }

        [HttpDelete]
        [Route("DeleteJob")]
        public ActionResult DeleteJob(int id)
        {
            return Ok(_serviceFacade.DeleteJob(id));
        }

        [HttpGet]
        [Route("AllJobs")]
        public ActionResult GetAllJobs()
        {
            return Ok(_serviceFacade.GetAllJobsAdmin());
        }

        [HttpGet]
        [Route("AllEmployers")]
        public ActionResult GetAllEmployers()
        {
            return Ok(_serviceFacade.GetAllEmployersAdmin());
        }

        [HttpGet]
        [Route("AllStudents")]
        public ActionResult GetAllStudents()
        {
            return Ok(_serviceFacade.GetAllStudentsAdmin());
        }

        [HttpPost]
        [Route("EditEmployer")]
        public ActionResult EditEmployer(Employer employer)
        {
            return Ok(_serviceFacade.EditEmployerAdmin(employer));
        }

        [HttpDelete]
        [Route("DeleteEmployer")]
        public ActionResult DeleteEmployer(int id)
        {
            return Ok(_serviceFacade.DeleteEmployerAdmin(id));
        }

        [HttpPost]
        [Route("EditStudent")]
        public ActionResult EditStudent(Student student)
        {
            return Ok(_serviceFacade.EditStudentAdmin(student));
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public ActionResult DeleteStudent(int id)
        {
            return Ok(_serviceFacade.DeleteStudentAdmin(id));
        }
    }
}
