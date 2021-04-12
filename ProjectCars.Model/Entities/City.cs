using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<CarService> CarServices { get; set; }
        public ICollection<User> Users { get; set; }
    }
}