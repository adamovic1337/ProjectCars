using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using System.Collections.Generic;

namespace ProjectCars.Repository.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Returns all users that match input filters
        /// </summary>
        /// <param name="searchUser"></param>
        /// <returns></returns>
        List<UserDto> GetAll(SearchUserDto searchUser);

        /// <summary>
        /// Get one user that matches input filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDto GetOne(int id);
    }
}