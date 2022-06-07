using AutoMapper;
using InteractiveMap.Application.Repositories;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Services.MapLayerService;

public class MapLayerService : BaseMapLayerService<MapLayer>, IMapLayerService
{
    public MapLayerService(IMapper mapper, IMapLayerRepository<MapLayer> repository) : base(mapper, repository)
    {
    }
}
