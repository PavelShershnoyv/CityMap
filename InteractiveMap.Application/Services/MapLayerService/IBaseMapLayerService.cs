using InteractiveMap.Application.Services.MapLayerService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Services.MapLayerService;

public interface IBaseMapLayerService<TMapLayer> where TMapLayer : BaseMapLayer
{
    Task<int> CreateAsync(MapLayerRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MapLayerBaseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<MapLayerDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, UpdateMapLayerRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
