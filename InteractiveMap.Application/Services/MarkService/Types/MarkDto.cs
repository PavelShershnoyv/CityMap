using InteractiveMap.Application.Common.Types;

namespace InteractiveMap.Application.Services.MarkService.Types;

public class MarkDto : MarkBaseDto
{
    public ICollection<ImageDto> Images { get; set; }
    public string Description { get; set; }
}
