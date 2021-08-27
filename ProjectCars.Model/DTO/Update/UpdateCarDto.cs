using System;

namespace ProjectCars.Model.DTO.Update
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public DateTime FirstRegistration { get; set; }
        public int Mileage { get; set; }
        public int ModelId { get; set; }
    }
}