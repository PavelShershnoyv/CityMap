using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkImageService.Types;
using InteractiveMap.Application.Repositories;
using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.Services.MarkService;

public class BaseMarkService<TMark, TMapLayer> : IBaseMarkService<TMark>
    where TMark : BaseMark
    where TMapLayer : BaseMapLayer
{
    protected readonly IMapper _mapper;
    protected readonly IMarkRepository<TMark> _repository;
    protected readonly IMarkImageRepository _imageRepository;
    protected readonly IMapLayerRepository<TMapLayer> _layerRepository;
    protected readonly IBlobStorage _blobStorage;

    public BaseMarkService(
        IMapper mapper,
        IMarkRepository<TMark> repository,
        IMarkImageRepository imageRepository,
        IMapLayerRepository<TMapLayer> layerRepository,
        IBlobStorage blobService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
        _layerRepository = layerRepository ?? throw new ArgumentNullException(nameof(layerRepository));
        _blobStorage = blobService ?? throw new ArgumentNullException(nameof(blobService));
    }

    public async Task<int> CreateAsync(MarkRequest request, CancellationToken cancellationToken = default)
    {
        var layer = await _layerRepository.GetByIdAsync(request.MapLayerId, cancellationToken);

        if (layer == null)
        {
            throw new NotFoundException(nameof(MapLayer), request.MapLayerId);
        }

        var entity = _mapper.Map<TMark>(request);

        await _repository.CreateAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<IEnumerable<MarkBaseDto>> GetAllAsync(int mapLayerId, CancellationToken cancellationToken = default)
    {
        return await _repository
            .GetAll(mark => mark.MapLayerId == mapLayerId)
            .ProjectTo<MarkBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<MarkDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Mark), id);
        }

        return _mapper.Map<MarkDto>(entity);
    }

    public async Task UpdateAsync(int id, UpdateMarkRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TMark>(request);

        _repository.Update(entity);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<string> AddImageAsync(int id, ImageRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<MarkImage>(request);
        entity.MarkId = id;

        var imageUrl = await _blobStorage.SaveAsync("images", request.File, cancellationToken);
        entity.Url = imageUrl;
        var image = await _imageRepository.CreateAsync(entity, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return image.Url;
    }

    public async Task DeleteImageAsync(int id, int imageId, CancellationToken cancellationToken = default)
    {
        var entity = await _imageRepository.GetByIdAsync(imageId, cancellationToken);

        if (entity == null || entity.MarkId != id)
        {
            throw new NotFoundException(nameof(MarkImage), id);
        }

        _imageRepository.Delete(entity);
        await _imageRepository.SaveChangesAsync(cancellationToken);
        _blobStorage.Delete(entity.Url);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    
}
