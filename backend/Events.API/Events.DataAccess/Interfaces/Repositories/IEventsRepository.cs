using Events.Core.Models;
using System.Threading;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IEventsRepository
    {
        Task<Guid> Create(Event Event, CancellationToken cancellationToken = default);
        Task<Guid> Delete(Guid id, CancellationToken cancellationToken = default);
        Task<PagedList<Event>> Get(
            string? searchName,
            string? searchPlace,
            string? searchCategory,
            string? sortItem,
            string? sortOrder,
            int page,
            int pageSize,
            CancellationToken cancellationToken = default);
        Task<Event> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<Guid> Update(
            Guid id,
            string name,
            string description,
            string place,
            string category,
            int maxParticipantCount,
            DateTime time,
            CancellationToken cancellationToken = default);
        Task<List<Participant>> GetParticipants(Guid eventId, CancellationToken cancellationToken = default);
    }
}
