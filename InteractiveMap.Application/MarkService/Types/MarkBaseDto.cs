using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Application.MarkService.Types;

public class MarkBaseDto
{
    public int Id { get; set; }
    public Position Position { get; set; }
    public string Title { get; set; }
}
