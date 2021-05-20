using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timesheets.Data.Ef;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Implementation;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TimesheetDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("Postgres"),
                    b=>b.MigrationsAssembly("Timesheets"));
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtAccessOptions>(configuration.GetSection("Authentication:JwtAccessOptions"));

            var jwtSettings = new JwtOptions();
            configuration.Bind("Authentication:JwtAccessOptions", jwtSettings);

            services.AddTransient<ILoginManager, LoginManager>();

            services
                .AddAuthentication(
                    x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = jwtSettings.GetTokenValidationParameters();
                });
        }

        public static void ConfigureDomainManagers(this IServiceCollection services)
        {
            services.AddScoped<ISheetManager, SheetManager>();
            services.AddScoped<IContractManager, ContractManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ILoginManager, LoginManager>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISheetRepo, SheetRepo>();
            services.AddScoped<IContractRepo, ContractRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
        }
    }
}