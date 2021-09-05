using FluentValidation;
using ProjectCars.Model.DTO.Jwt;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class LoginValidator : AbstractValidator<UserLoginDto>
    {
        public LoginValidator(ProjectCarsContext context)
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter")
                .Must(email => context.Users.Any(u => u.Email == email))
                .WithMessage("User doesn't exists");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required parameter");
        }
    }
}
