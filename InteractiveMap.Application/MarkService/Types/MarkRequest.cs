using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Application.MarkService.Types;

public class MarkRequest
{
    public Position Position { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<byte[]> Images { get; set; }
    public int MapLayerId { get; set; }
}
