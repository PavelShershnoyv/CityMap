using InteractiveMap.Application.MapLayerService.Types;

namespace InteractiveMap.Application.MapLayerService;

public interface IUserMapLayerService
{
    Task<int> CreateLayerAsync(int userId, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task<MapLayerListDto> GetLayersAsync(int userId, CancellationToken cancellationToken = default);
    Task<MapLayerDto> GetLayerAsync(int userId, int id, CancellationToken cancellationToken = default);
    Task UpdateLayerAsync(int userId, int id, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task DeleteLayerAsync(int userId, int id, CancellationToken cancellationToken = default);
}
