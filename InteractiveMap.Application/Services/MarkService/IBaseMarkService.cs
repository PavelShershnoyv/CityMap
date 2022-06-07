using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkImageService.Types;
using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Services.MarkService;

public interface IBaseMarkService<TMark> where TMark : BaseMark
{
    Task<int> CreateAsync(MarkRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MarkBaseDto>> GetAllAsync(int mapLayerId, CancellationToken cancellationToken = default);
    Task<MarkDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, UpdateMarkRequest request, CancellationToken cancellationToken = default);
    Task<string> AddImageAsync(int id, ImageRequest request, CancellationToken cancellationToken = default);
    Task DeleteImageAsync(int id, int imageId, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
