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
                    var deletePerson = _context.Person.FirstOrDefault(x => x.Id == id);
                    if (deletePerson != null)
                    {
                        List<Note> note = _context.Note.Where(x => x.PersonId == id).ToList();
                        if (note != null)
                        {
                            for (int i = 0; i < note.Count; i++)
                            {
                                _context.Entry(note).State = EntityState.Deleted;
                                _context.SaveChanges();
                            }
                        }
                        _context.Entry(deletePerson).State = EntityState.Deleted;
                        _context.SaveChanges();
                        return deletePerson;
                    }
                    return null;
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

        public List<Person> GetAllPerson()
        {
            using (_context)
            {
                try
                {

                    return _context.Set<Person>().Include(x => x.Notes).ToList();
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
                    var person = _context.Person.FirstOrDefault(x => x.Email == email);
                    if (person != null) return person;
                    return null;
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
        public Person CreatePerson(Person entity)
        {
            using (_context)
            {
                try
                {
                    if (_context.Person.FirstOrDefault(x => x.Email == entity.Email && x.Id != entity.Id) == null)
                    {
                        _context.Set<Person>().Add(entity);
                        _context.SaveChanges();
                        return entity;
                    }
                    return null;

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
        public Person UpdatePerson(Person entity)
        {
            using (_context)
            {
                try
                {
                    if (_context.Person.FirstOrDefault(x => x.Email == entity.Email && x.Id != entity.Id) != null)
                        return null;
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                    return entity;
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
