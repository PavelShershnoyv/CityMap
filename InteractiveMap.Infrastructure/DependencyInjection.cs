using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Repositories;
using InteractiveMap.Core.Entities;
using InteractiveMap.Infrastructure.Identity;
using InteractiveMap.Infrastructure.Persistence;
using InteractiveMap.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveMap.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMapLayerRepository<MapLayer>, MapLayerRepository<MapLayer>>();
            services.AddScoped<IMarkRepository<Mark>, MarkRepository<Mark>>();

            services.AddScoped<IMapLayerRepository<UserMapLayer>, MapLayerRepository<UserMapLayer>>();
            services.AddScoped<IMarkRepository<UserMark>, MarkRepository<UserMark>>();

            services.AddScoped<IMarkImageRepository, MarkImageRepository>();

            services.AddDbContext<MapContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DbConnection")));

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("IdentityDbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddTransient<IAccountService, AccountService>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "Auth";
            });

            return services;
        }
    }
}
