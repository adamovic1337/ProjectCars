using FluentValidation;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class CreateFuelTypeValidator : AbstractValidator<CreateFuelTypeDto>
    {
        public CreateFuelTypeValidator(ProjectCarsContext context)
        {
            RuleFor(f => f.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(15)
                .WithMessage("Maximum length is 15 characters")
                .Must(name => !context.FuelTypes.Any(f => f.Name == name))
                .WithMessage("Name must be unique");
        }
    }
}