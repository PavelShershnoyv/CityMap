using InteractiveMap.Application.Common.Interfaces;

namespace InteractiveMap.Web.Services;

public class BlobStorage : IBlobStorage
{
    private readonly IWebHostEnvironment _environment;

    public BlobStorage(IWebHostEnvironment environment)
    {
        _environment = environment ?? throw new ArgumentNullException(nameof(environment));
    }

    public async Task<string> SaveAsync(string folderName, IFormFile file, CancellationToken cancellationToken = default)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var rootPath = _environment.WebRootPath ?? _environment.ContentRootPath;
        var directoryPath = Path.Combine(
                                rootPath,
                                "uploads",
                                folderName,
                                DateTime.Now.Year.ToString(),
                                DateTime.Now.Month.ToString());

        Directory.CreateDirectory(directoryPath);
        var filePath = Path.Combine(directoryPath, fileName);
        using var fileStream = new FileStream(filePath, FileMode.Create);

        await file.CopyToAsync(fileStream, cancellationToken);

        return filePath;
    }

    public void Delete(string filePath)
    {
        if (!File.Exists(filePath)) return;

        File.Delete(filePath);
    }
}