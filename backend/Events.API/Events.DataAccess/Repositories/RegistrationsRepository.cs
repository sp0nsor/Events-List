using AutoMapper;
using Events.Core.Models;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Events.DataAccess.Interfaces.Repositories;

namespace Events.DataAccess.Repositories
{
    public class RegistrationsRepository : IRegistrationsRepository
    {
        private readonly EventsDbContext context;
        private readonly IMapper mapper;

        public RegistrationsRepository(EventsDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Guid> Create(Registration registration)
        {
            var registrationEntity = mapper.Map<RegistrationEntity>(registration);
            await context.Registrations.AddAsync(registrationEntity);

            return registrationEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await context.Registrations
                .Where(r => r.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
