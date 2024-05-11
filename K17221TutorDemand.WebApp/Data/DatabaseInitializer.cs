using K17221TutorDemand.DataAccess;
using K17221TutorDemand.Models.Entities;
using K17221TutorDemand.Models.Enums;
using K17221TutorDemand.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace K17221TutorDemand.WebApp.Data;

public static class DatabaseInitializerExtension
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        // Create IServiceScope to resolve service scope
        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();

            // Initiate database (if any)
            await initializer.InitializeAsync();

            // Try to seeding data
            await initializer.SeedAsync();
        }
    }
}

public interface IDatabaseInitializer
{
    Task InitializeAsync();
    Task SeedAsync();
    Task TrySeedAsync();
}

public class DatabaseInitializer : IDatabaseInitializer
{
    private readonly TutorDemandDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public DatabaseInitializer(TutorDemandDbContext context,
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        try
        {
            // Check if database is not exist 
            if (!_context.Database.CanConnect())
            {
                Console.WriteLine("Initializing database");
                // Migration Database - Create database 
                await _context.Database.MigrateAsync();
            }

            // Check if migrations have already been applied 
            var appliedMigrations = await _context.Database.GetAppliedMigrationsAsync();

            if (appliedMigrations.Any())
            {
                Console.WriteLine("Migrations have already been applied. Skip migrations proccess.");
                return;
            }

            Console.WriteLine("Database migrated successfully");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        try
        {
            if (_context.Cars!.Any()) Console.WriteLine("Data has been already seed. Skip seeding process.");

            Console.WriteLine("--> Seeding Data");

            // Roles
            List<Role> roles = new()
            {
                new Role
                {
                    Name = RoleAccount.ADMINISTRATOR,
                    NormalizedName = RoleAccount.ADMINISTRATOR.ToUpperInvariant()
                },
                new Role
                {
                    Name = RoleAccount.CUSTOMER,
                    NormalizedName = RoleAccount.CUSTOMER.ToUpperInvariant()
                },
                new Role
                {
                    Name = RoleAccount.EMPLOYEE,
                    NormalizedName = RoleAccount.EMPLOYEE.ToUpperInvariant()
                }
            };

            // Seeding roles
            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }
            // Administrator account
            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@localhost",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(adminUser, "@Admin123");
            if (result.Succeeded)
            {
                // Add the admin user to the Admin role
                await _userManager.AddToRoleAsync(adminUser, RoleAccount.ADMINISTRATOR);
            }

            // Car statuses
            var carStatuses = new[]
            {
                new CarStatus { CarStatusId = Guid.NewGuid(), Name = "Available" },
                new CarStatus { CarStatusId = Guid.NewGuid(), Name = "Under Maintenance" },
                new CarStatus { CarStatusId = Guid.NewGuid(), Name = "Unavailable" }
            };

            // Cars
            var brands = new string[] { "Toyota", "Honda", "Ford", "Chevrolet", "BMW", "Mercedes-Benz", "Audi", "Volkswagen" };
            var colors = new string[] { "Red", "Blue", "Green", "White", "Black", "Silver", "Gray" };
            var random = new Random();
            List<Car> cars = new();

            for (int i = 0; i < 15; i++)
            {
                var licensePlate = LicensePlateHelper.GenerateLicensePlate(random);

                var car = new Car
                {
                    CarId = Guid.NewGuid(),
                    Brand = brands[random.Next(brands.Length - 1)],
                    Color = colors[random.Next(colors.Length - 1)],
                    Year = random.Next(2000, DateTime.Now.Year + 1),
                    Seat = random.Next(2, 8),
                    Model = "Model" + i,
                    LicensePlate = licensePlate,
                    CarStatusId = carStatuses[random.Next(carStatuses.Length - 1)].CarStatusId
                };
                cars.Add(car);
            }

            await _context.CarStatuses!.AddRangeAsync(carStatuses);
            await _context.Cars!.AddRangeAsync(cars);
            var seedingSuccess = await _context.SaveChangesAsync() > 0;

            if (seedingSuccess) Console.WriteLine("--> Seeding Data Successfully");
        }
        catch (Exception)
        {
            throw;
        }
    }
}

