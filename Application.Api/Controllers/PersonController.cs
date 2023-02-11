using Application.Api.Hubs;
using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos;
using ApplicationService.Dtos.PersonDtos;
using Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly ILogger<PersonController> _logger;


        public PersonController(IPersonService personService, IHubContext<SignalHub> hubContext, ILogger<PersonController> logger)
        {
            _personService = personService;
            _hubContext = hubContext;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllPerson() => Json(_personService.GetAll());
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPerson(int id) => Json(_personService.GetPerson(id));

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonDto personDto)
        {
            return Json(_personService.CreatePerson(personDto));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult UpdatePerson(int id) => Json(_personService.GetPerson(id));


        [HttpPost]
        public IActionResult UpdatePerson(EditPersonDto personDto)
        {
            return Json(_personService.UpdatePerson(personDto));
        }
        [HttpDelete("id")]
        public IActionResult DeletePerson(int id) => Json(_personService.DeletePerson(id));
    }
}
