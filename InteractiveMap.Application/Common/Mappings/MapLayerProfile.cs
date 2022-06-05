using AutoMapper;
using InteractiveMap.Application.MapLayerService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Common.Mappings;

public class MapLayerProfile : Profile
{
    public MapLayerProfile()
    {
        CreateMap<MapLayerRequest, MapLayer>();
        CreateMap<MapLayerRequest, UserMapLayer>();

        CreateMap<MapLayer, MapLayerBaseDto>();
        CreateMap<MapLayer, MapLayerDto>();
    }
}
