using AutoMapper;
using InteractiveMap.Application.MapLayerService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Common.Mappings;

public class MapsProfile : Profile
{
    public MapsProfile()
    {
        CreateMap<MapLayerRequest, MapLayer>();
        CreateMap<MapLayerRequest, UserMapLayer>();

        CreateMap<MapLayer, MapLayerBaseDto>();
        CreateMap<MapLayer, MapLayerDto>();
    }
}
