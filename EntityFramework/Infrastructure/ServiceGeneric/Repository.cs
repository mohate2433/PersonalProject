using EntityFramework.GenericEfCore.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFramework.Infrastructure.ServiceGeneric
{
    public class Repository<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            using (_context)
            {
                try
                {

                    _context.Set<T>().Add(entity);
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

        public T Delete(Tkey id)
        {
            using (_context)
            {
                try
                {
                    var entity = _context.Set<T>().Find(id);
                    _context.Entry(entity).State = EntityState.Deleted;
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

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            using (_context)
            {
                try
                {
                    return _context.Set<T>().Any(expression);
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

        public T Get(Tkey id)
        {
            using (_context)
            {
                try
                {
                    return _context.Set<T>().Find(id);
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

        public List<T> GetAll()
        {
            using (_context)
            {
                try
                {

                    return _context.Set<T>().ToList();
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

        public T Update(T entity)
        {
            using (_context)
            {
                try
                {
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
