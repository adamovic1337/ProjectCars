using System;

namespace ProjectCars.Model.DTO.Create
{
    public class CreateServiceRequestDto
    {
        public string UserDescription { get; set; }
        public DateTime? Appointment { get; set; }
        public DateTime? RepairStart { get; set; }
        public DateTime? RepairEnd { get; set; }
        public int CarServiceId { get; set; }
        public int UserCarId { get; set; }
        public int StatusId { get; set; }
    }
}
