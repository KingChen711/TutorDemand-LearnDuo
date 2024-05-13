using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K17221TutorDemand.DataAccess.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder
            .Property(e => e.MessageId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.MessageId)
            .IsUnique();

        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.Receiver)
            .WithMany(p => p.ReceivedMessages)
            .HasPrincipalKey(p => p.UserId)
            .HasForeignKey(d => d.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(d => d.Sender)
            .WithMany(p => p.SendMessages)
            .HasPrincipalKey(p => p.UserId)
            .HasForeignKey(d => d.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(d => d.Hub)
            .WithMany(p => p.Messages)
            .HasPrincipalKey(p => p.HubId)
            .HasForeignKey(d => d.HubId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}