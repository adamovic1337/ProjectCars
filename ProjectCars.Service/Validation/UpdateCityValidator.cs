using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;

namespace ProjectCars.Service.Validation
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityDto>
    {
        public UpdateCityValidator(ProjectCarsContext context)
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