using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.MapLayerService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using ApplicationException = InteractiveMap.Application.Common.Exceptions.ApplicationException;

namespace InteractiveMap.Application.MapLayerService;

public class MapLayerService : IMapLayerService
{
    private readonly IMapContext _context;
    private readonly IMapper _mapper;

    public MapLayerService(IMapContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<string> CreateLayerAsync(MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _context.PublicMapLayers
            .FirstOrDefaultAsync(layer => layer.Title == request.Title, cancellationToken);

        if (existingEntity != null)
        {
            throw new ApplicationException($"{nameof(MapLayer)} {request.Title} already exists.");
        }

        var entity = _mapper.Map<MapLayer>(request);


        await _context.PublicMapLayers.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync();

        return entity.Title;
    }

    public async Task<IEnumerable<MapLayerBaseDto>> GetLayersAsync(CancellationToken cancellationToken = default)
    {
        return await _context.PublicMapLayers
            .ProjectTo<MapLayerBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<MapLayerDto> GetLayerAsync(string title, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMapLayers
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Title == title, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(MapLayer), title);
        }

        return _mapper.Map<MapLayerDto>(entity);
    }

    public async Task UpdateLayerAsync(int id, MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMapLayers
            .FirstOrDefaultAsync(layer => layer.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(MapLayer), id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteLayerAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMapLayers
            .FirstOrDefaultAsync(layer => layer.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(MapLayer), id);
        }

        _context.PublicMapLayers.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
