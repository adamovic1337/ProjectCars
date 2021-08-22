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
    [Route("api/serviceRequests")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        #region FIELDS

        private readonly IServiceRequestService _serviceRequestService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public ServiceRequestsController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private ServiceRequestDto CreateLinks(int serviceRequestId, ServiceRequestDto serviceRequestDto)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetServiceRequest", new {serviceRequestId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateServiceRequest", new {}),
                    "create_serviceRequest",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateServiceRequestPut", new {serviceRequestId}),
                    "update_serviceRequest",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateServiceRequestPatch", new {serviceRequestId}),
                    "update_serviceRequest",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteServiceRequest", new {serviceRequestId}),
                    "delete_serviceRequest",
                    "DELETE"
                )
            };

            serviceRequestDto.Links = links;

            return serviceRequestDto;
        }

        private string CreateResourceUri(SearchServiceRequestDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetServiceRequests",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, status = search.Status }),
                ResourceUriType.NextPage => Url.Link("GetServiceRequests",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, status = search.Status }),
                ResourceUriType.Current => Url.Link("GetServiceRequests",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, status = search.Status }),
                _ => Url.Link("GetServiceRequests",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, status = search.Status })
            };
        }

        private dynamic CreateLinksForList(SearchServiceRequestDto search, IEnumerable<ServiceRequestDto> serviceRequestDto)
        {
            var links = new List<LinkDto>();

            var collection = serviceRequestDto.Select(serviceRequest => CreateLinks(serviceRequest.Id, serviceRequest)).ToList();

            var serviceRequests = _serviceRequestService.PagedListServiceRequests(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (serviceRequests.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (serviceRequests.HasNext)
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

        // GET: api/serviceRequests
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetServiceRequests")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchServiceRequestDto searchServiceRequest, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_serviceRequestService.PagedListServiceRequests(searchServiceRequest));

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_serviceRequestService.GetServiceRequests(searchServiceRequest))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchServiceRequest, _serviceRequestService.GetServiceRequests(searchServiceRequest))
                        : _serviceRequestService.GetServiceRequests(searchServiceRequest)
                     );
        }

        // GET api/serviceRequests/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{serviceRequestId}", Name = "GetServiceRequest")]
        public IActionResult Get(int serviceRequestId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_serviceRequestService.GetServiceRequestById(serviceRequestId))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(serviceRequestId, _serviceRequestService.GetServiceRequestById(serviceRequestId))
                        : _serviceRequestService.GetServiceRequestById(serviceRequestId)
                     );
        }

        // OPTIONS api/serviceRequests
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/serviceRequests
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateServiceRequest")]
        public IActionResult Post([FromBody] CreateServiceRequestDto serviceRequestDto)
        {
            var serviceRequestToReturn = _serviceRequestService.CreateServiceRequest(serviceRequestDto);
            var serviceRequest = CreateLinks(serviceRequestToReturn.Id, serviceRequestToReturn);

            return CreatedAtRoute("GetServiceRequest",
                                  new { serviceRequestId = serviceRequest.Id },
                                  serviceRequest);
        }

        // PUT api/serviceRequests/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{serviceRequestId}", Name = "UpdateServiceRequestPut")]
        public IActionResult Put(int serviceRequestId, [FromBody] UpdateServiceRequestDto roleDto)
        {
            _serviceRequestService.UpdateServiceRequestPut(serviceRequestId, roleDto);
            return NoContent();
        }

        // PATCH api/serviceRequests/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{serviceRequestId}", Name = "UpdateServiceRequestPatch")]
        public IActionResult Patch(int serviceRequestId, [FromBody] JsonPatchDocument<UpdateServiceRequestDto> patchDocument)
        {
            _serviceRequestService.UpdateServiceRequestPatch(serviceRequestId, patchDocument);
            return NoContent();
        }

        // DELETE api/serviceRequests/5
        [HttpDelete("{serviceRequestId}", Name = "DeleteServiceRequest")]
        public IActionResult Delete(int serviceRequestId)
        {
            _serviceRequestService.DeleteServiceRequest(serviceRequestId);
            return NoContent();
        }
    }
}