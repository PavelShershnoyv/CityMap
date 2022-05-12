using AutoMapper;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.MarkService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.MarkService;

public class PublicMarkService : IPublicMarkService
{
    private readonly IMapsDbContext _context;
    private readonly IMapper _mapper;

    public PublicMarkService(IMapsDbContext context, IMapper mapper)
    {

        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> CreateMarkAsync(MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = new Mark
        {
            Position = request.Position,
            Title = request.Title,
            MapLayerId = request.MapLayerId,
            Details = new MarkDetails
            {
                Description = request.Description,
                Images = request.Images
            }
        };

        await _context.PublicMarks.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<MarkListDto> GetMarksAsync(int mapLayerId, CancellationToken cancellationToken = default)
    {
        var layer = await _context.PublicMapLayers
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Id == mapLayerId, cancellationToken);

        if (layer == null)
        {
            throw new NotFoundException(nameof(MapLayer), mapLayerId);
        }

        var entities = layer.Marks.Select(_mapper.Map<MarkBaseDto>).ToList();

        return new MarkListDto { Marks = entities };
    }

    public async Task<MarkDto> GetMarkAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMarks
             .Include(entity => entity.Details)
             .FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

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

    public async Task UpdateMarkAsync(int id, MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMarks
            .FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

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

    public async Task DeleteMarkAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMarks
           .FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        _context.PublicMarks.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
