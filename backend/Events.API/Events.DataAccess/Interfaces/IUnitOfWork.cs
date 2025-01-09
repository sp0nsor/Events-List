namespace Events.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IEventsRepository Events { get; }
        IParticipantsRepository Participants { get; }
        IRegistrationsRepository Registrations { get; }

        void Dispose();
        Task<int> SaveChangesAsync();
    }
}