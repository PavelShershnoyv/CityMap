using System.Security.Claims;
using InteractiveMap.Application.Common.Interfaces;

namespace InteractiveMap.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public Guid UserId
        {
            get
            {
                _ = Guid.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out var id);

                return id;
            }
        }
    }
}
