using FluentValidation;
using ProjectCars.Model.DTO.Create;

namespace ProjectCars.Service.Validation
{
    public class CreateEngineValidator : AbstractValidator<CreateEngineDto>
    {
        public CreateEngineValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter");

            RuleFor(e => e.FuelTypeId)
                .NotEmpty()
                .WithMessage("Fuel Type is required parameter");

            RuleFor(e => e.Power)
                .NotEmpty()
                .WithMessage("Power is required parameter");
        }
    }
}
