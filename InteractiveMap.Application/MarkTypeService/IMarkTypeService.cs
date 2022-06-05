using InteractiveMap.Application.Common.Types;

namespace InteractiveMap.Application.MarkTypeService.Types;

public interface IMarkTypeService
{
    Task<int> CreateMarkType(MarkTypeRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<MarkTypeBaseDto>> GetMarkTypesAsync(CancellationToken cancellationToken = default);
    Task<MarkTypeDto> GetMarkTypeAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateMarkTypeAsync(int id, MarkTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteMarkTypeAsync(int id, CancellationToken cancellationToken = default);
}
