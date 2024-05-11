using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder
            .HasIndex(e => e.ContractId)
            .IsUnique();

        builder.HasOne(r => r.Contract)
            .WithOne(s => s.Feedback)
            .HasPrincipalKey<Contract>(p => p.ContractId)
            .HasForeignKey<Feedback>(r => r.ContractId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}