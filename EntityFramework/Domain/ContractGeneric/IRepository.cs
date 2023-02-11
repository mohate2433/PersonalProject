using System.Linq.Expressions;

namespace EntityFramework.GenericEfCore.Contract
{
    public interface IRepository<Tkey, T> where T : class
    {
        List<T> GetAll();
        T Get(Tkey id);
        T Delete(Tkey id);
        T Create(T entity);
        T Update(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
