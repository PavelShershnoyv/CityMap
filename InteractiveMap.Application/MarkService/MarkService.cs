using AutoMapper;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.MarkService;

public class MarkService : IMarkService
{
    private readonly IMapContext _context;
    private readonly IMapper _mapper;

    public MarkService(IMapContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> CreateMarkAsync(MarkRequest request, CancellationToken cancellationToken = default)
    {
        var layer = await _context.PublicMapLayers.FirstOrDefaultAsync(layer => layer.Id == request.MapLayerId, cancellationToken);

        if (layer == null)
        {
            throw new NotFoundException(nameof(MapLayer), request.MapLayerId);
        }

        var entity = _mapper.Map<Mark>(request);

        await _context.PublicMarks.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<IEnumerable<MarkBaseDto>> GetMarksAsync(int mapLayerId, CancellationToken cancellationToken = default)
    {
        var layer = await _context.PublicMapLayers
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Id == mapLayerId, cancellationToken);

        if (layer == null)
        {
            throw new NotFoundException(nameof(MapLayer), mapLayerId);
        }

        return layer.Marks.Select(_mapper.Map<MarkBaseDto>).ToList();
    }

    public async Task<MarkDto> GetMarkAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMarks
             .Include(entity => entity.Details)
             .ThenInclude(details => details.Images)
             .FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        return _mapper.Map<MarkDto>(entity);
    }

    public async Task UpdateMarkAsync(int id, MarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMarks.FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

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
        var entity = await _context.PublicMarks.FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        _context.PublicMarks.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
