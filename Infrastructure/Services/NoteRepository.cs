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

        public List<Note> GetNotes(int PersonId)
        {
            using (_context)
            {
                try
                {
                    return _context.Note.Where(x=>x.PersonId== PersonId).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }
    }
}
