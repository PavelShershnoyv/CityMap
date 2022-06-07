using AutoMapper;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Repositories;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Services.MarkService;

public class MarkService : BaseMarkService<Mark, MapLayer>, IMarkService
{
    public MarkService(
        IMapper mapper,
        IMarkRepository<Mark> repository,
        IMarkImageRepository imageRepository,
        IMapLayerRepository<MapLayer> layerRepository, 
        IBlobStorage blobService) : base(mapper, repository, imageRepository, layerRepository, blobService)
    {
    }
}
