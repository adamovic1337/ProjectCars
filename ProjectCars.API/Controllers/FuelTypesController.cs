﻿using Microsoft.AspNetCore.Authorization;
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
    [Route("api/fuelTypes")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class FuelTypesController : ControllerBase
    {
        #region FIELDS

        private readonly IFuelTypeService _fuelTypeService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public FuelTypesController(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private FuelTypeDto CreateLinks(int fuelTypeId, FuelTypeDto fuelTypeDto)
        {
            var name = "FuelType";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new {fuelTypeId}),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {}),
                    $"Create_{name}",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new {fuelTypeId}),
                    $"Update_{name}",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new {fuelTypeId}),
                    $"Update_{name}",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}Type", new {fuelTypeId}),
                    $"Delete_{name}",
                    "DELETE"
                )
            };

            fuelTypeDto.Links = links;

            return fuelTypeDto;
        }

        private string CreateResourceUri(SearchFuelTypeDto search, ResourceUriType type)
        {
            var name = "FuelTypes";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, fuelTypeName = search.FuelTypeName }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, fuelTypeName = search.FuelTypeName }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, fuelTypeName = search.FuelTypeName }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, fuelTypeName = search.FuelTypeName })
            };
        }

        private dynamic CreateLinksForList(SearchFuelTypeDto search, IEnumerable<FuelTypeDto> fuelTypeDto)
        {
            var links = new List<LinkDto>();

            var collection = fuelTypeDto.Select(fuelType => CreateLinks(fuelType.Id, fuelType)).ToList();

            var paginationData = _fuelTypeService.PaginationData(search);

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

        // GET: api/fuelTypes
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetfuelTypes")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchFuelTypeDto searchFuelType, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_fuelTypeService.PaginationData(searchFuelType));

            var fuelTypes = _fuelTypeService.GetFuelTypes(searchFuelType);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(fuelTypes)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchFuelType, fuelTypes)
                        : fuelTypes
                     );
        }

        // GET api/fuelTypes/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{fuelTypeId}", Name = "GetFuelType")]
        public IActionResult Get(int fuelTypeId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var fuelType = _fuelTypeService.GetFuelTypeById(fuelTypeId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(fuelType)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(fuelTypeId, fuelType)
                        : fuelType
                     );
        }

        // OPTIONS api/fuelTypes
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/fuelTypes
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateFuelType")]
        public IActionResult Post([FromBody] CreateFuelTypeDto fuelTypeDto)
        {
            var fuelTypeToReturn = _fuelTypeService.CreateFuelType(fuelTypeDto);
            var fuelType = CreateLinks(fuelTypeToReturn.Id, fuelTypeToReturn);

            return CreatedAtRoute("GetFuelType",
                                  new { fuelTypeId = fuelType.Id },
                                  fuelType);
        }

        // PUT api/fuelTypes/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{fuelTypeId}", Name = "UpdateFuelTypePut")]
        public IActionResult Put(int fuelTypeId, [FromBody] UpdateFuelTypeDto fuelTypeDto)
        {
            _fuelTypeService.UpdateFuelTypePut(fuelTypeId, fuelTypeDto);
            return NoContent();
        }

        // PATCH api/fuelTypes/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{fuelTypeId}", Name = "UpdateFuelTypePatch")]
        public IActionResult Patch(int fuelTypeId, [FromBody] JsonPatchDocument<UpdateFuelTypeDto> patchDocument)
        {
            _fuelTypeService.UpdateFuelTypePatch(fuelTypeId, patchDocument);
            return NoContent();
        }

        // DELETE api/fuelTypes/5
        [HttpDelete("{fuelTypeId}", Name = "DeleteFuelType")]
        public IActionResult Delete(int fuelTypeId)
        {
            _fuelTypeService.DeleteFuelType(fuelTypeId);
            return NoContent();
        }
    }
}
