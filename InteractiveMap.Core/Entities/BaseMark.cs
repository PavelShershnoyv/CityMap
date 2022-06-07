using InteractiveMap.Core.Entities.Base;
using InteractiveMap.Core.Enums;
using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Core.Entities;

public class BaseMark : BaseEntity
{
    public MarkType Type { get; set; }
    public Position Position { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<MarkImage> Images { get; set; }
    public int MapLayerId { get; set; }
}
