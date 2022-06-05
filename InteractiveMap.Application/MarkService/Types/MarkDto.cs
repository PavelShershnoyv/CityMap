using InteractiveMap.Application.Common.Types;
using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Application.MarkService.Types;

public class MarkDto : MarkBaseDto
{
    public ICollection<Image> Images { get; set; }
    public string Description { get; set; }
}
