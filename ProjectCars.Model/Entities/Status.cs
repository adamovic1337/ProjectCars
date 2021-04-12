using System.Collections.Generic;

namespace ProjectCars.Model.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}