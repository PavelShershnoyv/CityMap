using InteractiveMap.Application.MapLayerService.Types;

namespace InteractiveMap.Application.MapLayerService;

public interface IUserMapLayerService
{
    Task<int> CreateLayerAsync(string userId, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task<MapLayerListDto> GetLayersAsync(string userId, CancellationToken cancellationToken = default);
    Task<MapLayerDto> GetLayerAsync(string userId, int id, CancellationToken cancellationToken = default);
    Task UpdateLayerAsync(string userId, int id, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task DeleteLayerAsync(string userId, int id, CancellationToken cancellationToken = default);
}
