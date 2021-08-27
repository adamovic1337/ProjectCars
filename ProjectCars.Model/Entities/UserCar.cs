using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class UserCar
    {
        public int UserId { get; set; }
        public int CarId { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }
    }
}