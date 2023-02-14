using Domain.Aggregates;
using Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PersonalDbContext : DbContext 
    {
        public PersonalDbContext(DbContextOptions options) : base(options)
        {
        }


        private readonly SignalHub _hub;

        public PersonalDbContext(SignalHub hub)
        {
            _hub = hub;
        }



        public DbSet<Person>? Person { get; set; }
        public DbSet<Note>? Note { get; set; }


        public async Task RecivePerson(Person person)
        {
            await _hub.Clients.All.SendAsync("RecivePerson", person);
        }
        public async Task ReciveNote(Note note)
        {
            await _hub.Clients.All.SendAsync("ReciveNote", note);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var personAssembly = typeof(Person).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(personAssembly);
            var bookAssembly = typeof(Note).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(bookAssembly);


            base.OnModelCreating(modelBuilder);
        }

    }
}
