using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Infrastructure.Identity.Services.UserScopes;

public class UserMarkScope : IUserScope<UserMark>
{
    public Task<bool> CanUserReadAsync(Guid userId, UserMark entity)
    {
        return Task.FromResult(entity.UserId == userId);
    }

    public Task<bool> CanUserWriteAsync(Guid userId, UserMark entity)
    {
        return Task.FromResult(entity.UserId == userId);
    }
}
