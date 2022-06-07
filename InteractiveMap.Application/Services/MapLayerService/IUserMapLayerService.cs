using InteractiveMap.Application.Services.MapLayerService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Services.MapLayerService;

public interface IUserMapLayerService : IBaseMapLayerService<UserMapLayer>
{
    Task<int> CreateAsync(Guid userId, MapLayerRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MapLayerBaseDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);
}
