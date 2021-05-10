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
using System.Text.Json;

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

        #endregion

        #region METHODS

        private void PaginationMetadata(SearchCarModelDto searchCarModel)
        {
            var carModels = _carModelService.PagedListCarModels(searchCarModel);

            var paginationMetadata = new
            {
                totalCount = carModels.TotalCount,
                pageSize = carModels.PageSize,
                currentPage = carModels.CurrentPage,
                totalPages = carModels.TotalPages,
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
        }

        private dynamic CreateLinksForCarModel(int carModelId, CarModelDto carModelDto)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetCarModel", new {carModelId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateCarModel", new {}),
                    "create_carModel",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateCarModelPut", new {carModelId}),
                    "update_carModel",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateCarModelPatch", new {carModelId}),
                    "update_carModel",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteCarModel", new {carModelId}),
                    "delete_carModel",
                    "DELETE"
                )
            };

            var result = new
            {
                id = carModelDto.Id,
                name = carModelDto.Name,
                engineId = carModelDto.EngineId,
                manufacturerId = carModelDto.ManufacturerId,
                links
            };

            return result;
        }

        private string CreateResourceUri(SearchCarModelDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetCarModels",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, carModel = search.CarModelName }),
                ResourceUriType.NextPage => Url.Link("GetCarModels",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, carModel = search.CarModelName }),
                ResourceUriType.Current => Url.Link("GetCarModels",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, carModel = search.CarModelName }),
                _ => Url.Link("GetCarModels",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, carModel = search.CarModelName })
            };
        }

        private dynamic CreateLinksForCarModels(SearchCarModelDto searchCarModel, IEnumerable<CarModelDto> carModelDto)
        {
            var links = new List<LinkDto>();

            var collection = carModelDto.Select(carModel => CreateLinksForCarModel(carModel.Id, carModel)).ToList();

            var carModels = _carModelService.PagedListCarModels(searchCarModel);

            links.Add(
                new LinkDto(
                    CreateResourceUri(searchCarModel, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (carModels.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(searchCarModel, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (carModels.HasNext)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(searchCarModel, ResourceUriType.NextPage),
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
        public IActionResult Get([FromQuery] SearchCarModelDto searchCarModel, [FromHeader(Name = "Accept")] string mediaType)
        {
            PaginationMetadata(searchCarModel);

            if (!MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType))
                return Ok(_carModelService.GetCarModels(searchCarModel));

            return Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json" ?
                CreateLinksForCarModels(searchCarModel, _carModelService.GetCarModels(searchCarModel)) : _carModelService.GetCarModels(searchCarModel)
            );
        }

        // GET api/carModels/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{carModelId}", Name = "GetCarModel")]
        public IActionResult Get(int carModelId, [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType))
                return Ok(_carModelService.GetCarModelById(carModelId));

            return Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json" ?
                CreateLinksForCarModel(carModelId, _carModelService.GetCarModelById(carModelId)) : _carModelService.GetCarModelById(carModelId)
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
        public IActionResult Post([FromBody] CreateCarModelDto carModelDto)
        {
            var carModelToReturn = _carModelService.CreateCarModel(carModelDto);
            var carModel = CreateLinksForCarModel(carModelToReturn.Id, carModelToReturn);

            return CreatedAtRoute("GetCarModel",
                new { carModelId = carModel.id },
                carModel);
        }

        // PUT api/carModels/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{carModelId}", Name = "UpdateCarModelPut")]
        public IActionResult Put(int carModelId, [FromBody] UpdateCarModelDto carModelDto)
        {
            _carModelService.UpdateCarModelPut(carModelId, carModelDto);
            return NoContent();
        }

        // PATCH api/roles/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{carModelId}", Name = "UpdateCarModelPatch")]
        public IActionResult Patch(int carModelId, [FromBody] JsonPatchDocument<UpdateCarModelDto> patchDocument)
        {
            _carModelService.UpdateCarModelPatch(carModelId, patchDocument);
            return NoContent();
        }

        // DELETE api/carModels/5
        [HttpDelete("{carModelId}", Name = "DeleteCarModel")]
        public IActionResult Delete(int carModelId)
        {
            _carModelService.DeleteCarModel(carModelId);
            return NoContent();
        }
    }
}
