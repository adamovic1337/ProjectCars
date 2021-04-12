using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Repository.Helpers;

namespace ProjectCars.Service.Contract
{
    public interface IRoleService
    {
        /// <summary>
        /// Returns all Roles based on user filters
        /// </summary>
        /// <param name="searchRole"></param>
        /// <returns>Returns collection of <see cref="Role"/></returns>
        IEnumerable<RoleDto> GetRoles(SearchRoleDto searchRole);
        
        /// <summary>
        /// Return PagedList for creating X-Pagination header
        /// </summary>
        /// <param name="searchRole"></param>
        /// <returns>Returns PagedList of roles</returns>
        PagedList<Role> PagedListRoles(SearchRoleDto searchRole);

        /// <summary>
        /// Returns one Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns one <see cref="Role"/> object</returns>
        RoleDto GetRoleById(int id);

        /// <summary>
        /// Creates <see cref="Role"/> entity
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns>Created Role for Location header</returns>
        RoleDto CreateRole(CreateRoleDto roleDto);

        /// <summary>
        /// Update <see cref="Role"/> using PUT method entity
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleDto"></param>
        void UpdateRolePut(int roleId, UpdateRoleDto roleDto);

        /// <summary>
        /// Update <see cref="Role"/> using PATCH method entity
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="patchDocument"></param>
        void UpdateRolePatch(int roleId, JsonPatchDocument<UpdateRoleDto> patchDocument);

        /// <summary>
        /// Delete <see cref="Role"/>
        /// </summary>
        /// <param name="roleId"></param>
        void DeleteRole(int roleId);
    }
}