using Domain.Aggregates;
using EntityFramework.GenericEfCore.Contract;

namespace Domain.Contract
{
    public interface IPersonRepository : IRepository<int, Person>
    {
    }
}
