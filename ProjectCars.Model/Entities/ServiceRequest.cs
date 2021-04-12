using System;

namespace ProjectCars.Model.Entities
{
    public class ServiceRequest : BaseEntity
    {
        public string UserDescription { get; set; }
        public DateTime? Appointment { get; set; }
        public DateTime? RepairStart { get; set; }
        public DateTime? RepairEnd { get; set; }
        public int CarServiceId { get; set; }
        public int UserCarId { get; set; }
        public int StatusId { get; set; }

        public CarService CarService { get; set; }
        public UserCar UserCars { get; set; }
        public Status Status { get; set; }
    }
}