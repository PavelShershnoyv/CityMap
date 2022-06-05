using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkService.Types;

namespace InteractiveMap.Application.MarkService;

public interface IUserMarkService
{
    Task<int> CreateMarkAsync(Guid userId, MarkRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MarkBaseDto>> GetMarksAsync(Guid userId, int mapLayerId, CancellationToken cancellationToken = default);
    Task<MarkDto> GetMarkAsync(Guid userId, int id, CancellationToken cancellationToken = default);
    Task UpdateMarkAsync(Guid userId, int id, MarkRequest request, CancellationToken cancellationToken = default);
    Task DeleteMarkAsync(Guid userId, int id, CancellationToken cancellationToken = default);
}
