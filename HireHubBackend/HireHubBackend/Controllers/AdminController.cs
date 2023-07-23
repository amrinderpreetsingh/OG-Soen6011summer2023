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
    }
}
