using AutoMapper;
using Events.DataAccess.Interfaces.Repositories;
using Events.DataAccess.Repositories;

namespace Events.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper mapper;
        private readonly EventsDbContext context;

        private EventsRepository eventsRepository;
        private ParticipantsRepository participantsRepository;
        private RegistrationsRepository registrationsRepository;
        private UsersRepository usersRepository;

        public UnitOfWork(EventsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public IParticipantsRepository Participants =>
            participantsRepository ??= new ParticipantsRepository(context, mapper);

        public IEventsRepository Events =>
            eventsRepository ??= new EventsRepository(context, mapper);

        public IRegistrationsRepository Registrations =>
            registrationsRepository ??= new RegistrationsRepository(context, mapper);

        public IUsersRepository Users => 
            usersRepository ??= new UsersRepository(context, mapper);

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
