using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Application.Common.Types;

public class MarkBaseDto
{
    public int Id { get; set; }
    public MarkTypeBaseDto MarkType { get; set; }
    public Position Position { get; set; }
    public string Title { get; set; }
}
