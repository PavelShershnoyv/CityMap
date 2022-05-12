using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.MapLayerService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.MapLayerService;

public class PublicMapLayerService : IPublicMapLayerService
{
    private readonly IMapsDbContext _context;
    private readonly IMapper _mapper;

    public PublicMapLayerService(IMapsDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> CreateLayerAsync(MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<MapLayer>(request);

        await _context.PublicMapLayers.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<MapLayerListDto> GetLayersAsync(CancellationToken cancellationToken = default)
    {
        var layers = await _context.PublicMapLayers
            .ProjectTo<MapLayerBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new MapLayerListDto { MapLayers = layers };
    }

    public async Task<MapLayerDto> GetLayerAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.PublicMapLayers
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(MapLayer), id);
        }

        return _mapper.Map<MapLayerDto>(entity);
    }

    public async Task UpdateLayerAsync(int id, MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMapLayers
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
