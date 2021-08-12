﻿using Microsoft.AspNetCore.JsonPatch;
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

            carModelDto.Links = links;

            return carModelDto;
        }

        private string CreateResourceUri(SearchCarModelDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetCarModels",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, carModelName = search.CarModelName }),
                ResourceUriType.NextPage => Url.Link("GetCarModels",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, carModelName = search.CarModelName }),
                ResourceUriType.Current => Url.Link("GetCarModels",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, carModelName = search.CarModelName }),
                _ => Url.Link("GetCarModels",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, carModelName = search.CarModelName })
            };
        }

        private dynamic CreateLinksForList(SearchCarModelDto search, IEnumerable<CarModelDto> carModelDto)
        {
            var links = new List<LinkDto>();

            var collection = carModelDto.Select(carModel => CreateLinks(carModel.Id, carModel)).ToList();

            var carModels = _carModelService.PagedListCarModels(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (carModels.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (carModels.HasNext)
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
        public IActionResult Get([FromQuery] SearchCarModelDto searchCarModel, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_carModelService.PagedListCarModels(searchCarModel));

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_carModelService.GetCarModels(searchCarModel))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchCarModel, _carModelService.GetCarModels(searchCarModel))
                        : _carModelService.GetCarModels(searchCarModel)
                     );
        }

        // GET api/carModels/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{carModelId}", Name = "GetCarModel")]
        public IActionResult Get(int carModelId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_carModelService.GetCarModelById(carModelId))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(carModelId, _carModelService.GetCarModelById(carModelId))
                        : _carModelService.GetCarModelById(carModelId)
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
            var carModel = CreateLinks(carModelToReturn.Id, carModelToReturn);

            return CreatedAtRoute("GetCarModel",
                                  new { carModelId = carModel.Id },
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

        // PATCH api/carModels/5
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