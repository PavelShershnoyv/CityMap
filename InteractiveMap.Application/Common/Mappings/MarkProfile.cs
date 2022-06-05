using AutoMapper;
using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Common.Mappings;

public class MarkProfile : Profile
{
    public MarkProfile()
    {
        CreateMap<MarkRequest, Mark>();
        CreateMap<MarkRequest, UserMark>();

        CreateMap<Mark, MarkBaseDto>();
        CreateMap<Mark, MarkDto>();
    }
}
