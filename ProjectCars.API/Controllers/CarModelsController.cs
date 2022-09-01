using Microsoft.AspNetCore.Authorization;
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
    [Route("api/carModels")]
    [ApiController]    
    public class CarModelsController : ControllerBase
    {
        #region FIELDS

        private readonly ICarModelService _carModelService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarModelsController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private CarModelDto CreateLinks(int carModelId, CarModelDto carModelDto)
        {
            var name = "CarModel";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new {carModelId}),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {}),
                    $"Create_{name}",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new {carModelId}),
                    $"Update_{name}",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new {carModelId}),
                    $"Update_{name}",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}", new {carModelId}),
                    $"Delete_{name}",
                    "DELETE"
                )
            };

            carModelDto.Links = links;

            return carModelDto;
        }

        private string CreateResourceUri(SearchCarModelDto search, ResourceUriType type)
        {
            var name = "CarModels";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, carModelName = search.CarModelName }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, carModelName = search.CarModelName }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, carModelName = search.CarModelName }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, carModelName = search.CarModelName })
            };
        }

        private dynamic CreateLinksForList(SearchCarModelDto search, IEnumerable<CarModelDto> carModelDto)
        {
            var links = new List<LinkDto>();

            var collection = carModelDto.Select(carModel => CreateLinks(carModel.Id, carModel)).ToList();

            var paginationData = _carModelService.PaginationData(search);

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

        // GET: api/carModels
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetCarModels")]
        [HttpHead]
        [Authorize(Roles = "Admin,User,ServiceOwner")]
        public IActionResult Get([FromQuery] SearchCarModelDto searchCarModel, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_carModelService.PaginationData(searchCarModel));

            var carModels = _carModelService.GetCarModels(searchCarModel);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(carModels)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchCarModel, carModels)
                        : carModels
                     );
        }

        // GET: api/carModels
        [HttpGet("ddl/{manufacturerId}")]
        [Authorize(Roles = "Admin,User,ServiceOwner")]
        public IActionResult Get(int manufacturerId)
        {          
            var carModels = _carModelService.GetCarModelsByManufacturer(manufacturerId);

            return Ok(carModels);
        }

        // GET api/carModels/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{carModelId}", Name = "GetCarModel")]
        [Authorize(Roles = "Admin")]
        public IActionResult Get(int carModelId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var carModel = _carModelService.GetCarModelById(carModelId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(carModel)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(carModelId, carModel)
                        : carModel
                     );
        }

        // OPTIONS api/carModels
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/carModels
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateCarModel")]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] CreateCarModelDto carModelDto)
        {
            var carModelToReturn = _carModelService.CreateCarModel(carModelDto);
            var carModel = CreateLinks(carModelToReturn.Id, carModelToReturn);

            return CreatedAtRoute("GetCarModel",
                                  new { carModelId = carModel.Id },
                                  carModel);
        }

        // PUT api/carModels/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{carModelId}", Name = "UpdateCarModelPut")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int carModelId, [FromBody] UpdateCarModelDto carModelDto)
        {
            _carModelService.UpdateCarModelPut(carModelId, carModelDto);
            return NoContent();
        }

        // PATCH api/carModels/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{carModelId}", Name = "UpdateCarModelPatch")]
        [Authorize(Roles = "Admin")]
        public IActionResult Patch(int carModelId, [FromBody] JsonPatchDocument<UpdateCarModelDto> patchDocument)
        {
            _carModelService.UpdateCarModelPatch(carModelId, patchDocument);
            return NoContent();
        }

        // DELETE api/carModels/5
        [HttpDelete("{carModelId}", Name = "DeleteCarModel")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int carModelId)
        {
            _carModelService.DeleteCarModel(carModelId);
            return NoContent();
        }
    }
}
