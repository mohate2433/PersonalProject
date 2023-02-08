using Domain.Aggregates;
using Domain.Contract;
using EntityFramework.Infrastructure.ServiceGeneric;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services
{
    public class NoteRepository : Repository<int, Note>, INoteRepository
    {
        private readonly PersonalDbContext _context;

        public NoteRepository(PersonalDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Note> SelectAll()
        {
            return _context.Book.Include(x => x.Person).ToList();
        }
    }
}
