using System;
using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class Car : BaseEntity
    {
        public string Vin { get; set; }
        public DateTime FirstRegistration { get; set; }
        public int Mileage { get; set; }
        public int ModelId { get; set; }

        public CarModel Model { get; set; }
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
        public ICollection<UserCar> UserCars { get; set; }
        public ICollection<Maintenance> Maintenance { get; set; }
    }
}