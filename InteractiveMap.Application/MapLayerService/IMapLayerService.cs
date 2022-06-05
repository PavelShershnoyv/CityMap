using InteractiveMap.Application.MapLayerService.Types;

namespace InteractiveMap.Application.MapLayerService;

public interface IMapLayerService
{
    Task<string> CreateLayerAsync(MapLayerRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MapLayerBaseDto>> GetLayersAsync(CancellationToken cancellationToken = default);
    Task<MapLayerDto> GetLayerAsync(string title, CancellationToken cancellationToken = default);
    Task UpdateLayerAsync(int id, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task DeleteLayerAsync(int id, CancellationToken cancellationToken = default);
}
