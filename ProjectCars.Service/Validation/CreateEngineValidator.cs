using FluentValidation;
using ProjectCars.Model.DTO.Create;

namespace ProjectCars.Service.Validation
{
    public class CreateEngineValidator : AbstractValidator<CreateEngineDto>
    {
        public CreateEngineValidator()
        {
            RuleFor(e => e.CubicCapacity)
                .LessThan(9999)
                .WithMessage("Maximum number is 9999 characters")
                .GreaterThan(600)
                .WithMessage("Maximum number is 600 characters");
        }
    }
}
