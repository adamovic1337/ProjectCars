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
    [Route("api/cities")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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

        private CityDto CreateLinks(int cityId, CityDto cityDto)
        {
            var name = "City";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new {cityId}),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {}),
                    $"Create_city",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new {cityId}),
                    $"Update_city",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new {cityId}),
                    $"Update_city",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}", new {cityId}),
                    $"Delete_city",
                    "DELETE"
                )
            };

            cityDto.Links = links;

            return cityDto;
        }

        private string CreateResourceUri(SearchCityDto search, ResourceUriType type)
        {
            var name = "Cities";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, cityName = search.CityName }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, cityName = search.CityName }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, cityName = search.CityName }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, cityName = search.CityName })
            };
        }

        private dynamic CreateLinksForList(SearchCityDto search, IEnumerable<CityDto> cityDto)
        {
            var links = new List<LinkDto>();

            var collection = cityDto.Select(city => CreateLinks(city.Id, city)).ToList();

            var paginationData = _cityService.PaginationData(search);

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

        // GET: api/cities
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetCities")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchCityDto searchCity, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_cityService.PaginationData(searchCity));

            var cities = _cityService.GetCities(searchCity);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(cities)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchCity, cities)
                        : cities
                     );
        }

        // GET api/cities/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{cityId}", Name = "GetCity")]        
        public IActionResult Get(int cityId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var city = _cityService.GetCityById(cityId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(city)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(cityId, city)
                        : city
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
                                  new { cityId = city.Id },
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
