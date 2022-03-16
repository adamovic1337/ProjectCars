using FluentValidation;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class CreateCarServiceValidator : AbstractValidator<CreateCarServiceDto>
    {
        public CreateCarServiceValidator(ProjectCarsContext context)
        {
            RuleFor(cs => cs.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters")
                .Must(name => !context.Roles.Any(r => r.Name == name))
                .WithMessage("Name must be unique");

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

            RuleFor(cs => cs.CityId)
                .NotEmpty()
                .WithMessage("City is required parameter");

            RuleFor(cs => cs.OwnerId)
                .NotEmpty()
                .WithMessage("Owner is required parameter");
        }
    }
}