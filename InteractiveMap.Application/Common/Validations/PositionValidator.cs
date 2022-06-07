using FluentValidation;
using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Application.Common.Validations;

public class PositionValidator : AbstractValidator<Position>
{
    public PositionValidator()
    {
        RuleFor(position => position.Latitude).GreaterThanOrEqualTo(0).LessThanOrEqualTo(90);
        RuleFor(position => position.Longitude).GreaterThanOrEqualTo(0).LessThanOrEqualTo(180);
    }
}
