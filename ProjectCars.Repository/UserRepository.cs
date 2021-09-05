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
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        #region CONSTRUCTORS

        public UserRepository(ProjectCarsContext context) : base(context)
        {
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<UserDto> GetAll(SearchUserDto searchUser)
        {
            var orderBy = searchUser.OrderBy.Split(new[] { '-' })[0];
            var direction = searchUser.OrderBy?.Split(new[] { '-' })[1];

            return (from u in Context.Users
                    join c in Context.Cities on u.CityId equals c.Id
                    join ur in Context.UserRoles on u.Id equals ur.UserId
                    join r in Context.Roles on ur.RoleId equals r.Id
                    where u.FirstName.Contains(searchUser.FirstName.Trim())
                       && u.LastName.Contains(searchUser.LastName.Trim())
                    select new UserDto
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Username = u.UserName,
                        Password = u.PasswordHash,
                        RoleId = r.Id,
                        RoleName = r.Name,
                        CityId = u.CityId,
                        CityName = c.Name,
                    }).OrderBy($"{orderBy} {direction}")
                      .Skip((searchUser.PageNumber - 1) * searchUser.PageSize)
                      .Take(searchUser.PageSize).ToList();
        }

        public UserDto GetOne(int id)
        {
            return (from u in Context.Users
                    join c in Context.Cities on u.CityId equals c.Id
                    join ur in Context.UserRoles on u.Id equals ur.UserId
                    join r in Context.Roles on ur.RoleId equals r.Id
                    where u.Id == id
                    select new UserDto
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Username = u.UserName,
                        Password = u.PasswordHash,
                        RoleId = r.Id,
                        RoleName = r.Name,
                        CityId = u.CityId,
                        CityName = c.Name,
                    }).FirstOrDefault();
        }

        #endregion METHODS
    }
}