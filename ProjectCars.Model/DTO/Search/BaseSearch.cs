namespace ProjectCars.Model.DTO.Search
{
    public abstract class BaseSearch
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}