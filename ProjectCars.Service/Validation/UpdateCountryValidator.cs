using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;

namespace ProjectCars.Service.Validation
{
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryDto>
    {
        public UpdateCountryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters");
        }
    }
}