using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder
            .Property(e => e.ContractId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.ContractId)
            .IsUnique();

        builder
            .HasOne(e => e.Car)
            .WithMany(e => e.Contracts)
            .HasPrincipalKey(p => p.CarId)
            .HasForeignKey(e => e.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(e => e.Customer)
            .WithMany(e => e.Contracts)
            .HasPrincipalKey(p => p.UserId)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(e => e.ContractStatus)
            .WithMany(e => e.Contracts)
            .HasPrincipalKey(p => p.ContractStatusId)
            .HasForeignKey(e => e.ContractStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}