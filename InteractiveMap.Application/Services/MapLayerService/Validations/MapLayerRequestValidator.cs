using FluentValidation;
using InteractiveMap.Application.Services.MapLayerService.Types;

namespace InteractiveMap.Application.Services.MapLayerService.Validations;

public class MapLayerRequestValidator : AbstractValidator<MapLayerRequest>
{
    public MapLayerRequestValidator()
    {
        RuleFor(request => request.Title).NotEmpty();
        RuleFor(request => request.Description);
    }
}
