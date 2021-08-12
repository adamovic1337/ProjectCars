using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateManufacturerValidator : AbstractValidator<UpdateManufacturerDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateManufacturerValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");

            RuleFor(c => c.CountryId)
                .NotEmpty()
                .WithMessage("CountryId is required parameter");
        }

        private bool UniqueName(UpdateManufacturerDto manufacturer, string name)
        {
            var sameRecord = _context.Manufacturers.Where(m => m.Id == manufacturer.Id && m.Name == name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Manufacturers.Where(m => m.Name == name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}