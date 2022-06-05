using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkService.Types;

namespace InteractiveMap.Application.MarkService;

public interface IMarkService
{
    Task<int> CreateMarkAsync(MarkRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MarkBaseDto>> GetMarksAsync(int mapLayerId, CancellationToken cancellationToken = default);
    Task<MarkDto> GetMarkAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateMarkAsync(int id, MarkRequest request, CancellationToken cancellationToken = default);
    Task DeleteMarkAsync(int id, CancellationToken cancellationToken = default);
}
