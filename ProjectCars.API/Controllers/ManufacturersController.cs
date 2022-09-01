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
    [Route("api/manufacturers")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        #region FIELDS

        private readonly IManufacturerService _manufacturerService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private ManufacturerDto CreateLinks(int manufacturerId, ManufacturerDto manufacturerDto)
        {
            var name = "Manufacturer";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new {manufacturerId}),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {}),
                    $"Create_{name}",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new {manufacturerId}),
                    $"Update_{name}",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new {manufacturerId}),
                    $"Update_{name}",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}", new {manufacturerId}),
                    $"Delete_{name}",
                    "DELETE"
                )
            };

            manufacturerDto.Links = links;

            return manufacturerDto;
        }

        private string CreateResourceUri(SearchManufacturerDto search, ResourceUriType type)
        {
            var name = "Manufacturers";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, manufacturerName = search.ManufacturerName }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, manufacturerName = search.ManufacturerName }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, manufacturerName = search.ManufacturerName }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, manufacturerName = search.ManufacturerName })
            };
        }

        private dynamic CreateLinksForList(SearchManufacturerDto search, IEnumerable<ManufacturerDto> manufacturerDto)
        {
            var links = new List<LinkDto>();

            var collection = manufacturerDto.Select(manufacturer => CreateLinks(manufacturer.Id, manufacturer)).ToList();

            var paginationData = _manufacturerService.PaginationData(search);

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

        // GET: api/manufacturers
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetManufacturers")]
        [HttpHead]
        [Authorize(Roles = "Admin,User,ServiceOwner")]
        public IActionResult Get([FromQuery] SearchManufacturerDto searchManufacturer, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_manufacturerService.PaginationData(searchManufacturer));

            var manufacturers = _manufacturerService.GetManufacturers(searchManufacturer);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(manufacturers)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchManufacturer, manufacturers)
                        : manufacturers
                     );
        }

        // GET api/manufacturers/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{manufacturerId}", Name = "GetManufacturer")]
        [Authorize(Roles = "Admin")]
        public IActionResult Get(int manufacturerId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var manufacturer = _manufacturerService.GetManufacturerById(manufacturerId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(manufacturer)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(manufacturerId, manufacturer)
                        : manufacturer
                     );
        }

        // OPTIONS api/manufacturers
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/manufacturers
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateManufacturers")]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] CreateManufacturerDto manufacturerDto)
        {
            var manufacturerToReturn = _manufacturerService.CreateManufacturer(manufacturerDto);
            var manufacturer = CreateLinks(manufacturerToReturn.Id, manufacturerToReturn);

            return CreatedAtRoute("GetManufacturer",
                                  new { manufacturerId = manufacturer.Id },
                                  manufacturer);
        }

        // PUT api/manufacturers/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{manufacturerId}", Name = "UpdateManufacturerPut")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int manufacturerId, [FromBody] UpdateManufacturerDto manufacturerDto)
        {
            _manufacturerService.UpdateManufacturerPut(manufacturerId, manufacturerDto);
            return NoContent();
        }

        // PATCH api/manufacturers/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{manufacturerId}", Name = "UpdateManufacturerPatch")]
        [Authorize(Roles = "Admin")]
        public IActionResult Patch(int manufacturerId, [FromBody] JsonPatchDocument<UpdateManufacturerDto> patchDocument)
        {
            _manufacturerService.UpdateManufacturerPatch(manufacturerId, patchDocument);
            return NoContent();
        }

        // DELETE api/manufacturers/5
        [HttpDelete("{manufacturerId}", Name = "DeleteManufacturer")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int manufacturerId)
        {
            _manufacturerService.DeleteManufacturer(manufacturerId);
            return NoContent();
        }
    }
}