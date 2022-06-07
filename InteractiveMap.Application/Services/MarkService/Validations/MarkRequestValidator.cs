using FluentValidation;
using InteractiveMap.Application.Common.Validations;
using InteractiveMap.Application.Services.MarkService.Types;

namespace InteractiveMap.Application.Services.MarkService.Validations;

public class MarkRequestValidator : AbstractValidator<MarkRequest>
{
    public MarkRequestValidator()
    {
        RuleFor(request => request.Title).NotEmpty();
        RuleFor(request => request.Description).NotEmpty();

        RuleFor(request => request.Position).SetValidator(new PositionValidator());

        RuleFor(request => request.MapLayerId).NotNull();
    }
}
