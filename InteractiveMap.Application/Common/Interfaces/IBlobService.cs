using Microsoft.AspNetCore.Http;

namespace InteractiveMap.Application.Common.Interfaces;

public interface IBlobService
{
    Task<string> SaveAsync(string path, IFormFile content, CancellationToken cancellationToken = default);
    void Delete(string filePath);
}
