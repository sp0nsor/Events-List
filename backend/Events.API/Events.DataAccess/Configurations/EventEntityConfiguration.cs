using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.DataAccess.Configurations
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.Place)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Category)
                .HasMaxLength(50);

            builder.Property(e => e.MaxParticipantCount)
                .IsRequired();

            builder.Property(e => e.Time)
                .IsRequired();

            builder.HasOne(e => e.Image)
                   .WithOne(i => i.Event)
                   .HasForeignKey<ImageEntity>(i => i.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Registrations)
                   .WithOne(r => r.Event)
                   .HasForeignKey(r => r.EventId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
