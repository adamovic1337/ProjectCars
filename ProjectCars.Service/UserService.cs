using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCars.Service
{
    public class UserService : IUserService
    {
        #region FIELDS

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UpdateUserValidator _updateUserValidator;
        private readonly UserManager<AppUser> _userManager;

        #endregion FIELDS

        #region CONSTRUCTORS

        public UserService(IUserRepository userRepository, IMapper mapper, UpdateUserValidator updateUserValidator, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _updateUserValidator = updateUserValidator;
            _userManager = userManager;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<UserDto> GetUsers(SearchUserDto searchUser)
        {
            return _userRepository.GetAll(searchUser);
        }

        public PaginationData<AppUser> PaginationData(SearchUserDto searchUser)
        {
            return _userRepository.GetPaginationData(searchUser,
                                                      u => u.FirstName.Contains(searchUser.FirstName.Trim()) && u.LastName.Contains(searchUser.LastName.Trim()));
        }

        public UserDto GetUserById(int userId)
        {
            return _userRepository.GetOne(userId).EntityNotFoundCheck();
        }

        public async Task<bool> UpdateUserPut(int userId, UpdateUserDto userDto)
        {
            var user = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            userDto.Id = userId;

            _updateUserValidator.ValidateAndThrow(userDto);
            _mapper.Map(userDto, user);

            var update = await _userManager.UpdateAsync(user);
            _userRepository.Save();

            return update.Succeeded;
        }

        public async Task<bool> UpdateUserPatch(int userId, JsonPatchDocument<UpdateUserDto> patchDocument)
        {
            var user = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            var userDto = _mapper.Map<UpdateUserDto>(user);

            patchDocument.ApplyTo(userDto);

            userDto.Id = userId;

            _updateUserValidator.ValidateAndThrow(userDto);
            _mapper.Map(userDto, user);

            var update = await _userManager.UpdateAsync(user);
            _userRepository.Save();

            return update.Succeeded;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            var delete = await _userManager.DeleteAsync(user);
            _userRepository.Save();

            return delete.Succeeded;
        }

        #endregion METHODS
    }
}