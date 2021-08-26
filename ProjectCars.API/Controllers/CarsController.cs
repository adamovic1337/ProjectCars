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


        

        // GET api/users/1/cars/5
        [Produces("application/json", "application/vnd.marvin.hateoas+json", "application/xml")]
        [HttpGet("{carId}", Name = "GetCar")]
        public IActionResult Get(int userId, int carId, [FromHeader(Name = "Accept")] string mediaType)
        {
            return Ok(_carService.GetCarById(userId, carId));
        }
        
    }
}
