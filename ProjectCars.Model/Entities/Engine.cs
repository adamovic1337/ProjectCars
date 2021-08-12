using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class Engine : BaseEntity
    {
        public string Name { get; set; }
        public int CubicCapacity { get; set; }
        public int Power { get; set; }
        public int FuelTypeId { get; set; }

        public FuelType FuelType { get; set; }
        public ICollection<CarModel> Models { get; set; }
    }
}