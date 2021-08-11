using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateStatusValidator : AbstractValidator<UpdateStatusDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateStatusValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");
        }

        private bool UniqueName(UpdateStatusDto status, string name)
        {
            var sameRecord = _context.Status.Where(s => s.Id == status.Id && s.Name == status.Name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Countries.Where(s => s.Name == status.Name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}
