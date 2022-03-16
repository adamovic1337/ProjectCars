namespace ProjectCars.Model.DTO.Search
{
    public class SearchEngineDto : BaseSearch
    {
        public string EngineName { get; set; } = string.Empty;
        public string OrderBy { get; set; } = "cubicCapacity-asc";
    }
}
