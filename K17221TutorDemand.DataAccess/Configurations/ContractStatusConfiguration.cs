using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class ContractStatusConfiguration : IEntityTypeConfiguration<ContractStatus>
{
    public void Configure(EntityTypeBuilder<ContractStatus> builder)
    {
        builder
            .Property(e => e.ContractStatusId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.ContractStatusId)
            .IsUnique();
    }
}