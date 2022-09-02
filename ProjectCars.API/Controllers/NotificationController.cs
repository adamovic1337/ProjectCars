using Microsoft.AspNetCore.Mvc;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Jwt;
using ProjectCars.Service.Contract;
using ProjectCars.Service.Email;
using System.Threading.Tasks;

namespace ProjectCars.API.Controllers
{
    [Route("api/Notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ISendNotification _sendNotification;

        public NotificationController(ISendNotification sendNotification)
        {
            _sendNotification = sendNotification;
        }

        
        [HttpPost("SendEmail")]
        public IActionResult SendEmail([FromBody] EmailNotificationDto emailNotification)
        {
            _sendNotification.SendEmailNotification(emailNotification);

            return Ok();
        }
    }
}