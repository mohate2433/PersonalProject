using ApplicationService.Dtos.BookDtos;
using ApplicationService.Dtos.PersonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Contracts.Contract
{
    public interface INoteService
    {
        List<SelectNoteDto> GetNotes(int personId);
        List<SelectNoteDto> GetAll();
        EditNoteDto GetNote(int id);
        CreateNoteDto CreateNote(CreateNoteDto noteDto);
        EditNoteDto UpdateNote(EditNoteDto noteDto);
        DeleteNoteDto DeleteNote(int id);
    }
}
