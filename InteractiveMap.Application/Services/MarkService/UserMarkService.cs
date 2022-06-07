using AutoMapper;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Repositories;
using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Services.MarkService;

public class UserMarkService : BaseMarkService<UserMark, UserMapLayer>, IUserMarkService
{
    public UserMarkService(
        IMapper mapper,
        IMarkRepository<UserMark> repository,
        IMarkImageRepository imageRepository,
        IMapLayerRepository<UserMapLayer> layerRepository,
        IBlobStorage blobService) : base(mapper, repository, imageRepository, layerRepository, blobService)
    {
    }

    public async Task<int> CreateAsync(Guid userId, MarkRequest request, CancellationToken cancellationToken = default)

    {
        var layer = await _layerRepository.GetByIdAsync(request.MapLayerId, cancellationToken);

        if (layer == null)
        {
            throw new NotFoundException(nameof(MapLayer), request.MapLayerId);
        }

        var entity = _mapper.Map<UserMark>(request);
        entity.UserId = userId;

        await _repository.CreateAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
