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
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        #region FIELDS

        private readonly ICityService _cityService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private dynamic CreateLinks(int cityId, CityDto cityDto)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetCity", new {cityId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateCity", new {}),
                    "create_city",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateCityPut", new {cityId}),
                    "update_city",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateCityPatch", new {cityId}),
                    "update_city",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteCity", new {cityId}),
                    "delete_city",
                    "DELETE"
                )
            };

            var result = new
            {
                id = cityDto.Id,
                name = cityDto.Name,
                links
            };

            return result;
        }

        private string CreateResourceUri(SearchCityDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetCities",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, cityName = search.CityName }),
                ResourceUriType.NextPage => Url.Link("GetCities",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, cityName = search.CityName }),
                ResourceUriType.Current => Url.Link("GetCities",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, cityName = search.CityName }),
                _ => Url.Link("GetCities",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, cityName = search.CityName })
            };
        }

        private dynamic CreateLinksForList(SearchCityDto search, IEnumerable<CityDto> cityDto)
        {
            var links = new List<LinkDto>();

            var collection = cityDto.Select(city => CreateLinks(city.Id, city)).ToList();

            var cities = _cityService.PagedListCities(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (cities.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (cities.HasNext)
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

        // GET: api/cities
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetCities")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchCityDto searchCity, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_cityService.PagedListCities(searchCity));

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_cityService.GetCities(searchCity))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchCity, _cityService.GetCities(searchCity))
                        : _cityService.GetCities(searchCity)
                     );
        }

        // GET api/cities/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{cityId}", Name = "GetCity")]
        public IActionResult Get(int cityId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_cityService.GetCityById(cityId))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(cityId, _cityService.GetCityById(cityId))
                        : _cityService.GetCityById(cityId)
                     );
        }

        // OPTIONS api/cities
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/cities
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateCity")]
        public IActionResult Post([FromBody] CreateCityDto cityDto)
        {
            var cityToReturn = _cityService.CreateCity(cityDto);
            var city = CreateLinks(cityToReturn.Id, cityToReturn);

            return CreatedAtRoute("GetCity",
                                  new { cityId = city.id },
                                  city);
        }

        // PUT api/cities/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{cityId}", Name = "UpdateCityPut")]
        public IActionResult Put(int cityId, [FromBody] UpdateCityDto cityDto)
        {
            _cityService.UpdateCityPut(cityId, cityDto);
            return NoContent();
        }

        // PATCH api/cities/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{cityId}", Name = "UpdateCityPatch")]
        public IActionResult Patch(int cityId, [FromBody] JsonPatchDocument<UpdateCityDto> patchDocument)
        {
            _cityService.UpdateCityPatch(cityId, patchDocument);
            return NoContent();
        }

        // DELETE api/cities/5
        [HttpDelete("{cityId}", Name = "DeleteCity")]
        public IActionResult Delete(int cityId)
        {
            _cityService.DeleteCity(cityId);
            return NoContent();
        }
    }
}
