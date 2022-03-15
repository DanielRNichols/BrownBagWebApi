using NET6.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6.Shared.Annotations
{
    public class Presenter_ImageNameContainsPresenterName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var presenter = validationContext.ObjectInstance as PresenterPostDto;
            if (presenter != null && !String.IsNullOrWhiteSpace(presenter.Name) && !string.IsNullOrWhiteSpace(presenter.Image))
            {
                var lowerImage = presenter.Image.ToLower();

                if (lowerImage.Contains(presenter.Name.ToLower()) ||
                    lowerImage.Contains(presenter.Name.Replace(" ", "_").ToLower()) ||
                    lowerImage.Contains(presenter.Name.ToLower().Replace(" ", ""))
                   )
                    return ValidationResult.Success;

                return new ValidationResult("Image name must include the presenter's name");
            }

            return ValidationResult.Success;
        }
    }
}
