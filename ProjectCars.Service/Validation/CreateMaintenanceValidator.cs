using FluentValidation;
using ProjectCars.Model.DTO.Create;

namespace ProjectCars.Service.Validation
{
    public class CreateMaintenanceValidator : AbstractValidator<CreateMaintenanceDto>
    {
        public CreateMaintenanceValidator()
        {
            RuleFor(m => m.Repairs)
                .NotEmpty()
                .WithMessage("Repairs is required parameter");

            RuleFor(m => m.Mileage)
                .NotEmpty()
                .WithMessage("Mileage is required parameter");

            RuleFor(m => m.RepairDate)
                .NotEmpty()
                .WithMessage("Repair Date is required parameter");
        }
    }
}
