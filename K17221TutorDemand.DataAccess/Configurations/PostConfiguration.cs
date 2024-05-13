using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .Property(e => e.PostId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.PostId)
            .IsUnique();

        builder
            .HasOne(d => d.Tutor)
            .WithMany(p => p.Posts)
            .HasPrincipalKey(p => p.UserId)
            .HasForeignKey(d => d.TutorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(d => d.Subject)
            .WithMany(p => p.Posts)
            .HasPrincipalKey(p => p.SubjectId)
            .HasForeignKey(d => d.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

