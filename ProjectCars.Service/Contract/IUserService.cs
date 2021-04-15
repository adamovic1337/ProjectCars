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
    public interface IUserService
    {
        /// <summary>
        /// Returns all Users based on user filters
        /// </summary>
        /// <param name="searchUser"></param>
        /// <returns>Returns collection of User></returns>
        IEnumerable<UserDto> GetUsers(SearchUserDto searchUser);

        /// <summary>
        /// Return PagedList for creating X-Pagination header
        /// </summary>
        /// <param name="searchUser"></param>
        /// <returns>Returns PagedList of Users</returns>
        PagedList<User> PagedListUsers(SearchUserDto searchUser);

        /// <summary>
        /// Returns one User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns one User object</returns>
        UserDto GetUserById(int userId);

        /// <summary>
        /// Creates User entity
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>Created User for Location header</returns>
        UserDto CreateUser(CreateUserDto userDto);

        /// <summary>
        /// Update User using PUT method entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userDto"></param>
        void UpdateUserPut(int userId, UpdateUserDto userDto);

        /// <summary>
        /// Update User using PATCH method entity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="patchDocument"></param>
        void UpdateUserPatch(int userId, JsonPatchDocument<UpdateUserDto> patchDocument);

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userId"></param>
        void DeleteUser(int userId);
    }
}