using System;

namespace ProjectCars.Model.DTO.Create
{
    public class CreateMaintenanceDto
    {
        public string Repairs { get; set; }
        public int Mileage { get; set; }
        public DateTime RepairDate { get; set; }
        public int CarId { get; set; }
        public int CarServiceId { get; set; }
    }
}