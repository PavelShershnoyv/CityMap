using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;
using InteractiveMap.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.Services.MarkService;

public class UserMarkService : BaseMarkService<UserMark>, IBaseMarkService<UserMark>
{
    public UserMarkService(
        IMapper mapper,
        IMapContext context,
        ICurrentUserService currentUserService,
        IUserScope<UserMark> userScopeService,
        IBlobStorage blobService) : base(mapper, context, currentUserService, userScopeService, blobService)
    {
    }

    public override async Task<int> CreateAsync(MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<UserMark>(request);
        entity.UserId = _currentUserService.UserId;

        await _context.UserMarks.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public override async Task<IEnumerable<MarkBaseDto>> GetAllAsync(LayerType layerType, CancellationToken cancellationToken = default)
    {
        var userId = _currentUserService.UserId;

        return await _context.UserMarks
            .AsNoTracking()
            .Where(mark => mark.UserId == userId && mark.LayerType == layerType)
            .ProjectTo<MarkBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
