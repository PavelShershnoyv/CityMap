using FluentValidation.AspNetCore;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Services.MarkService.Validations;
using InteractiveMap.Web.Services;

namespace InteractiveMap.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IBlobStorage, BlobStorage>();

        services.AddControllers();
        services.AddFluentValidation(config =>
            config.RegisterValidatorsFromAssemblyContaining<MarkRequestValidator>());

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
