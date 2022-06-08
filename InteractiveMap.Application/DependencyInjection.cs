using System.Reflection;
using InteractiveMap.Application.Services.MarkService;
using InteractiveMap.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveMap.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IBaseMarkService<Mark>, MarkService>();
        services.AddScoped<IBaseMarkService<UserMark>, UserMarkService>();

        return services;
    }
}
