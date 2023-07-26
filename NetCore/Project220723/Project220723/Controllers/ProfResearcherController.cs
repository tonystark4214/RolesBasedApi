using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project220723.Models;
using Project220723.Repository;

namespace Project220723.Controllers
{
    public class ProfResearcherController : Controller
    {
        public readonly InterfaceProfResearcher prof;
        public ProfResearcherController(InterfaceProfResearcher prof)
        {
            this.prof = prof;
        }

        [HttpGet]
        [Route("GetResearcherList")]
        [Authorize(Roles ="Professor,Researcher")]
        public IActionResult GetResearcherList()
        {

            return Ok(prof.GetResearcherList());
        }
        [HttpGet]
        [Route("GetProfessorList")]
        [Authorize(Roles = "Professor")]
        public IActionResult GetProfessorList()
        {

            return Ok(prof.GetProfessorList());
        }

        [HttpPost]
        [Route("PostResearcherData")]
        [Authorize(Roles = "Professor,Researcher")]
        public IActionResult PostResearcherData([FromBody] ResearcherModel data)
        {
            if (!ModelState.IsValid)
            {
                ResponseModel response = new ResponseModel();
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage));
                response.Message = message;

                return Ok(response);

            }
            return Ok(prof.PostResearcherData(data));
        }

        [HttpPost]
        [Route("PostProfessorData")]
        [Authorize(Roles = "Professor")]
        public IActionResult PostProfessorData([FromBody] ResearcherModel data)
        {
            if (!ModelState.IsValid)
            {
                ResponseModel response = new ResponseModel();
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage));
                response.Message = message;

                return Ok(response);

            }
            return Ok(prof.PostProfessorData(data));
        }

        [HttpDelete]
        [Route("DeletingProfessor")]
        [Authorize(Roles = "Professor")]
        public IActionResult DeleteProfessor(int id)
        {
            return Ok(prof.DeleteProfessor(id));
        }

        [HttpDelete]
        [Route("DeletingResearcher")]
        [Authorize(Roles = "Professor")]
        public IActionResult DeleteResearcher(int id)
        {
            return Ok(prof.DeleteResearcher(id));
        }

        [HttpGet]
        [Route("GetResearcherById")]
        [Authorize(Roles = "Professor")]
        public IActionResult GetResearcherById(int id)
        {
            return Ok(prof.GetResearcherById((int)id));
        }
        [HttpGet]
        [Route("GetProfessorById")]
        [Authorize(Roles = "Professor")]
        public IActionResult GetProfessorById(int id)
        {
            return Ok(prof.GetProfessorById((int)id));
        }
    }
}
