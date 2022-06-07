using Microsoft.AspNetCore.Http;

namespace InteractiveMap.Application.Common.Interfaces;

public interface IBlobStorage
{
    Task<string> SaveAsync(string folderName, IFormFile file, CancellationToken cancellationToken = default);
    void Delete(string filePath);
}
