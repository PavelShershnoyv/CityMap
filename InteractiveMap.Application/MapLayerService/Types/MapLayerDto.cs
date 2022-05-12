using InteractiveMap.Application.Common.Types;

namespace InteractiveMap.Application.MapLayerService.Types;

public class MapLayerDto : MapLayerBaseDto
{
    public ICollection<MarkDto> Marks { get; set; }
}
