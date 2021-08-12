using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateCityValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");

            RuleFor(c => c.CountryId)
                .NotEmpty()
                .WithMessage("CountryId is required parameter");
        }

        private bool UniqueName(UpdateCityDto city, string name)
        {
            var sameRecord = _context.Cities.Where(c => c.Id == city.Id && c.Name == name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Cities.Where(c => c.Name == name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}