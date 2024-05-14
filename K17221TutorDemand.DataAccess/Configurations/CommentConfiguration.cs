using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .Property(e => e.CommentId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.CommentId)
            .IsUnique();

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.Comments)
            .HasPrincipalKey(p => p.UserId)
            .HasForeignKey(d => d.CommentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(d => d.Post)
            .WithMany(p => p.Comments)
            .HasPrincipalKey(p => p.PostId)
            .HasForeignKey(d => d.CommentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(s => s.LikeUsers)
            .WithMany(c => c.LikeComments)
            .UsingEntity(
                "CommentUserLikes",
                l => l
                    .HasOne(typeof(User))
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasPrincipalKey(nameof(User.UserId))
                    .OnDelete(DeleteBehavior.Restrict),
                r => r
                    .HasOne(typeof(Comment))
                    .WithMany()
                    .HasForeignKey("CommentId")
                    .HasPrincipalKey(nameof(Comment.CommentId))
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasKey("UserId", "CommentId"));
    }
}