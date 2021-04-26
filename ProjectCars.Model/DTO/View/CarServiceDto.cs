namespace ProjectCars.Model.DTO.View
{
    public class CarServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int CityId { get; set; }
        public int OwnerId { get; set; }
    }
}