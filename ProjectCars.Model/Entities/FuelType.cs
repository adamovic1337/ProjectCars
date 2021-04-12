using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class FuelType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Engine> Engines { get; set; }
    }
}