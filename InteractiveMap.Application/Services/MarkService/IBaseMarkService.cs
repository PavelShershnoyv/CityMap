using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.Services.MarkService.Types;
using InteractiveMap.Core.Entities;
using InteractiveMap.Core.Enums;

namespace InteractiveMap.Application.Services.MarkService;

public interface IBaseMarkService<TMark>
    where TMark : BaseMark
{
    Task<int> CreateAsync(MarkRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MarkBaseDto>> GetAllAsync(LayerType layer, CancellationToken cancellationToken = default);
    Task<MarkDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, MarkRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
