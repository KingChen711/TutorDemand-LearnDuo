using System.Reflection;
using K17221TutorDemand.DataAccess.Configurations;
using K17221TutorDemand.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace K17221TutorDemand.DataAccess;

public class TutorDemandDbContext : IdentityDbContext<User, Role, int>
{
    public TutorDemandDbContext(DbContextOptions options) : base(options)
    {
    }

    public TutorDemandDbContext()
    {
    }

    public DbSet<Car>? Cars { get; set; }
    public DbSet<CarStatus>? CarStatuses { get; set; }
    public DbSet<Contract>? Contracts { get; set; }
    public DbSet<ContractStatus>? ContractStatuses { get; set; }
    public DbSet<Feedback>? Feedbacks { get; set; }
    public DbSet<Payment>? Payments { get; set; }
    //không cần tạo DbSet cho User và Role

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
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

        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CarStatusConfiguration());
        modelBuilder.ApplyConfiguration(new ContractConfiguration());
        modelBuilder.ApplyConfiguration(new ContractStatusConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}