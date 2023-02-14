using Domain.Aggregates;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Hubs
{
    public class SignalHub : Hub
    {
        public SignalHub()
        {
        }

        public async Task RecivePerson(Person person)
        {
            await Clients.All.SendAsync("RecivePerson", person);
        }
        public async Task ReciveNote(Note note)
        {
            await Clients.All.SendAsync("ReciveNote", note);
        }
    }
}
