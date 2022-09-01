using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ProjectCars.API.Helpers;
using ProjectCars.Model.DTO;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Search;
using ProjectCars.Model.DTO.Update;
using ProjectCars.Model.DTO.View;
using ProjectCars.Service.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCars.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region FIELDS

        private readonly IUserService _userService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private UserDto CreateLinks(int userId, UserDto userDto)
        {
            var name = "User";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new { userId }),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {}),
                    $"Create_{name}",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new { userId }),
                    $"Update_{name}",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new { userId }),
                    $"Update_{name}",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}", new { userId}),
                    $"Delete_{name}",
                    "DELETE"
                )
            };

            userDto.Links = links;

            return userDto;
        }

        private string CreateResourceUri(SearchUserDto search, ResourceUriType type)
        {
            var name = "Users";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, firstName = search.FirstName, lastName = search.LastName }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, firstName = search.FirstName, lastName = search.LastName }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, firstName = search.FirstName, lastName = search.LastName }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, firstName = search.FirstName, lastName = search.LastName })
            };
        }

        private dynamic CreateLinksForList(SearchUserDto search, IEnumerable<UserDto> userDto)
        {
            var links = new List<LinkDto>();

            var collection = userDto.Select(user => CreateLinks(user.Id, user)).ToList();

            var paginationData = _userService.PaginationData(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (paginationData.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (paginationData.HasNext)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.NextPage),
                        "next",
                        "GET"
                    ));
            }

            var result = new
            {
                collection,
                links
            };

            return result;
        }

        #endregion METHODS

        // GET: api/users
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetUsers")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchUserDto searchUser, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_userService.PaginationData(searchUser));

            var users = _userService.GetUsers(searchUser);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(users)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchUser, users)
                        : users
                     );
        }

        // GET api/users/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{userId}", Name = "GetUser")]
        public IActionResult Get(int userId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var user = _userService.GetUserById(userId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(user)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(userId, user)
                        : user
                     );
        }

        // OPTIONS api/users
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // PUT api/users/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{userId}")]
        public async Task<IActionResult> Put(int userId, [FromBody] UpdateUserDto userDto)
        {
            _ = await _userService.UpdateUserPut(userId, userDto);
            return NoContent();
        }

        // PATCH api/users/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{userId}", Name = "UpdateUserPatch")]
        public async Task<IActionResult> Patch(int userId, [FromBody] JsonPatchDocument<UpdateUserDto> patchDocument)
        {
            _ = await _userService.UpdateUserPatch(userId, patchDocument);
            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{userId}", Name = "DeleteUser")]
        public async Task<IActionResult> Delete(int userId)
        {
            _ = await _userService.DeleteUser(userId);
            return NoContent();
        }
    }
}
