using Domain.Aggregates;
using Domain.Contract;
using EntityFramework.Infrastructure.ServiceGeneric;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PersonRepository : Repository<int, Person>, IPersonRepository
    {
        private readonly PersonalDbContext _context;
        public PersonRepository(PersonalDbContext context) : base(context)
        {
            _context = context;
        }

        public Person DeletePerson(int id)
        {
            using (_context)
            {
                try
                {
                    List<Note> note = _context.Note.Where(x => x.PersonId == id).ToList();
                    var deletePerson = _context.Person.FirstOrDefault(x => x.Id == id);
                    if (deletePerson != null)
                    {
                        if (note != null)
                        {
                            for (int i = 0; i < note.Count; i++)
                            {
                                _context.Entry(note).State = EntityState.Deleted;
                                _context.SaveChanges();
                            }
                        }
                    }
                    _context.Entry(deletePerson).State = EntityState.Deleted;
                    _context.SaveChanges();
                    return deletePerson;

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

        public Person GetPerson(int id)
        {
            using (_context)
            {
                try
                {
                    return _context.Person.Include(x => x.Notes).FirstOrDefault(x => x.Id == id);
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

        public Person GetPersonEmail(string email)
        {
            using (_context)
            {
                try
                {
                    return _context.Person.FirstOrDefault(x => x.Email == email);
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
