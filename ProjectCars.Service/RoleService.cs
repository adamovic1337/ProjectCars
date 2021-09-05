using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
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
using System.Threading.Tasks;

namespace ProjectCars.Service
{
    public class RoleService : IRoleService
    {
        #region FIELDS

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly CreateRoleValidator _createRoleValidator;
        private readonly UpdateRoleValidator _updateRoleValidator;
        private readonly RoleManager<AppRole> _roleManager;

        #endregion FIELDS

        #region CONSTRUCTORS

        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository, IMapper mapper, CreateRoleValidator createRoleValidator, UpdateRoleValidator updateRoleValidator, RoleManager<AppRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _createRoleValidator = createRoleValidator;
            _updateRoleValidator = updateRoleValidator;
            _roleManager = roleManager;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public List<RoleDto> GetRoles(SearchRoleDto searchRole)
        {
            return _roleRepository.GetAll(searchRole);
        }

        public PaginationData<AppRole> PaginationData(SearchRoleDto searchRole)
        {
            return _roleRepository.GetPaginationData(searchRole, 
                                                     r => r.Name.Contains(Strings.Trim(searchRole.RoleName)));
        }

        public RoleDto GetRoleById(int roleId)
        {
            return _roleRepository.GetOne(roleId).EntityNotFoundCheck();
        }

        public async Task<RoleDto> CreateRole(CreateRoleDto roleDto)
        {
            _createRoleValidator.ValidateAndThrow(roleDto);

            var roleEntity = _mapper.Map<AppRole>(roleDto);

            _ = await _roleManager.CreateAsync(roleEntity);
            _unitOfWork.Commit();

            var roleToReturn = _mapper.Map<RoleDto>(roleEntity);
            return roleToReturn;
        }

        public async Task<bool> UpdateRolePut(int roleId, UpdateRoleDto roleDto)
        {
            var role = _roleRepository.GetEntity(roleId).EntityNotFoundCheck();

            roleDto.Id = roleId;

            _updateRoleValidator.ValidateAndThrow(roleDto);            
            _mapper.Map(roleDto, role);

            var update = await _roleManager.UpdateAsync(role);
            _unitOfWork.Commit();

            return update.Succeeded;
        }

        public async Task<bool> UpdateRolePatch(int roleId, JsonPatchDocument<UpdateRoleDto> patchDocument)
        {
            var role = _roleRepository.GetEntity(roleId).EntityNotFoundCheck();

            var roleDto = _mapper.Map<UpdateRoleDto>(role);

            patchDocument.ApplyTo(roleDto);

            roleDto.Id = roleId;

            _updateRoleValidator.ValidateAndThrow(roleDto);
            _mapper.Map(roleDto, role);

            var update = await _roleManager.UpdateAsync(role);
            _unitOfWork.Commit();

            return update.Succeeded;
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            var role = _roleRepository.GetEntity(roleId).EntityNotFoundCheck();

            var delete = await _roleManager.DeleteAsync(role);
            _unitOfWork.Commit();

            return delete.Succeeded;
        }

        #endregion METHODS
    }
}