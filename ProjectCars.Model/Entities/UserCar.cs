using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class UserCar : BaseEntity
    {
        public int UserId { get; set; }
        public int CarId { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}