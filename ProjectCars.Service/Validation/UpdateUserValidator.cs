using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateUserValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter")
                .MaximumLength(254)
                .WithMessage("Maximum length is 254 characters")
                .Must(UniqueEmail)
                .WithMessage("Email must be unique");

            RuleFor(u => u.Username)
                .NotEmpty()
                .WithMessage("Username is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");

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
        }

        private bool UniqueName(UpdateUserDto user, string name)
        {
            var sameRecord = _context.Users.Where(u => u.Id == user.Id && u.Username == user.Username).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Users.Where(u => u.Username == user.Username).SingleOrDefault();

            return differentRecord == null;
        }

        private bool UniqueEmail(UpdateUserDto user, string name)
        {
            var sameRecord = _context.Users.Where(u => u.Id == user.Id && u.Email == user.Email).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();

            return differentRecord == null;
        }
    }
}