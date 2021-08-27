using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int CityId { get; set; }

        public Role Role { get; set; }
        public City City { get; set; }
        public ICollection<UserCar> UserCars { get; set; }
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
        public ICollection<CarService> CarServices { get; set; }
    }
}