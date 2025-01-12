using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Events.DataAccess.Configurations
{
    public class ParticipantEntityConfiguration
        : IEntityTypeConfiguration<ParticipantEntity>
    {
        public void Configure(EntityTypeBuilder<ParticipantEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.BirthDate)
                .IsRequired();

            builder.HasMany(p => p.Registrations)
                   .WithOne(r => r.Participant)
                   .HasForeignKey(r => r.ParticipantId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
