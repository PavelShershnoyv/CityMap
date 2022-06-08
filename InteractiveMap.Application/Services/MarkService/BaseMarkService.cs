using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;
using InteractiveMap.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.Services.MarkService;

public abstract class BaseMarkService<TMark> : IBaseMarkService<TMark>
    where TMark : BaseMark
{
    protected readonly IMapper _mapper;
    protected readonly IMapContext _context;
    protected readonly ICurrentUserService _currentUserService;
    protected readonly IUserScope<TMark> _userScopeService;
    protected readonly IBlobStorage _blobStorage;

    public BaseMarkService(
        IMapper mapper,
        IMapContext context,
        ICurrentUserService currentUserService,
        IUserScope<TMark> userScopeService,
        IBlobStorage blobService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        _userScopeService = userScopeService ?? throw new ArgumentNullException(nameof(userScopeService));
        _blobStorage = blobService ?? throw new ArgumentNullException(nameof(blobService));
    }

    public virtual async Task<int> CreateAsync(MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TMark>(request);

        await _context.Set<TMark>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public virtual async Task<IEnumerable<MarkBaseDto>> GetAllAsync(LayerType layer, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TMark>()
            .AsNoTracking()
            .Where(mark => mark.LayerType == layer)
            .ProjectTo<MarkBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<MarkDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<TMark>().FindAsync(new object[] { id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TMark), id);
        }

        var userId = _currentUserService.UserId;
        var canUserWrite = await _userScopeService.CanUserReadAsync(userId, entity);

        if (!canUserWrite)
        {
            throw new ForbiddenException(userId.ToString(), nameof(TMark), id);
        }

        return _mapper.Map<MarkDto>(entity);
    }

    public async Task UpdateAsync(int id, MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<TMark>().FindAsync(new object[] { id }, cancellationToken);

        var userId = _currentUserService.UserId;
        var canUserWrite = await _userScopeService.CanUserWriteAsync(userId, entity);

        if (!canUserWrite)
        {
            throw new ForbiddenException(userId.ToString(), nameof(TMark), id);
        }

        entity.LayerType = request.LayerType;
        entity.Type = request.Type;
        entity.Position = request.Position;
        entity.Title = request.Title;
        entity.Description = request.Description;

        _context.Set<TMark>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var marks = _context.Set<TMark>();
        var entity = await marks.FindAsync(new object[] { id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TMark), id);
        }

        var userId = _currentUserService.UserId;
        var canUserWrite = await _userScopeService.CanUserWriteAsync(userId, entity);

        if (!canUserWrite)
        {
            throw new ForbiddenException(userId.ToString(), nameof(TMark), id);
        }

        marks.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
