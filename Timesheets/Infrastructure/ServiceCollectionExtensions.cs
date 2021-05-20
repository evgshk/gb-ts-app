using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timesheets.Data;

namespace Timesheets.Infrastructure
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
    }
}