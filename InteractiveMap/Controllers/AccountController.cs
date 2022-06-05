using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Infrastructure.Identity.Types;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[Route("api/account")]
public class AccountController : ApiControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
    {
        await _accountService.RegisterAsync(request);

        return Ok();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody] AuthenticationRequest request)
    {
        await _accountService.LoginAsync(request);

        return Ok();
    }
}
