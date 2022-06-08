using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Core.Entities;
using InteractiveMap.Infrastructure.Identity.Defaults;
using Microsoft.AspNetCore.Identity;

namespace InteractiveMap.Infrastructure.Identity.Services.UserScopes
{
    public class MarkScope : IUserScope<Mark>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MarkScope(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public Task<bool> CanUserReadAsync(Guid userId, Mark entity) => Task.FromResult(true);

        public async Task<bool> CanUserWriteAsync(Guid userId, Mark entity)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return await _userManager.IsInRoleAsync(user, RoleDefaults.Admin);
        }
    }
}
