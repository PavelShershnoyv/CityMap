using InteractiveMap.Infrastructure.Identity.Services.AccountService.Types;

namespace InteractiveMap.Infrastructure.Identity.Services.AccountService;

public interface IAccountService
{
    Task RegisterAsync(RegisterRequest request);
    Task LoginAsync(AuthenticationRequest request);
    Task LogoutAsync();
}
