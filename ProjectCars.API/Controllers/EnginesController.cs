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
    [Route("api/engines")]
    [ApiController]
    public class EnginesController : ControllerBase
    {
        #region FIELDS

        private readonly IEngineService _engineService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public EnginesController(IEngineService engineService)
        {
            _engineService = engineService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private void PaginationMetadata(SearchEngineDto searchEngine)
        {
            var engines = _engineService.PagedListEngines(searchEngine);

            var paginationMetadata = new
            {
                totalCount = engines.TotalCount,
                pageSize = engines.PageSize,
                currentPage = engines.CurrentPage,
                totalPages = engines.TotalPages,
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
        }

        private dynamic CreateLinksForEngine(int engineId, EngineDto engineDto)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link("GetEngine", new {engineId}),
                    "self",
                    "GET"
                ),
                new LinkDto(Url.Link("CreateEngine", new {}),
                    "create_engine",
                    "POST"
                ),
                new LinkDto(Url.Link("UpdateEnginePut", new {engineId}),
                    "update_engine",
                    "PUT"
                ),
                new LinkDto(Url.Link("UpdateEnginePatch", new {engineId}),
                    "update_engine",
                    "PATCH"
                ),
                new LinkDto(Url.Link("DeleteEngine", new {engineId}),
                    "delete_engine",
                    "DELETE"
                )
            };

            var result = new
            {
                id = engineDto.Id,
                cubicCapacity = engineDto.CubicCapacity,
                power = engineDto.Power,
                fuelTypeId = engineDto.FuelTypeId,
                links
            };

            return result;
        }

        private string CreateResourceUri(SearchEngineDto search, ResourceUriType type)
        {
            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link("GetEngines",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, cubicCapacityMax = search.CubicCapacityMax, cubicCapacityMin = search.CubicCapacityMin }),
                ResourceUriType.NextPage => Url.Link("GetEngines",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, cubicCapacityMax = search.CubicCapacityMax, cubicCapacityMin = search.CubicCapacityMin }),
                ResourceUriType.Current => Url.Link("GetEngines",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, cubicCapacityMax = search.CubicCapacityMax, cubicCapacityMin = search.CubicCapacityMin }),
                _ => Url.Link("GetEngines",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, cubicCapacityMax = search.CubicCapacityMax, cubicCapacityMin = search.CubicCapacityMin })
            };
        }

        private dynamic CreateLinksForEngines(SearchEngineDto searchEngine, IEnumerable<EngineDto> engineDto)
        {
            var links = new List<LinkDto>();

            var collection = engineDto.Select(engine => CreateLinksForEngine(engine.Id, engine)).ToList();

            var engines = _engineService.PagedListEngines(searchEngine);

            links.Add(
                new LinkDto(
                    CreateResourceUri(searchEngine, ResourceUriType.Current),
                    "current",
                    "GET"
                ));

            if (engines.HasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(searchEngine, ResourceUriType.PreviousPage),
                        "previous",
                        "GET"
                    ));
            }

            if (engines.HasNext)
            {
                links.Add(
                    new LinkDto(
                        CreateResourceUri(searchEngine, ResourceUriType.NextPage),
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

        // GET: api/engines
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetEngines")]
        [HttpHead]
        public IActionResult Get([FromQuery] SearchEngineDto searchEngine, [FromHeader(Name = "Accept")] string mediaType)
        {
            PaginationMetadata(searchEngine);

            if (!MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType))
                return Ok(_engineService.GetEngines(searchEngine));

            return Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json" ?
                CreateLinksForEngines(searchEngine, _engineService.GetEngines(searchEngine)) : _engineService.GetEngines(searchEngine)
            );
        }

        // GET api/engines/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{engineId}", Name = "GetEngine")]
        public IActionResult Get(int engineId, [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType))
                return Ok(_engineService.GetEngineById(engineId));

            return Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json" ?
                CreateLinksForEngine(engineId, _engineService.GetEngineById(engineId)) : _engineService.GetEngineById(engineId)
            );
        }

        // OPTIONS api/engines
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/engines
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateEngine")]
        public IActionResult Post([FromBody] CreateEngineDto engineDto)
        {
            var engineToReturn = _engineService.CreateEngine(engineDto);
            var engine = CreateLinksForEngine(engineToReturn.Id, engineToReturn);

            return CreatedAtRoute("GetEngine",
                new { engineId = engine.id },
                engine);
        }

        // PUT api/engines/5
        [Consumes("application/json", "application/xml")]
        [HttpPut("{engineId}", Name = "UpdateEnginePut")]
        public IActionResult Put(int engineId, [FromBody] UpdateEngineDto engineDto)
        {
            _engineService.UpdateEnginePut(engineId, engineDto);
            return NoContent();
        }

        // PATCH api/engines/5
        [Consumes("application/json-patch+json")]
        [HttpPatch("{engineId}", Name = "UpdateEnginePatch")]
        public IActionResult Patch(int engineId, [FromBody] JsonPatchDocument<UpdateEngineDto> patchDocument)
        {
            _engineService.UpdateEnginePatch(engineId, patchDocument);
            return NoContent();
        }

        // DELETE api/engines/5
        [HttpDelete("{engineId}", Name = "DeleteEngine")]
        public IActionResult Delete(int engineId)
        {
            _engineService.DeleteEngine(engineId);
            return NoContent();
        }
    }
}