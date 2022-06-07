using FluentValidation;
using InteractiveMap.Infrastructure.Identity.Types;

namespace InteractiveMap.Infrastructure.Identity.Validations;

public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
{
    public AuthenticationRequestValidator()
    {
        RuleFor(request => request.Email).NotEmpty().EmailAddress();
        RuleFor(request => request.Password).NotEmpty().MinimumLength(7);
    }
}
