using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Infrastructure.Identity.Types;
using Microsoft.AspNetCore.Identity;

namespace InteractiveMap.Infrastructure.Identity;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        var userWithSameName = await _userManager.FindByNameAsync(request.UserName);

        if (userWithSameName != null)
        {
            throw new ApplicationException($"Username {request.UserName} is already taken.");
        }

        var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);

        if (userWithSameEmail != null)
        {
            throw new ApplicationException($"Email {request.Email} is already registered.");
        }

        var user = new ApplicationUser { Email = request.Email, UserName = request.UserName };

        var result = await _userManager.CreateAsync(user);

        if (!result.Succeeded)
        {
            throw new ApplicationException(result.Errors.FirstOrDefault()?.Description);
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
    }

    public async Task AuthenticateaAsync(AuthenticationRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new ApplicationException($"No users with email {request.Email}.");
        }

        await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
    }
}
