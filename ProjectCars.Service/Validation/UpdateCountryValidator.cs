using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryDto>
    {
        public UpdateCountryValidator(ProjectCarsContext context)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters")
                .Must(name => !context.Countries.Any(c => c.Name == name))
                .WithMessage("Name must be unique");
        }
    }
}