using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Jwt;
using ProjectCars.Model.Entities;
using ProjectCars.Repository.Contracts;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Helpers;
using ProjectCars.Service.JWT;
using ProjectCars.Service.Validation;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCars.Service
{
    public class AuthService : IAuthService
    {
        #region FIELDS

        private readonly UserManager<AppUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly CreateUserValidator _createUserValidator;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly LoginValidator _loginValidator;

        #endregion FIELDS

        #region CONSTRUCTORS

        public AuthService(UserManager<AppUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, CreateUserValidator createUserValidator, IMapper mapper, ICityRepository cityRepository, LoginValidator loginValidator)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _createUserValidator = createUserValidator;
            _mapper = mapper;
            _cityRepository = cityRepository;
            _loginValidator = loginValidator;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public async Task<RegistrationResponseDto> CreateUser(CreateUserDto userDto)
        {
            _createUserValidator.ValidateAndThrow(userDto);

            _ = _cityRepository.GetEntity(userDto.CityId).EntityNotFoundCheck();

            var newUser = _mapper.Map<AppUser>(userDto);

            var isCreated = await _userManager.CreateAsync(newUser, userDto.Password);

            if (!isCreated.Succeeded)
            {
                return new RegistrationResponseDto { Error = "Unable to create user", Success = false };
            }
            var result = await _userManager.AddToRoleAsync(newUser, userDto.Role);

            var roles = await _userManager.GetRolesAsync(newUser);

            return new RegistrationResponseDto { Token = GenerateJwtToken(newUser, roles), Success = false };
        }

        public async Task<RegistrationResponseDto> Login(UserLoginDto userDto)
        {
            _loginValidator.ValidateAndThrow(userDto);

            var user = await _userManager.FindByEmailAsync(userDto.Email).EntityNotFoundCheck();

            var isCorrect = await _userManager.CheckPasswordAsync(user, userDto.Password);

            if (!isCorrect)
            {
                return new RegistrationResponseDto { Error = "Unable to login user", Success = false };
            }
            var roles = await _userManager.GetRolesAsync(user);

            return new RegistrationResponseDto { Token = GenerateJwtToken(user, roles), Success = true };
        }

        public string GenerateJwtToken(AppUser user, IList<string> roles)
        {
            var jwtTokenhandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    // JWT Claims: https://datatracker.ietf.org/doc/html/rfc7519#section-4.1

                    new Claim("Id", user.Id.ToString(), ClaimValueTypes.String),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email, ClaimValueTypes.String),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName, ClaimValueTypes.String),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email, ClaimValueTypes.String),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.String),
                    new Claim(ClaimTypes.Role, roles[0].ToString(), ClaimValueTypes.String),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenhandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenhandler.WriteToken(token);

            return jwtToken;
        }

        #endregion METHODS
    }
}