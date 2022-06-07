using AutoMapper;
using InteractiveMap.Application.Services.MapLayerService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Common.Mappings;

public class MapLayerProfile : Profile
{
    public MapLayerProfile()
    {
        CreateMap<MapLayerRequest, MapLayer>();
        CreateMap<UpdateMapLayerRequest, MapLayer>();

        CreateMap<MapLayerRequest, UserMapLayer>();
        CreateMap<UpdateMapLayerRequest, UserMapLayer>();

        CreateMap<MapLayer, MapLayerBaseDto>();
        CreateMap<MapLayer, MapLayerDto>();

        CreateMap<UserMapLayer, MapLayerBaseDto>();
        CreateMap<UserMapLayer, MapLayerDto>();
    }
}
