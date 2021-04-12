using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<Manufacturer> Manufacturers { get; set; }
    }
}