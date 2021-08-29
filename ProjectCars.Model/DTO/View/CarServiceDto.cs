namespace ProjectCars.Model.DTO.View
{
    public class CarServiceDto : BaseViewDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}