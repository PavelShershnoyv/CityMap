using InteractiveMap.Core.Entities.Base;

namespace InteractiveMap.Core.Entities;

public class MarkType : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Color { get; set; }
}
