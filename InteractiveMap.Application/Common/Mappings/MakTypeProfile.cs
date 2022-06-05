using AutoMapper;
using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkTypeService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Common.Mappings;

public class MakTypeProfile : Profile
{
    public MakTypeProfile()
    {
        CreateMap<MarkTypeRequest, MarkType>();

        CreateMap<MarkType, MarkTypeBaseDto>();
        CreateMap<MarkType, MarkTypeDto>();
    }
}
