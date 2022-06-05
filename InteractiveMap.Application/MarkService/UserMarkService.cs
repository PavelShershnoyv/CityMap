using AutoMapper;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.MarkService;

public class UserMarkService : IUserMarkService
{
    private readonly IMapContext _context;
    private readonly IMapper _mapper;

    public UserMarkService(IMapContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> CreateMarkAsync(Guid userId, MarkRequest request, CancellationToken cancellationToken = default)
    {
        var layer = await _context.UserMapLayers.FirstOrDefaultAsync(layer => layer.Id == request.MapLayerId, cancellationToken);

        if (layer == null || layer.UserId != userId)
        {
            throw new NotFoundException(nameof(UserMapLayer), request.MapLayerId);
        }

        var entity = _mapper.Map<UserMark>(request);
        entity.UserId = userId;

        await _context.UserMarks.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<IEnumerable<MarkBaseDto>> GetMarksAsync(Guid userId, int mapLayerId, CancellationToken cancellationToken = default)
    {
        var layer = await _context.UserMapLayers
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Id == mapLayerId, cancellationToken);

        if (layer == null || layer.UserId != userId)
        {
            throw new NotFoundException(nameof(UserMapLayer), mapLayerId);
        }

        return layer.Marks.Select(_mapper.Map<MarkBaseDto>).ToList();
    }

    public async Task<MarkDto> GetMarkAsync(Guid userId, int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMarks
            .Include(entity => entity.Details)
            .FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

        if (entity == null || entity.UserId == userId)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        return _mapper.Map<MarkDto>(entity);
    }

    public async Task UpdateMarkAsync(Guid userId, int id, MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMarks
            .FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

        if (entity == null || entity.UserId != userId)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        entity.Position = request.Position;
        entity.Title = request.Title;
        entity.Details.Description = request.Description;
        entity.Details.Images = request.Images;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteMarkAsync(Guid userId, int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMarks
            .FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

        if (entity == null || entity.UserId != userId)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        _context.UserMarks.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

}
