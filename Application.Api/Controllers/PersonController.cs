using Application.Api.Hubs;
using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.PersonDtos;
using Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet(Name = "GetListPerson")]
        public IActionResult GetAllPerson() => Json(_personService.GetAll());

    }
}
