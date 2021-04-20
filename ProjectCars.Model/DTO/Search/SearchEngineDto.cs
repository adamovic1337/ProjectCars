namespace ProjectCars.Model.DTO.Search
{
    public class SearchEngineDto : BaseSearch
    {
        public int CubicCapacityMin { get; set; }
        public int CubicCapacityMax { get; set; }
        public string OrderBy { get; set; } = "cubicCapacity-asc";
    }
}
