using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class CarService : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int CityId { get; set; }
        public int OwnerId { get; set; }

        public City City { get; set; }
        public AppUser User { get; set; }
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
        public ICollection<Maintenance> Maintenance { get; set; }
    }
}