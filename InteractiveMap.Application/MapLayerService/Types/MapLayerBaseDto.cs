namespace InteractiveMap.Application.MapLayerService.Types;

public class MapLayerBaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
}
