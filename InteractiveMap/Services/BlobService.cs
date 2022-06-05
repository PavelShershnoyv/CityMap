using InteractiveMap.Application.Common.Interfaces;

namespace InteractiveMap.Web.Services;

public class BlobService : IBlobService
{
    public async Task<string> SaveAsync(string path, IFormFile file, CancellationToken cancellationToken = default)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(path, fileName);

        using var fileStream = new FileStream(filePath, FileMode.CreateNew);

        await file.CopyToAsync(fileStream, cancellationToken);

        return filePath;
    }

    public void Delete(string filePath)
    {
        if (!File.Exists(filePath)) return;

        File.Delete(filePath);
    }

}