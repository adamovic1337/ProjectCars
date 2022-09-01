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
    [Route("api/users/{userId}/cars")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class CarsController : ControllerBase
    {
        #region FIELDS

        private readonly ICarsService _carService;

        #endregion FIELDS

        #region CONSTRUCTORS

        public CarsController(ICarsService carService)
        {
            _carService = carService;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        private CarDto CreateLinks(int userId, int carId, CarDto carDto)
        {
            var name = "Car";

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link($"Get{name}", new { userId, carId }),
                    "Self",
                    "GET"
                ),
                new LinkDto(Url.Link($"Create{name}", new {userId}),
                    $"Create_car",
                    "POST"
                ),
                new LinkDto(Url.Link($"Update{name}Put", new { userId, carId }),
                    $"Update_car",
                    "PUT"
                ),
                new LinkDto(Url.Link($"Update{name}Patch", new { userId, carId }),
                    $"Update_car",
                    "PATCH"
                ),
                new LinkDto(Url.Link($"Delete{name}", new { userId, carId }),
                    $"Delete_car",
                    "DELETE"
                )
            };

            carDto.Links = links;

            return carDto;
        }

        private string CreateResourceUri(SearchCarDto search, ResourceUriType type)
        {
            var name = "Cars";

            return type switch
            {
                ResourceUriType.PreviousPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber - 1, pageSize = search.PageSize, modelName = search.ModelName }),
                ResourceUriType.NextPage => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber + 1, pageSize = search.PageSize, modelName = search.ModelName }),
                ResourceUriType.Current => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, modelName = search.ModelName }),
                _ => Url.Link($"Get{name}",
                    new { orderBy = search.OrderBy, pageNumber = search.PageNumber, pageSize = search.PageSize, modelName = search.ModelName })
            };
        }

        private dynamic CreateLinksForList(int userId, SearchCarDto search, IEnumerable<CarDto> carDto)
        {
            var links = new List<LinkDto>();

            var collection = carDto.Select(car => CreateLinks(userId, car.Id, car)).ToList();

            var paginationData = _carService.PaginationData(userId, search);

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

        // GET: api/users/1/cars
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet(Name = "GetCars")]
        [HttpHead]
        public IActionResult Get(int userId, [FromQuery] SearchCarDto searchCar, [FromHeader(Name = "Accept")] string mediaType)
        {
            this.PaginationMetadata(_carService.PaginationData(userId, searchCar));

            var cars = _carService.GetCars(userId, searchCar);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(cars)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinksForList(userId, searchCar, cars)
                        : cars
                     );
        }

        // GET api/users/1/cars/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{carId}", Name = "GetCar")]
        public IActionResult Get(int userId, int carId, [FromHeader(Name = "Accept")] string mediaType)
        {
            var car = _carService.GetCarById(userId, carId);

            return !MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)
                   ? Ok(car)
                   : Ok(parsedMediaType.MediaType == "application/vnd.marvin.hateoas+json"
                        ? CreateLinks(userId, carId, car)
                        : car
                     );
        }

        // OPTIONS api/users/1/cars
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        // POST api/users/1/cars
        [Consumes("application/json", "application/xml")]
        [HttpPost(Name = "CreateCar")]
        public IActionResult Post(int userId, [FromBody] CreateCarDto carDto)
        {
            var carToReturn = _carService.CreateCar(userId, carDto);
            var car = CreateLinks(userId, carToReturn.Id, carToReturn);

            return CreatedAtRoute("GetCar",
                                  new { userId, carId = car.Id },
                                  car);
        }

        // PUT api/users/1/cars
        [Consumes("application/json", "application/xml")]
        [HttpPut("{carId}", Name = "UpdateCarPut")]
        public IActionResult Put(int userId, int carId, [FromBody] UpdateCarDto carDto)
        {
            _carService.UpdateCarPut(userId, carId, carDto);
            return NoContent();
        }

        // PATCH api/users/1/cars
        [Consumes("application/json-patch+json")]
        [HttpPatch("{carId}", Name = "UpdateCarPatch")]
        public IActionResult Patch(int userId, int carId, [FromBody] JsonPatchDocument<UpdateCarDto> patchDocument)
        {
            _carService.UpdateCarPatch(userId, carId, patchDocument);
            return NoContent();
        }

        // DELETE api/users/1/cars
        [HttpDelete("{carId}", Name = "DeleteCar")]
        public IActionResult Delete(int userId, int carId)
        {
            _carService.DeleteCar(userId, carId);
            return NoContent();
        }

    }
}
