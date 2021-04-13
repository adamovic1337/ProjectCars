namespace ProjectCars.Model.DTO.Search
{
    public class SearchCountryDto : BaseSearch
    {
        public string CountryName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "name-asc";
    }
}