using AutoMapper;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.MarkService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.MarkService;

public class UserMarkService : IUserMarkService
{
    private readonly IMapsDbContext _context;
    private readonly IMapper _mapper;

    public UserMarkService(IMapsDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> CreateMarkAsync(int userId, MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = new UserMark
        {
            UserId = userId,
            Position = request.Position,
            Title = request.Title,
            MapLayerId = request.MapLayerId,
            Details = new MarkDetails
            {
                Description = request.Description,
                Images = request.Images
            }
        };

        await _context.UserMarks.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<MarkListDto> GetMarksAsync(int userId, int mapLayerId, CancellationToken cancellationToken = default)
    {
        var layer = await _context.UserMapLayers
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Id == mapLayerId && layer.UserId == userId, cancellationToken);

        if (layer == null)
        {
            throw new NotFoundException(nameof(UserMapLayer), mapLayerId);
        }

        var entities = layer.Marks.Select(_mapper.Map<MarkBaseDto>).ToList();

        return new MarkListDto { Marks = entities };
    }

    public async Task<MarkDto> GetMarkAsync(int userId, int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMarks
            .Include(entity => entity.Details)
            .FirstOrDefaultAsync(mark => mark.Id == id && mark.UserId == userId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        return new MarkDto
        {
            Id = entity.Id,
            Position = entity.Position,
            Title = entity.Title,
            Description = entity.Details.Description,
            Images = entity.Details.Images
        };
    }

    public async Task UpdateMarkAsync(int userId, int id, MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMarks
            .FirstOrDefaultAsync(mark => mark.Id == id && mark.UserId == userId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        entity.Position = request.Position;
        entity.Title = request.Title;
        entity.Details.Description = request.Description;
        entity.Details.Images = request.Images;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteMarkAsync(int userId, int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMarks
            .FirstOrDefaultAsync(mark => mark.Id == id && mark.UserId == userId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        _context.UserMarks.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
