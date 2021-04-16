using FluentValidation;
using ProjectCars.Model.DTO.Update;

namespace ProjectCars.Service.Validation
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters");
        }
    }
}