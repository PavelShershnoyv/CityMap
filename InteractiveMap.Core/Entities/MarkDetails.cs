namespace InteractiveMap.Core.Entities;

public class MarkDetails
{
    public string Description { get; set; } = string.Empty;
    public ICollection<byte[]> Images { get; set; }
    public int MarkId { get; set; }
}
