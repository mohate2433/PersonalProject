using Microsoft.EntityFrameworkCore;
using WebApplication1.Aggregates;

namespace WebApplication1
{
    public class PersonDbContext : DbContext

    {
        public PersonDbContext(DbContextOptions options) : base(options)
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
