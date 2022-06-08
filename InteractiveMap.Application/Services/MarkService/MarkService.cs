using AutoMapper;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Services.MarkService;

public class MarkService : BaseMarkService<Mark>, IBaseMarkService<Mark>
{
    public MarkService(
        IMapper mapper,
        IMapContext context,
        ICurrentUserService currentUserService,
        IUserScope<Mark> userScopeService,
        IBlobStorage blobService) : base(mapper, context, currentUserService, userScopeService, blobService)
    {
    }
}
