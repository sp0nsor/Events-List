using Events.Core.Models;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IParticipantsRepository
    {
        Task<Guid> Create(Participant participant);
        Task<List<Participant>> Get();
        Task<Participant> GetById(Guid id);
        Task<Guid> Delete(Guid id);
    }
}