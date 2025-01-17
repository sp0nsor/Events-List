using Events.Core.Models;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IParticipantsRepository
    {
        Task<Guid> Create(Participant participant);
        Task<PagedList<Participant>> Get(int page, int pageSize);
        Task<Participant> GetById(Guid id);
        Task<Guid> Delete(Guid id);
    }
}