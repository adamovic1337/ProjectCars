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
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        #region FIELDS

        private readonly IStatusService _statusService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        #endregion CONSTRUCTORS

        #region METHODS
        
        private dynamic CreateLinks(int statusId, StatusDto statusDto)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetStatus", new {statusId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateStatus", new {}),
                    "create_status",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateStatusPut", new {statusId}),
                    "update_status",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateStatusPatch", new {statusId}),
                    "update_status",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteStatus", new {statusId}),
                    "delete_status",
                    "DELETE"
                )
            };

            var result = new
            {
                id = statusDto.Id,
                name = statusDto.Name,
                links
            };

            return result;
        }

        private string CreateResourceUri(SearchStatusDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetStatuses",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, statusName = search.StatusName }),
                ResourceUriType.NextPage => Url.Link("GetStatuses",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, statusName = search.StatusName }),
                ResourceUriType.Current => Url.Link("GetStatuses",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, statusName = search.StatusName }),
                _ => Url.Link("GetStatuses",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, statusName = search.StatusName })
            };
        }

        private dynamic CreateLinksForList(SearchStatusDto search, IEnumerable<StatusDto> statusDto)
        {
            var links = new List<LinkDto>();

            var collection = statusDto.Select(status => CreateLinks(status.Id, status)).ToList();

            var status = _statusService.PagedListStatus(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (status.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (status.HasNext)
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

        // GET: api/status
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetStatuses")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchStatusDto searchStatus, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_statusService.PagedListStatus(searchStatus));

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_statusService.GetStatus(searchStatus))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchStatus, _statusService.GetStatus(searchStatus))
                        : _statusService.GetStatus(searchStatus)
                     );
        }

        // GET api/status/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{statusId}", Name = "GetStatus")]
        public IActionResult Get(int statusId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_statusService.GetStatusById(statusId))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(statusId, _statusService.GetStatusById(statusId))
                        : _statusService.GetStatusById(statusId)
                     );
        }

        // OPTIONS api/status
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/status
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateStatus")]
        public IActionResult Post([FromBody] CreateStatusDto statusDto)
        {
            var statusToReturn = _statusService.CreateStatus(statusDto);
            var status = CreateLinks(statusToReturn.Id, statusToReturn);

            return CreatedAtRoute("GetStatus",
                                  new { statusId = status.id },
                                  status);
        }

        // PUT api/status/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{statusId}", Name = "UpdateStatusPut")]
        public IActionResult Put(int statusId, [FromBody] UpdateStatusDto statusDto)
        {
            _statusService.UpdateStatusPut(statusId, statusDto);
            return NoContent();
        }

        // PATCH api/status/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{statusId}", Name = "UpdateStatusPatch")]
        public IActionResult Patch(int statusId, [FromBody] JsonPatchDocument<UpdateStatusDto> patchDocument)
        {
            _statusService.UpdateStatusPatch(statusId, patchDocument);
            return NoContent();
        }

        // DELETE api/status/5
        [HttpDelete("{statusId}", Name = "DeleteStatus")]
        public IActionResult Delete(int statusId)
        {
            _statusService.DeleteStatus(statusId);
            return NoContent();
        }
    }
}
