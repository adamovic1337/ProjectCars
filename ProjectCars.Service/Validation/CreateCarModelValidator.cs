using FluentValidation;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class CreateCarModelValidator : AbstractValidator<CreateCarModelDto>
    {
        public CreateCarModelValidator(ProjectCarsContext context)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters")
                .Must(name => !context.CarModels.Any(c => c.Name == name))
                .WithMessage("Name must be unique");
        }
    }
}
