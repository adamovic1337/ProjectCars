using FluentValidation;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class CreateStatusValidator : AbstractValidator<CreateStatusDto>
    {
        public CreateStatusValidator(ProjectCarsContext context)
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters")
                .Must(name => !context.Status.Any(s => s.Name == name))
                .WithMessage("Name must be unique");
        }
    }
}
