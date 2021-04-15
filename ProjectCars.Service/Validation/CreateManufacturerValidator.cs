using FluentValidation;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class CreateManufacturerValidator : AbstractValidator<CreateManufacturerDto>
    {
        public CreateManufacturerValidator(ProjectCarsContext context)
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters")
                .Must(name => !context.Manufacturers.Any(m => m.Name == name))
                .WithMessage("Name must be unique");

            RuleFor(c => c.CountryId)
                .NotEmpty()
                .WithMessage("CountryId is required parameter");
        }
    }
}