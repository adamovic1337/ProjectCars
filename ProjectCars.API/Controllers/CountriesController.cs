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
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        #region FIELDS

        private readonly ICountryService _countryService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private dynamic CreateLinks(int countryId, CountryDto countryDto)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetCountry", new {countryId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateCountry", new {}),
                    "create_country",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateCountryPut", new {countryId}),
                    "update_country",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateCountryPatch", new {countryId}),
                    "update_country",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteCountry", new {countryId}),
                    "delete_country",
                    "DELETE"
                )
            };

            var result = new
            {
                id = countryDto.Id,
                name = countryDto.Name,
                links
            };

            return result;
        }

        private string CreateResourceUri(SearchCountryDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetCountries",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, countryName = search.CountryName }),
                ResourceUriType.NextPage => Url.Link("GetCountries",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, countryName = search.CountryName }),
                ResourceUriType.Current => Url.Link("GetCountries",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, countryName = search.CountryName }),
                _ => Url.Link("GetCountries",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, countryName = search.CountryName })
            };
        }

        private dynamic CreateLinksForList(SearchCountryDto search, IEnumerable<CountryDto> countryDto)
        {
            var links = new List<LinkDto>();

            var collection = countryDto.Select(country => CreateLinks(country.Id, country)).ToList();

            var countries = _countryService.PagedListCountries(search);

            links.Add(
                new LinkDto(
                    CreateResourceUri(search, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (countries.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(search, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (countries.HasNext)
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

        // GET: api/countries
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetCountries")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchCountryDto searchCountry, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_countryService.PagedListCountries(searchCountry));

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_countryService.GetCountries(searchCountry))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(searchCountry, _countryService.GetCountries(searchCountry))
                        : _countryService.GetCountries(searchCountry)
                     );
        }

        // GET api/countries/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{countryId}", Name = "GetRole")]
        public IActionResult Get(int countryId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(_countryService.GetCountryById(countryId))
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(countryId, _countryService.GetCountryById(countryId))
                        : _countryService.GetCountryById(countryId)
                     );
        }

        // OPTIONS api/countries
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/countries
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateCountries")]
        public IActionResult Post([FromBody] CreateCountryDto countryDto)
        {
            var countryToReturn = _countryService.CreateCountry(countryDto);
            var country = CreateLinks(countryToReturn.Id, countryToReturn);

            return CreatedAtRoute("GetCountry",
                                  new { countryId = country.id },
                                  country);
        }

        // PUT api/countries/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{countryId}", Name = "UpdateRolePut")]
        public IActionResult Put(int countryId, [FromBody] UpdateCountryDto countryDto)
        {
            _countryService.UpdateCountryPut(countryId, countryDto);
            return NoContent();
        }

        // PATCH api/countries/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{countryId}", Name = "UpdateRolePatch")]
        public IActionResult Patch(int countryId, [FromBody] JsonPatchDocument<UpdateCountryDto> patchDocument)
        {
            _countryService.UpdateCountryPatch(countryId, patchDocument);
            return NoContent();
        }

        // DELETE api/countries/5
        [HttpDelete("{countryId}", Name = "DeleteRole")]
        public IActionResult Delete(int countryId)
        {
            _countryService.DeleteCountry(countryId);
            return NoContent();
        }
    }
}