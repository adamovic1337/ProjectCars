using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateCountryValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");
        }
        private bool UniqueName(UpdateCountryDto country, string name)
        {
            var sameRecord = _context.Countries.Where(c => c.Id == country.Id && c.Name == name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Countries.Where(c => c.Name == name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}