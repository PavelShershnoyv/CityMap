namespace InteractiveMap.Application.MarkService.Types;

public class MarkDto : MarkBaseDto
{
    public ICollection<byte[]> Images { get; set; }
    public string Description { get; set; }
}
