using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Repositories;
using InteractiveMap.Application.Services.MapLayerService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.Services.MapLayerService;

public class UserMapLayerService : BaseMapLayerService<UserMapLayer>, IUserMapLayerService
{
    public UserMapLayerService(IMapper mapper, IMapLayerRepository<UserMapLayer> repository) : base(mapper, repository)
    {
    }

    public async Task<int> CreateAsync(Guid userId, MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<UserMapLayer>(request);
        entity.UserId = userId;

        await _repository.CreateAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<IEnumerable<MapLayerBaseDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _repository
            .GetAll(layer => layer.UserId == userId)
            .ProjectTo<MapLayerBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

}
