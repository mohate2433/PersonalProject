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
        EditNoteDto GetNote(int id);
        void CreateNote(CreateNoteDto noteDto);
        void UpdateNote(EditNoteDto noteDto);
        void DeleteNote(int id);
    }
}
