using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PersonalDbContext : DbContext
    {
        public PersonalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person>? Person { get; set; }
        public DbSet<Note>? Note { get; set; }

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
