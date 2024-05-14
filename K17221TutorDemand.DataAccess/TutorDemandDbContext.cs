using K17221TutorDemand.DataAccess.Configurations;
using K17221TutorDemand.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace K17221TutorDemand.DataAccess;

public class TutorDemandDbContext : IdentityDbContext<User, Role, int>
{
    public TutorDemandDbContext(DbContextOptions options) : base(options)
    {
    }

    public TutorDemandDbContext()
    {
    }

    public DbSet<Feedback> Comments { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Hub> Hubs { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    //không cần tạo DbSet cho User và Role

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(GetBasePath())
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("TutorDemandDbContextConnection"));
    }

    private string GetBasePath()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
        return Path.Combine(directoryInfo.Parent!.FullName, "K17221TutorDemand.WebApp");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new HubConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectConfiguration());
    }
}