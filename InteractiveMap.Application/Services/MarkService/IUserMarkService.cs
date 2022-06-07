using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Services.MarkService;

public interface IUserMarkService : IBaseMarkService<UserMark>
{
    Task<int> CreateAsync(Guid userId, MarkRequest request, CancellationToken cancellationToken = default);
}
