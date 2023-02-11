using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.PersonDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Application.ProjectApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;


        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet(Name = "GetListPerson")]
        public IActionResult GetAllPerson() => Json(_personService.GetAll());

        [HttpGet(Name = "GetPerson")]
        public IActionResult GetPerson(int id) => Json(_personService.GetPerson(id));

        [HttpPost(Name = "CreatePerson")]
        public IActionResult CreatePerson(CreatePersonDto personDto)
        {
            var EmailPerson = _personService.GetPerson(personDto.Email);
            if (EmailPerson != null)
            {
                return Json("The Entered Email Is Duplicate, Please Try Again.");
            }
            return Json(_personService.CreatePerson(personDto));
        }


        [HttpPost(Name = "EditPerson")]
        public IActionResult UpdatePerson(EditPersonDto personDto)
        {
            var EmailPerson = _personService.GetPerson(personDto.Email);
            if (EmailPerson != null)
            {
                return Json("The Entered Email Is Duplicate, Please Try Again.");
            }
            return Json(_personService.UpdatePerson(personDto));
        }
    }
}
