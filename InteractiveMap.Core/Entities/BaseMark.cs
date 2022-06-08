using InteractiveMap.Core.Entities.Base;
using InteractiveMap.Core.Enums;
using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Core.Entities;

public abstract class BaseMark : BaseEntity
{
    public LayerType LayerType { get; set; }
    public MarkType Type { get; set; }
    public Position Position { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
