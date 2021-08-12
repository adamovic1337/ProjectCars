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
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetManufacturer", new {manufacturerId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateManufacturer", new {}),
                    "create_manufacturer",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateManufacturerPut", new {manufacturerId}),
                    "update_manufacturer",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateManufacturerPatch", new {manufacturerId}),
                    "update_manufacturer",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteManufacturer", new {manufacturerId}),
                    "delete_manufacturer",
                    "DELETE"
                )
            };

            manufacturerDto.Links = links;

            return manufacturerDto;
        }

        private string CreateResourceUri(SearchManufacturerDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetManufacturers",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, manufacturerName = search.ManufacturerName }),
                ResourceUriType.NextPage => Url.Link("GetManufacturers",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, manufacturerName = search.ManufacturerName }),
                ResourceUriType.Current => Url.Link("GetManufacturers",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, manufacturerName = search.ManufacturerName }),
                _ => Url.Link("GetManufacturers",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, manufacturerName = search.ManufacturerName })
            };
        }

        private dynamic CreateLinksForList(SearchManufacturerDto search, IEnumerable<ManufacturerDto> manufacturerDto)
        {
            var links = new List<LinkDto>();

            var collection = manufacturerDto.Select(manufacturer => CreateLinks(manufacturer.Id, manufacturer)).ToList();

            var manufacturers = _manufacturerService.PagedListManufacturers(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (manufacturers.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (manufacturers.HasNext)
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
        //[Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetManufacturers")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchManufacturerDto searchManufacturer, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_manufacturerService.PagedListManufacturers(searchManufacturer));

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_manufacturerService.GetManufacturers(searchManufacturer))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchManufacturer, _manufacturerService.GetManufacturers(searchManufacturer))
                        : _manufacturerService.GetManufacturers(searchManufacturer)
                     );
        }

        // GET api/manufacturers/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{manufacturerId}", Name = "GetManufacturer")]
        public IActionResult Get(int manufacturerId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_manufacturerService.GetManufacturerById(manufacturerId))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(manufacturerId, _manufacturerService.GetManufacturerById(manufacturerId))
                        : _manufacturerService.GetManufacturerById(manufacturerId)
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
        public IActionResult Put(int manufacturerId, [FromBody] UpdateManufacturerDto manufacturerDto)
        {
            _manufacturerService.UpdateManufacturerPut(manufacturerId, manufacturerDto);
            return NoContent();
        }

        // PATCH api/manufacturers/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{manufacturerId}", Name = "UpdateManufacturerPatch")]
        public IActionResult Patch(int manufacturerId, [FromBody] JsonPatchDocument<UpdateManufacturerDto> patchDocument)
        {
            _manufacturerService.UpdateManufacturerPatch(manufacturerId, patchDocument);
            return NoContent();
        }

        // DELETE api/manufacturers/5
        [HttpDelete("{manufacturerId}", Name = "DeleteManufacturer")]
        public IActionResult Delete(int manufacturerId)
        {
            _manufacturerService.DeleteManufacturer(manufacturerId);
            return NoContent();
        }
    }
}