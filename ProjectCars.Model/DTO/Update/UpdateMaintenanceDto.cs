using System;

namespace ProjectCars.Model.DTO.Update
{
    public class UpdateMaintenanceDto
    {
        public int Id { get; set; }
        public string Repairs { get; set; }
        public int Mileage { get; set; }
        public DateTime RepairDate { get; set; }
        public int CarId { get; set; }
        public int CarServiceId { get; set; }
    }
}