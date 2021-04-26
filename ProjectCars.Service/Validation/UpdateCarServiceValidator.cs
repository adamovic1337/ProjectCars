using FluentValidation;
using ProjectCars.Model.DTO.Update;

namespace ProjectCars.Service.Validation
{
    public class UpdateCarServiceValidator : AbstractValidator<UpdateCarServiceDto>
    {
        public UpdateCarServiceValidator()
        {
            RuleFor(cs => cs.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters");

            RuleFor(cs => cs.Phone)
                .NotEmpty()
                .WithMessage("Phone is required parameter")
                .MaximumLength(20)
                .WithMessage("Maximum length is 20 characters");

            RuleFor(cs => cs.Address)
                .NotEmpty()
                .WithMessage("Address is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters");

            RuleFor(cs => cs.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter")
                .MaximumLength(254)
                .WithMessage("Maximum length is 254 characters");
        }
    }
}
