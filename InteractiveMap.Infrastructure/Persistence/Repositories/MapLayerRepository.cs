using InteractiveMap.Application.Repositories;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Infrastructure.Persistence.Repositories;

public class MapLayerRepository<TMapLayer> : BaseRepository<TMapLayer>, IMapLayerRepository<TMapLayer>
    where TMapLayer : BaseMapLayer
{
    public MapLayerRepository(MapContext context) : base(context) { }

    public override async Task<TMapLayer> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _set
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Id == id, cancellationToken);
    }
}
