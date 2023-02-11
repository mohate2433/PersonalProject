using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.PersonDtos;
using Domain.Aggregates;
using Domain.Contract;

namespace ApplicationService.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
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

        public List<SelectPersonDto> GetAll() => PersonService.Convert(_personRepository.GetAll());

        public EditPersonDto GetPerson(int id) => Convert(_personRepository.GetPerson(id));

        public CreatePersonDto CreatePerson(CreatePersonDto personDto) => ConvertCreate(_personRepository.CreatePerson(Convert(personDto)));

        public EditPersonDto UpdatePerson(EditPersonDto personDto) => ConvertEdit(_personRepository.Update(Convert(personDto)));

        public DeletePersonDto DeletePerson(int id) => ConvertDelete(_personRepository.DeletePerson(id));

        public EditPersonDto GetPerson(string email) => Convert(_personRepository.GetPersonEmail(email));
    }
}
