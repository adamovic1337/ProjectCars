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
    [Route("api")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        #region FIELDS

        private readonly IMaintenanceService _maintenanceService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public MaintenancesController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        #endregion CONSTRUCTORS

        #region METHODS
        // for Cars route
        private MaintenanceDto CreateLinksForCars(int userId, int carId, int maintenanceId, MaintenanceDto maintenanceDto)
        {
            var name = "Maintenance";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new { userId, carId, maintenanceId }),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {userId, carId}),
                    $"Create_{name}",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new { userId, carId, maintenanceId }),
                    $"Update_{name}",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new { userId, carId, maintenanceId }),
                    $"Update_{name}",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}", new { userId, carId, maintenanceId }),
                    $"Delete_{name}",
                    "DELETE"
                )
            };

            maintenanceDto.Links = links;

            return maintenanceDto;
        }
        // for Cars route
        private string CreateResourceUriForCars(SearchMaintenanceDto search, ResourceUriType type)
        {
            var name = "MaintenancesForCars";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, dateFrom = search.DateFrom, dateTo = search.DateTo }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, dateFrom = search.DateFrom, dateTo = search.DateTo }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, dateFrom = search.DateFrom, dateTo = search.DateTo }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, dateFrom = search.DateFrom, dateTo = search.DateTo })
            };
        }
        // for Cars route
        private dynamic CreateLinksForListForCars(int userId, int carId, SearchMaintenanceDto search, IEnumerable<MaintenanceDto> maintenanceDto)
        {
            var links = new List<LinkDto>();

            var collection = maintenanceDto.Select(maintenance => CreateLinksForCars(userId, carId, maintenance.Id, maintenance)).ToList();

            var paginationData = _maintenanceService.PaginationData(userId, carId,search);

            links.Add(
                new LinkDto(
                    CreateResourceUriForCars(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (paginationData.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUriForCars(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (paginationData.HasNext)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUriForCars(search, ResourceUriType.NextPage),
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

        private MaintenanceDto CreateLinks(int carServiceId, int maintenanceId, MaintenanceDto maintenanceDto)
        {
            var name = "Maintenance";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new { carServiceId, maintenanceId }),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {carServiceId}),
                    $"Create_{name}",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new { carServiceId, maintenanceId }),
                    $"Update_{name}",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new { carServiceId, maintenanceId }),
                    $"Update_{name}",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}", new { carServiceId, maintenanceId }),
                    $"Delete_{name}",
                    "DELETE"
                )
            };

            maintenanceDto.Links = links;

            return maintenanceDto;
        }

        private string CreateResourceUri(SearchMaintenanceDto search, ResourceUriType type)
        {
            var name = "Maintenances";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, dateFrom = search.DateFrom, dateTo = search.DateTo }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, dateFrom = search.DateFrom, dateTo = search.DateTo }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, dateFrom = search.DateFrom, dateTo = search.DateTo }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, dateFrom = search.DateFrom, dateTo = search.DateTo })
            };
        }

        private dynamic CreateLinksForList(int carServiceId, SearchMaintenanceDto search, IEnumerable<MaintenanceDto> maintenanceDto)
        {
            var links = new List<LinkDto>();

            var collection = maintenanceDto.Select(maintenance => CreateLinks(carServiceId, maintenance.Id, maintenance)).ToList();

            var paginationData = _maintenanceService.PaginationData(carServiceId,search);

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

        // GET: api/users/1/cars/1/maintenances
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(template: "users/{userId}/cars/{carId}/maintenances", Name = "GetMaintenancesForCars")]
        [HttpHead("users/{userId}/cars/{carId}/maintenances")]
        public IActionResult Get(int userId, int carId, [FromQuery] SearchMaintenanceDto searchCar, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_maintenanceService.PaginationData(userId, carId, searchCar));

            var cars = _maintenanceService.GetMaintenances(userId, carId, searchCar);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(cars)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForListForCars(userId, carId, searchCar, cars)
                        : cars
                     );
        }

        // GET: api/carServices/1/maintenances
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(template: "carServices/{carServiceId}/maintenances", Name = "GetMaintenances")]
        [HttpHead("carServices/{carServiceId}/maintenances")]
        public IActionResult Get(int carServiceId, [FromQuery] SearchMaintenanceDto searchCar, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_maintenanceService.PaginationData(carServiceId, searchCar));

            var maintenances = _maintenanceService.GetMaintenances(carServiceId, searchCar);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(maintenances)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(carServiceId, searchCar, maintenances)
                        : maintenances
                     );
        }

        // GET api/carServices/1/maintenances/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(template: "carServices/{carServiceId}/maintenances/{maintenanceId}", Name = "GetMaintenance")]
        public IActionResult Get(int carServiceId, int maintenanceId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var maintenance = _maintenanceService.GetMaintenanceById(carServiceId, maintenanceId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(maintenance)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(carServiceId, maintenanceId, maintenance)
                        : maintenance
                     );
        }

        // OPTIONS api/carServices/1/maintenances
        [HttpOptions("carServices/{carServiceId}/maintenances")]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/carServices/1/maintenances
        [Consumes("application/json", "application/xml")]
        [HttpPost(template: "carServices/{carServiceId}/maintenances", Name = "CreateMaintenance")]
        public IActionResult Post(int carServiceId, [FromBody] CreateMaintenanceDto maintenanceDto)
        {
            var maintenanceToReturn = _maintenanceService.CreateMaintenance(carServiceId, maintenanceDto);
            var maintenance = CreateLinks(carServiceId, maintenanceToReturn.Id, maintenanceToReturn);

            return CreatedAtRoute("GetMaintenance",
                                  new { carServiceId, maintenanceId = maintenance.Id },
                                  maintenance);
        }

        // PUT api/carServices/1/maintenances/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("carServices/{carServiceId}/maintenances/{maintenanceId}", Name = "UpdateMaintenancePut")]
        public IActionResult Put(int carServiceId, int maintenanceId, [FromBody] UpdateMaintenanceDto maintenanceDto)
        {
            _maintenanceService.UpdateMaintenancePut(carServiceId, maintenanceId, maintenanceDto);
            return NoContent();
        }

        // PATCH api/carServices/1/maintenances/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("carServices/{carServiceId}/maintenances/{maintenanceId}", Name = "UpdateMaintenancePatch")]
        public IActionResult Patch(int carServiceId, int maintenanceId, [FromBody] JsonPatchDocument<UpdateMaintenanceDto> patchDocument)
        {
            _maintenanceService.UpdateMaintenancePatch(carServiceId, maintenanceId, patchDocument);
            return NoContent();
        }

        // DELETE api/carServices/1/maintenances/5
        [HttpDelete("carServices/{carServiceId}/maintenances/{maintenanceId}", Name = "DeleteMaintenance")]
        public IActionResult Delete(int carServiceId, int maintenanceId)
        {
            _maintenanceService.DeleteMaintenance(carServiceId, maintenanceId);
            return NoContent();
        }

    }
}
