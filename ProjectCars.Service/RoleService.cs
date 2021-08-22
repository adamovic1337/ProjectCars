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
using ProjectCars.Repository.Helpers;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.Validation;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;

namespace ProjectCars.Service
{
    public class RoleService : IRoleService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IMapper _mapper;
        private readonly CreateRoleValidator _createRoleValidator;
        private readonly UpdateRoleValidator _updateRoleValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public RoleService(IUnitOfWork unitOfWork, IGenericRepository<Role> roleRepository, IMapper mapper, CreateRoleValidator createRoleValidator, UpdateRoleValidator updateRoleValidator)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _createRoleValidator = createRoleValidator;
            _updateRoleValidator = updateRoleValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public IEnumerable<RoleDto> GetRoles(SearchRoleDto searchRole)
        {
            var orderBy = searchRole.OrderBy.Split(new[] { '-' })[0];
            var direction = searchRole.OrderBy?.Split(new[] { '-' })[1];

            var roles = _roleRepository.GetAll(searchRole.PageNumber, 
                                               searchRole.PageSize,
                                               r => r.Name.Contains(Strings.Trim(searchRole.RoleName)),
                                               q => q.OrderBy($"{orderBy} {direction}"));

            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public PagedList<Role> PagedListRoles(SearchRoleDto searchRole)
        {
            return _roleRepository.GetAll(searchRole.PageNumber, 
                                          searchRole.PageSize, 
                                          r => r.Name.Contains(Strings.Trim(searchRole.RoleName)));
        }

        public RoleDto GetRoleById(int roleId)
        {
            var role = _roleRepository.GetOne(roleId).EntityNotFoundCheck();

            return _mapper.Map<RoleDto>(role);
        }

        public RoleDto CreateRole(CreateRoleDto roleDto)
        {
            _createRoleValidator.ValidateAndThrow(roleDto);

            var roleEntity = _mapper.Map<Role>(roleDto);
            _roleRepository.Create(roleEntity);
            _unitOfWork.Commit();

            var roleToReturn = _mapper.Map<RoleDto>(roleEntity);
            return roleToReturn;
        }

        public void UpdateRolePut(int roleId, UpdateRoleDto roleDto)
        {
            var role = _roleRepository.GetOne(roleId).EntityNotFoundCheck();

            roleDto.Id = roleId;

            _updateRoleValidator.ValidateAndThrow(roleDto);
            _roleRepository.Update(role);
            _mapper.Map(roleDto, role);
            _unitOfWork.Commit();
        }

        public void UpdateRolePatch(int roleId, JsonPatchDocument<UpdateRoleDto> patchDocument)
        {
            var role = _roleRepository.GetOne(roleId).EntityNotFoundCheck();

            var roleDto = _mapper.Map<UpdateRoleDto>(role);

            patchDocument.ApplyTo(roleDto);

            roleDto.Id = roleId;

            _updateRoleValidator.ValidateAndThrow(roleDto);
            _roleRepository.Update(role);
            _mapper.Map(roleDto, role);
            _unitOfWork.Commit();
        }

        public void DeleteRole(int roleId)
        {
            _ = _roleRepository.GetOne(roleId).EntityNotFoundCheck();

            _roleRepository.Delete(roleId);
            _unitOfWork.Commit();
        }

        #endregion METHODS
    }
}