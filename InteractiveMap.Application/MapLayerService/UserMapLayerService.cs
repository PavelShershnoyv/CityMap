using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.MapLayerService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.MapLayerService;

public class UserMapLayerService : IUserMapLayerService
{
    private readonly IMapsDbContext _context;
    private readonly IMapper _mapper;

    public UserMapLayerService(IMapsDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> CreateLayerAsync(int userId, MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<UserMapLayer>(request);

        await _context.UserMapLayers.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<MapLayerListDto> GetLayersAsync(int userId, CancellationToken cancellationToken = default)
    {
        var layers = await _context.UserMapLayers
            .Where(layer => layer.UserId == userId)
            .ProjectTo<MapLayerBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new MapLayerListDto { MapLayers = layers };
    }

    public async Task<MapLayerDto> GetLayerAsync(int userId, int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMapLayers
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Id == id && layer.UserId == userId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserMapLayer), id);
        }

        return _mapper.Map<MapLayerDto>(entity);
    }


    public async Task UpdateLayerAsync(int userId, int id, MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMapLayers
        .FirstOrDefaultAsync(layer => layer.Id == id && layer.UserId == userId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserMapLayer), id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteLayerAsync(int userId, int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMapLayers
        .FirstOrDefaultAsync(layer => layer.Id == id && layer.UserId == userId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(UserMapLayer), id);
        }

        _context.UserMapLayers.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
