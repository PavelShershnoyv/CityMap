using System.Reflection;
using InteractiveMap.Application.MapLayerService;
using InteractiveMap.Application.MarkService;
using InteractiveMap.Application.MarkTypeService.Types;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveMap.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IMapLayerService, MapLayerService.MapLayerService>();
        services.AddScoped<IMarkService, MarkService.MarkService>();

        services.AddScoped<IMarkTypeService, MarkTypeService.MarkTypeService>();

        services.AddScoped<IUserMapLayerService, UserMapLayerService>();
        services.AddScoped<IUserMarkService, UserMarkService>();

        return services;
    }
}
