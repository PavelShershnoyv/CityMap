using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveMap.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected Guid UserId => User.Identity.IsAuthenticated ? Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) : Guid.Empty;
}
