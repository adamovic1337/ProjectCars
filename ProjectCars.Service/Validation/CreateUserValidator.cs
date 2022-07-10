using FluentValidation;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator(ProjectCarsContext context)
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter")
                .MaximumLength(254)
                .WithMessage("Maximum length is 254 characters")
                .Must(email => !context.Users.Any(u => u.Email == email))
                .WithMessage("Email must be unique");

            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("Username is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters")
                .Must(username => !context.Users.Any(u => u.UserName == username))
                .WithMessage("Username must be unique");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required parameter")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")
                .WithMessage("Password must have at least: 1 lower case letter, 1 uppercase letter, 1 number, 1 special character, min length 8 characters ");

            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required parameter")
                .MaximumLength(50)
                .WithMessage("Maximum length is 50 characters");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required parameter")
                .MaximumLength(50)
                .WithMessage("Maximum length is 50 characters");

            RuleFor(u => u.CityId)
                .NotEmpty()
                .WithMessage("City is required parameter");

            RuleFor(u => u.Role)
                .NotEmpty()
                .WithMessage("Role is required parameter");
        }
    }
}