namespace ProjectCars.Model.DTO.Search
{
    public class SearchEngineDto : BaseSearch
    {
        public int CubicCapacityMin { get; set; } = 600;
        public int CubicCapacityMax { get; set; } = 9999;
        public string OrderBy { get; set; } = "cubicCapacity-asc";
    }
}
