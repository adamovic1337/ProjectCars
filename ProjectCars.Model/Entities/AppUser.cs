using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }

        
        public City City { get; set; }
        public ICollection<UserCar> UserCars { get; set; }
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
        public ICollection<CarService> CarServices { get; set; }
    }
}