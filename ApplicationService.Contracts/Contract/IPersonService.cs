using ApplicationService.Dtos.PersonDtos;

namespace ApplicationService.Contracts.Contract
{
    public interface IPersonService
    {
        List<SelectPersonDto> GetAll();
        EditPersonDto GetPerson(int id);
        EditPersonDto GetPerson(string email);
        CreatePersonDto CreatePerson(CreatePersonDto personDto);
        EditPersonDto UpdatePerson(EditPersonDto personDto);
        DeletePersonDto DeletePerson(int id);

    }
}
