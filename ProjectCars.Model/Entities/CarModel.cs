using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class CarModel : BaseEntity
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public int EngineId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Engine Engine { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}