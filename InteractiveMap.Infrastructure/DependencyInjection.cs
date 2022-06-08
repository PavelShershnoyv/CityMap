using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Core.Entities;
using InteractiveMap.Infrastructure.Identity;
using InteractiveMap.Infrastructure.Identity.Services.AccountService;
using InteractiveMap.Infrastructure.Identity.Services.UserScopes;
using InteractiveMap.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveMap.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserScope<Mark>, MarkScope>();
        services.AddScoped<IUserScope<UserMark>, UserMarkScope>();

        services.AddDbContext<MapContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DbConnection")));

        services.AddScoped<IMapContext>(provider => provider.GetService<MapContext>());

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
