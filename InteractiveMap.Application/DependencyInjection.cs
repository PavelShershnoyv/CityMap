using System.Reflection;
using InteractiveMap.Application.Services.MapLayerService;
using InteractiveMap.Application.Services.MarkService;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveMap.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IMapLayerService, MapLayerService>();
        services.AddScoped<IMarkService, MarkService>();

        services.AddScoped<IUserMapLayerService, UserMapLayerService>();
        services.AddScoped<IUserMarkService, UserMarkService>();

        return services;
    }
}
