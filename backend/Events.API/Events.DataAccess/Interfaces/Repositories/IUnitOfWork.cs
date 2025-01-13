namespace Events.DataAccess.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IEventsRepository Events { get; }
        IParticipantsRepository Participants { get; }
        IRegistrationsRepository Registrations { get; }
        public IUsersRepository Users { get; }

        void Dispose();
        Task<int> SaveChangesAsync();
    }
}