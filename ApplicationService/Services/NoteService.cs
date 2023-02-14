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
        private static EditNoteDto Convert(Note note)
        {
            if (note == null)
            {
                return null;
            }
            var editDto = new EditNoteDto();
            editDto.Id = note.Id;
            editDto.Contente = note.Contente;
            editDto.DateCreated = note.DateCreated;
            editDto.DateModified = note.DateModified;
            editDto.Views = note.Views;
            editDto.PersonId = note.PersonId;

            return editDto;
        }
        private static EditNoteDto ConvertEdit(Note note)
        {
            var editDto = new EditNoteDto();
            editDto.Contente = note.Contente;
            editDto.DateCreated = note.DateCreated;
            editDto.DateModified = note.DateModified;
            editDto.Views = note.Views;
            editDto.PersonId = note.PersonId;

            return editDto;
        }
        private static CreateNoteDto ConvertCreate(Note note)
        {
            var createDto = new CreateNoteDto();
            createDto.Contente = note.Contente;
            createDto.DateCreated = note.DateCreated;
            createDto.DateModified = note.DateModified;
            createDto.Views = note.Views;
            createDto.PersonId = note.PersonId;

            return createDto;
        }
        private static DeleteNoteDto ConvertDelete(Note note)
        {
            if(note== null)
            {
                return null;
            }
            var deleteDto = new DeleteNoteDto();
            deleteDto.Contente = note.Contente;
            deleteDto.DateCreated = note.DateCreated;
            deleteDto.DateModified = note.DateModified;
            deleteDto.Views = note.Views;
            deleteDto.PersonId = note.PersonId;

            return deleteDto;
        }

        private static Note Convert(EditNoteDto edit)
        {
            var person = new Note()
            {
                Id = edit.Id,
                Contente = edit.Contente,
                DateCreated = edit.DateCreated,
                DateModified = DateTime.Now,
                Views = edit.Views,
                Published = edit.Published,
                PersonId = edit.PersonId,
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
                Views = create.Views,
                Published = false,
                PersonId = create.PersonId,
            };
            return person;
        }


        public List<SelectNoteDto> GetNotes(int personId) => NoteService.Convert(_noteRepository.GetNotes(personId));
        public List<SelectNoteDto> GetAll() => NoteService.Convert(_noteRepository.GetAll());
        public EditNoteDto GetNote(int id) => Convert(_noteRepository.Get(id));
        public EditNoteDto UpdateNote(EditNoteDto noteDto) => ConvertEdit(_noteRepository.Update(Convert(noteDto)));
        public CreateNoteDto CreateNote(CreateNoteDto noteDto) => ConvertCreate(_noteRepository.Create(Convert(noteDto)));
        public DeleteNoteDto DeleteNote(int id) => ConvertDelete(_noteRepository.Delete(id));
    }
}
