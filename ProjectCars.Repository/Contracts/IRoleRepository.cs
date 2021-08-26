using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        /// <summary>
        /// Returns all roles that match input filters
        /// </summary>
        /// <param name="searchRole"></param>
        /// <returns></returns>
        List<RoleDto> GetAll(SearchRoleDto searchRole);

        /// <summary>
        /// Get one role that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleDto GetOne(int id);
    }
}
