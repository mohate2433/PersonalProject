using Domain.Aggregates;
using EntityFramework.GenericEfCore.Contract;
using System.Linq.Expressions;

namespace Domain.Contract
{
    public interface IPersonRepository : IRepository<int, Person>
    {
        Person GetPerson(int id);
        Person GetPersonEmail(string email);
        Person DeletePerson(int id);
    }
}
