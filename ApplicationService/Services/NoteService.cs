using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.BookDtos;
using ApplicationService.Dtos.PersonDtos;
using Domain.Aggregates;
using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        private static List<SelectNoteDto> Convert(List<Note> notes)
        {
            var dtoList = new List<SelectNoteDto>();
            for (int i = 0; i < notes.Count; i++)
            {
                dtoList.Add(new SelectNoteDto());
                dtoList[i].Id = notes[i].Id;
                dtoList[i].Contente = notes[i].Contente;
                dtoList[i].Views = notes[i].Views;
                dtoList[i].DateCreated = notes[i].DateCreated;
                dtoList[i].DateModified = notes[i].DateModified;
                dtoList[i].PersonId = notes[i].PersonId;
            }
            return dtoList;
        }
        private static EditPersonDto Convert(Note note)
        {
            var editDto = new EditPersonDto();
            editDto.Id = note.Id;
            editDto.FirstName = note.FirstName;
            editDto.LastName = note.LastName;
            editDto.Email = note.Email;
            editDto.Website = note.Website;
            editDto.Age = note.Age;

            return editDto;
        }

        private static Note Convert(EditNoteDto edit)
        {
            var person = new Note()
            {
                Id = edit.Id,
                Contente = edit.Contente,
                DateCreated = edit.DateCreated,
                DateModified = DateTime.Now,
                Views= edit.Views,
                Published = edit.Published,
                PersonId= edit.PersonId,
            };
            return person;
        }
        private static Note Convert(CreateNoteDto create)
        {
            var person = new Note()
            {
                Contente = create.Contente,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Views= create.Views,
                Published = false,
                PersonId= create.PersonId,
            };
            return person;
        }


        public List<SelectNoteDto> GetNotes(int personId) =>NoteService.Convert(_noteRepository.GetNotes(personId));
       
        public EditNoteDto GetNote(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNote(EditNoteDto noteDto) => _noteRepository.Update(Convert(noteDto));
       
        public void CreateNote(CreateNoteDto noteDto) => _noteRepository.Create(Convert(noteDto));

        public void DeleteNote(int id) => _noteRepository.Delete(id);
    }
}
