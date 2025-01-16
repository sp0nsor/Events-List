using Events.DataAccess.Configurations;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Events.DataAccess
{
    public class EventsDbContext : DbContext
    {
        private readonly IOptions<AuthorizationOptions> authOptions;

        public EventsDbContext(
            DbContextOptions<EventsDbContext> options,
            IOptions<AuthorizationOptions> authOptions)
            : base(options)
        {
            this.authOptions = authOptions;
        }

        public DbSet<EventEntity> Events { get; set; }

        public DbSet<ImageEntity> Images { get; set; }
        
        public DbSet<ParticipantEntity> Participants { get; set; }

        public DbSet<RegistrationEntity> Registrations { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventsDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new RolePermissionEntityConfiguration(authOptions.Value));
        }
    }
}
