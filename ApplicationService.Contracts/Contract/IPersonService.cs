using ApplicationService.Dtos.PersonDtos;

namespace ApplicationService.Contracts.Contract
{
    public interface IPersonService
    {
        List<SelectPersonDto> GetAll();
        SelectPersonDto GetPerson(int id);
        CreatePersonDto CreatePerson(CreatePersonDto personDto);
        EditPersonDto UpdatePerson(EditPersonDto personDto);
        DeletePersonDto DeletePerson(int id);

    }
}
