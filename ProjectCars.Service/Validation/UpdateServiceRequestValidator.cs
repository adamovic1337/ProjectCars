using FluentValidation;
using ProjectCars.Model.DTO.Update;

namespace ProjectCars.Service.Validation
{
    public class UpdateServiceRequestValidator : AbstractValidator<UpdateServiceRequestDto>
    {
        public UpdateServiceRequestValidator()
        {
            RuleFor(sr => sr.UserDescription)
                .NotEmpty()
                .WithMessage("User Description is required parameter");
        }
    }
}
