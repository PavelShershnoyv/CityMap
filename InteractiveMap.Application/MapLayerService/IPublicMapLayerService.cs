using InteractiveMap.Application.MapLayerService.Types;

namespace InteractiveMap.Application.MapLayerService;

public interface IPublicMapLayerService
{
    Task<int> CreateLayerAsync(MapLayerRequest request, CancellationToken cancellationToken = default);
    Task<MapLayerListDto> GetLayersAsync(CancellationToken cancellationToken = default);
    Task<MapLayerDto> GetLayerAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateLayerAsync(int id, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task DeleteLayerAsync(int id, CancellationToken cancellationToken = default);
}
