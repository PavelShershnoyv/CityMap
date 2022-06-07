using Microsoft.AspNetCore.Http;

namespace InteractiveMap.Application.MarkImageService.Types
{
    public class ImageRequest
    {
        public IFormFile File { get; set; }
    }
}
