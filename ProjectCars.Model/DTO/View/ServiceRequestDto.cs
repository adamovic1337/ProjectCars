using System;

namespace ProjectCars.Model.DTO.View
{
    public class ServiceRequestDto : BaseViewDTO
    {
        public string UserDescription { get; set; }
        public string Appointment { get; set; }
        public string RepairStart { get; set; }
        public string RepairEnd { get; set; }
        public int CarServiceId { get; set; }
        public string CarServiceName { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string CarManufacturer { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}