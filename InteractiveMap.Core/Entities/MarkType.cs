using InteractiveMap.Core.Entities.Base;
using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Core.Entities;

public class MarkType : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public Image Image { get; set; }
}
