using Application.Api.Hubs;
using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly ILogger<NoteController> _logger;


        public NoteController(INoteService noteService, IHubContext<SignalHub> hubContext, ILogger<NoteController> logger)
        {
            _noteService = noteService;
            _hubContext = hubContext;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllNote() => Json(_noteService.GetAll());
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAllNotes(int id) => Json(_noteService.GetNotes(id));
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetNote(int id) => Json(_noteService.GetNote(id));

        [HttpPost]
        public IActionResult CreateNote(CreateNoteDto noteDto)
        {
            return Json(_noteService.CreateNote(noteDto));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult UpdateNote(int id) => Json(_noteService.GetNote(id));


        [HttpPost]
        public IActionResult UpdateNote(EditNoteDto editDto)
        {
            return Json(_noteService.UpdateNote(editDto));
        }
        [HttpDelete("id")]
        public IActionResult DeleteNote(int id) => Json(_noteService.DeleteNote(id));
    }
}
