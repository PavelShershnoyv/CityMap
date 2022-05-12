namespace InteractiveMap.Core.Entities.Base;

public abstract class BaseEntity : IEntity<int>
{
    public int Id { get; set; }
}
