using FluentValidation;
using InteractiveMap.Infrastructure.Identity.Types;

namespace InteractiveMap.Infrastructure.Identity.Validations;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(request => request.UserName).MinimumLength(4);
        RuleFor(request => request.Email).EmailAddress();
        RuleFor(request => request.Password).MinimumLength(7);
        RuleFor(request => request.Password).Equal(request => request.ConfirmPassword);
    }
}
