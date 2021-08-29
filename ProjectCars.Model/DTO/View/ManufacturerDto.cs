namespace ProjectCars.Model.DTO.View
{
    public class ManufacturerDto : BaseViewDTO
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}