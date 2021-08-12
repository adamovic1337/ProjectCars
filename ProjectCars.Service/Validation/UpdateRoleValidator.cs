using FluentValidation;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Repository.DbContexts;
using System.Linq;

namespace ProjectCars.Service.Validation
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
    {
        private readonly ProjectCarsContext _context;

        public UpdateRoleValidator(ProjectCarsContext context)
        {
            _context = context;

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters")
                .Must(UniqueName)
                .WithMessage("Name must be unique");
        }

        private bool UniqueName(UpdateRoleDto role, string name)
        {
            var sameRecord = _context.Roles.Where(r => r.Id == role.Id && r.Name == name).SingleOrDefault();

            if (sameRecord != null)
            {
                return true;
            }
            var differentRecord = _context.Roles.Where(r => r.Name == name).SingleOrDefault();

            return differentRecord == null;
        }
    }
}