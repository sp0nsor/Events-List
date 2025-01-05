using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.DataAccess.Configurations
{
    public class RegistrationEntityConfiguration : IEntityTypeConfiguration<RegistrationEntity>
    {
        public void Configure(EntityTypeBuilder<RegistrationEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.RegistrationDate)
                .IsRequired();

            builder.HasOne(r => r.Event)
                   .WithMany(e => e.Registrations)
                   .HasForeignKey(r => r.EventId);

            builder.HasOne(r => r.Participant)
                   .WithMany(p => p.Registrations)
                   .HasForeignKey(r => r.ParticipantId);
        }
    }
}
