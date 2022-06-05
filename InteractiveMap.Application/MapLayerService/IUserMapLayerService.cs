using InteractiveMap.Application.MapLayerService.Types;

namespace InteractiveMap.Application.MapLayerService;

public interface IUserMapLayerService
{
    Task<int> CreateLayerAsync(Guid userId, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MapLayerBaseDto>> GetLayersAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<MapLayerDto> GetLayerAsync(Guid userId, int id, CancellationToken cancellationToken = default);
    Task UpdateLayerAsync(Guid userId, int id, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task DeleteLayerAsync(Guid userId, int id, CancellationToken cancellationToken = default);
}
