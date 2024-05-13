using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder
            .HasIndex(e => e.ReservationId)
            .IsUnique();

        builder.HasOne(r => r.Reservation)
            .WithOne(s => s.Feedback)
            .HasPrincipalKey<Reservation>(p => p.ReservationId)
            .HasForeignKey<Feedback>(r => r.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}