using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class CarStatusConfiguration : IEntityTypeConfiguration<CarStatus>
{
    public void Configure(EntityTypeBuilder<CarStatus> builder)
    {
        builder
            .Property(e => e.CarStatusId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.CarStatusId)
            .IsUnique();
    }
}