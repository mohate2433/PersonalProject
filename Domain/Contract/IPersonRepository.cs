using Domain.Aggregates;
using EntityFramework.GenericEfCore.Contract;
using System.Linq.Expressions;

namespace Domain.Contract
{
    public interface IPersonRepository : IRepository<int, Person>
    {
        Person GetPerson(int id);
        public Person CreatePerson(Person entity);
        Person GetPersonEmail(string email);
        Person DeletePerson(int id);
    }
}
