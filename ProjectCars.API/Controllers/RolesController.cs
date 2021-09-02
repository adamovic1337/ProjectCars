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

        private RoleDto CreateLinks(int roleId, RoleDto roleDto)
        {
            var name = "Role";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new {roleId}),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {}),
                    $"Create_{name}",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new {roleId}),
                    $"Update_{name}",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new {roleId}),
                    $"Update_{name}",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}", new {roleId}),
                    $"Delete_{name}",
                    "DELETE"
                )
            };

            roleDto.Links = links;

            return roleDto;
        }

        private string CreateResourceUri(SearchRoleDto search, ResourceUriType type)
        {
            var name = "Roles";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, roleName = search.RoleName }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, roleName = search.RoleName }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, roleName = search.RoleName }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, roleName = search.RoleName })
            };
        }

        private dynamic CreateLinksForList(SearchRoleDto search, IEnumerable<RoleDto> roleDto)
        {
            var links = new List<LinkDto>();

            var collection = roleDto.Select(role => CreateLinks(role.Id, role)).ToList();

            var paginationData = _roleService.PaginationData(search);

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

        // GET: api/roles
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetRoles")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchRoleDto searchRole, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_roleService.PaginationData(searchRole));

            var roles = _roleService.GetRoles(searchRole);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(roles)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchRole, roles)
                        : roles
                     );
        }

        // GET api/roles/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{roleId}", Name = "GetRole")]
        public IActionResult Get(int roleId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var role = _roleService.GetRoleById(roleId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(role)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(roleId, role)
                        : role
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
                                  new { roleId = role.Id },
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