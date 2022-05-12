using InteractiveMap.Core.Entities.Base;
using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Core.Entities;

public class Mark : BaseEntity
{
    public Position Position { get; set; }
    public string Title { get; set; }
    public MarkDetails Details { get; set; }
    public int MapLayerId { get; set; }
}
