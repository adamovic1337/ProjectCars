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
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        #region FIELDS

        private readonly IRoleService _roleService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private dynamic CreateLinks(int roleId, RoleDto roleDto)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetRole", new {roleId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateRole", new {}),
                    "create_role",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateRolePut", new {roleId}),
                    "update_role",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateRolePatch", new {roleId}),
                    "update_role",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteRole", new {roleId}),
                    "delete_role",
                    "DELETE"
                )
            };

            var result = new
            {
                id = roleDto.Id,
                name = roleDto.Name,
                links
            };

            return result;
        }

        private string CreateResourceUri(SearchRoleDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetRoles",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, roleName = search.RoleName }),
                ResourceUriType.NextPage => Url.Link("GetRoles",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, roleName = search.RoleName }),
                ResourceUriType.Current => Url.Link("GetRoles",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, roleName = search.RoleName }),
                _ => Url.Link("GetRoles",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, roleName = search.RoleName })
            };
        }

        private dynamic CreateLinksForList(SearchRoleDto search, IEnumerable<RoleDto> roleDto)
        {
            var links = new List<LinkDto>();

            var collection = roleDto.Select(role => CreateLinks(role.Id, role)).ToList();

            var roles = _roleService.PagedListRoles(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (roles.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (roles.HasNext)
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

        // GET: api/roles
        //[Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetRoles")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchRoleDto searchRole, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_roleService.PagedListRoles(searchRole));

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_roleService.GetRoles(searchRole))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchRole, _roleService.GetRoles(searchRole))
                        : _roleService.GetRoles(searchRole)
                     );
        }

        // GET api/roles/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{roleId}", Name = "GetRole")]
        public IActionResult Get(int roleId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_roleService.GetRoleById(roleId))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(roleId, _roleService.GetRoleById(roleId))
                        : _roleService.GetRoleById(roleId)
                     );
        }

        // OPTIONS api/roles
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/roles
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateRole")]
        public IActionResult Post([FromBody] CreateRoleDto roleDto)
        {
            var roleToReturn = _roleService.CreateRole(roleDto);
            var role = CreateLinks(roleToReturn.Id, roleToReturn);

            return CreatedAtRoute("GetRole",
                                  new { roleId = role.id },
                                  role);
        }

        // PUT api/roles/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{roleId}", Name = "UpdateRolePut")]
        public IActionResult Put(int roleId, [FromBody] UpdateRoleDto roleDto)
        {
            _roleService.UpdateRolePut(roleId, roleDto);
            return NoContent();
        }

        // PATCH api/roles/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{roleId}", Name = "UpdateRolePatch")]
        public IActionResult Patch(int roleId, [FromBody] JsonPatchDocument<UpdateRoleDto> patchDocument)
        {
            _roleService.UpdateRolePatch(roleId, patchDocument);
            return NoContent();
        }

        // DELETE api/roles/5
        [HttpDelete("{roleId}", Name = "DeleteRole")]
        public IActionResult Delete(int roleId)
        {
            _roleService.DeleteRole(roleId);
            return NoContent();
        }
    }
}