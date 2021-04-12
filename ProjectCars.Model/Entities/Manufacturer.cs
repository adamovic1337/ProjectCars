using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<CarModel> Models { get; set; }
    }
}