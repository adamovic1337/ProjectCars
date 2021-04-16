using FluentValidation;
using ProjectCars.Model.DTO.Update;

namespace ProjectCars.Service.Validation
{
    public class UpdateFuelTypeValidator : AbstractValidator<UpdateFuelTypeDto>
    {
        public UpdateFuelTypeValidator()
        {
            RuleFor(f => f.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(15)
                .WithMessage("Maximum length is 15 characters");
        }
    }
}