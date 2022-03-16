using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateCarModelValidator : AbstractValidator<UpdateCarModelDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateCarModelValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");

            RuleFor(c => c.ManufacturerId)
                .NotEmpty()
                .WithMessage("Manufacturer is required parameter");

            RuleFor(c => c.EngineId)
                .NotEmpty()
                .WithMessage("Engine is required parameter");
        }

        private bool UniqueName(UpdateCarModelDto carModel, string name)
        {
            var sameRecord = _context.CarModels.Where(cm => cm.Id == carModel.Id && cm.Name == name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.CarModels.Where(cm => cm.Name == name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}