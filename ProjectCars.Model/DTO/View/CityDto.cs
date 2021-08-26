namespace ProjectCars.Model.DTO.View
{
    public class CityDto : BaseViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}