using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Infrastructure.Identity;
using InteractiveMap.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveMap.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MapsDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IMapsDbContext>(provider => provider.GetRequiredService<MapsDbContext>());

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MapsDbContext>();

            services.AddAuthentication().AddCookie("Authorization");

            return services;
        }
    }
}
