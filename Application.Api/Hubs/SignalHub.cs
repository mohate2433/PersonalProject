using ApplicationService.Contracts.Contract;
using ApplicationService.Dtos.PersonDtos;
using Microsoft.AspNetCore.SignalR;

namespace Application.Api.Hubs
{
    public class SignalHub: Hub
    {
        
        public async Task CreatePerson(CreatePersonDto personDto)
        {
            Clients.All.SendAsync("ReciveCreatePerson", personDto);
        }
        public async Task EditPerson(EditPersonDto personDto)
        {
            Clients.All.SendAsync("ReciveEditPerson", personDto);
        }
    }
}
