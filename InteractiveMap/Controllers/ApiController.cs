using InteractiveMap.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    private ICurrentUserService _currentUserService;

    protected ICurrentUserService CurrentUserService =>
        _currentUserService ??= HttpContext.RequestServices.GetRequiredService<ICurrentUserService>();
}
