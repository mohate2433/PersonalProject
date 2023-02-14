using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.BookDtos;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
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
