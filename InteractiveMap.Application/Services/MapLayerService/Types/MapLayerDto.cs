using InteractiveMap.Application.Common.Types;

namespace InteractiveMap.Application.Services.MapLayerService.Types;

public class MapLayerDto : MapLayerBaseDto
{
    public ICollection<MarkBaseDto> Marks { get; set; }
}
