using Domain.Aggregates;
using Domain.Contract;
using EntityFramework.Infrastructure.ServiceGeneric;

namespace Infrastructure.Services
{
    public class PersonRepository : Repository<int, Person>, IPersonRepository
    {
        private readonly PersonalDbContext _context;
        public PersonRepository(PersonalDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
