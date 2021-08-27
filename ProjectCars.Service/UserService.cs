using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.VisualBasic;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Common.Contract;
using ProjectCars.Repository.Contracts;
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.Validation;
using System.Collections.Generic;

namespace ProjectCars.Service
{
    public class UserService : IUserService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly CreateUserValidator _createUserValidator;
        private readonly UpdateUserValidator _updateUserValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, CreateUserValidator createUserValidator, UpdateUserValidator updateUserValidator)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
            _createUserValidator = createUserValidator;
            _updateUserValidator = updateUserValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<UserDto> GetUsers(SearchUserDto searchUser)
        {
            return _userRepository.GetAll(searchUser);
        }

        public PaginationData<User> PaginationData(SearchUserDto searchUser)
        {
            return _userRepository.GetPaginationData(searchUser,
                                                      u => u.FirstName.Contains(Strings.Trim(searchUser.FirstName)) && u.LastName.Contains(Strings.Trim(searchUser.LastName)));
        }

        public UserDto GetUserById(int userId)
        {
            return _userRepository.GetOne(userId).EntityNotFoundCheck();
        }

        public UserDto CreateUser(CreateUserDto userDto)
        {
            _createUserValidator.ValidateAndThrow(userDto);

            var userEntity = _mapper.Map<User>(userDto);
            _userRepository.Create(userEntity);
            _unitOfWork.Commit();

            var userToReturn = _mapper.Map<UserDto>(userEntity);
            return userToReturn;
        }

        public void UpdateUserPut(int userId, UpdateUserDto userDto)
        {
            var user = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            userDto.Id = userId;

            _updateUserValidator.ValidateAndThrow(userDto);
            _userRepository.Update(user);
            _mapper.Map(userDto, user);
            _unitOfWork.Commit();
        }

        public void UpdateUserPatch(int userId, JsonPatchDocument<UpdateUserDto> patchDocument)
        {
            var user = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            var userDto = _mapper.Map<UpdateUserDto>(user);

            patchDocument.ApplyTo(userDto);

            userDto.Id = userId;

            _updateUserValidator.ValidateAndThrow(userDto);
            _userRepository.Update(user);
            _mapper.Map(userDto, user);
            _unitOfWork.Commit();
        }

        public void DeleteUser(int userId)
        {
            var user = _userRepository.GetEntity(userId).EntityNotFoundCheck();

            _userRepository.Delete(user);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}