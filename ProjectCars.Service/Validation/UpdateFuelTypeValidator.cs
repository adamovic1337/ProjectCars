using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateFuelTypeValidator : AbstractValidator<UpdateFuelTypeDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateFuelTypeValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(f => f.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(15)
                .WithMessage("Maximum length is 15 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");
        }

        private bool UniqueName(UpdateFuelTypeDto fuelType, string name)
        {
            var sameRecord = _context.FuelTypes.Where(f => f.Id == fuelType.Id && f.Name == fuelType.Name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.FuelTypes.Where(f => f.Name == fuelType.Name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}