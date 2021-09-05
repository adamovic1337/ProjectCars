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
    public interface IUserService
    {
        /// <summary>
        /// Returns all Users based on user filters
        /// </summary>
        /// <param name="searchUser"></param>
        /// <returns>Returns collection of AppUser></returns>
        List<UserDto> GetUsers(SearchUserDto searchUser);

        /// <summary>
        /// Returns pagination data for creating X-Pagination header
        /// </summary>
        /// <param name="searchUser"></param>
        /// <returns>Returns PagedList of Users</returns>
        PaginationData<AppUser> PaginationData(SearchUserDto searchUser);
        /// <summary>
        /// Returns one AppUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns one AppUser object</returns>
        UserDto GetUserById(int userId);

        /// <summary>
        /// Update AppUser using PUT method entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userDto"></param>
        Task<bool> UpdateUserPut(int userId, UpdateUserDto userDto);

        /// <summary>
        /// Update AppUser using PATCH method entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="patchDocument"></param>
        Task<bool> UpdateUserPatch(int userId, JsonPatchDocument<UpdateUserDto> patchDocument);

        /// <summary>
        /// Delete AppUser
        /// </summary>
        /// <param name="userId"></param>
        Task<bool> DeleteUser(int userId);
    }
}