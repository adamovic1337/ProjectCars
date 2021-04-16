using FluentValidation;
using ProjectCars.Model.DTO.Update;

namespace ProjectCars.Service.Validation
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityDto>
    {
        public UpdateCityValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters");

            RuleFor(c => c.CountryId)
                .NotEmpty()
                .WithMessage("CountryId is required parameter");
        }
    }
}