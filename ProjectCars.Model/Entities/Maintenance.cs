using System;

namespace ProjectCars.Model.Entities
{
    public class Maintenance : BaseEntity
    {
        public string Repairs { get; set; }
        public int Mileage { get; set; }
        public DateTime RepairDate { get; set; }
        public int CarId { get; set; }
        public int CarServiceId { get; set; }

        public Car Car { get; set; }
        public CarService CarService { get; set; }
    }
}