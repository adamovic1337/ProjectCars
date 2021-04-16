namespace ProjectCars.Model.DTO.Search
{
    public class SearchFuelTypeDto : BaseSearch
    {
        public string FuelTypeName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "name-asc";
    }
}