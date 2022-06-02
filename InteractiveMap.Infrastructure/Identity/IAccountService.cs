using InteractiveMap.Infrastructure.Identity.Types;

namespace InteractiveMap.Application.Common.Interfaces;

public interface IAccountService
{
    Task RegisterAsync(RegisterRequest request);
    Task AuthenticateaAsync(AuthenticationRequest request);
}
