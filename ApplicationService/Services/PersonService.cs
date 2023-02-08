using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.BookDtos;
using ApplicationService.Dtos.PersonDtos;
using Domain.Aggregates;
using Domain.Contract;
using EntityFramework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly INoteService _noteService;

        public PersonService(IPersonRepository personRepository, INoteService noteService)
        {
            _personRepository = personRepository;
            _noteService = noteService;
        }

        private static List<SelectPersonDto> Convert(List<Person> person)
        {
            var dtoList = new List<SelectPersonDto>();
            for (int i = 0; i < person.Count; i++)
            {
                dtoList.Add(new SelectPersonDto());
                dtoList[i].Id = person[i].Id;
                dtoList[i].FirstName = person[i].FirstName;
                dtoList[i].LastName = person[i].LastName;
                dtoList[i].Email = person[i].Email;
                dtoList[i].Website = person[i].Website;
                dtoList[i].Age = person[i].Age;
            }
            return dtoList;
        }

        private static EditPersonDto ConvertEdit(Person person)
        {
            var editDto = new EditPersonDto();
            editDto.Id = person.Id;
            editDto.FirstName = person.FirstName;
            editDto.LastName = person.LastName;
            editDto.Email = person.Email;
            editDto.Website = person.Website;
            editDto.Age = person.Age;
            for (int i = 0; i < person.Notes.Count; i++)
            {
                editDto.Notes[i].Id = person.Notes[i].Id;
                editDto.Notes[i].Contente = person.Notes[i].Contente;
                editDto.Notes[i].DateCreated = person.Notes[i].DateCreated;
                editDto.Notes[i].DateModified = person.Notes[i].DateModified;
                editDto.Notes[i].Views = person.Notes[i].Views;
            }
            
            return editDto;
        }
        private static Person Convert(CreatePersonDto create)
        {
            var person = new Person()
            {
                FirstName = create.FirstName,
                LastName = create.LastName,
                Email = create.Email,
                Website = create.Website,
                Age = create.Age
            };
            return person;
        }
        private static Person Convert(EditPersonDto edit)
        {
            var person = new Person()
            {
                FirstName = edit.FirstName,
                LastName = edit.LastName,
                Email = edit.Email,
                Website = edit.Website,
                Age = edit.Age
            };
            return person;
        }

        public List<SelectPersonDto> GetAll() => PersonService.Convert(_personRepository.GetAll());

        public EditPersonDto GetPerson(int id) => ConvertEdit(_personRepository.GetPerson(id));

        public OprationResult CreatePerson(CreatePersonDto personDto)
        {
            throw new NotImplementedException();
        }

        public OprationResult UpdatePerson(EditPersonDto personDto)
        {
            throw new NotImplementedException();
        }

        public OprationResult DeletePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
