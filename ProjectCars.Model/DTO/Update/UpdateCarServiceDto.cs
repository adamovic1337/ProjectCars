namespace ProjectCars.Model.DTO.Update
{
    public class UpdateCarServiceDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int CityId { get; set; }
        public int OwnerId { get; set; }
    }
}