using Events.Core.Models;

namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IParticipantsRepository
    {
        Task Create(Participant participant);
        Task<List<Participant>> Get();
        Task<Participant> GetById(Guid id);
        Task Delete(Guid id);
    }
}