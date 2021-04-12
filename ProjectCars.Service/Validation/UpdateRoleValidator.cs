using FluentValidation;
using ProjectCars.Repository.DbContexts;
using System.Linq;
using ProjectCars.Model.DTO.Update;

namespace ProjectCars.Service.Validation
{
    public  class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleValidator(ProjectCarsContext context)
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .MaximumLength(30)
                .WithMessage("Maximum length is 30 characters")
                .Must(name => !context.Roles.Any(r => r.Name == name))
                .WithMessage("Name must be unique");
        }
    }
}