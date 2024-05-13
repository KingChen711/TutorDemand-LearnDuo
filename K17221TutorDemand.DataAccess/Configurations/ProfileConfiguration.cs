using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder
            .HasIndex(e => e.UserId)
            .IsUnique();

        builder.HasOne(r => r.User)
            .WithOne(s => s.Profile)
            .HasPrincipalKey<User>(p => p.UserId)
            .HasForeignKey<Profile>(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}