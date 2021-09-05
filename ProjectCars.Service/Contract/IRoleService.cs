using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCars.Service.Contract
{
    public interface IRoleService
    {
        /// <summary>
        /// Returns all Roles based on user filters
        /// </summary>
        /// <param name="searchRole"></param>
        /// <returns>Returns collection of AppRole></returns>
        List<RoleDto> GetRoles(SearchRoleDto searchRole);

        /// <summary>
        /// Return pagination data for creating X-Pagination header
        /// </summary>
        /// <param name="searchRole"></param>
        /// <returns>Returns PagedList of Roles</returns>
        PaginationData<AppRole> PaginationData(SearchRoleDto searchRole);

        /// <summary>
        /// Returns one AppRole
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Returns one AppRole object</returns>
        RoleDto GetRoleById(int roleId);

        /// <summary>
        /// Creates AppRole entity
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns>Created AppRole for Location header</returns>
        Task<RoleDto> CreateRole(CreateRoleDto roleDto);

        /// <summary>
        /// Update AppRole using PUT method entity
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleDto"></param>
        Task<bool> UpdateRolePut(int roleId, UpdateRoleDto roleDto);

        /// <summary>
        /// Update AppRole using PATCH method entity
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="patchDocument"></param>
        Task<bool> UpdateRolePatch(int roleId, JsonPatchDocument<UpdateRoleDto> patchDocument);

        /// <summary>
        /// Delete AppRole
        /// </summary>
        /// <param name="roleId"></param>
        Task<bool> DeleteRole(int roleId);
    }
}