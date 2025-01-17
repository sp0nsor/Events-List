using Events.Core.Models;
using System.Threading;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IParticipantsRepository
    {
        Task<Guid> Create(Participant participant, CancellationToken cancellationToken = default);
        Task<PagedList<Participant>> Get(int page, int pageSize, CancellationToken cancellationToken = default);
        Task<Participant> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<Guid> Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
