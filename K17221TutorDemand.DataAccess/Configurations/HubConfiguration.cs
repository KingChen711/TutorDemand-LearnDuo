using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class HubConfiguration : IEntityTypeConfiguration<Hub>
{
    public void Configure(EntityTypeBuilder<Hub> builder)
    {
        builder
            .Property(e => e.HubId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.HubId)
            .IsUnique();

        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.LastMessageAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        builder
            .HasMany(s => s.Users)
            .WithMany(c => c.Hubs)
            .UsingEntity(
                "UserHubs",
                l => l
                    .HasOne(typeof(User))
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasPrincipalKey(nameof(User.UserId))
                    .OnDelete(DeleteBehavior.Cascade),
                r => r
                    .HasOne(typeof(Hub))
                    .WithMany()
                    .HasForeignKey("HubId")
                    .HasPrincipalKey(nameof(Hub.HubId))
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasKey("UserId", "HubId"));
    }
}