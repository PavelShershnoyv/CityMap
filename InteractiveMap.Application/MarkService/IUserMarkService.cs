using InteractiveMap.Application.MarkService.Types;

namespace InteractiveMap.Application.MarkService;

public interface IUserMarkService
{
    Task<int> CreateMarkAsync(int userId, MarkRequest request, CancellationToken cancellationToken = default);
    Task<MarkListDto> GetMarksAsync(int userId, int mapLayerId, CancellationToken cancellationToken = default);
    Task<MarkDto> GetMarkAsync(int userId, int id, CancellationToken cancellationToken = default);
    Task UpdateMarkAsync(int userId, int id, MarkRequest request, CancellationToken cancellationToken = default);
    Task DeleteMarkAsync(int userId, int id, CancellationToken cancellationToken = default);
}
