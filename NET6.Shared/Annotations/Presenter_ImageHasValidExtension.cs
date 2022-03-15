using NET6.Shared.Dtos;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace NET6.Shared.Annotations
{
    public class PresenterPostDto_ImageHasValidExtension : ValidationAttribute
    {
        private readonly List<string> validExtensions = new List<string> { ".png", ".jpg", ".svg" };
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var presenter = validationContext.ObjectInstance as PresenterPostDto;
            if (presenter != null && !string.IsNullOrWhiteSpace(presenter.Image))
            {
                var ext = Path.GetExtension(presenter.Image)?.ToLower();
                if (ext == null || !validExtensions.Contains(ext))
                    return new ValidationResult($"Image has an invalid extension, valid extensions are {string.Join(",", validExtensions)}");
            }

            return ValidationResult.Success;
        }
    }

}
