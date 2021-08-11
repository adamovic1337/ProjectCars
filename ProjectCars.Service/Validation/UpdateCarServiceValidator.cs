using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateCarServiceValidator : AbstractValidator<UpdateCarServiceDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateCarServiceValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(cs => cs.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters")
                .Must(UniqueName)
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
        }

        private bool UniqueName(UpdateCarServiceDto carService, string name)
        {
            var sameRecord = _context.CarServices.Where(cs => cs.Id == carService.Id && cs.Name == carService.Name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Roles.Where(cs => cs.Name == carService.Name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}
