using ApplicationService.Dtos.PersonDtos;
using EntityFramework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Contracts.Contract
{
    public interface IPersonService
    {
        List<SelectPersonDto> GetAll();
        EditPersonDto GetPerson(int id);
        OprationResult CreatePerson(CreatePersonDto personDto);
        OprationResult UpdatePerson(EditPersonDto personDto);
        OprationResult DeletePerson(int id);

    }
}
