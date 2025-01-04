using Events.DataAccess.Configurations;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.DataAccess
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options) { }

        public DbSet<EventEntity> Events { get; set; }

        public DbSet<ImageEntity> Images { get; set; }
        
        public DbSet<ParticipantEntity> Participants { get; set; }

        public DbSet<RegistrationEntity> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ImageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationEntityConfiguration());
        }
    }
}
