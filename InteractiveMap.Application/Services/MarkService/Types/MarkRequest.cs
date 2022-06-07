using InteractiveMap.Core.Enums;
using InteractiveMap.Core.ValueObjects;

namespace InteractiveMap.Application.Services.MarkService.Types;

public class MarkRequest
{
    public MarkType Type { get; set; }
    public Position Position { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int MapLayerId { get; set; }
}
