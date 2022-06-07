using FluentValidation;
using InteractiveMap.Application.MarkImageService.Types;

namespace InteractiveMap.Application.ImageService.Validations;

public class ImageValidator : AbstractValidator<ImageRequest>
{
    public ImageValidator()
    {
        RuleFor(request => request.File).NotEmpty().Must(file =>
        {
            var extension = file.FileName.Split(".").LastOrDefault();

            if (extension == null) return false;

            return new[] { "jpg", "png", "svg", "webp" }.Contains(extension);
        });
    }
}
