using InteractiveMap.Core.Entities.Base;
using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Core.Entities;

public class MarkDetails : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public ICollection<Image> Images { get; set; }
    public int MarkId { get; set; }
}
