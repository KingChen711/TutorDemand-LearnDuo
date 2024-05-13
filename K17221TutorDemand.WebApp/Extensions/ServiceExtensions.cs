using K17221TutorDemand.BusinessLogic;
using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Dtos.Hub;
using K17221TutorDemand.Models.Dtos.User;
using K17221TutorDemand.Models.Entities;
using K17221TutorDemand.Models.SettingModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace K17221TutorDemand.WebApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureServiceFactory(this IServiceCollection services) =>
            services.AddScoped<IServiceFactory, ServiceFactory>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddSqlServer<TutorDemandDbContext>(
                    configuration.GetConnectionString("TutorDemandDbContextConnection"))
                .AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<TutorDemandDbContext>();

        public static void RegisterMapsterConfiguration(this IServiceCollection _)
        {
            TypeAdapterConfig<Hub, HubWithLastMessageDto>
                .NewConfig()
                .Map(dest => dest.LastMessage,
                    src => src.Messages.Count != 0
                        ? src.Messages.ToList()[0].Adapt<MessageWithSenderDto>()
                        : null);

            TypeAdapterConfig<Hub, HubDetailDto>
                .NewConfig()
                .Map(dest => dest.OtherUser,
                    src => src.Users.Count != 0
                        ? src.Users.ToList()[0].Adapt<UserWithProfileDto>()
                        : null);
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(o =>
                {
                    o.Password.RequireDigit = true;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 10;
                    o.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<TutorDemandDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddFluentEmail(this IServiceCollection services, IConfiguration
            configuration)
        {
            var emailConfiguration = new EmailConfiguration();
            services.Configure<EmailConfiguration>(configuration.GetSection(emailConfiguration.Section));

            var emailSettings = configuration.GetSection(emailConfiguration.Section);

            services
                .AddFluentEmail(emailSettings["DefaultFromEmail"])
                .AddSmtpSender(
                    emailSettings["SmtpHost"],
                    emailSettings.GetValue<int>("Port"),
                    emailSettings["BusinessEmail"],
                    emailSettings["Password"])
                .AddRazorRenderer();
        }
    }
}