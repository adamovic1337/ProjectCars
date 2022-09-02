using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCars.Model.DTO.Create
{
    public class EmailNotificationDto
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int StatusId { get; set; }
    }
}
