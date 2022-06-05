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
    private readonly IMapContext _context;
    private readonly IMapper _mapper;

    public UserMapLayerService(IMapContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> CreateLayerAsync(Guid userId, MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<UserMapLayer>(request);
        entity.UserId = userId;

        await _context.UserMapLayers.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<IEnumerable<MapLayerBaseDto>> GetLayersAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.UserMapLayers
            .Where(layer => layer.UserId == userId)
            .ProjectTo<MapLayerBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<MapLayerDto> GetLayerAsync(Guid userId, int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMapLayers
            .Include(layer => layer.Marks)
            .FirstOrDefaultAsync(layer => layer.Id == id, cancellationToken);

        if (entity == null || entity.UserId != userId)
        {
            throw new NotFoundException(nameof(UserMapLayer), id);
        }

        return _mapper.Map<MapLayerDto>(entity);
    }

    public async Task UpdateLayerAsync(Guid userId, int id, MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMapLayers.FirstOrDefaultAsync(layer => layer.Id == id, cancellationToken);

        if (entity == null || entity.UserId != userId)
        {
            throw new NotFoundException(nameof(UserMapLayer), id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteLayerAsync(Guid userId, int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.UserMapLayers.FirstOrDefaultAsync(layer => layer.Id == id, cancellationToken);

        if (entity == null || entity.UserId != userId)
        {
            throw new NotFoundException(nameof(UserMapLayer), id);
        }

        _context.UserMapLayers.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
