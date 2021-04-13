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
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        #region FIELDS

        private readonly ICityService _cityService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private void PaginationMetadata(SearchCityDto searchCity)
        {
            var cities = _cityService.PagedListCities(searchCity);

            var paginationMetadata = new
            {
                totalCount = cities.TotalCount,
                pageSize = cities.PageSize,
                currentPage = cities.CurrentPage,
                totalPages = cities.TotalPages,
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
        }

        private dynamic CreateLinksForCity(int cityId, CityDto cityDto)
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
                countryId = cityDto.CountryId,
                links
            };

            return result;
        }

        private string CreateResourceUri(SearchCityDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetCountries",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, roleName = search.CityName }),
                ResourceUriType.NextPage => Url.Link("GetCountries",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, roleName = search.CityName }),
                ResourceUriType.Current => Url.Link("GetCountries",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, roleName = search.CityName }),
                _ => Url.Link("GetCountries",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, roleName = search.CityName })
            };
        }

        private dynamic CreateLinksForCountries(SearchCityDto searchCity, IEnumerable<CityDto> cityDto)
        {
            var links = new List<LinkDto>();

            var collection = cityDto.Select(city => CreateLinksForCity(city.Id, city)).ToList();

            var cities = _cityService.PagedListCities(searchCity);

            links.Add(
                new LinkDto(
                    CreateResourceUri(searchCity, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (cities.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(searchCity, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (cities.HasNext)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(searchCity, ResourceUriType.NextPage),
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
            PaginationMetadata(searchCity);

            if (!MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType))
                return Ok(_cityService.GetCountries(searchCity));

            return Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json" ?
                CreateLinksForCountries(searchCity, _cityService.GetCountries(searchCity)) : _cityService.GetCountries(searchCity)
            );
        }

        // GET api/cities/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{cityId}", Name = "GetCity")]
        public IActionResult Get(int cityId, [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType))
                return Ok(_cityService.GetCityById(cityId));

            return Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json" ?
                CreateLinksForCity(cityId, _cityService.GetCityById(cityId)) : _cityService.GetCityById(cityId)
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
            var city = CreateLinksForCity(cityToReturn.Id, cityToReturn);

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

        // PATCH api/roles/5
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