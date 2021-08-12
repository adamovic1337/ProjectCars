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
                .WithMessage("Maximum number is 9999")
                .GreaterThan(600)
                .WithMessage("Minimum number is 600");
            RuleFor(e => e.FuelTypeId)
                .NotEmpty()
                .WithMessage("Fuel Type is required parameter");
        }
    }
}
