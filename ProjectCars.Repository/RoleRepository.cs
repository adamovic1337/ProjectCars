using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        #region CONSTRUCTORS

        public RoleRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<RoleDto> GetAll(SearchRoleDto searchRole)
        {
            var orderBy = searchRole.OrderBy.Split(new[] { '-' })[0];
            var direction = searchRole.OrderBy?.Split(new[] { '-' })[1];

            return (from r in Context.Roles
                    where r.Name.Contains(searchRole.RoleName.Trim())
                    select new RoleDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchRole.PageNumber - 1) * searchRole.PageSize)
                      .Take(searchRole.PageSize).ToList();
        }

        public RoleDto GetOne(int id)
        {
            return Context.Roles.Where(r => r.Id == id).Select(r => new RoleDto { Id = r.Id, Name = r.Name }).FirstOrDefault();
        }

        #endregion METHODS
    }
}