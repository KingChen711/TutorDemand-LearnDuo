using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .Property(e => e.ReservationId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.ReservationId)
            .IsUnique();

        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.Post)
            .WithMany(p => p.Reservations)
            .HasPrincipalKey(p => p.PostId)
            .HasForeignKey(d => d.PostId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(d => d.Customer)
            .WithMany(p => p.Reservations)
            .HasPrincipalKey(p => p.UserId)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}