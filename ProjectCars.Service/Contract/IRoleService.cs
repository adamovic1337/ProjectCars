using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Helpers;
using System.Collections.Generic;

namespace ProjectCars.Service.Contract
{
    public interface IRoleService
    {
        /// <summary>
        /// Returns all Roles based on user filters
        /// </summary>
        /// <param name="searchRole"></param>
        /// <returns>Returns collection of Role></returns>
        List<RoleDto> GetRoles(SearchRoleDto searchRole);

        /// <summary>
        /// Return pagination data for creating X-Pagination header
        /// </summary>
        /// <param name="searchRole"></param>
        /// <returns>Returns PagedList of Roles</returns>
        PaginationData<Role> PaginationData(SearchRoleDto searchRole);

        /// <summary>
        /// Returns one Role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Returns one Role object</returns>
        RoleDto GetRoleById(int roleId);

        /// <summary>
        /// Creates Role entity
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns>Created Role for Location header</returns>
        RoleDto CreateRole(CreateRoleDto roleDto);

        /// <summary>
        /// Update Role using PUT method entity
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleDto"></param>
        void UpdateRolePut(int roleId, UpdateRoleDto roleDto);

        /// <summary>
        /// Update Role using PATCH method entity
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="patchDocument"></param>
        void UpdateRolePatch(int roleId, JsonPatchDocument<UpdateRoleDto> patchDocument);

        /// <summary>
        /// Delete Role
        /// </summary>
        /// <param name="roleId"></param>
        void DeleteRole(int roleId);
    }
}