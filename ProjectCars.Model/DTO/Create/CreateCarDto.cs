using System;

namespace ProjectCars.Model.DTO.Create
{
    public class CreateCarDto
    {
        public string Vin { get; set; }
        public DateTime FirstRegistration { get; set; }
        public int Mileage { get; set; }
        public int ModelId { get; set; }
    }
}