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
    [Route("api/carServices")]
    [ApiController]
    public class CarServicesController : ControllerBase
    {
        #region FIELDS

        private readonly ICarServiceService _carServiceService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarServicesController(ICarServiceService carService)
        {
            _carServiceService = carService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private CarServiceDto CreateLinks(int carServiceId, CarServiceDto carServiceDto)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetCarService", new {carServiceId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateCarService", new {}),
                    "create_carService",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateCarServicePut", new {carServiceId}),
                    "update_carService",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateCarServicePatch", new {carServiceId}),
                    "update_carService",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteCarService", new {carServiceId}),
                    "delete_carService",
                    "DELETE"
                )
            };

            carServiceDto.Links = links;

            return carServiceDto;
        }

        private string CreateResourceUri(SearchCarServiceDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetCarServices",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, carServiceName = search.CarServiceName }),
                ResourceUriType.NextPage => Url.Link("GetCarServices",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, carServiceName = search.CarServiceName }),
                ResourceUriType.Current => Url.Link("GetCarServices",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, carServiceName = search.CarServiceName }),
                _ => Url.Link("GetCarServices",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, carServiceName = search.CarServiceName })
            };
        }

        private dynamic CreateLinksForList(SearchCarServiceDto search, IEnumerable<CarServiceDto> carServiceDto)
        {
            var links = new List<LinkDto>();

            var collection = carServiceDto.Select(carService => CreateLinks(carService.Id, carService)).ToList();

            var paginationData = _carServiceService.PaginationData(search);

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

        // GET: api/carServices
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetCarServices")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchCarServiceDto searchCarService, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_carServiceService.PaginationData(searchCarService));

            var carServices = _carServiceService.GetCarServices(searchCarService);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(carServices)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchCarService, carServices)
                        : carServices
                     );
        }

        // GET api/carServices/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{carServiceId}", Name = "GetCarService")]
        public IActionResult Get(int carServiceId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var carService = _carServiceService.GetCarServiceById(carServiceId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(carService)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(carServiceId, carService)
                        : carService 
                     );
        }

        // OPTIONS api/carServices
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/carServices
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateCarService")]
        public IActionResult Post([FromBody] CreateCarServiceDto carServiceDto)
        {
            var carServiceToReturn = _carServiceService.CreateCarService(carServiceDto);
            var carService = CreateLinks(carServiceToReturn.Id, carServiceToReturn);

            return CreatedAtRoute("GetCarService",
                                  new { carServiceId = carService.Id },
                                  carService);
        }

        // PUT api/carServices/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{carServiceId}", Name = "UpdateCarServicePut")]
        public IActionResult Put(int carServiceId, [FromBody] UpdateCarServiceDto carServiceDto)
        {
            _carServiceService.UpdateCarServicePut(carServiceId, carServiceDto);
            return NoContent();
        }

        // PATCH api/carServices/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{carServiceId}", Name = "UpdateCarServicePatch")]
        public IActionResult Patch(int carServiceId, [FromBody] JsonPatchDocument<UpdateCarServiceDto> patchDocument)
        {
            _carServiceService.UpdateCarServicePatch(carServiceId, patchDocument);
            return NoContent();
        }

        // DELETE api/carServices/5
        [HttpDelete("{carServiceId}", Name = "DeleteCarService")]
        public IActionResult Delete(int carServiceId)
        {
            _carServiceService.DeleteCarService(carServiceId);
            return NoContent();
        }
    }
}
