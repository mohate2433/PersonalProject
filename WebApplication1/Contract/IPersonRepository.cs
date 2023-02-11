using EntityFramework.GenericEfCore.Contract;
using System.Linq.Expressions;
using WebApplication1.Aggregates;

namespace Domain.Contract
{
    public interface IPersonRepository : IRepository<int, Person>
    {
        Person GetPerson(int id);
        Person GetPersonEmail(string email);
        Person DeletePerson(int id);
    }
}
