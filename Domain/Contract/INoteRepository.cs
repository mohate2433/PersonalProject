using Domain.Aggregates;
using EntityFramework.GenericEfCore.Contract;

namespace Domain.Contract
{
    public interface INoteRepository : IRepository<int, Note>
    {
        public List<Note> GetNotes(int PersonId);
    }
}
