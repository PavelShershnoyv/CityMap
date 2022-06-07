using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Repositories;
using InteractiveMap.Application.Services.MapLayerService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.Services.MapLayerService;

public class BaseMapLayerService<TMapLayer> : IBaseMapLayerService<TMapLayer> where TMapLayer : BaseMapLayer
{
    protected readonly IMapper _mapper;
    protected readonly IMapLayerRepository<TMapLayer> _repository;

    public BaseMapLayerService(IMapper mapper, IMapLayerRepository<TMapLayer> repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<int> CreateAsync(MapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TMapLayer>(request);

        await _repository.CreateAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<IEnumerable<MapLayerBaseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAll()
            .ProjectTo<MapLayerBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<MapLayerDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(MapLayer), id);
        }

        return _mapper.Map<MapLayerDto>(entity);
    }

    public async Task UpdateAsync(int id, UpdateMapLayerRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TMapLayer>(request);

        _repository.Update(entity);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}

