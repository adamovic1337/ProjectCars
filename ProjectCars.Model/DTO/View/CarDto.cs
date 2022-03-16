using System;

namespace ProjectCars.Model.DTO.View
{
    public class CarDto : BaseViewDTO
    {
        public string Vin { get; set; }
        public DateTime FirstRegistration { get; set; }
        public int Mileage { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int EngineId { get; set; }
        public string EngineName { get; set; }
        public int? CubicCapacity { get; set; }
        public int Power { get; set; }
        public int FuelTypeId { get; set; }
        public string FuelTypeName { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
    }
}