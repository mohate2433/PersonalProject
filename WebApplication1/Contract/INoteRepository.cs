using EntityFramework.GenericEfCore.Contract;
using WebApplication1.Aggregates;

namespace WebApplication1.Contract
{
    public interface INoteRepository : IRepository<int, Note>
    {
        public List<Note> GetNotes(int PersonId);
    }
}
