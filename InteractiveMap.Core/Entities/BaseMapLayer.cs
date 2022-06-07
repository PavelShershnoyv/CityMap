using InteractiveMap.Core.Entities.Base;

namespace InteractiveMap.Core.Entities
{
    public class BaseMapLayer : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
