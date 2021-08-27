using FluentValidation;
using ProjectCars.Model.DTO.Update;

namespace ProjectCars.Service.Validation
{
    public class UpdateCarValidator : AbstractValidator<UpdateCarDto>
    {
        public UpdateCarValidator()
        {
            RuleFor(c => c.Vin)
                .NotEmpty()
                .WithMessage("VIN number is required parameter")
                .MaximumLength(17)
                .WithMessage("Maximum length is 17 characters");

            RuleFor(c => c.FirstRegistration)
                .NotEmpty()
                .WithMessage("First Registration is required parameter");

            RuleFor(c => c.Mileage)
                .NotEmpty()
                .WithMessage("First Registration is required parameter");

            RuleFor(c => c.ModelId)
                .NotEmpty()
                .WithMessage("Model is required parameter");
        }
    }
}
