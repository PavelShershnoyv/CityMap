using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Application.Common.Types;

public class MarkDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Position Position { get; set; }
}
