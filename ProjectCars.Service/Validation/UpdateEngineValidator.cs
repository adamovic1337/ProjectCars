using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateEngineValidator : AbstractValidator<UpdateEngineDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateEngineValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");

            RuleFor(e => e.FuelTypeId)
                .NotEmpty()
                .WithMessage("Fuel Type is required parameter");

            RuleFor(e => e.Power)
                .NotEmpty()
                .WithMessage("Power is required parameter");
        }

        private bool UniqueName(UpdateEngineDto engine, string name)
        {
            var sameRecord = _context.Engines.Where(e => e.Id == engine.Id && e.Name == name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Engines.Where(e => e.Name == name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}
