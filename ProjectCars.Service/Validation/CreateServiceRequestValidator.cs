using FluentValidation;
using ProjectCars.Model.DTO.Create;

namespace ProjectCars.Service.Validation
{
    public class CreateServiceRequestValidator : AbstractValidator<CreateServiceRequestDto>
    {
        public CreateServiceRequestValidator()
        {
            RuleFor(sr => sr.UserDescription)
                .NotEmpty()
                .WithMessage("User Description is required parameter");
        }
    }
}
