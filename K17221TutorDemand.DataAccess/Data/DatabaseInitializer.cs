using K17221TutorDemand.Models.Entities;
using K17221TutorDemand.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.DataAccess.Data
{
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

        //  Summary:
        //      Initilize Database (if any)
        public async Task InitializeAsync()
        {
            try
            {
                // Check if database is not exist 
                if (!_context.Database.CanConnect())
                {
                    // Migration Database - Create database 
                    await _context.Database.MigrateAsync();
                }

                // Check if migrations have already been applied 
                var appliedMigrations = await _context.Database.GetAppliedMigrationsAsync();

                if (appliedMigrations.Any())
                {
                    Console.WriteLine("Migrations have already been applied. Skip migratons proccess.");
                    return;
                }

                Console.WriteLine("Database migrated successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //  Summary:
        //      Seeding Data
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

        //  Summary:
        //      Seeding Data for several entities 
        public async Task TrySeedAsync()
        {
            try
            {
                if (_userManager.Users!.Any())
                {
                    Console.WriteLine("Data has been already seed. Skip seeding process.");
                    return;
                };

                Console.WriteLine("--> Seeding Data");

                // Roles
                await SeedRolesAsync();

                // Admins
                var adminEmails = new List<string> { "admin@localhost.com", "admin1@localhost.com" };
                await SeedUsersAsync(adminEmails, RoleAccount.Administrator);

                // Moderators
                var moderatorEmails = new List<string> { "moderator@localhost.com", "moderator1@localhost.com" };
                await SeedUsersAsync(adminEmails, RoleAccount.Moderator);

                // Tutors
                var tutorEmails = Enumerable.Range(1, 5).Select(i => $"tutor{i}@localhost.com");
                tutorEmails = tutorEmails.Append("tutor@localhost.com");
                await SeedUsersAsync(tutorEmails.ToList(), RoleAccount.Tutor);

                // Students
                var studentEmails = Enumerable.Range(1, 11).Select(i => $"student{i}@localhost.com");
                studentEmails = studentEmails.Append("student@localhost.com");
                await SeedUsersAsync(studentEmails.ToList(), RoleAccount.Student);

                // System handler
                await SeedUsersAsync("systemhandler@localhost.com", RoleAccount.SystemHandler);

                var isSuccess = await _context.SaveChangesAsync() > 0;

                if(isSuccess) Console.WriteLine("--> Seeding Data Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
    

        //  Summary:
        //      Seed all role data 
        private async Task SeedRolesAsync()
        {
            foreach(var role in Enum.GetValues(typeof(RoleAccount)))
            {
                if (role is null) continue;

                //var displayAttribute = role.GetType()?
                //                       .GetField(role.ToString()!)?
                //                       .GetCustomAttribute<DisplayAttribute>();

                //var roleName = displayAttribute != null ? displayAttribute.Name : role.ToString();

                var roleName = role.ToString();
                if (!await _roleManager.RoleExistsAsync(roleName ?? string.Empty))
                {
                    var roleEntity = new Role
                    {
                        Name = roleName,
                        NormalizedName = roleName!.ToUpperInvariant()
                    };

                    await _roleManager.CreateAsync(roleEntity);
                }
            }
        }
    
        
        //  Summary:
        //      Seed users data include (List<string> email, RoleAccount role)
        private async Task SeedUsersAsync(List<string> emails, RoleAccount role)
        {
            foreach(var email in emails)
            {
                if(_userManager.Users.All(x => x.Email != email))
                {
                    var userId = Guid.NewGuid();
                    var user = new User
                    {
                        UserId = userId,
                        Email = email,
                        UserName = email,
                        EmailConfirmed = true,
                        FullName = "Nguyen Van A"
                    };

                    var result = await _userManager.CreateAsync(user, "@Password123");
                    if (result.Succeeded)
                    {
                        // Add Role 
                        await _userManager.AddToRoleAsync(user, role.ToString());

                        // Add Profile
                        await _context.Profiles.AddAsync(await SeedProfileAsync(userId));
                    }
                }
            }
        }

        //  Summary:
        //      Seed users data include (string email, RoleAccount role)
        private async Task SeedUsersAsync(string email, RoleAccount role)
        {
            if (_userManager.Users.All(x => x.Email != email))
            {
                var userId = Guid.NewGuid();
                var user = new User
                {
                    UserId = userId,
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                    FullName = "Nguyen Van A"
                };

                var result = await _userManager.CreateAsync(user, "@Password123");
                if (result.Succeeded)
                {
                    // Add Role 
                    await _userManager.AddToRoleAsync(user, role.ToString());

                    // Add Profile
                    await _context.Profiles.AddAsync(await SeedProfileAsync(userId));
                }
            }
        }
    
        
        //  Summary:
        //      Seed profile for users
        private async Task<Profile> SeedProfileAsync(Guid userId)
        {
            var random = new Random();
            var genders = Enum.GetValues(typeof(Gender));

            var profile = new Profile
            {
                UserId = userId,
                Avatar = $"/images/default-avatar.jpg",
                Album = "[]",
                Nickname = $"Nickname",
                Bio = $"This is the biography of user.",
                Gender = genders.GetValue(random.Next(genders.Length))!.ToString(),
                IsAvailable = random.Next(2) == 0, // Randomly true or false
                AutomaticGreeting = $"Hello, I am user!",
            };

            await Task.CompletedTask;
            return profile;
        }
    }
}
