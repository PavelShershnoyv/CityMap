using InteractiveMap.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveMap.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
            config.AddProfile<MapsProfile>());

        return services;
    }
}
