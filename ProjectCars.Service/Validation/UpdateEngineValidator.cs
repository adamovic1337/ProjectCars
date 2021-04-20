using FluentValidation;
using ProjectCars.Model.DTO.Update;

namespace ProjectCars.Service.Validation
{
    public class UpdateEngineValidator : AbstractValidator<UpdateEngineDto>
    {
        public UpdateEngineValidator()
        {
            RuleFor(e => e.CubicCapacity)
                .LessThan(9999)
                .WithMessage("Maximum number is 9999 characters")
                .GreaterThan(600)
                .WithMessage("Maximum number is 600 characters");
        }
    }
}
