using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Jwt;
using ProjectCars.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCars.Service.Contract
{
    public interface IAuthService
    {
        /// <summary>
        /// Register user and return JWT token
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public Task<RegistrationResponseDto> CreateUser(CreateUserDto userDto);

        /// <summary>
        /// Returns JWT token for authorization
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public Task<RegistrationResponseDto> Login(UserLoginDto userDto);

        /// <summary>
        /// Generate JWT token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        string GenerateJwtToken(AppUser user, IList<string> roles);
    }
}