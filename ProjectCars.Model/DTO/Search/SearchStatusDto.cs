namespace ProjectCars.Model.DTO.Search
{
    public class SearchStatusDto : BaseSearch
    {
        public string StatusName { get; set; } = string.Empty;

        public string OrderBy { get; set; } = "name-asc";
    }
}