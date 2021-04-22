namespace ProjectCars.Model.DTO.Search
{
    public class SearchCarModelDto : BaseSearch
    {
        public string CarModelName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "name-asc";
    }
}