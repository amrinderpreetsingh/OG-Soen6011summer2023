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
            return Ok(_serviceFacade.EmployerSignup(employer));
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            return Ok(_serviceFacade.EmployerLogin(email, password));
        }

        [HttpPost]
        [Route("postjob")]
        public ActionResult PostJob(Job job)
        {
            return Ok(_serviceFacade.PostJob(job));
        }

        [HttpGet]
        [Route("getjobs")]
        public ActionResult GetJobs(string email)
        {
            return Ok(_serviceFacade.GetJobsPostedByAnEmployer(email));
        }

        [HttpGet]
        [Route("getstudents")]
        public ActionResult GetAllStudents()
        {
            return Ok(_serviceFacade.GetStudents());
        }

        [HttpGet]
        [Route("getListofStudentsForAJob")]
        public ActionResult GetListOfAppliedStudentsForAJob(int id)
        {
            return Ok(_serviceFacade.GetListOfAppliedStudentsInJob(id));
        }

        [HttpDelete]
        [Route("DeleteJob")]
        public ActionResult DeleteJob(int id)
        {
            return Ok(_serviceFacade.DeleteJob(id));
        }

        [HttpGet]
        [Route("AcceptApplication")]
        public ActionResult AcceptApplication(int studentId,int jobId)
        {
            return Ok(_serviceFacade.AcceptStudent(studentId, jobId));
        }

        [HttpGet]
        [Route("DeclineApplication")]
        public ActionResult DeclineApplication(int studentId, int jobId)
        {
            return Ok(_serviceFacade.DeclinetStudent(studentId, jobId));
        }
    }
}
