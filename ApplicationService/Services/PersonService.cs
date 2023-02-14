using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.BookDtos;
using ApplicationService.Dtos.PersonDtos;
using Domain.Aggregates;
using Domain.Contract;

namespace ApplicationService.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;
        private readonly INoteRepository _noteRepository;

        public PersonService(IPersonRepository personRepository, INoteRepository noteRepository)
        {
            _personRepository = personRepository;
            _noteRepository = noteRepository;
        }

        private static List<SelectPersonDto> Convert(List<Person> person)
        {
            var listNote = new List<SelectNoteDto>();
            var dtoList = new List<SelectPersonDto>();





            for (int i = 0; i < person.Count; i++)
            {
                dtoList.Add(new SelectPersonDto()
                {
                    Id = person[i].Id,
                    FirstName = person[i].FirstName,
                    LastName = person[i].LastName,
                    Email = person[i].Email,
                    Website = person[i].Website,
                    Age = person[i].Age
                });
                foreach (var item in person[i].Notes)
                {
                    dtoList[i].Notes = person[i].Notes.Where(x => x.PersonId == person[i].Id).Select(x => new SelectNoteDto
                    {
                        Id = x.Id,
                        Contente = x.Contente,
                        DateCreated = x.DateCreated,
                        DateModified = x.DateModified,
                        Views = x.Views,
                        Published = x.Published
                    }).ToList();
                }
            }

            return dtoList;
        }

        private static SelectPersonDto ConvertGet(Person person)
        {
            if (person == null)
            {
                return null;
            }
            var editDto = new SelectPersonDto();
            editDto.Id = person.Id;
            editDto.FirstName = person.FirstName;
            editDto.LastName = person.LastName;
            editDto.Email = person.Email;
            editDto.Website = person.Website;
            editDto.Age = person.Age;
            foreach(var item in person.Notes)
            {
                editDto.Notes = person.Notes.Where(x => x.PersonId == person.Id).Select(x => new SelectNoteDto
                {
                    Id = x.Id,
                    Contente = x.Contente,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    Views = x.Views,
                    Published = x.Published
                }).ToList();
            }

            return editDto;
        }
        private static EditPersonDto Convert(Person person)
        {
            if (person == null)
            {
                return null;
            }
            var editDto = new EditPersonDto();
            editDto.Id = person.Id;
            editDto.FirstName = person.FirstName;
            editDto.LastName = person.LastName;
            editDto.Email = person.Email;
            editDto.Website = person.Website;
            editDto.Age = person.Age;

            return editDto;
        }

        private static EditPersonDto ConvertEdit(Person person)
        {
            if (person == null) return null;
            var create = new EditPersonDto()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Website = person.Website,
                Age = person.Age
            };
            return create;
        }
        private static DeletePersonDto ConvertDelete(Person person)
        {
            if (person== null)
            {
                return null;
            }
            var editDto = new DeletePersonDto();
            editDto.FirstName = person.FirstName;
            editDto.LastName = person.LastName;
            editDto.Email = person.Email;
            editDto.Website = person.Website;
            editDto.Age = person.Age;

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
        private static CreatePersonDto ConvertCreate(Person person)
        {
            if (person == null) return null;
            var create = new CreatePersonDto()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Website = person.Website,
                Age = person.Age
            };
            return create;
        }
        private static Person Convert(EditPersonDto edit)
        {
            var person = new Person()
            {
                Id = edit.Id,
                FirstName = edit.FirstName,
                LastName = edit.LastName,
                Email = edit.Email,
                Website = edit.Website,
                Age = edit.Age
            };
            return person;
        }

        public List<SelectPersonDto> GetAll() => PersonService.Convert(_personRepository.GetAllPerson());

        public SelectPersonDto GetPerson(int id) => ConvertGet(_personRepository.GetPerson(id));
        public EditPersonDto GetPersonForEdit(int id) => Convert(_personRepository.GetPerson(id));

        public CreatePersonDto CreatePerson(CreatePersonDto personDto) => ConvertCreate(_personRepository.CreatePerson(Convert(personDto)));

        public EditPersonDto UpdatePerson(EditPersonDto personDto) => ConvertEdit(_personRepository.UpdatePerson(Convert(personDto)));

        public DeletePersonDto DeletePerson(int id) => ConvertDelete(_personRepository.DeletePerson(id));

    }
}
