using Domain.Aggregates;
using EntityFramework.GenericEfCore.Contract;
using System.Linq.Expressions;

namespace Domain.Contract
{
    public interface IPersonRepository : IRepository<int, Person>
    {
        List<Person> GetAllPerson();
        Person GetPerson(int id);
        Person CreatePerson(Person entity);
        Person UpdatePerson(Person entity);
        Person DeletePerson(int id);

    }
}
