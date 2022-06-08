using FluentValidation;
using InteractiveMap.Infrastructure.Identity.Services.AccountService.Types;

namespace InteractiveMap.Infrastructure.Identity.Services.AccountService.Validations;

public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
{
    public AuthenticationRequestValidator()
    {
        RuleFor(request => request.Email).NotEmpty().EmailAddress();
        RuleFor(request => request.Password).NotEmpty().MinimumLength(7);
    }
}
