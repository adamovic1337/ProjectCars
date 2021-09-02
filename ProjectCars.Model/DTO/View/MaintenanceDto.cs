using System;

namespace ProjectCars.Model.DTO.View
{
    public class MaintenanceDto : BaseViewDTO
    {
        public string Repairs { get; set; }
        public int Mileage { get; set; }
        public DateTime RepairDate { get; set; }
        public int CarId { get; set; }
        public string ManufactrurerName { get; set; }
        public string ModelName { get; set; }
        public int CarServiceId { get; set; }
        public string CarServiceName { get; set; }
    }
}