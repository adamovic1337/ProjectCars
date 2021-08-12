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
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetUser", new {userId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateUser", new {}),
                    "create_user",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateUserPut", new {userId}),
                    "update_user",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateUserPatch", new {userId}),
                    "update_user",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteUser", new {userId}),
                    "delete_user",
                    "DELETE"
                )
            };

            userDto.Links = links;

            return userDto;
        }

        private string CreateResourceUri(SearchUserDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetUsers",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, firstName = search.FirstName, lastName = search.LastName }),
                ResourceUriType.NextPage => Url.Link("GetUsers",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, firstName = search.FirstName, lastName = search.LastName }),
                ResourceUriType.Current => Url.Link("GetUsers",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, firstName = search.FirstName, lastName = search.LastName }),
                _ => Url.Link("GetUsers",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, firstName = search.FirstName, lastName = search.LastName })
            };
        }

        private dynamic CreateLinksForList(SearchUserDto search, IEnumerable<UserDto> userDto)
        {
            var links = new List<LinkDto>();

            var collection = userDto.Select(user => CreateLinks(user.Id, user)).ToList();

            var users = _userService.PagedListUsers(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (users.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (users.HasNext)
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
            this.PaginationMetadata(_userService.PagedListUsers(searchUser));

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_userService.GetUsers(searchUser))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchUser, _userService.GetUsers(searchUser))
                        : _userService.GetUsers(searchUser)
                     );
        }

        // GET api/users/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{userId}", Name = "GetUser")]
        public IActionResult Get(int userId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_userService.GetUserById(userId))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(userId, _userService.GetUserById(userId))
                        : _userService.GetUserById(userId)
                     );
        }

        // OPTIONS api/users
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/users
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateUser")]
        public IActionResult Post([FromBody] CreateUserDto userDto)
        {
            var userToReturn = _userService.CreateUser(userDto);
            var user = CreateLinks(userToReturn.Id, userToReturn);

            return CreatedAtRoute("GetUser",
                                  new { userId = user.Id },
                                  user);
        }

        // PUT api/users/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{userId}", Name = "UpdateUserPut")]
        public IActionResult Put(int userId, [FromBody] UpdateUserDto userDto)
        {
            _userService.UpdateUserPut(userId, userDto);
            return NoContent();
        }

        // PATCH api/users/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{userId}", Name = "UpdateUserPatch")]
        public IActionResult Patch(int userId, [FromBody] JsonPatchDocument<UpdateUserDto> patchDocument)
        {
            _userService.UpdateUserPatch(userId, patchDocument);
            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{userId}", Name = "DeleteUser")]
        public IActionResult Delete(int userId)
        {
            _userService.DeleteUser(userId);
            return NoContent();
        }
    }
}
